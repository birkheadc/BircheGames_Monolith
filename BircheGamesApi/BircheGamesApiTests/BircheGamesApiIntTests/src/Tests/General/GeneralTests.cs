using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace BircheGamesApiIntTests.Tests.General;

public class GeneralTests : IClassFixture<WebApplicationFactory<Program>>
{
  private readonly WebApplicationFactory<Program> _factory;
  public GeneralTests(WebApplicationFactory<Program> factory)
  {
    _factory = factory;
  }

  [Fact]
  public async Task Program_ReturnsGreeting_WhenReceive_GetRequestAtRoot()
  {
    HttpClient client = _factory.CreateClient();
    HttpResponseMessage response = await client.GetAsync("/");
    string actual = await response.Content.ReadAsStringAsync();
    string expected = "Birche Games API";
    Assert.Contains(expected, actual);
  }
}