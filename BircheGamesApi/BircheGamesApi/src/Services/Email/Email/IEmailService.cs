using Amazon.SimpleEmail.Model;

namespace BircheGamesApi.Services;

public interface IEmailService
{
  public Task<Result> SendEmail(string from, string[] to, Message message);
}