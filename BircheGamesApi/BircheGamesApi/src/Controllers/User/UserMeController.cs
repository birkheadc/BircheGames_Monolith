using BircheGamesApi.Authorization;
using BircheGamesApi.Models;
using BircheGamesApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BircheGamesApi.Controllers;

[ApiController]
[Authorize]
[Route("users/me")]
public class UserMeController : ExtendedControllerBase
{
  private readonly IUserService _userService;

  public UserMeController(IUserService userService)
  {
    _userService = userService;
  }

  [HttpGet]
  [RequiresEmailVerified]
  public async Task<ActionResult<UserResponseDto>> GetUser()
  {
    string? id = GetCurrentUserId();
    if (id is null) return Error();

    Result result = await _userService.GetUser(id);
    if (result.WasSuccess == false)
    {
      return NotFound();
    }

    return Ok("Conver to dto");
  }
}