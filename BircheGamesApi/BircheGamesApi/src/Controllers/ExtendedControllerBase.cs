using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace BircheGamesApi.Controllers;

public class ExtendedControllerBase : ControllerBase
{
  internal string? GetCurrentUserId()
  {
    return HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault()?.Value;
  }

  internal ActionResult Error(string? message = null)
  {
    return StatusCode(500, message);
  }
}