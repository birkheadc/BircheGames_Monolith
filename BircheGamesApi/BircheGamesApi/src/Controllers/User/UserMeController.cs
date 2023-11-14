using BircheGamesApi.Authorization;
using BircheGamesApi.Models;
using BircheGamesApi.Requests;
using BircheGamesApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BircheGamesApi.Controllers;

[ApiController]
[Authorize]
[RequiresEmailVerified]
[Route("users/me")]
public class UserMeController : ExtendedControllerBase
{
  private readonly IUserService _userService;
  private readonly string _userId;

  public UserMeController(IUserService userService)
  {
    _userService = userService;
    string? id = GetCurrentUserId();
    if (id is null)
    {
      throw new ArgumentNullException();
    }
    _userId = id;
  }

  [HttpGet]
  public async Task<ActionResult<UserResponseDto>> GetUser()
  {
    Result<UserEntity> result = await _userService.GetUser(_userId);
    if (result.WasSuccess == false)
    {
      return NotFound();
    }

    return Ok(new UserResponseDto(result.Value));
  }

  [HttpPatch]
  [Route("display-name")]
  public async Task<ActionResult> PatchDisplayNameAndTag([FromBody] ChangeDisplayNameAndTagRequest request)
  {
    Result result = await _userService.PatchUserDisplayNameAndTag(_userId, request);
    return ResultToActionResult(result);
  }
}