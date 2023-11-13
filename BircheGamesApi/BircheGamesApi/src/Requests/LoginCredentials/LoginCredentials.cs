namespace BircheGamesApi.Requests;

public record LoginCredentials
{
  public string EmailAddress { get; init; } = "";
  public string Password { get; init; } = "";
}