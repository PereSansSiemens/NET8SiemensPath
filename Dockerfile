# -------- BUILD --------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .
RUN dotnet publish VaquerSansPereFrontendWebApi/VaquerSansPereFrontendWebApi.csproj \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false

# -------- RUNTIME --------
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/publish .

# Render injects the PORT env var; fallback to 8080 for local testing
ENV ASPNETCORE_URLS=http://+:${PORT:-8080}
ENV ASPNETCORE_ENVIRONMENT=Production
EXPOSE 8080

ENTRYPOINT ["dotnet", "VaquerSansPereFrontendWebApi.dll"]
