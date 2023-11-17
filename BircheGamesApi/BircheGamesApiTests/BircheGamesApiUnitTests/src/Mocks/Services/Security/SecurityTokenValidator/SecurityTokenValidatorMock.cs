using BircheGamesApi.Services;

namespace BircheGamesApiUnitTests.Mocks.Services;

public class SecurityTokenValidatorMock : BasicMock, ISecurityTokenValidator
{
  public string? GetTokenUserId(string token)
  {
    throw new System.NotImplementedException();
  }
}