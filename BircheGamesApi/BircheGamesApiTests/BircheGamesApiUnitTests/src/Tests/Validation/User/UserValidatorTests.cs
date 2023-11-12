using BircheGamesApi;
using BircheGamesApi.Validation;
using BircheGamesApiUnitTests.Mocks.Config;
using Xunit;

namespace BircheGamesApiUnitTests.Tests.Validation;

public class UserValidatorTests
{
  [Fact]
  public void Validate_ReturnsFailure_WhenEmailEmpty()
  {
    UserValidator userValidator = new(UserValidationConfig_Mocks.Default);
    Result result = userValidator
      .WithEmailAddress("")
      .Validate();
    Assert.False(result.WasSuccess);
  }

  [Fact]
  public void Validate_ReturnsFailure_WhenEmailInvalid()
  {
    string[] invalidAddresses = {
      "plainaddress", 
      "#@%^%#$@#$@#.com", 
      "@example.com", 
      "email.example.com", 
      "email@example@example.com", 
      ".email@example.com", 
      "email@example.com (Joe Smith)", 
    };

    foreach (string emailAddress in invalidAddresses)
    {
      UserValidator userValidator = new(UserValidationConfig_Mocks.Default);
      Result result = userValidator
        .WithEmailAddress(emailAddress)
        .Validate();
      Assert.False(result.WasSuccess);
    }
  }

  [Fact]
  public void Validate_ReturnsSuccess_WhenEmailValid()
  {
    string[] validAddresses = {
      "email@example.com", 
      "firstname.lastname@example.com", 
      "email@subdomain.example.com", 
      "firstname+lastname@example.com", 
      "email@123.123.123.123", 
      "email@[123.123.123.123]", 
      "\"email\"@example.com", 
      "1234567890@example.com", 
      "email@example-one.com", 
      "_______@example.com", 
      "email@example.name", 
      "email@example.museum", 
      "email@example.co.jp", 
      "firstname-lastname@example.com",
    };

    foreach (string emailAddress in validAddresses)
    {
      UserValidator userValidator = new(UserValidationConfig_Mocks.Default);
      Result result = userValidator
        .WithEmailAddress(emailAddress)
        .Validate();
      Assert.True(result.WasSuccess);
    }
  }

  [Fact]
  public void Validate_ReturnsFailure_WhenDisplayName_TooShort()
  {
    UserValidator userValidator = new(UserValidationConfig_Mocks.Default);
    Result result = userValidator
      .WithDisplayName("")
      .Validate();
    Assert.False(result.WasSuccess);
  }

  [Fact]
  public void Validate_ReturnsFailure_WhenDisplayName_TooLong()
  {
    UserValidator userValidator = new(UserValidationConfig_Mocks.Default);
    Result result = userValidator
      .WithDisplayName("a2345678901234567")
      .Validate();
    Assert.False(result.WasSuccess);
  }

  [Fact]
  public void Validate_ReturnsFailure_WhenDisplayName_ContainsInvalidCharacters()
  {
    string[] invalidDisplayNames = {
      "abcdefgh!",
      "abcdefgh?",
      "abcdefgh#",
      "abcdefgh$",
      "abcdefgh%",
      "abcdefgh/",
      "abcdefgh\\",
      "a\\bcdefgh!",
      "\\abcdefgh!",
      "a:bcdefgh!",
      "abc;defgh!",
      "abcd\"efgh!",
      "abcd'efgh!",
      "abcdeあgh!",
      "abc亜efgh!",
      "1abcdefgh",
      "abcd-efgh",
      "abcdefgh__"
    };

    foreach (string displayName in invalidDisplayNames)
    {
      UserValidator userValidator = new(UserValidationConfig_Mocks.Default);
      Result result = userValidator
        .WithDisplayName(displayName)
        .Validate();
      Assert.False(result.WasSuccess);
    }
  }

  [Fact]
  public void Validate_ReturnsSuccess_WhenDisplayName_Valid()
  {
    string[] validDisplayNames = {
      "abcdefgh",
      "a1",
      "steak_sauce",
      "A",
      "a_1_steak_"
    };

    foreach (string displayName in validDisplayNames)
    {
      UserValidator userValidator = new(UserValidationConfig_Mocks.Default);
      Result result = userValidator
        .WithDisplayName(displayName)
        .Validate();
      Assert.True(result.WasSuccess);
    }
  }

  [Fact]
  public void Validate_ReturnsFailure_WhenTag_NotCorrectLength()
  {
    foreach (string tag in new[] { "12345", "1234567" })
    {
      UserValidator userValidator = new(UserValidationConfig_Mocks.Default);
      Result result = userValidator
        .WithTag(tag)
        .Validate();
      Assert.False(result.WasSuccess);
    }
  }

  [Fact]
  public void Validate_ReturnsFailure_WhenTag_ContainsInvalidCharacters()
  {
    string[] invalidTags = {
      "defgh!",
      "defgh?",
      "defgh#",
      "defgh$",
      "defgh%",
      "defgh/",
      "defgh\\",
      "a\\bjg!",
      "\\aefh!",
      "a:bch!",
      "abc;h!",
      "abcd\"!",
      "abcd'!",
      "agあgh!",
      "abc亜e!"
    };

    foreach (string tag in invalidTags)
    {
      UserValidator userValidator = new(UserValidationConfig_Mocks.Default);
      Result result = userValidator
        .WithTag(tag)
        .Validate();
      Assert.False(result.WasSuccess);
    }
  }

  [Fact]
  public void Validate_ReturnsSuccess_WhenTagValid()
  {
    string[] validTags = {
      "123456",
      "abcdef",
      "1b3d5f"
    };
    
    foreach (string tag in validTags)
    {
      UserValidator userValidator = new(UserValidationConfig_Mocks.Default);
      Result result = userValidator
        .WithTag(tag)
        .Validate();
      Assert.True(result.WasSuccess);
    }
  }

  [Fact]
  public void Validate_ReturnsFailure_WhenPassword_TooShort()
  {
    UserValidator userValidator = new(UserValidationConfig_Mocks.Default);
    Result result = userValidator
      .WithPassword("1234567")
      .Validate();
    Assert.False(result.WasSuccess);
  }

  [Fact]
  public void Validate_ReturnsFailure_WhenPassword_TooLong()
  {
    UserValidator userValidator = new(UserValidationConfig_Mocks.Default);
    Result result = userValidator
      .WithPassword("123456789012345678901234567890123")
      .Validate();
    Assert.False(result.WasSuccess);
  }

  [Fact]
  public void Validate_ReturnsSuccess_WhenPassword_CorrectLength()
  {
    foreach (string password in new[] { "123456789", "12345678901234567890123456789012" })
    {
      UserValidator userValidator = new(UserValidationConfig_Mocks.Default);
      Result result = userValidator
        .WithPassword(password)
        .Validate();
      Assert.True(result.WasSuccess);
    }
  }
}