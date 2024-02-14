# Imagen base
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copiar todo y compilar
COPY . ./
RUN dotnet publish -c Release -o out

# Generar imagen de runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "MyWebApi.dll"]