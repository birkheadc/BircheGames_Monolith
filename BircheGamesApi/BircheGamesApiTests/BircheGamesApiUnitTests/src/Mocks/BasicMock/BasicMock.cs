using System.Collections.Generic;

namespace BircheGamesApiUnitTests.Mocks;

public abstract class BasicMock
{
  public List<MethodCall> MethodCalls { get; set; } = new();
  public Dictionary<string, MethodResponse> MethodResponses = new();
}