using BircheGamesApi.Models;
using BircheGamesApi.Repositories;
using BircheGamesApi.Requests;

namespace BircheGamesApi.Services;

public class SecurityTokenService : ISecurityTokenService
{
  private readonly IUserRepository _userRepository;
  private readonly ISecurityTokenGenerator _securityTokenGenerator;
  
  public SecurityTokenService(IUserRepository userRepository, ISecurityTokenGenerator securityTokenGenerator)
  {
    _userRepository = userRepository;
    _securityTokenGenerator = securityTokenGenerator;
  }

  public Task<Result<SecurityTokenWrapper>> AuthenticateUser(LoginCredentials credentials)
  {
    
  }
}