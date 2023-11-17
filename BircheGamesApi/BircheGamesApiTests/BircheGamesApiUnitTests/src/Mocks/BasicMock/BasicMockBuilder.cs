namespace BircheGamesApiUnitTests.Mocks;

public class BasicMockBuilder<T> where T : BasicMock, new()
{
  private T _mock = new();

  public T Build()
  {
    return _mock;
  }

  public BasicMockBuilder<T> WithMethodResponse(string method, MethodResponse response)
  {
    _mock.MethodResponses.Add(method, response);
    return this;
  }
}