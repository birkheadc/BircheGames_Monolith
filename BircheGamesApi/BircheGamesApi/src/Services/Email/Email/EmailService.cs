using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using Microsoft.IdentityModel.Tokens;

namespace BircheGamesApi.Services;

public class EmailService : IEmailService
{
  private readonly IAmazonSimpleEmailService _amazonSimpleEmailService;

  public EmailService(IAmazonSimpleEmailService amazonSimpleEmailService)
  {
    _amazonSimpleEmailService = amazonSimpleEmailService;
  }

  public async Task<Result> SendEmail(string from, IEnumerable<string> to, Message message)
  {
    ResultBuilder resultBuilder = new();

    if (from.IsNullOrEmpty())
    {
      return resultBuilder
        .Fail()
        .WithGeneralError(422, "'From' field cannot be empty.")
        .Build();
    }

    if (to.IsNullOrEmpty())
    {
      return resultBuilder
        .Fail()
        .WithGeneralError(422, "'To' field cannot be empty.")
        .Build();
    }

    Destination destination = new()
    {
      ToAddresses = to.ToList()
    };

    SendEmailRequest request = new()
    {
      Source = from,
      Destination = destination,
      Message = message
    };

    SendEmailResponse response = await _amazonSimpleEmailService.SendEmailAsync(request);

    if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
    {
      return resultBuilder
        .Succeed()
        .Build();
    }
    return resultBuilder
      .Fail()
      .WithGeneralError((int)response.HttpStatusCode)
      .Build();

    throw new NotImplementedException();
  }
}