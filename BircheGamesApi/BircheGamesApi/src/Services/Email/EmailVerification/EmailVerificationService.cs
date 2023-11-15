using BircheGamesApi.Requests;

namespace BircheGamesApi.Services;

public class EmailVerificationService : IEmailVerificationService
{
  public Task<Result> GenerateAndSendVerificationEmail(GenerateVerificationEmailRequest request)
  {
    throw new NotImplementedException();
  }

  public Task<Result> VerifyEmail(VerifyEmailRequest request)
  {
    throw new NotImplementedException();
  }
}