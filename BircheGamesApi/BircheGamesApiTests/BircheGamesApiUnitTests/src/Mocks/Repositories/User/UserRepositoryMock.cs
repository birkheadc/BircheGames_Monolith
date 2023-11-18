using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BircheGamesApi;
using BircheGamesApi.Models;
using BircheGamesApi.Repositories;
using BircheGamesApiUnitTests.Mocks.Exceptions;
using Newtonsoft.Json;

namespace BircheGamesApiUnitTests.Mocks.Repositories;

public class UserRepositoryMock : BasicMock, IUserRepository
{

  public Task<Result> CreateUser(UserEntity user)
  {
    MethodCalls.Add(new(){ MethodName = "CreateUser", Arguments = new[]{JsonConvert.SerializeObject(user)}});
    
    MethodResponse response = GetMethodResponse("CreateUser");
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

  public Task<Result> DeleteUser(string id)
  {
    MethodCalls.Add(new(){ MethodName = "DeleteUser", Arguments = new[]{id}});

    MethodResponse response = GetMethodResponse("DeleteUser");
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

  public Task<Result<UserEntity>> GetUserByDisplayNameAndTag(string displayName, string tag)
  {
    MethodCalls.Add(new(){ MethodName = "GetUserByDisplayNameAndTag", Arguments = new[]{ displayName, tag }});

    MethodResponse response = GetMethodResponse("GetUserByDisplayNameAndTag");
    switch (response)
    {
      case MethodResponse.THROW:
        throw new IntentionalException();
      case MethodResponse.FAILURE:
        return Task.FromResult(
          new ResultBuilder<UserEntity>()
            .Fail()
            .Build()
        );
      case MethodResponse.SUCCESS:
        return Task.FromResult(
          new ResultBuilder<UserEntity>()
            .Succeed()
            .WithValue(new() { DisplayName = displayName, Tag = tag })
            .Build()
        );
      default:
        throw new NotImplementedException();
    }
  }

  public Task<Result<UserEntity>> GetUserById(string id)
  {
    MethodCalls.Add(new(){ MethodName = "GetUserById", Arguments = new[]{id}});

    MethodResponse response = GetMethodResponse("GetUserById");
    switch (response)
    {
      case MethodResponse.THROW:
        throw new IntentionalException();
      case MethodResponse.FAILURE:
        return Task.FromResult(
          new ResultBuilder<UserEntity>()
            .Fail()
            .Build()
        );
      case MethodResponse.SUCCESS:
        return Task.FromResult(
          new ResultBuilder<UserEntity>()
            .Succeed()
            .WithValue(new() { Id = id })
            .Build()
        );
      default:
        throw new NotImplementedException();
    }
  }

  public Task<Result<UserEntity>> GetUserByEmailAddress(string emailAddress)
  {
    MethodCalls.Add(new(){ MethodName = "GetUserByEmailAddress", Arguments = new[]{emailAddress}});

    MethodResponse response = GetMethodResponse("GetUserByEmailAddress");
    switch (response)
    {
      case MethodResponse.THROW:
        throw new IntentionalException();
      case MethodResponse.FAILURE:
        return Task.FromResult(
          new ResultBuilder<UserEntity>()
            .Fail()
            .Build()
        );
      case MethodResponse.SUCCESS:
        return Task.FromResult(
          new ResultBuilder<UserEntity>()
            .Succeed()
            .WithValue(new() { EmailAddress = emailAddress })
            .Build()
        );
      default:
        throw new NotImplementedException();
    }
  }

  public Task<Result> UpdateUser(UserEntity user)
  {
    MethodCalls.Add(new(){ MethodName = "UpdateUser", Arguments = new[]{JsonConvert.SerializeObject(user)}});

    MethodResponse response = GetMethodResponse("UpdateUser");
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