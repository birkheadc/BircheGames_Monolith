using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BircheGamesApi;
using BircheGamesApi.Models;
using BircheGamesApi.Requests;
using BircheGamesApi.Results;
using BircheGamesApi.Services;
using BircheGamesApiUnitTests.Mocks.Exceptions;

namespace BircheGamesApiUnitTests.Mocks.Services;

public class UserServiceMock : BasicMock, IUserService
{
  public Task<Result<UserEntity>> GetUser(string id)
  {
    throw new System.NotImplementedException();
  }

  public Task<Result<UserEntity>> GetUserByEmailAddress(string emailAddress)
  {
    AddMethodCall("GetUserByEmailAddress", emailAddress);
    MethodResponse response = GetMethodResponse("GetUserByEmailAddress");

    if (response == MethodResponse.THROW)
    {
      throw new IntentionalException();
    }

    if (response == MethodResponse.FAILURE)
    {
      return Task.FromResult(Result<UserEntity>.Fail());
    }

    return Task.FromResult(Result<UserEntity>.Succeed().WithValue(new()));
  }

  public Task<Result> PatchUserDisplayNameAndTag(string id, ChangeDisplayNameAndTagRequest request)
  {
    throw new System.NotImplementedException();
  }

  public Task<Result> RegisterUser(RegisterUserRequest request)
  {
    throw new System.NotImplementedException();
  }

  public Task<Result> ValidateUserEmail(string id)
  {
    AddMethodCall("ValidateUserEmail", id);
    MethodResponse response = GetMethodResponse("ValidateUserEmail");
    switch (response)
    {
      case MethodResponse.THROW:
        throw new IntentionalException();
      case MethodResponse.FAILURE:
        return Task.FromResult(Result.Fail());
      case MethodResponse.SUCCESS:
        return Task.FromResult(Result.Succeed());
      default:
        throw new NotImplementedException();
    }
  }
}