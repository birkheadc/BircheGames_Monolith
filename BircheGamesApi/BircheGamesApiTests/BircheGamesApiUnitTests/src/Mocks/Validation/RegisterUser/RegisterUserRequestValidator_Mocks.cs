using BircheGamesApi.Requests;
using FluentValidation;

namespace BircheGamesApiUnitTests.Mocks.Validation;

public class RegisterUserRequestValidator_Mocks_ReturnsInvalid : AbstractValidator<RegisterUserRequest>
{
  public RegisterUserRequestValidator_Mocks_ReturnsInvalid()
  {
    RuleFor(x => x).Must(x => false);
  }
}

public class RegisterUserRequestValidator_Mocks_ReturnsValid : AbstractValidator<RegisterUserRequest>
{
  public RegisterUserRequestValidator_Mocks_ReturnsValid()
  {
    RuleFor(x => x).Must(x => true);
  }
}