using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using BircheGamesApi.Config;
using BircheGamesApi.Repositories;
using BircheGamesApi.Requests;
using BircheGamesApi.Services;
using BircheGamesApi.Validation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

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
services.AddScoped<IDynamoDBContext, DynamoDBContext>();

AmazonSecrets amazonSecrets = AmazonSecretsRetriever.GetSecrets();

UserValidationConfig userValidationConfig = new();
config.GetSection("UserValidationConfig").Bind(userValidationConfig);
services.AddSingleton(userValidationConfig);

SecurityTokenConfig securityTokenConfig = new();
config.GetSection("SecurityTokenConfig").Bind(securityTokenConfig);
securityTokenConfig.SecretKey = amazonSecrets.AuthenticationSecretKey;
services.AddSingleton(securityTokenConfig);

EmailVerificationConfig emailVerificationConfig = new();
config.GetSection("EmailVerificationConfig").Bind(emailVerificationConfig);
emailVerificationConfig.SecurityTokenConfig.SecretKey = amazonSecrets.EmailVerificationSecretKey;
services.AddSingleton(emailVerificationConfig);

MasterValidatorBuilder masterValidatorBuilder = new();
masterValidatorBuilder.Register<RegisterUserRequest, RegisterUserRequestValidator>();
masterValidatorBuilder.Register<ChangeDisplayNameAndTagRequest, ChangeDisplayNameAndTagRequestValidator>();
services.AddSingleton(masterValidatorBuilder.Build());

services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<IUserService, UserService>();

services.AddTransient<JwtSecurityTokenHandler>();

services.AddCors(o => 
{
  o.AddPolicy(name: "All", builder =>
  {
    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
  });
});

services.AddAuthentication(options =>
{
  options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
  options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
  options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
  options.TokenValidationParameters = new TokenValidationParameters()
  {
    ValidIssuer = securityTokenConfig.Issuer,
    ValidAudience = securityTokenConfig.Audience,
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityTokenConfig.SecretKey)),
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true
  };
});

var app = builder.Build();
app.UseCors("All");

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

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

Console.WriteLine($"Birche Games API launched in {app.Environment.EnvironmentName} mode.");

app.MapGet("/", () => $"You've reached Birche Games API, running in {app.Environment.EnvironmentName} mode.");

app.Run();

public partial class Program { }