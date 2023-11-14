using Amazon.DynamoDBv2;
using BircheGamesApi.Config;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var config = builder.Configuration;

// Add services to the container.

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);
services.AddAWSService<IAmazonDynamoDB>();

AmazonSecrets amazonSecrets = AmazonSecretsRetriever.GetSecrets();

UserValidationConfig userValidationConfig = new();
// Bind userValidationConfig

SecurityTokenConfig securityTokenConfig = new();
// Bind securityTokenConfig to appsettings


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsDevelopment())
{
  app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "You've reached Birche Games API.");

app.Run();

public partial class Program { }