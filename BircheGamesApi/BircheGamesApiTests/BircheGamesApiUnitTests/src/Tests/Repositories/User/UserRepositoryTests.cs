using System;
using System.Net;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using BircheGamesApi;
using BircheGamesApi.Models;
using BircheGamesApi.Repositories;
using BircheGamesApi.Results;
using BircheGamesApiUnitTests.Mocks;
using BircheGamesApiUnitTests.Mocks.ThirdParty;
using Xunit;

namespace BircheGamesApiUnitTests.Tests.Repositories;

 public class UserRepositoryTests
 {

  #region CreateUser

  [Fact]
  public async Task CreateUser_Fails_WhenId_NotUnique()
  {
    DynamoDBContextMock dBContext = new BasicMockBuilder<DynamoDBContextMock>()
      .WithMethodResponse("LoadAsync", MethodResponse.SUCCESS)
      .Build();
    UserRepository userRepository = new(dBContext);

    string id = "id";
    UserEntity user = new(){ Id = id };

    Result result = await userRepository.CreateUser(user);

    Assert.False(result.WasSuccess);
    Assert.DoesNotContain(dBContext.MethodCalls, m => m.MethodName == "SaveAsync");
  }

  [Fact]
  public async Task CreateUser_Succeeds_WhenId_IsUnique()
  {
    DynamoDBContextMock dBContext = new BasicMockBuilder<DynamoDBContextMock>()
      .WithMethodResponse("LoadAsync", MethodResponse.FAILURE)
      .Build();
    UserRepository userRepository = new(dBContext);

    string id = "id";
    UserEntity user = new(){ Id = id };

    Result result = await userRepository.CreateUser(user);

    Assert.True(result.WasSuccess);
    Assert.Contains(dBContext.MethodCalls, m => m.MethodName == "SaveAsync");
  }

  [Fact]
  public async Task CreateUser_FailsGracefully_WhenContextThrows()
  {
    DynamoDBContextMock dBContext = new BasicMockBuilder<DynamoDBContextMock>()
      .WithMethodResponse("LoadAsync", MethodResponse.THROW)
      .Build();
    UserRepository userRepository = new(dBContext);

    Result result = await userRepository.CreateUser(new());

    Assert.False(result.WasSuccess);
    Assert.Contains(result.Errors, e => e.StatusCode == HttpStatusCode.InternalServerError);
  }

  [Fact]
  public async Task CreateUser_Calls_SaveAsync_WhenSucceeds()
  {
    DynamoDBContextMock dBContext = new BasicMockBuilder<DynamoDBContextMock>()
      .WithMethodResponse("LoadAsync", MethodResponse.FAILURE)
      .Build();
    
    UserRepository userRepository = new(dBContext);

    Result result = await userRepository.CreateUser(new());

    Assert.True(result.WasSuccess);
    Assert.Contains(dBContext.MethodCalls, m => m.MethodName == "SaveAsync");
  }

  #endregion CreateUser

  #region UpdateUser

  [Fact]
  public async Task UpdateUser_Fails_WhenUserId_NotFound()
  {
    DynamoDBContextMock dBContext = new BasicMockBuilder<DynamoDBContextMock>()
      .WithMethodResponse("LoadAsync", MethodResponse.FAILURE)
      .Build();
    UserRepository userRepository = new(dBContext);

    string id = "id";
    UserEntity user = new(){ Id = id };

    Result result = await userRepository.UpdateUser(user);

    Assert.False(result.WasSuccess);
    Assert.DoesNotContain(dBContext.MethodCalls, m => m.MethodName == "SaveAsync");
  }

  [Fact]
  public async Task UpdateUser_Succeeds_WhenId_Found()
  {
    DynamoDBContextMock dBContext = new BasicMockBuilder<DynamoDBContextMock>()
      .WithMethodResponse("LoadAsync", MethodResponse.SUCCESS)
      .Build();
    UserRepository userRepository = new(dBContext);

    string id = "id";
    UserEntity user = new(){ Id = id };

    Result result = await userRepository.UpdateUser(user);

    Assert.True(result.WasSuccess);
    Assert.Contains(dBContext.MethodCalls, m => m.MethodName == "SaveAsync");
  }

  [Fact]
  public async Task UpdateUser_FailsGracefully_WhenContextThrows()
  {
    DynamoDBContextMock dBContext = new BasicMockBuilder<DynamoDBContextMock>()
      .WithMethodResponse("LoadAsync", MethodResponse.THROW)
      .Build();
    UserRepository userRepository = new(dBContext);

    Result result = await userRepository.UpdateUser(new());

    Assert.False(result.WasSuccess);
    Assert.Contains(result.Errors, e => e.StatusCode == HttpStatusCode.InternalServerError);
  }

  #endregion UpdateUser

  #region GetUserByDisplayNameAndTag

  [Fact]
  public async Task GetUserByDisplayNameAndTag_Fails_WhenNotFound()
  {
    DynamoDBContextMock dBContext = new BasicMockBuilder<DynamoDBContextMock>()
      .WithMethodResponse("QueryAsync", MethodResponse.FAILURE)
      .Build();
    UserRepository userRepository = new(dBContext);

    Result result = await userRepository.GetUserByDisplayNameAndTag("", "");

    Assert.False(result.WasSuccess);
  }

  [Fact]
  public async Task GetUserByDisplayNameAndTag_Succeeds_WhenFound()
  {
    DynamoDBContextMock dBContext = new BasicMockBuilder<DynamoDBContextMock>()
      .WithMethodResponse("QueryAsync", MethodResponse.SUCCESS)
      .Build();
    UserRepository userRepository = new(dBContext);

    Result result = await userRepository.GetUserByDisplayNameAndTag("", "");

    Assert.True(result.WasSuccess);
  }

  [Fact]
  public async Task GetUserByDisplayNameAndTag_FailsGracefully_AndIndicatesServerError_WhenContextThrows()
  {
    DynamoDBContextMock dBContext = new BasicMockBuilder<DynamoDBContextMock>()
      .WithMethodResponse("QueryAsync", MethodResponse.THROW)
      .Build();
    UserRepository userRepository = new(dBContext);
    Result result = await userRepository.GetUserByDisplayNameAndTag("", "");

    Assert.False(result.WasSuccess);
    Assert.Contains(result.Errors, e => e.StatusCode == HttpStatusCode.InternalServerError);
  }

  #endregion GetUserByDisplayNameAndTag

  #region GetUserByEmailAddress

  [Fact]
  public async Task GetUserByEmailAddress_Fails_WhenNotFound()
  {
    DynamoDBContextMock dBContext = new BasicMockBuilder<DynamoDBContextMock>()
      .WithMethodResponse("QueryAsync", MethodResponse.FAILURE)
      .Build();
    UserRepository userRepository = new(dBContext);

    Result result = await userRepository.GetUserByEmailAddress("");

    Assert.False(result.WasSuccess);
  }

  [Fact]
  public async Task GetUserByEmailAddress_Succeeds_WhenFound()
  {
    DynamoDBContextMock dBContext = new BasicMockBuilder<DynamoDBContextMock>()
      .WithMethodResponse("QueryAsync", MethodResponse.SUCCESS)
      .Build();
    UserRepository userRepository = new(dBContext);

    Result result = await userRepository.GetUserByEmailAddress("");

    Assert.True(result.WasSuccess);
  }

  [Fact]
  public async Task GetUserByEmailAddress_FailsGracefully_AndIndicatesServerError_WhenContextThrows()
  {
    DynamoDBContextMock dBContext = new BasicMockBuilder<DynamoDBContextMock>()
      .WithMethodResponse("QueryAsync", MethodResponse.THROW)
      .Build();
    UserRepository userRepository = new(dBContext);
    Result result = await userRepository.GetUserByEmailAddress("");

    Assert.False(result.WasSuccess);
    Assert.Contains(result.Errors, e => e.StatusCode == HttpStatusCode.InternalServerError);
  }

  #endregion GetUserByEmailAddress

  #region DeleteUser

  [Fact]
  public async Task DeleteUser_FailsGracefully_WhenContextThrows()
  {
    DynamoDBContextMock dBContext = new BasicMockBuilder<DynamoDBContextMock>()
      .WithMethodResponse("DeleteAsync", MethodResponse.THROW)
      .Build();

    UserRepository userRepository = new(dBContext);

    Result result = await userRepository.DeleteUser("");

    Assert.False(result.WasSuccess);
    Assert.Contains(dBContext.MethodCalls, m => m.MethodName == "DeleteAsync");
  }

  [Fact]
  public async Task DeleteUser_CallsDeleteAsync()
  {
    DynamoDBContextMock dBContext = new BasicMockBuilder<DynamoDBContextMock>()
      .WithMethodResponse("DeleteAsync", MethodResponse.SUCCESS)
      .Build();

    UserRepository userRepository = new(dBContext);

    Result result = await userRepository.DeleteUser("");

    Assert.True(result.WasSuccess);
    Assert.Contains(dBContext.MethodCalls, m => m.MethodName == "DeleteAsync");
  }

  #endregion DeleteUser
 }