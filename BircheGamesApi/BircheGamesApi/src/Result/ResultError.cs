namespace BircheGamesApi;

public record ResultError
{
  public string? Field { get; init; } = default;
  public int? StatusCode { get; init; } = default;
  public string? Message { get; init; } = default;
}