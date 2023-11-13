using BircheGamesApi.Models;
using BircheGamesApi.Requests;

namespace BircheGamesApi.Services;

public interface ISecurityTokenService
{
  public Task<Result<SecurityTokenWrapper>> AuthenticateUser(LoginCredentials credentials); 
}