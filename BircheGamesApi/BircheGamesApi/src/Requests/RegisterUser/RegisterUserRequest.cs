namespace BircheGamesApi.Requests;

public record RegisterUserRequest
{
  public string EmailAddress { get; init; } = "";
  public string Password { get; init; } = "";
}