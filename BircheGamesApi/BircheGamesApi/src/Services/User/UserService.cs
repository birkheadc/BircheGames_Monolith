using System.Net;
using BircheGamesApi.Models;
using BircheGamesApi.Repositories;
using BircheGamesApi.Requests;
using BircheGamesApi.Results;
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

  public async Task<Result> PatchUserDisplayNameAndTag(string id, ChangeDisplayNameAndTagRequest request)
  {
    Result validationResult = request.Validate(_userValidatorFactory.Create());
    if (validationResult.WasSuccess == false) return validationResult;

    Result<UserEntity> result = await _userRepository.GetUserById(id);
    if (result.WasSuccess == false || result.Value is null) return result;

    UserEntity user = result.Value;

    if (user.IsDisplayNameChosen) return Result.Fail().WithGeneralError(HttpStatusCode.UnprocessableEntity, "User has already chosen their display name and tag.");

    bool isDisplayNameAndTagUnique = await IsDisplayNameAndTagUnique(request.DisplayName, request.Tag);
    if (isDisplayNameAndTagUnique == false) return Result.Fail().WithGeneralError(HttpStatusCode.Conflict);

    user.DisplayName = request.DisplayName;
    user.Tag = request.Tag;
    user.IsDisplayNameChosen = true;

    return await _userRepository.UpdateUser(user);
  }

  private async Task<bool> IsDisplayNameAndTagUnique(string displayName, string tag)
  {
    Result<UserEntity> result = await _userRepository.GetUserByDisplayNameAndTag(displayName, tag);
    return !result.WasSuccess;
  }

  public async Task<Result> RegisterUser(RegisterUserRequest request)
  {
    Result validationResult = request.Validate(_userValidatorFactory.Create());
    if (validationResult.WasSuccess == false) return validationResult;

    bool isEmailAddressUnique = await IsEmailAddressUnique(request.EmailAddress);
    if (isEmailAddressUnique == false) return Result.Fail().WithGeneralError(HttpStatusCode.Conflict);

    UserEntity user = UserEntity.FromRegisterUserRequest(request);

    Result result = await _userRepository.CreateUser(user);
    return result;
  }

  private async Task<bool> IsEmailAddressUnique(string emailAddress)
  {
    Result result = await _userRepository.GetUserByEmailAddress(emailAddress);
    return !result.WasSuccess;
  }

  public async Task<Result<UserEntity>> GetUser(string id)
  {
    return await _userRepository.GetUserById(id);
  }

  public async Task<Result<UserEntity>> GetUserByEmailAddress(string emailAddress)
  {
    return await _userRepository.GetUserByEmailAddress(emailAddress);
  }

  public async Task<Result> ValidateUserEmail(string id)
  {
    Result<UserEntity> result = await _userRepository.GetUserById(id);
    if (result.WasSuccess == false || result.Value is null) return Result.Fail().WithGeneralError(HttpStatusCode.NotFound);
    
    UserEntity user = result.Value;
    user.IsEmailVerified = true;
    
    return await _userRepository.UpdateUser(user);
  }
}