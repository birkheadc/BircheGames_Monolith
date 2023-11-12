using BircheGamesApi.Validation;

namespace BircheGamesApiUnitTests.Mocks.Validation;

public class UserValidatorFactory_Mocks_ReturnsInvalid : IUserValidatorFactory
{
  public IUserValidator Create()
  {
    return new UserValidator_Mocks_ReturnsInvalid();
  }
}

public class UserValidatorFactory_Mocks_ReturnsValid : IUserValidatorFactory
{
  public IUserValidator Create()
  {
    return new UserValidator_Mocks_ReturnsValid();
  }
}