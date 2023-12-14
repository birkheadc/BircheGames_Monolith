using FluentValidation;
using FluentValidation.Results;

namespace BircheGamesApi.Validation;

public interface IMasterValidator
{
  public ValidationResult Validate<T>(T obj);
}