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
      .WithGetUserByEmailAddressResult(new() { WasSuccess = false })
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
    UserRepositoryMock userRepositoryMock = new UserRepositoryMockBuilder()
      .WithAllSuccessfulResult()
      .WithGetUserByEmailAddressResult(new() { WasSuccess = false })
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
    UserRepositoryMock userRepositoryMock = new UserRepositoryMockBuilder()
      .WithAllSuccessfulResult()
      .WithGetUserByEmailAddressResult(new(){ WasSuccess = true, Value = new() })
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
    Assert.DoesNotContain(userRepositoryMock.MethodCalls, m => m.MethodName == "UpdateUser");
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
    Assert.Contains(userRepositoryMock.MethodCalls, m => m.MethodName == "UpdateUser");
  }

  [Fact]
  public async Task PatchUserDisplayNameAndTag_Fails_WhenNotUnique()
  {
    UserRepositoryMock userRepositoryMock = new UserRepositoryMockBuilder()
      .WithAllSuccessfulResult()
      .WithGetUserByDisplayNameAndTagResult(new(){ WasSuccess = true, Value = new() })
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
}