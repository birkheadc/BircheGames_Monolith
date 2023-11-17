namespace BircheGamesApiUnitTests.Mocks.Services;

public class EmailServiceMockBuilder
{
  private EmailServiceMock _emailServiceMock = new();

  public EmailServiceMock Build()
  {
    return _emailServiceMock;
  }

  public EmailServiceMockBuilder WithMethodResponse(string method, MethodResponse response)
  {
    _emailServiceMock.MethodResponses.Add(method, response);
    return this;
  }
}