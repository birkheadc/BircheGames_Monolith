using System;
using BircheGamesApi.Services;
using BircheGamesApiUnitTests.Mocks.Exceptions;

namespace BircheGamesApiUnitTests.Mocks.Services;

public class SecurityTokenValidatorMock : BasicMock, ISecurityTokenValidator
{
  public string? GetTokenUserId(string token)
  {
    MethodResponse response = GetMethodResponse("GetTokenUserId");

    switch (response)
    {
      case MethodResponse.THROW:
        throw new IntentionalException();
      case MethodResponse.FAILURE:
        return null;
      case MethodResponse.SUCCESS:
        return "id";
      default:
        throw new NotImplementedException();
    }
  }
}