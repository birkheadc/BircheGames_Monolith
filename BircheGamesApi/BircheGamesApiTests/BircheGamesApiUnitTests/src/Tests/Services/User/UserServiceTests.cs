using System.Threading.Tasks;
using BircheGamesApi;
using BircheGamesApi.Requests;
using BircheGamesApi.Services;
using BircheGamesApiUnitTests.Mocks.Validation;
using Xunit;

namespace BircheGamesApiUnitTests.Tests.Services;

public class UserServiceTests
{
  [Fact]
  public async Task RegisterUser_Fails_WhenValidatorFails()
  {
    UserService userService = new(new UserValidator_Mocks_ReturnsInvalid());

    Result result = await userService.RegisterUser(new());

    Assert.False(result.WasSuccess);
  }

  [Fact]
  public async Task RegisterUser_Succeeds_WhenValidatorSucceeds()
  {
    UserService userService = new(new UserValidator_Mocks_ReturnsValid());

    Result result = await userService.RegisterUser(new());

    Assert.False(result.WasSuccess);
  }
}