using System;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using BircheGamesApi;
using BircheGamesApi.Models;
using BircheGamesApi.Repositories;
using BircheGamesApiUnitTests.Mocks.ThirdParty;
using Xunit;

namespace BircheGamesApiUnitTests.Tests.Repositories;

 public class UserRepositoryTests
 {

  #region CreateUser

  [Fact]
  public async Task CreateUser_Fails_WhenId_NotUnique()
  {
    DynamoDBContextMock dBContext = new DynamoDBContextMockBuilder()
      .WithLoadAsync_UserEntity_Succeeds()
      .Build();
    UserRepository userRepository = new(dBContext);

    string id = "id";
    UserEntity user = new(){ Id = id };

    Result result = await userRepository.CreateUser(user);

    Assert.False(result.WasSuccess);
    Assert.DoesNotContain(dBContext.MethodsCalled, m => m.MethodName == "SaveAsync");
  }

  [Fact]
  public async Task CreateUser_Succeeds_WhenId_IsUnique()
  {
    DynamoDBContextMock dBContext = new DynamoDBContextMockBuilder()
      .WithLoadAsync_UserEntity_Fails()
      .Build();
    UserRepository userRepository = new(dBContext);

    string id = "id";
    UserEntity user = new(){ Id = id };

    Result result = await userRepository.CreateUser(user);

    Assert.True(result.WasSuccess);
    Assert.Contains(dBContext.MethodsCalled, m => m.MethodName == "SaveAsync");
  }

  [Fact]
  public async Task CreateUser_FailsGracefully_WhenContextThrows()
  {
    DynamoDBContextMock dBContext = new DynamoDBContextMockBuilder()
      .WithEverythingThrows()
      .Build();
    UserRepository userRepository = new(dBContext);

    Result result = await userRepository.CreateUser(new());

    Assert.False(result.WasSuccess);
    Assert.Contains(result.Errors, e => e.StatusCode == 500);
  }

  #endregion CreateUser

  #region UpdateUser

  [Fact]
  public async Task UpdateUser_Fails_WhenUserId_NotFound()
  {
    DynamoDBContextMock dBContext = new DynamoDBContextMockBuilder()
      .WithLoadAsync_UserEntity_Fails()
      .Build();
    UserRepository userRepository = new(dBContext);

    string id = "id";
    UserEntity user = new(){ Id = id };

    Result result = await userRepository.UpdateUser(user);

    Assert.False(result.WasSuccess);
    Assert.DoesNotContain(dBContext.MethodsCalled, m => m.MethodName == "SaveAsync");
  }

  [Fact]
  public async Task UpdateUser_Succeeds_WhenId_Found()
  {
    DynamoDBContextMock dBContext = new DynamoDBContextMockBuilder()
      .WithLoadAsync_UserEntity_Succeeds()
      .Build();
    UserRepository userRepository = new(dBContext);

    string id = "id";
    UserEntity user = new(){ Id = id };

    Result result = await userRepository.UpdateUser(user);

    Assert.True(result.WasSuccess);
    Assert.Contains(dBContext.MethodsCalled, m => m.MethodName == "SaveAsync");
  }

  [Fact]
  public async Task UpdateUser_FailsGracefully_WhenContextThrows()
  {
    DynamoDBContextMock dBContext = new DynamoDBContextMockBuilder()
      .WithEverythingThrows()
      .Build();
    UserRepository userRepository = new(dBContext);

    Result result = await userRepository.UpdateUser(new());

    Assert.False(result.WasSuccess);
    Assert.Contains(result.Errors, e => e.StatusCode == 500);
  }

  #endregion UpdateUser

  #region GetUserByDisplayNameAndTag

  [Fact]
  public async Task GetUserByDisplayNameAndTag_Fails_WhenNotFound()
  {
    DynamoDBContextMock dBContext = new DynamoDBContextMockBuilder()
      .WithQueryAsync_UserEntity_ReturnsN(0)
      .Build();
    UserRepository userRepository = new(dBContext);

    Result result = await userRepository.GetUserByDisplayNameAndTag("", "");

    Assert.False(result.WasSuccess);
  }

  [Fact]
  public async Task GetUserByDisplayNameAndTag_Succeeds_WhenFound()
  {
    DynamoDBContextMock dBContext = new DynamoDBContextMockBuilder()
      .WithQueryAsync_UserEntity_ReturnsN(1)
      .Build();
    UserRepository userRepository = new(dBContext);

    Result result = await userRepository.GetUserByDisplayNameAndTag("", "");

    Assert.True(result.WasSuccess);
  }

  [Fact]
  public async Task GetUserByDisplayNameAndTag_FailsGracefully_AndIndicatesServerError_WhenContextThrows()
  {
    DynamoDBContextMock dBContext = new DynamoDBContextMockBuilder()
      .WithEverythingThrows()
      .Build();
    UserRepository userRepository = new(dBContext);
    Result result = await userRepository.GetUserByDisplayNameAndTag("", "");

    Assert.False(result.WasSuccess);
    Assert.Contains(result.Errors, e => e.StatusCode == 500);
  }

  #endregion GetUserByDisplayNameAndTag

  #region GetUserByEmailAddress

  [Fact]
  public async Task GetUserByEmailAddress_Fails_WhenNotFound()
  {
    DynamoDBContextMock dBContext = new DynamoDBContextMockBuilder()
      .WithQueryAsync_UserEntity_ReturnsN(0)
      .Build();
    UserRepository userRepository = new(dBContext);

    Result result = await userRepository.GetUserByEmailAddress("");

    Assert.False(result.WasSuccess);
  }

  [Fact]
  public async Task GetUserByEmailAddress_Succeeds_WhenFound()
  {
    DynamoDBContextMock dBContext = new DynamoDBContextMockBuilder()
      .WithQueryAsync_UserEntity_ReturnsN(1)
      .Build();
    UserRepository userRepository = new(dBContext);

    Result result = await userRepository.GetUserByEmailAddress("");

    Assert.True(result.WasSuccess);
  }

  [Fact]
  public async Task GetUserByEmailAddress_FailsGracefully_AndIndicatesServerError_WhenContextThrows()
  {
    DynamoDBContextMock dBContext = new DynamoDBContextMockBuilder()
      .WithEverythingThrows()
      .Build();
    UserRepository userRepository = new(dBContext);
    Result result = await userRepository.GetUserByEmailAddress("");

    Assert.False(result.WasSuccess);
    Assert.Contains(result.Errors, e => e.StatusCode == 500);
  }

  #endregion GetUserByEmailAddress
 }