using BircheGamesApi.Results;

namespace BircheGamesApi.Validation;

public interface IUserValidator
{
  public Result Validate();
  public IUserValidator WithEmailAddress(string emailAddress);
  public IUserValidator WithDisplayName(string displayName);
  public IUserValidator WithTag(string tag);
  public IUserValidator WithPassword(string password);
}