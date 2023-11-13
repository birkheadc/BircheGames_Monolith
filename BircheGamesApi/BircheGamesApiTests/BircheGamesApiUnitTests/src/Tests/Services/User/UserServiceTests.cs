using System.Threading.Tasks;
using BircheGamesApi;
using BircheGamesApi.Services;
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
    UserRepositoryMock userRepositoryMock = new UserRepositoryMockBuilder()
      .WithAllSuccessfulResult()
      .Build();

    UserService userService = new
    (
      new UserValidatorFactory_Mocks_ReturnsInvalid(),
      userRepositoryMock
    );

    Result result = await userService.RegisterUser(new());

    Assert.False(result.WasSuccess);
  }

  [Fact]
  public async Task RegisterUser_Succeeds_WhenValidatorSucceeds()
  {
    UserRepositoryMock userRepositoryMock = new UserRepositoryMockBuilder()
      .WithAllSuccessfulResult()
      .Build();
      
    UserService userService = new
    (
      new UserValidatorFactory_Mocks_ReturnsValid(),
      userRepositoryMock  
    );

    Result result = await userService.RegisterUser(new());

    Assert.True(result.WasSuccess);
  }

  [Fact]
  public async Task RegisterUser_DoesNotCall_CreateUser_OnRepository_WhenValidatorFails()
  {
    UserRepositoryMock userRepositoryMock = new UserRepositoryMockBuilder()
      .WithAllSuccessfulResult()
      .Build();
      
    UserService userService = new
    (
      new UserValidatorFactory_Mocks_ReturnsInvalid(),
      userRepositoryMock
    );

    Result _ = await userService.RegisterUser(new());

    Assert.Empty(userRepositoryMock.MethodsCalled);
  }

  [Fact]
  public async Task RegisterUser_Calls_CreateUser_WithNewUserEntity_OnRepository_WhenValidatorSucceeds()
  {
    UserRepositoryMock userRepositoryMock = new UserRepositoryMockBuilder()
      .WithAllSuccessfulResult()
      .Build();
      
    UserService userService = new
    (
      new UserValidatorFactory_Mocks_ReturnsValid(),
      userRepositoryMock
    );

    Result result = await userService.RegisterUser(new());
    
    Assert.Equal("CreateUser", userRepositoryMock.MethodsCalled[0].Item1);
  }

  #endregion RegisterUser

  #region PatchUserDisplayNameAndTag

  [Fact]
  public async Task PatchUserDisplayNameAndTag_Fails_WhenValidatorFails()
  {
    UserRepositoryMock userRepositoryMock = new UserRepositoryMockBuilder()
      .WithAllSuccessfulResult()
      .Build();
      
    UserService userService = new
    (
      new UserValidatorFactory_Mocks_ReturnsInvalid(),
      userRepositoryMock
    );

    Result result = await userService.PatchUserDisplayNameAndTag("", new());

    Assert.False(result.WasSuccess);
  }

  [Fact]
  public async Task PatchUserDisplayNameAndTag_Succeeds_WhenValidatorSucceeds()
  {
    UserRepositoryMock userRepositoryMock = new UserRepositoryMockBuilder()
      .WithAllSuccessfulResult()
      .WithGetUserByDisplayNameAndTagResult(new(){ WasSuccess = false })
      .Build();
      
    UserService userService = new
    (
      new UserValidatorFactory_Mocks_ReturnsValid(),
      userRepositoryMock
    );

    Result result = await userService.PatchUserDisplayNameAndTag("", new());

    Assert.True(result.WasSuccess);
  }

  [Fact]
  public async Task PatchUserDisplayNameAndTag_DoesNotCall_Repository_WhenValidatorFails()
  {
    UserRepositoryMock userRepositoryMock = new UserRepositoryMockBuilder()
      .WithAllSuccessfulResult()
      .Build();
      
    UserService userService = new
    (
      new UserValidatorFactory_Mocks_ReturnsInvalid(),
      userRepositoryMock
    );

    Result _ = await userService.PatchUserDisplayNameAndTag("", new());

    Assert.Empty(userRepositoryMock.MethodsCalled);
  }

  [Fact]
  public async Task PatchUserDisplayNameAndTag_Calls_UpdateUser_OnRepository_WhenValidatorSucceeds()
  {
    UserRepositoryMock userRepositoryMock = new UserRepositoryMockBuilder()
      .WithAllSuccessfulResult()
      .WithGetUserByDisplayNameAndTagResult(new(){ WasSuccess = false })
      .Build();
      
    UserService userService = new
    (
      new UserValidatorFactory_Mocks_ReturnsValid(),
      userRepositoryMock
    );

    Result result = await userService.PatchUserDisplayNameAndTag("", new());

    Assert.NotEmpty(userRepositoryMock.MethodsCalled);
    Assert.Contains(userRepositoryMock.MethodsCalled, m => m.Item1 == "UpdateUser");
  }

  #endregion PatchUserDisplayNameAndTag
}