using System;
using System.Threading.Tasks;
using BircheGamesApi.Models;
using BircheGamesApi.Repositories;
using BircheGamesApi.Results;
using BircheGamesApiUnitTests.Mocks.Exceptions;
using Newtonsoft.Json;

namespace BircheGamesApiUnitTests.Mocks.Repositories;

public class UserRepositoryMock : BasicMock, IUserRepository
{

  public Task<Result> CreateUser(UserEntity user)
  {
    AddMethodCall("CreateUser", user);
    
    MethodResponse response = GetMethodResponse("CreateUser");
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

  public Task<Result> DeleteUser(string id)
  {
    AddMethodCall("DeleteUser", id);

    MethodResponse response = GetMethodResponse("DeleteUser");
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

  public Task<Result<UserEntity>> GetUserByDisplayNameAndTag(string displayName, string tag)
  {
    AddMethodCall("GetUserByDisplayNameAndTag", displayName, tag);

    MethodResponse response = GetMethodResponse("GetUserByDisplayNameAndTag");
    switch (response)
    {
      case MethodResponse.THROW:
        throw new IntentionalException();
      case MethodResponse.FAILURE:
        return Task.FromResult(Result<UserEntity>.Fail());
      case MethodResponse.SUCCESS:
        return Task.FromResult(Result<UserEntity>.Succeed().WithValue(new() { DisplayName = displayName, Tag = tag }));
      default:
        throw new NotImplementedException();
    }
  }

  public Task<Result<UserEntity>> GetUserById(string id)
  {
    AddMethodCall("GetUserById", id);

    MethodResponse response = GetMethodResponse("GetUserById");
    switch (response)
    {
      case MethodResponse.THROW:
        throw new IntentionalException();
      case MethodResponse.FAILURE:
        return Task.FromResult(Result<UserEntity>.Fail());
      case MethodResponse.SUCCESS:
        return Task.FromResult(Result<UserEntity>.Succeed().WithValue(new() { Id = id }));
      default:
        throw new NotImplementedException();
    }
  }

  public Task<Result<UserEntity>> GetUserByEmailAddress(string emailAddress)
  {
    AddMethodCall("GetUserByEmailAddress", emailAddress);

    MethodResponse response = GetMethodResponse("GetUserByEmailAddress");
    switch (response)
    {
      case MethodResponse.THROW:
        throw new IntentionalException();
      case MethodResponse.FAILURE:
        return Task.FromResult(Result<UserEntity>.Fail());
      case MethodResponse.SUCCESS:
        return Task.FromResult(Result<UserEntity>.Succeed().WithValue(new() { EmailAddress = emailAddress }));
      default:
        throw new NotImplementedException();
    }
  }

  public Task<Result> UpdateUser(UserEntity user)
  {
    AddMethodCall("UpdateUser", user);

    MethodResponse response = GetMethodResponse("UpdateUser");
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