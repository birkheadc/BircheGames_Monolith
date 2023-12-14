using System.Threading.Tasks;
using Amazon.SimpleEmail.Model;
using BircheGamesApi;
using BircheGamesApi.Results;
using BircheGamesApi.Services;
using BircheGamesApiUnitTests.Mocks;
using BircheGamesApiUnitTests.Mocks.ThirdParty;
using Xunit;

namespace BircheGamesApiUnitTests.Tests.Services;

public class EmailServiceTests
{
  [Fact]
  public async Task SendMail_FailsWhenFrom_IsBlank()
  {
    AmazonSimpleEmailServiceMock amazonSimpleEmailServiceMock = new BasicMockBuilder<AmazonSimpleEmailServiceMock>()
      .Build();
    EmailService emailService = new(amazonSimpleEmailServiceMock);

    Result result = await emailService.SendEmail("", new string[1], new Message());

    Assert.False(result.WasSuccess);
  }

  [Fact]
  public async Task SendEmail_FailsWhenTo_IsEmpty()
  {
    AmazonSimpleEmailServiceMock amazonSimpleEmailServiceMock = new BasicMockBuilder<AmazonSimpleEmailServiceMock>()
      .Build();
    EmailService emailService = new(amazonSimpleEmailServiceMock);

    Result result = await emailService.SendEmail("", new string[0], new Message());

    Assert.False(result.WasSuccess);
  }

  [Fact]
  public async Task SendEmail_Calls_SendEmailAsync_WhenValid()
  {
    AmazonSimpleEmailServiceMock amazonSimpleEmailServiceMock = new BasicMockBuilder<AmazonSimpleEmailServiceMock>()
    .WithMethodResponse("SendEmailAsync", MethodResponse.SUCCESS)
      .Build();
    EmailService emailService = new(amazonSimpleEmailServiceMock);

    Result result = await emailService.SendEmail("test@email.com", new string[1]{ "" }, new Message());

    Assert.Contains(amazonSimpleEmailServiceMock.MethodCalls, m => m.MethodName == "SendEmailAsync");
  }

  [Fact]
  public async Task SendEmail_FailsWhen_SendEmailAsync_ReportsFailure()
  {
    AmazonSimpleEmailServiceMock amazonSimpleEmailServiceMock = new BasicMockBuilder<AmazonSimpleEmailServiceMock>()
    .WithMethodResponse("SendEmailAsync", MethodResponse.FAILURE)
      .Build();
    EmailService emailService = new(amazonSimpleEmailServiceMock);

    Result result = await emailService.SendEmail("test@email.com", new string[1]{ "" }, new Message());

    Assert.False(result.WasSuccess);
    Assert.Contains(amazonSimpleEmailServiceMock.MethodCalls, m => m.MethodName == "SendEmailAsync");
  }

  [Fact]
  public async Task SendEmail_SucceedsWhen_SendEmailAsync_ReportsSuccess()
  {
    AmazonSimpleEmailServiceMock amazonSimpleEmailServiceMock = new BasicMockBuilder<AmazonSimpleEmailServiceMock>()
    .WithMethodResponse("SendEmailAsync", MethodResponse.SUCCESS)
      .Build();
    EmailService emailService = new(amazonSimpleEmailServiceMock);

    Result result = await emailService.SendEmail("test@email.com", new string[1]{ "" }, new Message());

    Assert.True(result.WasSuccess);
    Assert.Contains(amazonSimpleEmailServiceMock.MethodCalls, m => m.MethodName == "SendEmailAsync");
  }

  [Fact]
  public async Task SendEmail_FailsGracefullyWhen_SendEmailAsync_Throws()
  {
    AmazonSimpleEmailServiceMock amazonSimpleEmailServiceMock = new BasicMockBuilder<AmazonSimpleEmailServiceMock>()
    .WithMethodResponse("SendEmailAsync", MethodResponse.THROW)
      .Build();
    EmailService emailService = new(amazonSimpleEmailServiceMock);

    Result result = await emailService.SendEmail("test@email.com", new string[1]{ "" }, new Message());

    Assert.False(result.WasSuccess);
    Assert.Contains(amazonSimpleEmailServiceMock.MethodCalls, m => m.MethodName == "SendEmailAsync");
  }
}