namespace BircheGamesApi.Services;

public class PasswordVerifier : IPasswordVerifier
{
  public bool Verify(string text, string hash)
  {
    return BCrypt.Net.BCrypt.Verify(text, hash);
  }
}