namespace BircheGamesApi.Config;

public record UserValidationConfig
{
  public int DisplayNameMinChars { get; init; } = 0;
  public int DisplayNameMaxChars { get; init; } = 0;
  public string DisplayNameRegexPattern { get; init; } = "";
  public int TagChars { get; init; } = 0;
  public string TagRegexPattern { get; init; } = "";
  public int PasswordMinChars { get; init; } = 0;
  public int PasswordMaxChars { get; init; } = 0;
}