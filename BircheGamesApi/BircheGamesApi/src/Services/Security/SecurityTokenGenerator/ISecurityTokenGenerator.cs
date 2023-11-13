using BircheGamesApi.Models;

namespace BircheGamesApi.Services;

public interface ISecurityTokenGenerator
{
  public SecurityTokenWrapper GenerateTokenForUser(UserEntity user);
}