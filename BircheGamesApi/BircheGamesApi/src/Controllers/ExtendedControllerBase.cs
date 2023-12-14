using System.Net;
using System.Security.Claims;
using BircheGamesApi.Models;
using BircheGamesApi.Results;
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
    if (result.WasSuccess) return Ok();

    HttpStatusCode statusCode = result.Errors.Where(e => e.StatusCode is not null).FirstOrDefault()?.StatusCode ?? HttpStatusCode.BadRequest;
    return StatusCode((int)statusCode, result.Errors);
  }
}