using System.Net;

namespace BircheGamesApi.Results;

public record Result
{
  public bool WasSuccess { get; set; } = false;
  public List<ResultError> Errors { get; set; } = new();
  public Result()
  {

  }

  public static Result Succeed()
  {
    return new Result()
    {
      WasSuccess = true
    };
  }

  public static Result Fail()
  {
    return new Result()
    {
      WasSuccess = false
    };
  }

  public Result<T> WithValue<T>(T value)
  {
    return new Result<T>()
    {
      WasSuccess = WasSuccess,
      Errors = Errors,
      Value = value
    };
  }

  public Result WithError(ResultError error)
  {
    Errors.Add(error);
    return this;
  }

  public Result WithErrors(List<ResultError> errors)
  {
    Errors.AddRange(errors);
    return this;
  }

  public Result WithGeneralError(HttpStatusCode? statusCode = null, string? message = null)
  {
    ResultError error = new()
    {
      Field = null,
      StatusCode = statusCode,
      Message = message
    };
    Errors.Add(error);
    return this;
  }

  public Result WithFieldError(string field, HttpStatusCode? statusCode = null, string? message = null)
  {
    ResultError error = new()
    {
      Field = field,
      StatusCode = statusCode,
      Message = message
    };
    Errors.Add(error);
    return this;
  }
}

public record Result<T>
{
  public T? Value { get; set; } = default;
  public bool WasSuccess { get; set; } = false;
  public List<ResultError> Errors { get; set; } = new();

  public static implicit operator Result<T>(Result result)
  {
    return new Result<T>()
    {
      WasSuccess = result.WasSuccess,
      Errors = result.Errors,
      Value = default
    };
  }

  public static implicit operator Result(Result<T> resultT)
  {
    return new Result()
    {
      WasSuccess = resultT.WasSuccess,
      Errors = resultT.Errors
    };
  }
  
  public Result()
  {
    
  }

  public static Result<T> Succeed()
  {
    return new Result<T>()
    {
      WasSuccess = true
    };
  }

  public static Result<T> Fail()
  {
    return new Result<T>()
    {
      WasSuccess = false
    };
  }

  public Result<T> WithValue(T value)
  {
    Value = value;
    return this;
  }

  public Result<T> WithError(ResultError error)
  {
    Errors.Add(error);
    return this;
  }

  public Result<T> WithErrors(List<ResultError> errors)
  {
    Errors.AddRange(errors);
    return this;
  }

  public Result<T> WithGeneralError(HttpStatusCode? statusCode = null, string? message = null)
  {
    ResultError error = new()
    {
      Field = null,
      StatusCode = statusCode,
      Message = message
    };
    Errors.Add(error);
    return this;
  }

  public Result<T> WithFieldError(string field, HttpStatusCode? statusCode = null, string? message = null)
  {
    ResultError error = new()
    {
      Field = field,
      StatusCode = statusCode,
      Message = message
    };
    Errors.Add(error);
    return this;
  }
}