# Demo Rest API con .Net minimal: MyWebApi

## Ejecutar el proyecto

```bash
dotnet run
```

## Ejecutar curl de ejemplo para weatherforecast
    
```bash
curl -X GET "http://localhost:5112/weatherforecast"
```

## Ejecutar curl de ejemplo para weatherforecast ordenado

```bash
curl -X GET "http://localhost:5112/weatherforecast/sorted"
```

## Crear un proyecto de test

```bash
dotnet new xunit -n MyWebApi.Tests
```

### Agregar referencia al proyecto principal

```bash
dotnet add MyWebApi.Tests/MyWebApi.Tests.csproj reference MyWebApi/MyWebApi.csproj
```

### Ejecutar los tests

```bash
dotnet test
```

## Containerizar la aplicación

### Construir la imagen

```bash
docker build -t mywebapi .
```

### Ejecutar el contenedor

```bash
docker run -p 5112:80 --name mywebapi mywebapi
```

