namespace BircheGamesApiUnitTests.Mocks.ThirdParty;

public class AmazonSimpleEmailServiceMockBuilder
{
  private AmazonSimpleEmailServiceMock _amazonSimpleEmailServiceMock = new();

  public AmazonSimpleEmailServiceMock Build()
  {
    return _amazonSimpleEmailServiceMock;
  }
}