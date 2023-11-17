using BircheGamesApi.Models;
using BircheGamesApi.Services;

namespace BircheGamesApiUnitTests.Mocks.Services;

public class SecurityTokenGeneratorMock : ISecurityTokenGenerator
{
  public SecurityTokenWrapper GenerateTokenForUser(UserEntity user)
  {
    throw new System.NotImplementedException();
  }
}