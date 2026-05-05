using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VaquerSansPere.Backend.WebApi.Data;
using VaquerSansPere.Backend.WebApi.Services;
using VaquerSansPere.Backend.WebApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ITriangleArea, TriangleArea>();

builder.Services.AddScoped<IOrderNumList,  OrderNumList>();

builder.Services.AddScoped<IGreatestNumList, GreatestNumList>();

builder.Services.AddScoped<IPalindromeWord, PalindromeWord>();

builder.Services.AddScoped<ILowestNumList, LowestNumList>();

builder.Services.AddScoped<IPrimeNumber,  PrimeNumber>();

builder.Services.AddScoped<ICircleData, CircleData>();

builder.Services.AddScoped<IBookData, BookData>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, XmlFileName));

});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        npgsqlOptions => npgsqlOptions.MigrationsHistoryTable("__EFMigrationsHistory", "PVS-BBDD")
     )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

// Do NOT use UseHttpsRedirection() — Render handles TLS at the proxy level

app.UseAuthorization();

app.MapControllers();

app.Run();
