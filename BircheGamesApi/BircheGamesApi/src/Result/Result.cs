namespace BircheGamesApi;

public record Result
{
  public bool WasSuccess { get; set; } = false;
  public List<ResultError> Errors { get; init; } = new();
  public Result()
  {

  }
  public Result(Result result)
  {
    WasSuccess = result.WasSuccess;
    Errors = result.Errors;
  }
}

public record Result<T> : Result
{
  public T? Value { get; set; } = default;
  public Result()
  {
    
  }
  public Result(Result result)
  {
    WasSuccess = result.WasSuccess;
    Errors = result.Errors;
  }
}