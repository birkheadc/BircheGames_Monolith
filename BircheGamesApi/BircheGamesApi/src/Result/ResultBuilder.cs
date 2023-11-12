namespace BircheGamesApi;

public class ResultBuilder
{
  private readonly Result _result = new();

  public Result Build()
  {
    return _result;
  }

  public ResultBuilder Succeed()
  {
    _result.WasSuccess = true;
    return this;
  }

  public ResultBuilder Fail()
  {
    _result.WasSuccess = false;
    return this;
  }

  public ResultBuilder WithError(ResultError error)
  {
    _result.Errors.Add(error);
    return this;
  }

  public ResultBuilder WithErrors(List<ResultError> errors)
  {
    _result.Errors.AddRange(errors);
    return this;
  }

  public ResultBuilder WithGeneralError(int? statusCode = null, string? message = null)
  {
    ResultError error = new()
    {
      Field = null,
      StatusCode = statusCode,
      Message = message
    };
    _result.Errors.Add(error);
    return this;
  }

  public ResultBuilder WithFieldError(string field, int? statusCode = null, string? message = null)
  {
    ResultError error = new()
    {
      Field = field,
      StatusCode = statusCode,
      Message = message
    };
    _result.Errors.Add(error);
    return this;
  }
}

public class ResultBuilder<T>
{
  private readonly Result<T> _result = new();

  public Result<T> Build()
  {
    return _result;
  }

  public ResultBuilder<T> Succeed()
  {
    _result.WasSuccess = true;
    return this;
  }

  public ResultBuilder<T> Fail()
  {
    _result.WasSuccess = false;
    return this;
  }

  public ResultBuilder<T> WithError(ResultError error)
  {
    _result.Errors.Add(error);
    return this;
  }

  public ResultBuilder<T> WithErrors(List<ResultError> errors)
  {
    _result.Errors.AddRange(errors);
    return this;
  }

  public ResultBuilder<T> WithGeneralError(int? statusCode = null, string? message = null)
  {
    ResultError error = new()
    {
      Field = null,
      StatusCode = statusCode,
      Message = message
    };
    _result.Errors.Add(error);
    return this;
  }

  public ResultBuilder<T> WithFieldError(string field, int? statusCode = null, string? message = null)
  {
    ResultError error = new()
    {
      Field = field,
      StatusCode = statusCode,
      Message = message
    };
    _result.Errors.Add(error);
    return this;
  }

  public ResultBuilder<T> WithValue(T value)
  {
    _result.Value = value;
    return this;
  }
}