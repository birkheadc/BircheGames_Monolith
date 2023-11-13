using BircheGamesApi.Config;

namespace BircheGamesApiUnitTests.Mocks.Config;

public static class SecurityTokenConfig_Mocks
{
  public static SecurityTokenConfig Default = new()
  {
    SecretKey = "v14D6qXdfh41Sed34P+3eewO/EOOUYV3UpobQg0Zt+phn854VG7wqpEsLk6TVxDEedVRJY1neiBnGV6U",
    LifespanHours = 1,
    Issuer = "localhost",
    Audience = "localhost" 
  };  
}