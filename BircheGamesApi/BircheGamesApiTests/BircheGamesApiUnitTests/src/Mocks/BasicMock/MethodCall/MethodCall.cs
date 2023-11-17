namespace BircheGamesApiUnitTests.Mocks;

public record MethodCall
{
  public string MethodName { get; init; } = "";
  public string[] Arguments { get; init; } = System.Array.Empty<string>();
}