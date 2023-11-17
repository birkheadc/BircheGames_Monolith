using BircheGamesApi.Config;

namespace BircheGamesApiUnitTests.Mocks.Config;

public static class EmailVerificationConfig_Mocks
{
  public static EmailVerificationConfig Default = new()
  {
    SecurityTokenConfig = SecurityTokenConfig_Mocks.Default,
    SenderAddress = "test@example.com"
  };
}