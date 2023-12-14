using FluentValidation;

namespace BircheGamesApi.Validation;

public interface IMasterValidatorBuilder
{
  public void Register<T, TValidator>() where TValidator : AbstractValidator<T>;
  public IMasterValidator Build();
}