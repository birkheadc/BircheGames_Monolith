namespace BircheGamesApi.Requests;

public record VerifyEmailRequest
{
  public string VerificationCode { get; init; } = "";
}