using System.Collections.Generic;
using BircheGamesApi.Validation;
using BircheGamesApiUnitTests.Mocks.Exceptions;
using FluentValidation;
using FluentValidation.Results;

namespace BircheGamesApiUnitTests.Mocks.Validation;

public class MasterValidator_Mocks_ReturnsValid : IMasterValidator
{
  public void Register<T, TValidator>() where TValidator : IValidator<T>
  {
    throw new System.NotImplementedException();
  }

  public ValidationResult Validate<T>(T obj)
  {
    return new ValidationResult(new List<ValidationFailure>());
  }
}

public class MasterValidator_Mocks_ReturnsInvalid : IMasterValidator
{
  public void Register<T, TValidator>() where TValidator : IValidator<T>
  {
    throw new System.NotImplementedException();
  }

  public ValidationResult Validate<T>(T obj)
  {
    return new ValidationResult(new List<ValidationFailure>(){ new ValidationFailure() });
  }
}