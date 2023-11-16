using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BircheGamesApi;
using BircheGamesApi.Models;
using BircheGamesApi.Repositories;
using Newtonsoft.Json;

namespace BircheGamesApiUnitTests.Mocks.Repositories;

public class UserRepositoryMock : IUserRepository
{
  public Result CreateUserResult = new();
  public Result DeleteUserResult = new();
  public Result<UserEntity> GetUserByDisplayNameAndTagResult = new();
  public Result<UserEntity> GetUserByIdResult = new();
  public Result<UserEntity> GetUserByEmailAddressResult = new();
  public Result UpdateUserResult = new();

  public readonly List<MethodCall> MethodCalls = new();

  public Task<Result> CreateUser(UserEntity user)
  {
    MethodCalls.Add(new(){ MethodName = "CreateUser", Arguments = new[]{JsonConvert.SerializeObject(user)}});
    return Task.FromResult(CreateUserResult);
  }

  public Task<Result> DeleteUser(string id)
  {
    MethodCalls.Add(new(){ MethodName = "DeleteUser", Arguments = new[]{id}});
    return Task.FromResult(DeleteUserResult);
  }

  public Task<Result<UserEntity>> GetUserByDisplayNameAndTag(string displayName, string tag)
  {
    MethodCalls.Add(new(){ MethodName = "GetUserByDisplayNameAndTag", Arguments = new[]{ displayName, tag }});
    if (GetUserByDisplayNameAndTagResult.WasSuccess)
    {
      if (GetUserByDisplayNameAndTagResult.Value is null)
      {
        GetUserByDisplayNameAndTagResult.Value = new();
      }
      GetUserByDisplayNameAndTagResult.Value.DisplayName = displayName;
      GetUserByDisplayNameAndTagResult.Value.Tag = tag;
    }
    
    return Task.FromResult(GetUserByDisplayNameAndTagResult);
  }

  public Task<Result<UserEntity>> GetUserById(string id)
  {
    MethodCalls.Add(new(){ MethodName = "GetUserById", Arguments = new[]{id}});
    if (GetUserByIdResult.WasSuccess)
    {
      if (GetUserByIdResult.Value is null)
      {
        GetUserByIdResult.Value = new();
      }
      GetUserByIdResult.Value.Id = id;
    }
    return Task.FromResult(GetUserByIdResult);
  }

  public Task<Result<UserEntity>> GetUserByEmailAddress(string emailAddress)
  {
    MethodCalls.Add(new(){ MethodName = "GetUserByEmailAddress", Arguments = new[]{emailAddress}});
    if (GetUserByEmailAddressResult.WasSuccess)
    {
      if (GetUserByEmailAddressResult.Value is null)
      {
        GetUserByEmailAddressResult.Value = new();
      }
      GetUserByEmailAddressResult.Value.EmailAddress = emailAddress;
    }
    return Task.FromResult(GetUserByEmailAddressResult);
  }

  public Task<Result> UpdateUser(UserEntity user)
  {
    MethodCalls.Add(new(){ MethodName = "UpdateUser", Arguments = new[]{JsonConvert.SerializeObject(user)}});
    return Task.FromResult(UpdateUserResult);
  }
}