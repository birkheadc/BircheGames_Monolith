using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BircheGamesApi.Config;
using BircheGamesApi.Models;
using Microsoft.IdentityModel.Tokens;


namespace BircheGamesApi.Services;

public class SecurityTokenGenerator : ISecurityTokenGenerator
{
  private readonly SecurityTokenConfig _config;
  private readonly JwtSecurityTokenHandler _handler;

  public SecurityTokenGenerator(SecurityTokenConfig config)
  {
    _config = config;
    _handler = new();
  }

  public SecurityTokenWrapper GenerateTokenForUser(UserEntity user)
  {
    SecurityToken token = _handler.CreateToken(GetSecurityTokenDescriptor(user));
    return new()
    {
      Token = _handler.WriteToken(token)
    };
  }

  private SecurityTokenDescriptor GetSecurityTokenDescriptor(UserEntity user)
  {
    Dictionary<string, object> claims = GenerateClaimsForUser(user);
    return new SecurityTokenDescriptor()
    {
      Expires = DateTime.UtcNow.AddHours(_config.LifespanHours),
      Issuer = _config.Issuer,
      Audience = _config.Audience,
      SigningCredentials = new(
        new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config.SecretKey)),
        SecurityAlgorithms.HmacSha512Signature
      ),
      Claims = claims
    };
  }

  private Dictionary<string, object> GenerateClaimsForUser(UserEntity user)
  {
    Dictionary<string, object> claims = new()
    {
      { ClaimTypes.NameIdentifier, user.Id },
      { ClaimTypes.Role, user.Role },
      { "IsEmailVerified", user.IsEmailVerified ? "1" : "0" }
    };
    return claims;
  }
}