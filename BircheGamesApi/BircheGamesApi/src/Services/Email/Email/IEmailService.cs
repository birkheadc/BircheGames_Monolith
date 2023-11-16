using Amazon.SimpleEmail.Model;

namespace BircheGamesApi.Services;

public interface IEmailService
{
  public Task<Result> SendEmail(string from, IEnumerable<string> to, Message message);
}