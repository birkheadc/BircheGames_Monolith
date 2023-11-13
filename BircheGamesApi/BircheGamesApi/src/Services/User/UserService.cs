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

  public async Task<Result> PatchUserDisplayNameAndTag(string id, ChangeDisplayNameAndTagRequest request)
  {
    Result validationResult = ValidateChangeDisplayNameAndTagRequest(request);
    if (validationResult.WasSuccess == false)
    {
      return validationResult;
    }

    UserEntity? user = (await _userRepository.GetUserById(id)).Value;
    if (user is null)
    {
      return new ResultBuilder()
        .Fail()
        .WithGeneralError(404)
        .Build();
    }

    if (user.IsDisplayNameChosen)
    {
      return new ResultBuilder()
        .Fail()
        .WithGeneralError(422, "User has already chosen their display name and tag.")
        .Build();
    }

    bool isDisplayNameAndTagUnique = await IsDisplayNameAndTagUnique(request.DisplayName, request.Tag);
    if (isDisplayNameAndTagUnique == false)
    {
      return new ResultBuilder()
        .Fail()
        .WithGeneralError(409)
        .Build();
    }

    user.DisplayName = request.DisplayName;
    user.Tag = request.Tag;
    user.IsDisplayNameChosen = true;

    Result result = await _userRepository.UpdateUser(user);
    return result;
  }

  private Result ValidateChangeDisplayNameAndTagRequest(ChangeDisplayNameAndTagRequest request)
  {
    IUserValidator userValidator = _userValidatorFactory.Create();
    Result validationResult = userValidator
      .WithDisplayName(request.DisplayName)
      .WithTag(request.Tag)
      .Validate();
    return validationResult;
  }

  private async Task<bool> IsDisplayNameAndTagUnique(string displayName, string tag)
  {
    UserEntity? user = (await _userRepository.GetUserByDisplayNameAndTag(displayName, tag)).Value;
    return user is null;
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