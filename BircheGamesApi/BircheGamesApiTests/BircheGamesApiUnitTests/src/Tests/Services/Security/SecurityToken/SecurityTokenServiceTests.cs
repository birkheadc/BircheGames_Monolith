using System.Threading.Tasks;
using BircheGamesApi;
using BircheGamesApi.Services;
using BircheGamesApiUnitTests.Mocks.Config;
using BircheGamesApiUnitTests.Mocks.Repositories;
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
    string invalidPassword = "password";
    string validPassword = "pa55w0rd";
    string passwordHash = BCrypt.Net.BCrypt.HashPassword(validPassword);
    UserRepositoryMock userRepositoryMock = new UserRepositoryMockBuilder()
      .WithAllSuccessfulResult()
      .WithGetUserByEmailAddressResult(new() { WasSuccess = true, Value = new() { PasswordHash = passwordHash } })
      .Build();

    SecurityTokenService securityTokenService = new
    (
      userRepositoryMock,
      new SecurityTokenGenerator(SecurityTokenConfig_Mocks.Default)
    );

    Result result = await securityTokenService.AuthenticateUser(new(){ EmailAddress = "test@email.com", Password = invalidPassword });
    Assert.False(result.WasSuccess);
  }

  [Fact]
  public async Task AuthenticateUser_ReturnsSecurityToken_WhenCredentialsValid()
  {
    string validPassword = "pa55w0rd";
    string passwordHash = BCrypt.Net.BCrypt.HashPassword(validPassword);
    UserRepositoryMock userRepositoryMock = new UserRepositoryMockBuilder()
      .WithAllSuccessfulResult()
      .WithGetUserByEmailAddressResult(new() { WasSuccess = true, Value = new() { PasswordHash = passwordHash } })
      .Build();

    SecurityTokenService securityTokenService = new
    (
      userRepositoryMock,
      new SecurityTokenGenerator(SecurityTokenConfig_Mocks.Default)
    );

    Result result = await securityTokenService.AuthenticateUser(new(){ EmailAddress = "test@email.com", Password = validPassword });
    Assert.True(result.WasSuccess);
  }
}