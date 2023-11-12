using System.Net.Mail;
using System.Text.RegularExpressions;
using BircheGamesApi.Config;

namespace BircheGamesApi.Validation;

public class UserValidator : IUserValidator
{
  private readonly UserValidationConfig _config;
  private readonly List<ResultError> _errors;

  public UserValidator(UserValidationConfig config)
  {
    _config = config;
    _errors = new();
  }

  public Result Validate()
  {
    return new Result()
    {
      WasSuccess = _errors.Count < 1,
      Errors = _errors
    };
  }

  public IUserValidator WithEmailAddress(string emailAddress)
  {
    if (emailAddress.Contains(' '))
    {
      _errors.Add(new(){ Field = "EmailAddress", StatusCode = 422, Message = "Email Address cannot contain spaces." });
    }
    try
    {
      MailAddress mailAddress = new(emailAddress);
    }
    catch
    {
      _errors.Add(new(){ Field = "EmailAddress", StatusCode = 422, Message = "Email Address format is invalid." });
    }
    return this;
  }

  public IUserValidator WithDisplayName(string displayName)
  {
    if (displayName.Length < _config.DisplayNameMinChars)
    {
      _errors.Add(new ResultError()
      {
        Field = "DisplayName",
        StatusCode = 422,
        Message = "Display name is too short."
      });
    }

    if (displayName.Length > _config.DisplayNameMaxChars)
    {
      _errors.Add(new ResultError()
      {
        Field = "DisplayName",
        StatusCode = 422,
        Message = "Display name is too long."
      });
    }

    string pattern = "^(?!.*__)[a-zA-Z][a-zA-Z0-9_]*$";
    bool doesMatch = Regex.IsMatch(displayName, pattern);
    if (doesMatch == false)
    {
      _errors.Add(new ResultError()
      {
        Field = "DisplayName",
        StatusCode = 422,
        Message = "Display name contains invalid characters. Must begin with a letter; and contain only letters, numbers, and underscores."
      });
    }

    return this;
  }

  public IUserValidator WithTag(string tag)
  {
    if (tag.Length != _config.TagChars)
    {
      _errors.Add(new ResultError()
      {
        Field = "Tag",
        StatusCode = 422,
        Message = "Tag must be exactly 6 characters."
      });
    }

    string pattern = "^[a-zA-Z0-9]*$";
    bool doesMatch = Regex.IsMatch(tag, pattern);
    if (doesMatch == false)
    {
      _errors.Add(new ResultError()
      {
        Field = "Tag",
        StatusCode = 422,
        Message = "Tag contains invalid characters. Must contain only letters and numbers."
      });
    }

    return this;
  }

  public IUserValidator WithPassword(string password)
  {
    if (password.Length < _config.PasswordMinChars)
    {
      _errors.Add(new ResultError()
      {
        Field = "Password",
        StatusCode = 422,
        Message = "Password is too short."
      });
    }

    if (password.Length > _config.PasswordMaxChars)
    {
      _errors.Add(new ResultError()
      {
        Field = "Password",
        StatusCode = 422,
        Message = "Password is too long."
      });
    }
    
    return this;
  }
}