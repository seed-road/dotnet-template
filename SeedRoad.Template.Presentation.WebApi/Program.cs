using Microsoft.AspNetCore.Mvc.ApiExplorer;
using SeedRoad.Common.Authentication.Configuration;
using SeedRoad.Common.Authentication.Extensions;
using SeedRoad.Common.Configuration;
using SeedRoad.Common.Presentation.WebApi.Extensions;
using SeedRoad.Template.Core.Application;
using SeedRoad.Template.Core.Application.UsesCases;
using SeedRoad.Template.Core.Application.UsesCases.Templates;
using SeedRoad.Template.Infrastructure;

const string test = "Template";
const string corsPolicy = "AllowClient";
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddResponseBuilder();
builder.Services.AddCommonHttpErrorService(builder.Environment.IsDevelopment());
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddCommonCors(corsPolicy, "http://allowed-client.io");
builder.Services.AddCommonVersioning(majorVersion: 1);

builder.Services.AddCommonControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCommonSwagger("Template", "Seed-road template project");
var authConfiguration = builder.Configuration.GetRequiredConfiguration<AuthConfiguration>();
builder.Services.AddCommonAuthentication(authConfiguration);
builder.Services.AddCommonAuthorization();
WebApplication app = builder.Build();
app.UseCommonExceptionHandler();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();