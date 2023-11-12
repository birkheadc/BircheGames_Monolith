using BircheGamesApi.Config;

namespace BircheGamesApiUnitTests.Mocks.Config;

public static class UserValidationConfig_Mocks
{
  public static UserValidationConfig Default = new UserValidationConfig()
    {
      DisplayNameMinChars = 1,
      DisplayNameMaxChars = 16,
      DisplayNameRegexPattern = "^(?!.*__)[a-zA-Z][a-zA-Z0-9_]*$",
      TagChars = 6,
      TagRegexPattern = "^[a-zA-Z0-9]*$",
      PasswordMinChars = 8,
      PasswordMaxChars = 32,
    };
}