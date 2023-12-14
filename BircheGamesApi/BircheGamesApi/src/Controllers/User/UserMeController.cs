using BircheGamesApi.Authorization;
using BircheGamesApi.Models;
using BircheGamesApi.Requests;
using BircheGamesApi.Results;
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

  public UserMeController(IUserService userService)
  {
    _userService = userService;
  }

  [HttpGet]
  public async Task<ActionResult<UserResponseDto>> GetUser()
  {
    string? id = GetCurrentUserId();
    if (id is null) return Error();

    Result<UserEntity> result = await _userService.GetUser(id);
    if (result.WasSuccess == false) return NotFound();

    return Ok(UserResponseDto.FromEntity(result.Value));
  }

  [HttpPatch]
  [Route("display-name")]
  public async Task<ActionResult> PatchDisplayNameAndTag([FromBody] ChangeDisplayNameAndTagRequest request)
  {
    string? id = GetCurrentUserId();
    if (id is null) return Error();

    Result result = await _userService.PatchUserDisplayNameAndTag(id, request);
    return ResultToActionResult(result);
  }
}