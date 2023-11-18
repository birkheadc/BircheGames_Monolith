using System.Collections.Generic;
using BircheGamesApiUnitTests.Mocks.Exceptions;

namespace BircheGamesApiUnitTests.Mocks;

public abstract class BasicMock
{
  public List<MethodCall> MethodCalls { get; set; } = new();
  public Dictionary<string, MethodResponse> MethodResponses = new();
  internal MethodResponse GetMethodResponse(string methodName)
  {
    if (!MethodResponses.ContainsKey(methodName))
    {
      throw new MethodResponseNotSetException(methodName);
    }
    return MethodResponses[methodName];
  }
}