using BircheGamesApi.Models;
using BircheGamesApi.Repositories;
using BircheGamesApi.Requests;
using BircheGamesApi.Validation;

namespace BircheGamesApi.Services;

public class UserService : IUserService
{
  private readonly IUserValidatorFactory _userValidatorFactory;
  private readonly IUserRepository _userRepository;

  public UserService(IUserValidatorFactory userValidatorFactory, IUserRepository userRepository)
  {
    _userValidatorFactory = userValidatorFactory;
    _userRepository = userRepository;
  }

  public Task<Result> PatchUserDisplayNameAndTag(ChangeDisplayNameAndTagRequest request)
  {
    throw new NotImplementedException();
  }

  public async Task<Result> RegisterUser(RegisterUserRequest request)
  {
    IUserValidator userValidator = _userValidatorFactory.Create();
    Result validationResult = userValidator
      .WithEmailAddress(request.EmailAddress)
      .WithPassword(request.Password)
      .Validate();

    if (validationResult.WasSuccess == false)
    {
      return validationResult;
    }

    UserEntity user = new(request);
    Result result = await _userRepository.CreateUser(user);
    
    return result;    
  }
}