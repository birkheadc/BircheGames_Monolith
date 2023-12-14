using FluentValidation;

namespace BircheGamesApi.Validation;

public class MasterValidatorBuilder : IMasterValidatorBuilder
{
  private readonly IServiceCollection _serviceCollection = new ServiceCollection();
  public IMasterValidator Build()
  {
    IMasterValidator masterValidator = new MasterValidator(_serviceCollection);
    return masterValidator;
  }

  public void Register<T, TValidator>() where TValidator : AbstractValidator<T>
  {
    _serviceCollection.AddTransient<IValidator<T>, TValidator>();
  }
}