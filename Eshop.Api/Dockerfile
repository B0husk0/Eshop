# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# copy iba csproj
COPY ["Eshop.Api.csproj", "."]
RUN dotnet restore "Eshop.Api.csproj"

# skopíruj zvyšok projektu
COPY . .
RUN dotnet build "Eshop.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Eshop.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# skopíruj publish + konfiguráky
COPY --from=publish /app/publish .
COPY appsettings*.json ./

ENTRYPOINT ["dotnet", "Eshop.Api.dll"]
