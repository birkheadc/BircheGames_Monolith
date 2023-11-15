using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;

namespace BircheGamesApi.Services;

public class EmailService : IEmailService
{
  private readonly IAmazonSimpleEmailService _amazonSimpleEmailService;

  public EmailService(IAmazonSimpleEmailService amazonSimpleEmailService)
  {
    _amazonSimpleEmailService = amazonSimpleEmailService;
  }

  public Task<Result> SendEmail(string from, string[] to, Message message)
  {
    throw new NotImplementedException();
  }
}