namespace BircheGamesApi.Requests;

public record ChangeDisplayNameAndTagRequest
{
  public string DisplayName { get; init; } = "";
  public string Tag { get; init; } = "";
}