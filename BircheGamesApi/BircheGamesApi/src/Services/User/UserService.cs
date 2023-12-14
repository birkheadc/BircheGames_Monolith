using System.Net;
using BircheGamesApi.Config;
using BircheGamesApi.Models;
using BircheGamesApi.Repositories;
using BircheGamesApi.Requests;
using BircheGamesApi.Results;
using BircheGamesApi.Validation;
using FluentValidation;
using FluentValidation.Results;

namespace BircheGamesApi.Services;

public class UserService : IUserService
{
  private readonly IUserRepository _userRepository;
  private readonly IMasterValidator _validator;
  public UserService(IUserRepository userRepository, IMasterValidator validator)
  {
    _userRepository = userRepository;
    _validator = validator;
  }

  public async Task<Result> PatchUserDisplayNameAndTag(string id, ChangeDisplayNameAndTagRequest request)
  {
    // Todo Inject validator
    ValidationResult validationResult = _validator.Validate(request);
    if (validationResult.IsValid == false) return Result.Fail();

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
    ValidationResult validationResult = _validator.Validate(request);
    if (validationResult.IsValid == false) return Result.Fail();

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