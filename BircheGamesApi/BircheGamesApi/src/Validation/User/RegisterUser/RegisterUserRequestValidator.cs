using System.Net.Mail;
using BircheGamesApi.Config;
using BircheGamesApi.Requests;
using FluentValidation;

namespace BircheGamesApi.Validation;

public class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequest>
{
  public RegisterUserRequestValidator(UserValidationConfig config)
  {
    RuleFor(request => request.EmailAddress)
      .Must(emailAddress => !emailAddress.Contains(' ')).WithMessage("Email Address cannot contain a space.")
      .Must(emailAddress => IsValidEmailAddress(emailAddress)).WithMessage("Email address format is invalid.");
    RuleFor(request => request.Password)
      .MinimumLength(config.PasswordMinChars).WithMessage($"Password is too short. It must be at least {config.PasswordMinChars} long.")
      .MaximumLength(config.PasswordMaxChars).WithMessage($"Password is too long. It must be at most {config.PasswordMaxChars} long.");
  }

  private static bool IsValidEmailAddress(string emailAddress)
  {
    try { MailAddress _ = new(emailAddress); }
    catch { return false; }
    return true;
  }
}