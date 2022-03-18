FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SeedRoad.Template.WebApi/SeedRoad.Template.WebApi.csproj", "SeedRoad.Template.WebApi/"]
RUN dotnet restore "SeedRoad.Template.WebApi/SeedRoad.Template.WebApi.csproj"
COPY . .
WORKDIR "/src/SeedRoad.Template.WebApi"
RUN dotnet build "SeedRoad.Template.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SeedRoad.Template.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SeedRoad.Template.WebApi.dll"]
