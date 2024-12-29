# Usar la imagen oficial de .NET como base
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["<nombre-del-proyecto>.csproj", "./"]
RUN dotnet restore "<nombre-del-proyecto>.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "<nombre-del-proyecto>.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "<nombre-del-proyecto>.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "<nombre-del-proyecto>.dll"]
