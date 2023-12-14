using System;

namespace BircheGamesApiUnitTests.Mocks;

public record MethodCall
{
  public string MethodName { get; init; } = "";
  public object?[] Arguments { get; init; } = Array.Empty<object>();
}