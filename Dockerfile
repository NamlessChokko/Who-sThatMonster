# Etapa de build
ARG DOTNET_OS_VERSION="-alpine"
ARG DOTNET_SDK_VERSION=8.0

FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_SDK_VERSION}${DOTNET_OS_VERSION} AS build
WORKDIR /src

# Copiar todo el código fuente
COPY . ./

# Restaurar paquetes NuGet
RUN dotnet restore

# Publicar con configuración Release
RUN dotnet publish -c Release -o /app --no-restore

# Etapa final (imagen más ligera para producción)
FROM mcr.microsoft.com/dotnet/aspnet:${DOTNET_SDK_VERSION}
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

WORKDIR /app
COPY --from=build /app /app

# Puerto expuesto (por convención, aunque Fly maneja esto automáticamente)
EXPOSE 8080

ENTRYPOINT ["dotnet", "Who_sThatMonster.web.dll"]
