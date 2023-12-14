using BircheGamesApi.Requests;
using FluentValidation;
using FluentValidation.Results;

namespace BircheGamesApi.Validation;

public class MasterValidator : IMasterValidator
{
  private readonly IServiceProvider _serviceProvider;

  public MasterValidator(IServiceCollection serviceCollection)
  {
    _serviceProvider = serviceCollection.BuildServiceProvider();
  }

  public ValidationResult Validate<T>(T obj)
  {
    IValidator<T>? validator = _serviceProvider.GetService<IValidator<T>>();
    if (validator is null) throw new NullReferenceException();

    return validator.Validate(obj);
  }
}