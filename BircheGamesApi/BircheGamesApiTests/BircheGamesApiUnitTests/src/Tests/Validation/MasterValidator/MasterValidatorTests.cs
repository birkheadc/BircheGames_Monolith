using System;
using BircheGamesApi.Requests;
using BircheGamesApi.Validation;
using BircheGamesApiUnitTests.Mocks.Validation;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BircheGamesApiUnitTests.Tests.Validation;

public class MasterValidatorTests
{
  [Fact]
  public void Validate_Fails_WhenRegisteredValidatorFails()
  {
    ServiceCollection serviceCollection = new();
    serviceCollection.AddTransient<IValidator<RegisterUserRequest>, RegisterUserRequestValidator_Mocks_ReturnsInvalid>();
    MasterValidator masterValidator = new(serviceCollection);

    RegisterUserRequest request = new();
    ValidationResult result = masterValidator.Validate(request);

    Assert.False(result.IsValid);
  }

  [Fact]
  public void Validate_Succeeds_WhenRegisteredValidatorSucceeds()
  {
    ServiceCollection serviceCollection = new();
    serviceCollection.AddTransient<IValidator<RegisterUserRequest>, RegisterUserRequestValidator_Mocks_ReturnsValid>();
    MasterValidator masterValidator = new(serviceCollection);

    RegisterUserRequest request = new();
    ValidationResult result = masterValidator.Validate(request);

    Assert.True(result.IsValid);
  }

  [Fact]
  public void Validate_Throws_WhenAttemptingToValidateAnObject_WithNoRegisteredValidator()
  {
    ServiceCollection serviceCollection = new();
    MasterValidator masterValidator = new(serviceCollection);

    RegisterUserRequest request = new();

    Assert.Throws<NullReferenceException>(() => {
      ValidationResult result = masterValidator.Validate(request);
    });
  }
}