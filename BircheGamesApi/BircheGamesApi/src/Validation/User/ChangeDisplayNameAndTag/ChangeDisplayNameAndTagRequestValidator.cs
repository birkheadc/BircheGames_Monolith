using BircheGamesApi.Config;
using BircheGamesApi.Requests;
using FluentValidation;

namespace BircheGamesApi.Validation;

public class ChangeDisplayNameAndTagRequestValidator : AbstractValidator<ChangeDisplayNameAndTagRequest>
{
  public ChangeDisplayNameAndTagRequestValidator(UserValidationConfig config)
  {
    RuleFor(request => request.DisplayName)
      .MinimumLength(config.DisplayNameMinChars).WithMessage($"Display Name is too short. It must be at least {config.DisplayNameMinChars} long.")
      .MaximumLength(config.DisplayNameMaxChars).WithMessage($"Display Name is too long. It must be at most {config.DisplayNameMaxChars} long.")
      .Matches(config.DisplayNameRegexPattern).WithMessage("Display Name contains invalid characters.");

    RuleFor(request => request.Tag)
      .Length(config.TagChars).WithMessage($"Tag must be exactly {config.TagChars} long.")
      .Matches(config.TagRegexPattern).WithMessage("Tag contains invalid characters.");
  }
}