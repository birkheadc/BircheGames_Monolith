using BircheGamesApi.Requests;
using BircheGamesApi.Validation;
using BircheGamesApiUnitTests.Mocks.Config;
using FluentValidation.Results;
using Xunit;

namespace BircheGamesApiUnitTests.Tests.Validation;

public class ChangeDisplayNameAndTagRequestValidatorTests
{
  private const string SHORT_DISPLAY_NAME = "";
  private const string LONG_DISPLAY_NAME = "a2345678901234567";
  private const string GOOD_DISPLAY_NAME = "abcdefgh";
  private const string SHORT_TAG = "12345";
  private const string LONG_TAG = "1234567";
  private const string GOOD_TAG = "123456";

  #region DisplayName

  [Fact]
  public void Validate_ReturnsFailure_WhenDisplayName_TooShort()
  {
    ChangeDisplayNameAndTagRequest request = new() { DisplayName = SHORT_DISPLAY_NAME, Tag = GOOD_TAG };
    ChangeDisplayNameAndTagRequestValidator validator = new(UserValidationConfig_Mocks.Default);
    ValidationResult result = validator.Validate(request);
    Assert.False(result.IsValid);
  }

  [Fact]
  public void Validate_ReturnsFailure_WhenDisplayName_TooLong()
  {
    ChangeDisplayNameAndTagRequest request = new() { DisplayName = LONG_DISPLAY_NAME, Tag = GOOD_TAG };
    ChangeDisplayNameAndTagRequestValidator validator = new(UserValidationConfig_Mocks.Default);
    ValidationResult result = validator.Validate(request);
    Assert.False(result.IsValid);
  }

  [Theory]
  [InlineData("abcdefgh!")]
  [InlineData("abcdefgh?")]
  [InlineData("abcdefgh#")]
  [InlineData("abcdefgh$")]
  [InlineData("abcdefgh%")]
  [InlineData("abcdefgh/")]
  [InlineData("abcdefgh\\)]")]
  [InlineData("a\\bcdefgh!)]")]
  [InlineData("\\abcdefgh!")]
  [InlineData("a:bcdefgh!")]
  [InlineData("abc;defgh!")]
  [InlineData("abcd\"efgh!)]")]
  [InlineData("abcd'efgh!")]
  [InlineData("abcdeあgh!")]
  [InlineData("abc亜efgh!")]
  [InlineData("1abcdefgh")]
  [InlineData("abcd-efgh")]
  [InlineData("abcdefgh__")]
  public void Validate_ReturnsFailure_WhenDisplayName_ContainsInvalidCharacters(string displayName)
  {
    ChangeDisplayNameAndTagRequest request = new() { DisplayName = displayName, Tag = GOOD_TAG };
    ChangeDisplayNameAndTagRequestValidator validator = new(UserValidationConfig_Mocks.Default);
    ValidationResult result = validator.Validate(request);
    Assert.False(result.IsValid);
  }

  [Theory]
  [InlineData("abcdefgh")]
  [InlineData("a1")]
  [InlineData("steak_sauce")]
  [InlineData("A")]
  [InlineData("a_1_steak_")]
  public void Validate_ReturnsSuccess_WhenDisplayName_Valid(string displayName)
  {
    ChangeDisplayNameAndTagRequest request = new() { DisplayName = displayName, Tag = GOOD_TAG };
    ChangeDisplayNameAndTagRequestValidator validator = new(UserValidationConfig_Mocks.Default);
    ValidationResult result = validator.Validate(request);
    Assert.True(result.IsValid);
  }

  #endregion DisplayName

  #region Tag

  [Theory]
  [InlineData(SHORT_TAG)]
  [InlineData(LONG_TAG)]
  public void Validate_ReturnsFailure_WhenTag_NotCorrectLength(string tag)
  {
    ChangeDisplayNameAndTagRequest request = new() { DisplayName = GOOD_DISPLAY_NAME, Tag = tag };
    ChangeDisplayNameAndTagRequestValidator validator = new(UserValidationConfig_Mocks.Default);
    ValidationResult result = validator.Validate(request);
    Assert.False(result.IsValid);
  }

  [Theory]
  [InlineData("defgh!")]
  [InlineData("defgh?")]
  [InlineData("defgh#")]
  [InlineData("defgh$")]
  [InlineData("defgh%")]
  [InlineData("defgh/")]
  [InlineData("defgh\\")]
  [InlineData("a\\bjg!")]
  [InlineData("\\aefh!")]
  [InlineData("a:bch!")]
  [InlineData("abc;h!")]
  [InlineData("abcd\"!")]
  [InlineData("abcd'!")]
  [InlineData("agあgh!")]
  [InlineData("abc亜e!")]
  public void Validate_ReturnsFailure_WhenTag_ContainsInvalidCharacters(string tag)
  {
    ChangeDisplayNameAndTagRequest request = new() { DisplayName = GOOD_DISPLAY_NAME, Tag = tag };
    ChangeDisplayNameAndTagRequestValidator validator = new(UserValidationConfig_Mocks.Default);
    ValidationResult result = validator.Validate(request);
    Assert.False(result.IsValid);
  }

  [Theory]
  [InlineData("123456")]
  [InlineData("abcdef")]
  [InlineData("1b3d5f")]
  public void Validate_ReturnsSuccess_WhenTagValid(string tag)
  {
    ChangeDisplayNameAndTagRequest request = new() { DisplayName = GOOD_DISPLAY_NAME, Tag = tag };
    ChangeDisplayNameAndTagRequestValidator validator = new(UserValidationConfig_Mocks.Default);
    ValidationResult result = validator.Validate(request);
    Assert.True(result.IsValid);
  }

  #endregion Tag
}