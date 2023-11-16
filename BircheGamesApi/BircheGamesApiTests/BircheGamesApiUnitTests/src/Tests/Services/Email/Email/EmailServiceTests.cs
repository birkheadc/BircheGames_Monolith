using System.Threading.Tasks;
using Amazon.SimpleEmail.Model;
using BircheGamesApi;
using BircheGamesApi.Services;
using BircheGamesApiUnitTests.Mocks.ThirdParty;
using Xunit;

namespace BircheGamesApiUnitTests.Tests.Services;

public class EmailServiceTests
{
  [Fact]
  public async Task SendMail_FailsWhenFrom_IsBlank()
  {
    AmazonSimpleEmailServiceMock amazonSimpleEmailServiceMock = new AmazonSimpleEmailServiceMockBuilder()
      .Build();
    EmailService emailService = new(amazonSimpleEmailServiceMock);

    Result result = await emailService.SendEmail("", new string[1], new Message());

    Assert.False(result.WasSuccess);
  }

  [Fact]
  public async Task SendEmail_FailsWhenTo_IsEmpty()
  {
    AmazonSimpleEmailServiceMock amazonSimpleEmailServiceMock = new AmazonSimpleEmailServiceMockBuilder()
      .Build();
    EmailService emailService = new(amazonSimpleEmailServiceMock);

    Result result = await emailService.SendEmail("", new string[0], new Message());

    Assert.False(result.WasSuccess);
  }

  [Fact]
  public async Task SendEmail_Calls_SendEmailAsync_WhenValid()
  {
    AmazonSimpleEmailServiceMock amazonSimpleEmailServiceMock = new AmazonSimpleEmailServiceMockBuilder()
      .Build();
    EmailService emailService = new(amazonSimpleEmailServiceMock);

    Result result = await emailService.SendEmail("test@email.com", new string[1]{ "" }, new Message());

    // Create method call tracking on mock and assert the proper method was called
  }

  [Fact]
  public async Task SendEmail_FailsWhen_SendEmailAsync_ReportsFailure()
  {

    // Create mock with failure response and assert failure
    // Essentially we're making sure that the http status code that the amazon service responds with is handled correctly
  }

  [Fact]
  public async Task SendEmail_SucceedsWhen_SendEmailAsync_ReportsSuccess()
  {

    // Create mock with success response and assert response
    // Essentially we're making sure that the http status code that the amazon service responds with is handled correctly
  }
}