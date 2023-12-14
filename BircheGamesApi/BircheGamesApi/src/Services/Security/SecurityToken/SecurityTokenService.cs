using System.Net;
using BircheGamesApi.Models;
using BircheGamesApi.Repositories;
using BircheGamesApi.Requests;
using BircheGamesApi.Results;

namespace BircheGamesApi.Services;

public class SecurityTokenService : ISecurityTokenService
{
  private readonly IUserRepository _userRepository;
  private readonly ISecurityTokenGenerator _securityTokenGenerator;
  private readonly IPasswordVerifier _passwordVerifier;

  public SecurityTokenService(IUserRepository userRepository, ISecurityTokenGenerator securityTokenGenerator, IPasswordVerifier passwordVerifier)
  {
    _userRepository = userRepository;
    _securityTokenGenerator = securityTokenGenerator;
    _passwordVerifier = passwordVerifier;
  }

  public async Task<Result<SecurityTokenWrapper>> AuthenticateUser(LoginCredentials credentials)
  {
    Result<UserEntity> result = await _userRepository.GetUserByEmailAddress(credentials.EmailAddress);
    if (result.WasSuccess == false || result.Value is null) return Result.Fail().WithGeneralError(HttpStatusCode.NotFound);

    bool isPasswordValid = _passwordVerifier.Verify(credentials.Password, result.Value.PasswordHash);    
    if (isPasswordValid == false) return Result.Fail().WithGeneralError(HttpStatusCode.Unauthorized);
    
    SecurityTokenWrapper securityTokenWrapper = _securityTokenGenerator.GenerateTokenForUser(result.Value);
    return Result.Succeed().WithValue(securityTokenWrapper);
  }
}