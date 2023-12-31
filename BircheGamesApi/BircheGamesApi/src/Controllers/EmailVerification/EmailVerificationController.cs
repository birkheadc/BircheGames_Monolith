using BircheGamesApi.Requests;
using BircheGamesApi.Results;
using BircheGamesApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BircheGamesApi.Controllers;

[ApiController]
[Route("email-verification")]
public class EmailVerificationController : ExtendedControllerBase
{
  private readonly IUserService _userService;
  private readonly IEmailVerificationService _emailVerificationService;

  public EmailVerificationController(IUserService userService, IEmailVerificationService emailVerificationService)
  {
    _userService = userService;
    _emailVerificationService = emailVerificationService;
  }

  [HttpPost]
  [Route("generate")]
  [AllowAnonymous]
  public async Task<IActionResult> GenerateVerificationEmail(GenerateVerificationEmailRequest request)
  {
    Result result = await _emailVerificationService.GenerateAndSendVerificationEmail(request);
    return ResultToActionResult(result);
  }

  [HttpPost]
  [Route("verify")]
  [AllowAnonymous]
  public async Task<IActionResult> VerifyEmail(VerifyEmailRequest request)
  {
    Result result = await _emailVerificationService.VerifyEmail(request);
    return ResultToActionResult(result);
  }
}