using System.Threading.Tasks;
using BircheGamesApi;
using BircheGamesApi.Services;
using BircheGamesApiUnitTests.Mocks.Config;
using BircheGamesApiUnitTests.Mocks.Repositories;
using BircheGamesApiUnitTests.Mocks.Validation;
using Xunit;

namespace BircheGamesApiUnitTests.Tests.Services;

public class SecurityTokenServiceTests
{
  [Fact]
  public async Task AuthenticateUser_Fails_WhenUserWithEmailAddress_NotFound()
  {
    UserRepositoryMock userRepositoryMock = new UserRepositoryMockBuilder()
      .WithAllSuccessfulResult()
      .WithGetUserByEmailAddressResult(new() { WasSuccess = false })
      .Build();

    SecurityTokenService securityTokenService = new
    (
      userRepositoryMock,
      new SecurityTokenGenerator(SecurityTokenConfig_Mocks.Default)
    );

    Result result = await securityTokenService.AuthenticateUser(new());
    Assert.False(result.WasSuccess);
  }

  [Fact]
  public async Task AuthenticateUser_Fails_WhenPassword_NotCorrect()
  {

  }

  [Fact]
  public async Task AuthenticateUser_ReturnsSecurityToken_WhenCredentialsValid()
  {

  }
}