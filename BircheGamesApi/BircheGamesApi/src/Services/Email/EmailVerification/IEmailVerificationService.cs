using BircheGamesApi.Requests;

namespace BircheGamesApi.Services;

public interface IEmailVerificationService
{
  public Task<Result> GenerateAndSendVerificationEmail(GenerateVerificationEmailRequest request);
  public Task<Result> VerifyEmail(VerifyEmailRequest request);
}