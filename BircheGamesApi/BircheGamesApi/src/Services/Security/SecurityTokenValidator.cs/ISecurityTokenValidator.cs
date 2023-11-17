namespace BircheGamesApi.Services;

public interface ISecurityTokenValidator
{
  public string? GetTokenUserId(string token);
}