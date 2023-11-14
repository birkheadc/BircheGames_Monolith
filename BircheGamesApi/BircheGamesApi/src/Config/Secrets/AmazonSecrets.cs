namespace BircheGamesApi.Config;

public record AmazonSecrets
{
  public string AuthenticationSecretKey { get; set; } = "";
  public string EmailVerificationSecretKey { get; set; } = "";
}