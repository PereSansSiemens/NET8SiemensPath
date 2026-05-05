using VaquerSansPereFrontendWebApi.Components;
using VaquerSansPereFrontendWebApi.Services;
using VaquerSansPereFrontendWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VaquerSansPere.Backend.WebApi.Data;
using VaquerSansPere.Backend.WebApi.Services;
using VaquerSansPere.Backend.WebApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// ==========================================
// Blazor Frontend
// ==========================================
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped(sp =>
{
    var nav = sp.GetRequiredService<NavigationManager>();
    return new HttpClient
    {
        BaseAddress = new Uri(nav.BaseUri)
    };
});

// Frontend services
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAreaTrianguloService, AreaTrianguloService>();
builder.Services.AddScoped<IOrderNumListService, OrderNumListService>();
builder.Services.AddScoped<IFindGreatestValueService, FindGreatestValueService>();
builder.Services.AddScoped<IFindLowestValueService, FindLowestValueService>();
builder.Services.AddScoped<ICircleAreaPerimeterService, CircleAreaPerimeterService>();
builder.Services.AddScoped<IIsPalindromeWordService, IsPalindromeWordService>();
builder.Services.AddScoped<IIsPrimeNumberService, IsPrimeNumberService>();

// ==========================================
// Backend Web API (integrated as monolith)
// ==========================================

// API Controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "|===== Web API =====|",
        Description = "Solutions to all 8 exercices from the first .NET course"
    });

    var XmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, XmlFileName);
    if (File.Exists(xmlPath))
    {
        options.IncludeXmlComments(xmlPath);
    }
});

// Backend business services
builder.Services.AddScoped<ITriangleArea, TriangleArea>();
builder.Services.AddScoped<IOrderNumList, OrderNumList>();
builder.Services.AddScoped<IGreatestNumList, GreatestNumList>();
builder.Services.AddScoped<IPalindromeWord, PalindromeWord>();
builder.Services.AddScoped<ILowestNumList, LowestNumList>();
builder.Services.AddScoped<IPrimeNumber, PrimeNumber>();
builder.Services.AddScoped<ICircleData, CircleData>();
builder.Services.AddScoped<IBookData, BookData>();

// ==========================================
// Database (PostgreSQL)
// ==========================================

// Render provides DATABASE_URL in postgres:// format.
// Npgsql expects a standard connection string, so we convert it.
var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
string connectionString;

if (!string.IsNullOrEmpty(databaseUrl))
{
    // Parse Render's postgres://user:pass@host:port/dbname format
    var uri = new Uri(databaseUrl);
    var userInfo = uri.UserInfo.Split(':');
    connectionString = $"Host={uri.Host};Port={uri.Port};Database={uri.AbsolutePath.TrimStart('/')};" +
                       $"Username={userInfo[0]};Password={userInfo[1]};SSL Mode=Require;Trust Server Certificate=true";
}
else
{
    // Fallback for local development
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found. Set DATABASE_URL env var or configure appsettings.json.");
}

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString,
        npgsqlOptions => npgsqlOptions.MigrationsHistoryTable("__EFMigrationsHistory", "PVS-BBDD")
    )
);

// ==========================================
// Build & Configure Pipeline
// ==========================================
var app = builder.Build();

// Apply pending migrations automatically on startup (useful for Render deploys)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    try
    {
        db.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogWarning(ex, "Could not apply migrations automatically. Database may not be available yet.");
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // Do NOT use HSTS or HTTPS redirect — Render handles TLS at the proxy level
}

app.UseStaticFiles();
app.UseAntiforgery();

// Swagger always enabled (useful for testing on Render)
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "VaquerSansPere API v1");
    options.RoutePrefix = "swagger";
});

// Map API controllers BEFORE Blazor components
app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
