# Etapa 1: Construir la aplicación
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copiar archivos de proyecto
COPY . ./

# Restaurar dependencias
RUN dotnet restore

# Compilar y publicar en modo Release
RUN dotnet publish -c Release -o /out

# Etapa 2: Ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

# Copiar los archivos compilados desde la etapa anterior
COPY --from=build /out .

# Exponer el puerto que usará la aplicación
EXPOSE 5000

# Configurar el comando de inicio
CMD ["dotnet", "TaskManager.dll"]
