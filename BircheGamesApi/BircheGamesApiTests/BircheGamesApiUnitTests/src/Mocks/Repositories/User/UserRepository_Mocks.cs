using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BircheGamesApi;
using BircheGamesApi.Models;
using BircheGamesApi.Repositories;
using Newtonsoft.Json;

namespace BircheGamesApiUnitTests.Mocks.Repositories;

public class UserRepository_Mocks_ReturnsSuccess_TracksMethodCalls : IUserRepository
{
  public readonly List<(string, string[])> MethodCalls = new();
  public Task<Result> CreateUser(UserEntity user)   
  {
    MethodCalls.Add(("CreateUser", new[]{JsonConvert.SerializeObject(user)}));
    ResultBuilder resultBuilder = new();
    return Task.FromResult(resultBuilder
      .Succeed()
      .Build());
  }

  public Task<Result> DeleteUser(string id)
  {
    MethodCalls.Add(("DeleteUser", new[]{id}));
    ResultBuilder resultBuilder = new();
    return Task.FromResult(resultBuilder
      .Succeed()
      .Build());
  }

  public Task<Result<UserEntity>> GetUserById(string id)
  {
    MethodCalls.Add(("GetUserById", new[]{id}));
    ResultBuilder<UserEntity> resultBuilder = new();
    return Task.FromResult(resultBuilder
      .Succeed()
      .WithValue(new UserEntity()
      {
        Id = id
      })
      .Build());
  }

  public Task<Result> UpdateUser(UserEntity user)
  {
    MethodCalls.Add(("UpdateUser", new[]{JsonConvert.SerializeObject(user)}));
    ResultBuilder resultBuilder = new();
    return Task.FromResult(resultBuilder
      .Succeed()
      .Build());
  }
}