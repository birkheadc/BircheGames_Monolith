using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BircheGamesApi.Config;
using Microsoft.IdentityModel.Tokens;

namespace BircheGamesApi.Services;

public class SecurityTokenValidator : ISecurityTokenValidator
{
  private readonly SecurityTokenConfig _config;
  private readonly JwtSecurityTokenHandler _handler;

  public SecurityTokenValidator(SecurityTokenConfig config, JwtSecurityTokenHandler handler)
  {
    _config = config;
    _handler = handler;
  }

  public string? GetTokenUserId(string token)
  {
    try
    {
      ClaimsPrincipal claims = _handler.ValidateToken(token, GetTokenValidationParameters(_config), out SecurityToken validatedToken);
      string? id = claims.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault()?.Value;
      if (id is null)
      {
        Console.WriteLine("Error when attempting to validate token: NameIdentifier was null.");
      }
      return id;
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error when attempting to validate token: {ex.Message}");
      return null;
    }
  }

  private static TokenValidationParameters GetTokenValidationParameters(SecurityTokenConfig config)
  {
    return new()
    {
      IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config.SecretKey)),
      ValidIssuer = config.Issuer,
      ValidAudience = config.Audience,
      ValidateIssuerSigningKey = true,
      ValidateIssuer = true,
      ValidateAudience = true,
      ValidateLifetime = true,
    };
  }
}