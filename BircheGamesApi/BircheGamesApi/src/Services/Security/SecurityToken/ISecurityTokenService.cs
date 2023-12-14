using BircheGamesApi.Models;
using BircheGamesApi.Requests;
using BircheGamesApi.Results;

namespace BircheGamesApi.Services;

public interface ISecurityTokenService
{
  public Task<Result<SecurityTokenWrapper>> AuthenticateUser(LoginCredentials credentials); 
}