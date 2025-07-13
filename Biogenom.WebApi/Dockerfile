# установка sdk
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# установка зависимостей
COPY Biogenom.WebApi/*.csproj ./Biogenom.WebApi/
RUN dotnet restore ./Biogenom.WebApi/Biogenom.WebApi.csproj

# перевод в единый образ
COPY Biogenom.WebApi/. ./Biogenom.WebApi/
WORKDIR /app/Biogenom.WebApi

# бронирование 80 порта
EXPOSE 80

# сборка
RUN dotnet publish -c Release -o out

# запуск
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/Biogenom.WebApi/out ./
ENTRYPOINT ["dotnet", "Biogenom.WebApi.dll"]