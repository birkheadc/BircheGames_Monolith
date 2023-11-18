using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BircheGamesApi;
using BircheGamesApi.Models;
using BircheGamesApi.Requests;
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
    MethodCalls.Add(new() { MethodName = "GetUserByEmailAddress", Arguments = new[]{ emailAddress } });
    MethodResponse response = GetMethodResponse("GetUserByEmailAddress");

    if (response == MethodResponse.THROW)
    {
      throw new IntentionalException();
    }

    if (response == MethodResponse.FAILURE)
    {
      return Task.FromResult(new ResultBuilder<UserEntity>()
        .Fail()
        .Build());
    }

    return Task.FromResult(new ResultBuilder<UserEntity>()
        .Succeed()
        .WithValue(new())
        .Build());
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
    MethodCalls.Add(new(){ MethodName = "ValidateUserEmail", Arguments = new[]{ id } });
    MethodResponse response = GetMethodResponse("ValidateUserEmail");
    switch (response)
    {
      case MethodResponse.THROW:
        throw new IntentionalException();
      case MethodResponse.FAILURE:
        return Task.FromResult(
          new ResultBuilder()
            .Fail()
            .Build()
        );
      case MethodResponse.SUCCESS:
        return Task.FromResult(
          new ResultBuilder()
            .Succeed()
            .Build()
        );
      default:
        throw new NotImplementedException();
    }
  }
}