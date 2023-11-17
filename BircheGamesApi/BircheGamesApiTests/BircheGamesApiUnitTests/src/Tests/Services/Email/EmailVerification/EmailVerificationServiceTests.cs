using System.Threading.Tasks;
using BircheGamesApi;
using BircheGamesApi.Services;
using BircheGamesApiUnitTests.Mocks;
using BircheGamesApiUnitTests.Mocks.Config;
using BircheGamesApiUnitTests.Mocks.Services;
using Xunit;

namespace BircheGamesApiUnitTests.Tests.Services;

public class EmailVerificationServiceTests
{
  [Fact]
  public async Task GenerateAndSendVerificationEmail_FailsWhen_UserNotFound()
  {
    EmailServiceMock emailServiceMock = new EmailServiceMockBuilder()
      .Build();
    UserServiceMock userServiceMock = new UserServiceMockBuilder()
      .WithMethodResponse("GetUserByEmailAddress", MethodResponse.FAILURE)
      .Build();

    EmailVerificationService emailVerificationService = new
    (
      new SecurityTokenGenerator(SecurityTokenConfig_Mocks.Default),
      emailServiceMock,
      EmailVerificationConfig_Mocks.Default,
      userServiceMock
    );

    Result result = await emailVerificationService.GenerateAndSendVerificationEmail(new());
    Assert.False(result.WasSuccess);
  }

  [Fact]
  public async Task GenerateAndSendVerificationEmail_Calls_EmailServiceSendEmail()
  {
    EmailServiceMock emailServiceMock = new EmailServiceMockBuilder()
      .WithMethodResponse("SendEmail", MethodResponse.SUCCESS)
      .Build();
    UserServiceMock userServiceMock = new UserServiceMockBuilder()
      .WithMethodResponse("GetUserByEmailAddress", MethodResponse.SUCCESS)
      .Build();

    EmailVerificationService emailVerificationService = new
    (
      new SecurityTokenGenerator(SecurityTokenConfig_Mocks.Default),
      emailServiceMock,
      EmailVerificationConfig_Mocks.Default,
      userServiceMock
    );

    Result result = await emailVerificationService.GenerateAndSendVerificationEmail(new());
    Assert.True(result.WasSuccess);
    Assert.Contains(emailServiceMock.MethodCalls, m => m.MethodName == "SendEmail");
  }
}