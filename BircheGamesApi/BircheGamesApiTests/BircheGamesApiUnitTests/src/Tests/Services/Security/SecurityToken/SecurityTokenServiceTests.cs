using System.Threading.Tasks;
using BircheGamesApi;
using BircheGamesApi.Services;
using BircheGamesApiUnitTests.Mocks;
using BircheGamesApiUnitTests.Mocks.Config;
using BircheGamesApiUnitTests.Mocks.Repositories;
using BircheGamesApiUnitTests.Mocks.Services;
using Xunit;

namespace BircheGamesApiUnitTests.Tests.Services;

public class SecurityTokenServiceTests
{
  [Fact]
  public async Task AuthenticateUser_Fails_WhenUserWithEmailAddress_NotFound()
  {
    UserRepositoryMock userRepositoryMock = new BasicMockBuilder<UserRepositoryMock>()
      .WithMethodResponse("GetUserByEmailAddress", MethodResponse.FAILURE)
      .Build();

    SecurityTokenService securityTokenService = new
    (
      userRepositoryMock,
      new SecurityTokenGenerator(SecurityTokenConfig_Mocks.Default),
      new PasswordVerifierMock_ReturnsTrue()
    );

    Result result = await securityTokenService.AuthenticateUser(new());
    Assert.False(result.WasSuccess);
  }

  [Fact]
  public async Task AuthenticateUser_Fails_WhenPassword_NotCorrect()
  {
    UserRepositoryMock userRepositoryMock = new BasicMockBuilder<UserRepositoryMock>()
      .WithMethodResponse("GetUserByEmailAddress", MethodResponse.SUCCESS)
      .Build();

    SecurityTokenService securityTokenService = new
    (
      userRepositoryMock,
      new SecurityTokenGenerator(SecurityTokenConfig_Mocks.Default),
      new PasswordVerifierMock_ReturnsFalse()
    );

    Result result = await securityTokenService.AuthenticateUser(new());
    Assert.False(result.WasSuccess);
  }

  [Fact]
  public async Task AuthenticateUser_ReturnsSecurityToken_WhenCredentialsValid()
  {
    UserRepositoryMock userRepositoryMock = new BasicMockBuilder<UserRepositoryMock>()
      .WithMethodResponse("GetUserByEmailAddress", MethodResponse.SUCCESS)
      .Build();

    SecurityTokenService securityTokenService = new
    (
      userRepositoryMock,
      new SecurityTokenGenerator(SecurityTokenConfig_Mocks.Default),
      new PasswordVerifierMock_ReturnsTrue()
    );

    Result result = await securityTokenService.AuthenticateUser(new());
    Assert.True(result.WasSuccess);
  }
}