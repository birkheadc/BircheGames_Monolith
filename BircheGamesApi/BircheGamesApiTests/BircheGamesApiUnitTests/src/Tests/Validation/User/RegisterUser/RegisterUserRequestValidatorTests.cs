using BircheGamesApi.Requests;
using BircheGamesApi.Validation;
using BircheGamesApiUnitTests.Mocks.Config;
using FluentValidation.Results;
using Xunit;

namespace BircheGamesApiUnitTests.Tests.Validation;

public class RegisterUserRequestValidatorTests
{
  private const string SHORT_PASSWORD = "1234567";
  private const string LONG_PASSWORD = "123456789012345678901234567890123";
  private const string GOOD_PASSWORD = "123456789";
  private const string EMPTY_EMAIL_ADDRESS = "";
  private const string GOOD_EMAIL_ADDRESS = "email@example.com";

  #region EmailAddress
  
  [Fact]
  public void Validate_ReturnsFailure_WhenEmailEmpty()
  {
    RegisterUserRequest request = new() { EmailAddress = EMPTY_EMAIL_ADDRESS, Password = GOOD_PASSWORD };
    RegisterUserRequestValidator validator = new(UserValidationConfig_Mocks.Default);
    ValidationResult result = validator.Validate(request);
    Assert.False(result.IsValid);
  }

  [Theory]
  [InlineData("plainaddress")]
  [InlineData("#@%^%#$@#$@#.com")]
  [InlineData("@example.com")]
  [InlineData("email.example.com")]
  [InlineData("email@example@example.com")]
  [InlineData(".email@example.com")]
  [InlineData("email@example.com (Joe Smith)")]
  public void Validate_ReturnsFailure_WhenEmailInvalid(string emailAddress)
  {
    RegisterUserRequest request = new() { EmailAddress = emailAddress, Password = GOOD_PASSWORD };
    RegisterUserRequestValidator validator = new(UserValidationConfig_Mocks.Default);
    ValidationResult result = validator.Validate(request);
    Assert.False(result.IsValid);
  }

  [Theory]
  [InlineData("email@example.com")]
  [InlineData("firstname.lastname@example.com")]
  [InlineData("email@subdomain.example.com")]
  [InlineData("firstname+lastname@example.com")]
  [InlineData("email@123.123.123.123")]
  [InlineData("email@[123.123.123.123]")]
  [InlineData("\"email\"@example.com")]
  [InlineData("1234567890@example.com")]
  [InlineData("email@example-one.com")]
  [InlineData("_______@example.com")]
  [InlineData("email@example.name")]
  [InlineData("email@example.museum")]
  [InlineData("email@example.co.jp")]
  [InlineData("firstname-lastname@example.com")]
  public void Validate_ReturnsSuccess_WhenEmailValid(string emailAddress)
  {
    RegisterUserRequest request = new() { EmailAddress = emailAddress, Password = GOOD_PASSWORD };
    RegisterUserRequestValidator validator = new(UserValidationConfig_Mocks.Default);
    ValidationResult result = validator.Validate(request);
    Assert.True(result.IsValid);
  }

  #endregion EmailAddress

  #region Password

  [Fact]
  public void Validate_ReturnsFailure_WhenPassword_TooShort()
  {
    RegisterUserRequest request = new() { EmailAddress = GOOD_EMAIL_ADDRESS, Password = SHORT_PASSWORD };
    RegisterUserRequestValidator validator = new(UserValidationConfig_Mocks.Default);
    ValidationResult result = validator.Validate(request);
    Assert.False(result.IsValid);
  }

  [Fact]
  public void Validate_ReturnsFailure_WhenPassword_TooLong()
  {
    RegisterUserRequest request = new() { EmailAddress = GOOD_EMAIL_ADDRESS, Password = LONG_PASSWORD };
    RegisterUserRequestValidator validator = new(UserValidationConfig_Mocks.Default);
    ValidationResult result = validator.Validate(request);
    Assert.False(result.IsValid);
  }

  [Theory]
  [InlineData("123456789")]
  [InlineData("12345678901234567890123456789012")]
  public void Validate_ReturnsSuccess_WhenPassword_CorrectLength(string password)
  {
    RegisterUserRequest request = new() { EmailAddress = GOOD_EMAIL_ADDRESS, Password = password };
    RegisterUserRequestValidator validator = new(UserValidationConfig_Mocks.Default);
    ValidationResult result = validator.Validate(request);
    Assert.True(result.IsValid);
  }

  #endregion Password
}