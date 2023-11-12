using BircheGamesApi.Config;
using BircheGamesApi.Requests;
using BircheGamesApi.Validation;

namespace BircheGamesApi.Services;

public class UserService : IUserService
{
  private readonly IUserValidator _userValidator;

  public UserService(IUserValidator userValidator)
  {
    _userValidator = userValidator;
  }

  public Task<Result> RegisterUser(RegisterUserRequest request)
  {
    // Create a user validator, maybe give it the config instead of this service?

    ResultBuilder resultBuilder = new();
    return Task.FromResult<Result>(resultBuilder
      .Fail()
      .Build());
  }
}