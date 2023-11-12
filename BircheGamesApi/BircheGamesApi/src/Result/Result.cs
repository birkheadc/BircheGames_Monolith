namespace BircheGamesApi;

public record Result
{
  public bool WasSuccess { get; set; } = false;
  public List<ResultError> Errors { get; init; } = new();
}

public record Result<T> : Result
{
  public T? Value { get; set; } = default;
}