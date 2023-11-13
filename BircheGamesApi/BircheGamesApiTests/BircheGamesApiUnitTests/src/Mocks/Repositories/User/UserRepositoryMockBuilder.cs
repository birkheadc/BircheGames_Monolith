using BircheGamesApi;
using BircheGamesApi.Models;

namespace BircheGamesApiUnitTests.Mocks.Repositories;

public class UserRepositoryMockBuilder
{
  private readonly UserRepositoryMock _userRepositoryMock = new();

  public UserRepositoryMock Build()
  {
    return _userRepositoryMock;
  }

  public UserRepositoryMockBuilder WithCreateUserResult(Result result)
  {
    _userRepositoryMock.CreateUserResult = result;
    return this;
  }

  public UserRepositoryMockBuilder WithDeleteUserResult(Result result)
  {
    _userRepositoryMock.DeleteUserResult = result;
    return this;
  }

  public UserRepositoryMockBuilder WithGetUserByDisplayNameAndTagResult(Result<UserEntity> result)
  {
    _userRepositoryMock.GetUserByDisplayNameAndTagResult = result;
    return this;
  }

  public UserRepositoryMockBuilder WithGetUserByIdResult(Result<UserEntity> result)
  {
    _userRepositoryMock.GetUserByIdResult = result;
    return this;
  }

  public UserRepositoryMockBuilder WithGetUserByEmailAddressResult(Result<UserEntity> result)
  {
    _userRepositoryMock.GetUserByEmailAddressResult = result;
    return this;
  }

  public UserRepositoryMockBuilder WithUpdateUserResult(Result result)
  {
    _userRepositoryMock.UpdateUserResult = result;
    return this;
  }

  public UserRepositoryMockBuilder WithAllSuccessfulResult()
  {
    _userRepositoryMock.DeleteUserResult = new(){ WasSuccess = true };
    _userRepositoryMock.CreateUserResult = new(){ WasSuccess = true };
    _userRepositoryMock.GetUserByDisplayNameAndTagResult = new(){ WasSuccess = true };
    _userRepositoryMock.GetUserByIdResult = new(){ WasSuccess = true };
    _userRepositoryMock.UpdateUserResult = new(){ WasSuccess = true };

    return this;
  }

  public UserRepositoryMockBuilder WithAllFailureResults()
  {
    _userRepositoryMock.DeleteUserResult = new(){ WasSuccess = false };
    _userRepositoryMock.CreateUserResult = new(){ WasSuccess = false };
    _userRepositoryMock.GetUserByDisplayNameAndTagResult = new(){ WasSuccess = false };
    _userRepositoryMock.GetUserByIdResult = new(){ WasSuccess = false };
    _userRepositoryMock.UpdateUserResult = new(){ WasSuccess = false };

    return this;
  }
}