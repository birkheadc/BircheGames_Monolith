using System.Text;
using BircheGamesApi.Authorization;
using BircheGamesApi.Models;
using BircheGamesApi.Requests;
using BircheGamesApi.Results;
using BircheGamesApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BircheGamesApi.Controllers;

[ApiController]
[Route("authentication")]
public class AuthenticationController : ExtendedControllerBase
{
  private readonly ISecurityTokenService _securityTokenService;

  public AuthenticationController(ISecurityTokenService securityTokenService)
  {
    _securityTokenService = securityTokenService;
  }

  [HttpPost]
  [AllowAnonymous]
  public async Task<ActionResult<SecurityTokenWrapper>> Authenticate()
  {
    LoginCredentials? credentials = GetCredentialsFromHeaders(Request.Headers);
    if (credentials is null)
    {
      return Unauthorized("Unable to retrieve credentials from Authorization header.");
    }

    Result<SecurityTokenWrapper> result = await _securityTokenService.AuthenticateUser(credentials);
    
    if (result.WasSuccess == false || result.Value is null)
    {
      return Unauthorized();
    }

    return Ok(result.Value);
  }

  [HttpGet]
  [Route("token-verification")]
  [Authorize]
  public IActionResult VerifyTokenAny()
  {
    return Ok("This token is valid.");
  }

  [HttpGet]
  [Route("token-verification/admin")]
  [Authorize]
  [RequiresRole(UserRole.ADMIN)]
  public IActionResult VerifyTokenAdmin()
  {
    return Ok("This token is valid and the user is an admin.");
  }

  [HttpGet]
  [Route("token-verification/super")]
  [Authorize]
  [RequiresRole(UserRole.SUPER)]
  public IActionResult VerifyTokenSuper()
  {
    return Ok("This token is valid and the user is a super admin.");
  }

  private static LoginCredentials? GetCredentialsFromHeaders(IHeaderDictionary headers)
  {
    try
    {
      string auth = headers.Authorization;
      string token = auth.Substring(6);
      string converted = Encoding.UTF8.GetString(Convert.FromBase64String(token));
      string[] split = converted.Split(':');
      if (split.Length == 2)
      {
        return new LoginCredentials()
        {
          EmailAddress = split[0],
          Password = split[1]
        };
      }
      return null;
    }
    catch (Exception e)
    {
      // Todo: Logging
      Console.WriteLine("Exception encountered while trying to retrieve credentials from header:");
      Console.WriteLine(e);
      return null;
    }
  }
}