FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /app
EXPOSE 5000/tcp 5001/tcp
ENV ASPNETCORE_URLS=http://+:5000;https://+:5001
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "SeedRoad.Template.Presentation.WebApi.dll"]