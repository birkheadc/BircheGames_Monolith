using BircheGamesApi.Results;
using BircheGamesApi.Validation;

namespace BircheGamesApi.Requests;

public class RegisterUserRequest
{
  public string EmailAddress { get; init; } = "";
  public string Password { get; init; } = "";
  public Result Validate(IUserValidator validator)
  {
    return validator
      .WithEmailAddress(EmailAddress)
      .WithPassword(Password)
      .Validate();
  }
}