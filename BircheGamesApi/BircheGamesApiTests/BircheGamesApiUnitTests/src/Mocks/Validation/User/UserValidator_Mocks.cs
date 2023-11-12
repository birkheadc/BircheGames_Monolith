using BircheGamesApi;
using BircheGamesApi.Validation;

namespace BircheGamesApiUnitTests.Mocks.Validation;

public class UserValidator_Mocks_ReturnsInvalid : IUserValidator
{
  public Result Validate()
  {
    return new Result()
    {
      WasSuccess = false
    };
  }

  public IUserValidator WithDisplayName(string displayName)
  {
    return this;
  }

  public IUserValidator WithEmailAddress(string emailAddress)
  {
    return this;
  }

  public IUserValidator WithPassword(string password)
  {
    return this;
  }

  public IUserValidator WithTag(string tag)
  {
    return this;
  }
}

public class UserValidator_Mocks_ReturnsValid : IUserValidator
{
  public Result Validate()
  {
    return new Result()
    {
      WasSuccess = true
    };
  }

  public IUserValidator WithDisplayName(string displayName)
  {
    return this;
  }

  public IUserValidator WithEmailAddress(string emailAddress)
  {
    return this;
  }

  public IUserValidator WithPassword(string password)
  {
    return this;
  }

  public IUserValidator WithTag(string tag)
  {
    return this;
  }
}