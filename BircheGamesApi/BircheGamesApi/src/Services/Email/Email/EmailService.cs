using System.Net;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using BircheGamesApi.Results;
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
    if (from.IsNullOrEmpty()) return Result.Fail().WithGeneralError(HttpStatusCode.UnprocessableEntity, "'From' field cannot be empty.");

    if (to.IsNullOrEmpty()) return Result.Fail().WithGeneralError(HttpStatusCode.UnprocessableEntity, "'To' field cannot be empty.");

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

    try
    {
      SendEmailResponse response = await _amazonSimpleEmailService.SendEmailAsync(request);

      if (response.HttpStatusCode != HttpStatusCode.OK) return Result.Fail().WithGeneralError(response.HttpStatusCode);
      return Result.Succeed();
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Exception encountered when attempting to Send Email Async: {ex.Message}");
      return Result.Fail().WithGeneralError(HttpStatusCode.InternalServerError, "Error when attempting to connect to AWS service.");
    }
  }
}