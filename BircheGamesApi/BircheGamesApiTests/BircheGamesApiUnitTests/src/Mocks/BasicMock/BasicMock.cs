using System;
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

  internal void AddMethodCall(string methodName, params object?[]? arguments)
  {
    MethodCalls.Add(new()
    {
      MethodName = methodName,
      Arguments = arguments ?? Array.Empty<object>()
    });
  }
}