using System.Collections.Generic;

namespace BircheGamesApiUnitTests.Mocks;

public abstract class BasicMock
{
  public List<MethodCall> MethodCalls { get; set; } = new();
  public Dictionary<string, MethodResponse> MethodResponses = new();
  internal MethodResponse GetMethodResponse(string methodName)
  {
    if (MethodResponses.ContainsKey(methodName))
    {
      return MethodResponses[methodName];
    }
    return MethodResponse.THROW;
  }
}