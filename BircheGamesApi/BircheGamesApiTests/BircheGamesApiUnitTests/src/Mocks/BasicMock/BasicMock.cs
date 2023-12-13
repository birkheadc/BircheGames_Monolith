using System.Collections.Generic;
using BircheGamesApiUnitTests.Mocks.Exceptions;
using Newtonsoft.Json;

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

  internal void AddMethodCall(string methodName, object? arguments = null)
  {
    MethodCall methodCall = new()
    {
      MethodName = methodName,
      Arguments = new[]{JsonConvert.SerializeObject(arguments)}
    };
    MethodCalls.Add(methodCall);
  }
}