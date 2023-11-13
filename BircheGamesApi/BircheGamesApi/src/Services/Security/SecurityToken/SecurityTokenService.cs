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

  public async Task<Result<SecurityTokenWrapper>> AuthenticateUser(LoginCredentials credentials)
  {
    ResultBuilder<SecurityTokenWrapper> resultBuilder = new();

    Result<UserEntity> result = await _userRepository.GetUserByEmailAddress(credentials.EmailAddress);
    if (result.WasSuccess == false || result.Value is null)
    {
      return resultBuilder
        .Fail()
        .WithGeneralError(404)
        .Build();
    }

    bool isPasswordValid = BCrypt.Net.BCrypt.Verify(credentials.Password, result.Value.PasswordHash);    

    if (isPasswordValid == false)
    {
      return resultBuilder
        .Fail()
        .WithGeneralError(401)
        .Build();
    }
    
    SecurityTokenWrapper securityTokenWrapper = _securityTokenGenerator.GenerateTokenForUser(result.Value);

    return resultBuilder
      .Succeed()
      .WithValue(securityTokenWrapper)
      .Build();
  }
}