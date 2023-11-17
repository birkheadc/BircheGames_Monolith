using Amazon.SimpleEmail.Model;
using BircheGamesApi.Config;
using BircheGamesApi.Models;
using BircheGamesApi.Requests;

namespace BircheGamesApi.Services;

public class EmailVerificationService : IEmailVerificationService
{
  private readonly EmailVerificationConfig _config;
  private readonly IEmailService _emailService;
  private readonly ISecurityTokenGenerator _securityTokenGenerator;
  private readonly IUserService _userService;

  public EmailVerificationService
  (
    ISecurityTokenGenerator securityTokenGenerator,
    IEmailService emailService,
    EmailVerificationConfig config,
    IUserService userService
  )
  {
    _securityTokenGenerator = securityTokenGenerator;
    _emailService = emailService;
    _config = config;
    _userService = userService;
  }

  public async Task<Result> GenerateAndSendVerificationEmail(GenerateVerificationEmailRequest request)
  {
    Result<UserEntity> getUserResult = await _userService.GetUserByEmailAddress(request.EmailAddress);
    if (getUserResult.WasSuccess == false || getUserResult.Value is null)
    {
      return new ResultBuilder()
        .Fail()
        .WithGeneralError(404, "User with that email address not found.")
        .Build();
    }

    SecurityTokenWrapper securityTokenWrapper = _securityTokenGenerator.GenerateTokenForUser(getUserResult.Value);

    string verificationLink = GenerateVerificationLink(securityTokenWrapper.Token, request.FrontendUrl);
    Message verificationMessage = GenerateVerificationMessage(verificationLink);

    Result sendEmailResult = await _emailService.SendEmail(_config.SenderAddress, new List<string>(){ request.EmailAddress }, verificationMessage);
    return sendEmailResult;
  }

  private static string GenerateVerificationLink(string verificationToken, string frontEndUrl)
  {
    return $"{frontEndUrl}?code={verificationToken}";
  }

  private static Message GenerateVerificationMessage(string link)
  {
    string html = EmailTemplates.VERIFICATION;
    html = html.Replace("{{verifyUrl}}", link);

    Body body = new()
    {
      Html = new Content()
      {
        Charset = "UTF-8",
        Data = html
      }
    };

    Message message = new()
    {
      Subject = new Content()
      {
        Charset = "UTF-8",
        Data = "Please verify your Birche Games account."
      },
      Body = body
    };

    return message;
  }

  public Task<Result> VerifyEmail(VerifyEmailRequest request)
  {
    throw new NotImplementedException();
  }
}