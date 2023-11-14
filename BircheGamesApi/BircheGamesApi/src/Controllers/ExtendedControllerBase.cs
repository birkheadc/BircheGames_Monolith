using System.Security.Claims;
using BircheGamesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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

  internal ActionResult ResultToActionResult(Result result)
  {
    if (result.WasSuccess)
    {
      return Ok();
    }
    
    if (result.Errors.IsNullOrEmpty())
    {
      return BadRequest();
    }

    int statusCode = result.Errors[0].StatusCode ?? 0;
    
    if (statusCode == 0)
    {
      return BadRequest(result.Errors);
    }
    
    return StatusCode(statusCode, result.Errors);
  }
}