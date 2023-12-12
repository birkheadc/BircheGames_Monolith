using System;
using System.Threading.Tasks;
using BircheGamesApi;
using BircheGamesApi.Results;
using BircheGamesApi.Services;
using BircheGamesApiUnitTests.Mocks;
using BircheGamesApiUnitTests.Mocks.Repositories;
using BircheGamesApiUnitTests.Mocks.Validation;
using Xunit;

namespace BircheGamesApiUnitTests.Tests.Services;

public class UserServiceTests
{
  #region RegisterUser

  [Fact]
  public async Task RegisterUser_Fails_WhenValidatorFails()
  {
    UserRepositoryMock userRepositoryMock = new BasicMockBuilder<UserRepositoryMock>()
      .WithMethodResponse("GetUserByEmailAddress", MethodResponse.SUCCESS)
      .Build();

    UserService userService = new
    (
      new UserValidatorFactory_Mocks_ReturnsInvalid(),
      userRepositoryMock
    );

    Result result = await userService.RegisterUser(new());

    Assert.False(result.WasSuccess);
    Assert.DoesNotContain(userRepositoryMock.MethodCalls, m => m.MethodName == "CreateUser");
  }

  [Fact]
  public async Task RegisterUser_Succeeds_WhenValidatorSucceeds()
  {
    UserRepositoryMock userRepositoryMock = new BasicMockBuilder<UserRepositoryMock>()
      .WithMethodResponse("GetUserByEmailAddress", MethodResponse.FAILURE)
      .WithMethodResponse("CreateUser", MethodResponse.SUCCESS)
      .Build();
      
    UserService userService = new
    (
      new UserValidatorFactory_Mocks_ReturnsValid(),
      userRepositoryMock  
    );

    Result result = await userService.RegisterUser(new());

    Assert.True(result.WasSuccess);
    Assert.Contains(userRepositoryMock.MethodCalls, m => m.MethodName == "CreateUser");
  }

  [Fact]
  public async Task RegisterUser_Fails_WhenEmailAddress_NotUnique()
  {
    UserRepositoryMock userRepositoryMock = new BasicMockBuilder<UserRepositoryMock>()
      .WithMethodResponse("GetUserByEmailAddress", MethodResponse.SUCCESS)
      .Build();

    UserService userService = new
    (
      new UserValidatorFactory_Mocks_ReturnsValid(),
      userRepositoryMock  
    );

    Result result = await userService.RegisterUser(new());

    Assert.False(result.WasSuccess);
    Assert.DoesNotContain(userRepositoryMock.MethodCalls, m => m.MethodName == "CreateUser");
  }

  #endregion RegisterUser

  #region PatchUserDisplayNameAndTag

  [Fact]
  public async Task PatchUserDisplayNameAndTag_Fails_WhenValidatorFails()
  {
    UserRepositoryMock userRepositoryMock = new BasicMockBuilder<UserRepositoryMock>()
      .Build();
      
    UserService userService = new
    (
      new UserValidatorFactory_Mocks_ReturnsInvalid(),
      userRepositoryMock
    );

    Result result = await userService.PatchUserDisplayNameAndTag("", new());

    Assert.False(result.WasSuccess);
    Assert.DoesNotContain(userRepositoryMock.MethodCalls, m => m.MethodName == "UpdateUser");
  }

  [Fact]
  public async Task PatchUserDisplayNameAndTag_Succeeds_WhenValidatorSucceeds()
  {
    UserRepositoryMock userRepositoryMock = new BasicMockBuilder<UserRepositoryMock>()
      .WithMethodResponse("GetUserByDisplayNameAndTag", MethodResponse.FAILURE)
      .WithMethodResponse("GetUserById", MethodResponse.SUCCESS)
      .WithMethodResponse("UpdateUser", MethodResponse.SUCCESS)
      .Build();
      
    UserService userService = new
    (
      new UserValidatorFactory_Mocks_ReturnsValid(),
      userRepositoryMock
    );

    Result result = await userService.PatchUserDisplayNameAndTag("", new());

    Assert.True(result.WasSuccess);
    Assert.Contains(userRepositoryMock.MethodCalls, m => m.MethodName == "UpdateUser");
  }

  [Fact]
  public async Task PatchUserDisplayNameAndTag_Fails_WhenNotUnique()
  {
    UserRepositoryMock userRepositoryMock = new BasicMockBuilder<UserRepositoryMock>()
      .WithMethodResponse("GetUserByDisplayNameAndTag", MethodResponse.SUCCESS)
      .WithMethodResponse("GetUserById", MethodResponse.SUCCESS)
      .Build();
      
    UserService userService = new
    (
      new UserValidatorFactory_Mocks_ReturnsValid(),
      userRepositoryMock
    );

    Result result = await userService.PatchUserDisplayNameAndTag("", new());

    Assert.False(result.WasSuccess);
    Assert.DoesNotContain(userRepositoryMock.MethodCalls, m => m.MethodName == "UpdateUser");
  }

  #endregion PatchUserDisplayNameAndTag

  #region ValidateUserEmail

  [Fact]
  public async Task ValidateUserEmail_Fails_WhenUserNotFound()
  {
    UserRepositoryMock userRepositoryMock = new BasicMockBuilder<UserRepositoryMock>()
      .WithMethodResponse("GetUserById", MethodResponse.FAILURE)
      .Build();

    UserService userService = new
    (
      new UserValidatorFactory_Mocks_ReturnsValid(),
      userRepositoryMock
    );

    Result result = await userService.ValidateUserEmail("");

    Assert.False(result.WasSuccess);
    Assert.DoesNotContain(userRepositoryMock.MethodCalls, m => m.MethodName == "UpdateUser");
  }

  [Fact]
  public async Task ValidateUserEmail_Calls_UpdateUser_WhenSucceeds()
  {
    UserRepositoryMock userRepositoryMock = new BasicMockBuilder<UserRepositoryMock>()
      .WithMethodResponse("GetUserById", MethodResponse.SUCCESS)
      .WithMethodResponse("UpdateUser", MethodResponse.SUCCESS)
      .Build();

    UserService userService = new
    (
      new UserValidatorFactory_Mocks_ReturnsValid(),
      userRepositoryMock
    );

    Result result = await userService.ValidateUserEmail("");

    Assert.True(result.WasSuccess);
    Assert.Contains(userRepositoryMock.MethodCalls, m => m.MethodName == "UpdateUser");
  }

  #endregion ValidateUserEmail
}