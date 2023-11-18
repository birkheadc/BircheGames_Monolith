namespace BircheGamesApi.Services;

public interface IPasswordVerifier
{
  public bool Verify(string text, string hash);
}