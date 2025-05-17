FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["backend/src/Services/CRGeo/CRGeo.backend.API/CRGeo.backend.API.csproj", "backend/src/Services/CRGeo/CRGeo.backend.API/"]
COPY ["backend/src/BuildingBlocks/BuildingBlocks/BuildingBlocks.csproj", "backend/src/BuildingBlocks/BuildingBlocks/"]
RUN dotnet restore "backend/src/Services/CRGeo/CRGeo.backend.API/CRGeo.backend.API.csproj"
COPY . .
WORKDIR "/src/backend/src/Services/CRGeo/CRGeo.backend.API"
RUN dotnet build "./CRGeo.backend.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CRGeo.backend.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CRGeo.backend.API.dll"]
