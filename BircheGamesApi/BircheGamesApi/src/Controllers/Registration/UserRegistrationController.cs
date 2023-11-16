using BircheGamesApi.Controllers;
using BircheGamesApi.Requests;
using BircheGamesApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BircheGamesApi.Controllers;

[ApiController]
[Route("registration")]
public class UserRegistrationController : ExtendedControllerBase
{
  private readonly IUserService _userService;

  public UserRegistrationController(IUserService userService)
  {
    _userService = userService;
  }

  [HttpPost]
  [AllowAnonymous]
  public async Task<IActionResult> RegisterNewUser([FromBody] RegisterUserRequest request)
  {
    Result result = await _userService.RegisterUser(request);
    return ResultToActionResult(result);
  }
}