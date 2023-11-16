namespace BircheGamesApiUnitTests.Mocks.ThirdParty;

public class AmazonSimpleEmailServiceMockBuilder
{
  private AmazonSimpleEmailServiceMock _amazonSimpleEmailServiceMock = new();

  public AmazonSimpleEmailServiceMock Build()
  {
    return _amazonSimpleEmailServiceMock;
  }

  public AmazonSimpleEmailServiceMockBuilder WithMethodResponse(string method, MethodResponse response)
  {
    _amazonSimpleEmailServiceMock.MethodResponses.Add(method, response);
    return this;
  }
}