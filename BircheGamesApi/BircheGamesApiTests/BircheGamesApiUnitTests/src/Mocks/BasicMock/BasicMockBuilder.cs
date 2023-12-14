using System.Collections.Generic;

namespace BircheGamesApiUnitTests.Mocks;

public class BasicMockBuilder<T> where T : BasicMock, new()
{
  private readonly Dictionary<string, MethodResponse> _methodResponses = new();

  public T Build()
  {
    return new()
    {
      MethodResponses = _methodResponses
    };
  }

  public BasicMockBuilder<T> WithMethodResponse(string method, MethodResponse response)
  {
    _methodResponses.Add(method, response);
    return this;
  }
}