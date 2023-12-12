using System.Net;

namespace BircheGamesApi.Results;

public record ResultError
{
  public string? Field { get; init; } = default;
  public HttpStatusCode? StatusCode { get; init; } = default;
  public string? Message { get; init; } = default;
}