namespace BircheGamesApi.Requests;

public record GenerateVerificationEmailRequest
{
  public string FrontendUrl { get; init; } = "";
  public string EmailAddress { get; init; } = "";
}