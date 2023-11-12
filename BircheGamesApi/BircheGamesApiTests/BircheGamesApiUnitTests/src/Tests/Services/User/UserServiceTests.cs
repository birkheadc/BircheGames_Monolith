using System.Threading.Tasks;
using BircheGamesApi;
using BircheGamesApi.Requests;
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
    UserService userService = new
    (
      new UserValidatorFactory_Mocks_ReturnsInvalid(),
      new UserRepository_Mocks_ReturnsSuccess_TracksMethodCalls()
    );

    Result result = await userService.RegisterUser(new());

    Assert.False(result.WasSuccess);
  }

  [Fact]
  public async Task RegisterUser_Succeeds_WhenValidatorSucceeds()
  {
    UserService userService = new
    (
      new UserValidatorFactory_Mocks_ReturnsValid(),
      new UserRepository_Mocks_ReturnsSuccess_TracksMethodCalls()  
    );

    Result result = await userService.RegisterUser(new());

    Assert.True(result.WasSuccess);
  }

  [Fact]
  public async Task RegisterUser_DoesNotCall_CreateUser_OnRepository_WhenValidatorFails()
  {
    UserRepository_Mocks_ReturnsSuccess_TracksMethodCalls userRepository = new();
    UserService userService = new
    (
      new UserValidatorFactory_Mocks_ReturnsInvalid(),
      userRepository
    );

    Result result = await userService.RegisterUser(new());

    Assert.Empty(userRepository.MethodCalls);
  }

  [Fact]
  public async Task RegisterUser_Calls_CreateUser_WithNewUserEntity_OnRepository_WhenValidatorSucceeds()
  {
    UserRepository_Mocks_ReturnsSuccess_TracksMethodCalls userRepository = new();
    UserService userService = new
    (
      new UserValidatorFactory_Mocks_ReturnsValid(),
      userRepository
    );

    Result result = await userService.RegisterUser(new());
    
    Assert.Equal("CreateUser", userRepository.MethodCalls[0].Item1);
  }

  #endregion RegisterUser

  #region PatchUserDisplayNameAndTag

  [Fact]
  public async Task PatchUserDisplayNameAndTag_Fails_WhenValidatorFails()
  {
    UserService userService = new
    (
      new UserValidatorFactory_Mocks_ReturnsInvalid(),
      new UserRepository_Mocks_ReturnsSuccess_TracksMethodCalls()
    );

    // Result result = await userService.PatchUserDisplayNameAndTag(new());

    // Assert.False(result.WasSuccess);
  }

  [Fact]
  public async Task PatchUserDisplayNameAndTag_Succeeds_WhenValidatorSucceeds()
  {
    UserService userService = new
    (
      new UserValidatorFactory_Mocks_ReturnsValid(),
      new UserRepository_Mocks_ReturnsSuccess_TracksMethodCalls()
    );

    // Result result = await userService.PatchUserDisplayNameAndTag(new());

    // Assert.True(result.WasSuccess);
  }

  [Fact]
  public async Task PatchUserDisplayNameAndTag_DoesNotCall_Repository_WhenValidatorFails()
  {

  }

  [Fact]
  public async Task PatchUserDisplayNameAndTag_Calls_UpdateUser_OnRepository_WhenValidatorSucceeds()
  {

  }

  #endregion PatchUserDisplayNameAndTag
}