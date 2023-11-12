using BircheGamesApi.Config;

namespace BircheGamesApi.Validation;

public class UserValidatorFactory : IUserValidatorFactory
{
  private readonly UserValidationConfig _config;

  public UserValidatorFactory(UserValidationConfig config)
  {
    _config = config;
  }

  public IUserValidator Create()
  {
    return new UserValidator(_config);
  }
}