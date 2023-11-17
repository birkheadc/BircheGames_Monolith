namespace BircheGamesApiUnitTests.Mocks.Services;

public class UserServiceMockBuilder
{
  private UserServiceMock _userServiceMock = new();

  public UserServiceMock Build()
  {
    return _userServiceMock;
  }

  public UserServiceMockBuilder WithMethodResponse(string method, MethodResponse response)
  {
    _userServiceMock.MethodResponses.Add(method, response);
    return this;
  }
}