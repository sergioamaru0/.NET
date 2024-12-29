# Imagen base para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000

# Imagen base para construir la aplicación
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG configuration=Release
WORKDIR /src

# Copiar y restaurar dependencias
COPY ["TaskManager.csproj", "./"]
RUN dotnet restore "TaskManager.csproj"

# Copiar el resto del código y construir la aplicación
COPY . .
RUN dotnet build "TaskManager.csproj" -c $configuration -o /app/build

# Publicar la aplicación
FROM build AS publish
ARG configuration=Release
RUN dotnet publish "TaskManager.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

# Imagen final para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Configuración de entrada
ENTRYPOINT ["dotnet", "TaskManager.dll"]
