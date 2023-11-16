using System.Threading.Tasks;
using BircheGamesApi.Services;
using Xunit;

namespace BircheGamesApiUnitTests.Tests.Services;

public class EmailServiceTests
{
  [Fact]
  public async Task SendEmail_FailsWhenTo_IsEmpty()
  {
    EmailService emailService = new();
  }
}