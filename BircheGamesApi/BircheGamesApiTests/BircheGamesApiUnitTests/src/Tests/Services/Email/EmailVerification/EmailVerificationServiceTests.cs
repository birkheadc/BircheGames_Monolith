using System;
using System.Threading.Tasks;
using BircheGamesApi;
using BircheGamesApi.Results;
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
    EmailServiceMock emailServiceMock = new BasicMockBuilder<EmailServiceMock>()
      .Build();
    UserServiceMock userServiceMock = new BasicMockBuilder<UserServiceMock>()
      .WithMethodResponse("GetUserByEmailAddress", MethodResponse.FAILURE)
      .Build();
    SecurityTokenValidatorMock securityTokenValidatorMock = new BasicMockBuilder<SecurityTokenValidatorMock>()
      .Build();

    EmailVerificationService emailVerificationService = new
    (
      new SecurityTokenGenerator(SecurityTokenConfig_Mocks.Default),
      emailServiceMock,
      EmailVerificationConfig_Mocks.Default,
      userServiceMock,
      securityTokenValidatorMock
    );

    Result result = await emailVerificationService.GenerateAndSendVerificationEmail(new());
    Assert.False(result.WasSuccess);
  }

  [Fact]
  public async Task GenerateAndSendVerificationEmail_Calls_EmailServiceSendEmail()
  {
    EmailServiceMock emailServiceMock = new BasicMockBuilder<EmailServiceMock>()
      .WithMethodResponse("SendEmail", MethodResponse.SUCCESS)
      .Build();
    UserServiceMock userServiceMock = new BasicMockBuilder<UserServiceMock>()
      .WithMethodResponse("GetUserByEmailAddress", MethodResponse.SUCCESS)
      .Build();
    SecurityTokenValidatorMock securityTokenValidatorMock = new BasicMockBuilder<SecurityTokenValidatorMock>()
      .Build();

    EmailVerificationService emailVerificationService = new
    (
      new SecurityTokenGenerator(SecurityTokenConfig_Mocks.Default),
      emailServiceMock,
      EmailVerificationConfig_Mocks.Default,
      userServiceMock,
      securityTokenValidatorMock
    );

    Result result = await emailVerificationService.GenerateAndSendVerificationEmail(new());
    Assert.True(result.WasSuccess);
    Assert.Contains(emailServiceMock.MethodCalls, m => m.MethodName == "SendEmail");
  }

  [Fact]
  public async Task VerifyEmail_FailsWhen_TokenValidatorFails()
  {
    EmailServiceMock emailServiceMock = new BasicMockBuilder<EmailServiceMock>()
      .WithMethodResponse("SendEmail", MethodResponse.SUCCESS)
      .Build();
    UserServiceMock userServiceMock = new BasicMockBuilder<UserServiceMock>()
      .WithMethodResponse("GetUserByEmailAddress", MethodResponse.SUCCESS)
      .Build();
    SecurityTokenValidatorMock securityTokenValidatorMock = new BasicMockBuilder<SecurityTokenValidatorMock>()
      .WithMethodResponse("GetTokenUserId", MethodResponse.FAILURE)
      .Build();

    EmailVerificationService emailVerificationService = new
    (
      new SecurityTokenGenerator(SecurityTokenConfig_Mocks.Default),
      emailServiceMock,
      EmailVerificationConfig_Mocks.Default,
      userServiceMock,
      securityTokenValidatorMock
    );

    Result result = await emailVerificationService.VerifyEmail(new());
    Assert.False(result.WasSuccess);
  }

  [Fact]
  public async Task VerifyEmail_Calls_UpdateUser_WhenSucceeds()
  {
    EmailServiceMock emailServiceMock = new BasicMockBuilder<EmailServiceMock>()
      .WithMethodResponse("SendEmail", MethodResponse.SUCCESS)
      .Build();
    UserServiceMock userServiceMock = new BasicMockBuilder<UserServiceMock>()
      .WithMethodResponse("GetUserByEmailAddress", MethodResponse.SUCCESS)
      .WithMethodResponse("ValidateUserEmail", MethodResponse.SUCCESS)
      .Build();
    SecurityTokenValidatorMock securityTokenValidatorMock = new BasicMockBuilder<SecurityTokenValidatorMock>()
      .WithMethodResponse("GetTokenUserId", MethodResponse.SUCCESS)
      .Build();
    
    EmailVerificationService emailVerificationService = new
    (
      new SecurityTokenGenerator(SecurityTokenConfig_Mocks.Default),
      emailServiceMock,
      EmailVerificationConfig_Mocks.Default,
      userServiceMock,
      securityTokenValidatorMock
    );

    Result result = await emailVerificationService.VerifyEmail(new());
    Assert.True(result.WasSuccess);

    Assert.Contains(userServiceMock.MethodCalls, m => m.MethodName == "ValidateUserEmail");
  }
}