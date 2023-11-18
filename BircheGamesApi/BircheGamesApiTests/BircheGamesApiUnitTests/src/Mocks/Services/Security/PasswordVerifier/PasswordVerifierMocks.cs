using BircheGamesApi.Services;

namespace BircheGamesApiUnitTests.Mocks.Services;

public class PasswordVerifierMock_ReturnsFalse : IPasswordVerifier
{
  public bool Verify(string text, string hash)
  {
    return false;
  }
}

public class PasswordVerifierMock_ReturnsTrue : IPasswordVerifier
{
  public bool Verify(string text, string hash)
  {
    return true;
  }
}