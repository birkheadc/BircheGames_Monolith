namespace BircheGamesApi.Config;

public class EmailVerificationConfig
{
  public SecurityTokenConfig SecurityTokenConfig { get; set; } = new();
  public string SenderAddress { get; set; } = "";
}