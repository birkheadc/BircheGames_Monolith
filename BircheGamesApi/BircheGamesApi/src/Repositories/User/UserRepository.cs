using System.Net;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using BircheGamesApi.Models;
using BircheGamesApi.Results;
using Microsoft.IdentityModel.Tokens;

namespace BircheGamesApi.Repositories;

public class UserRepository : IUserRepository
{
  private readonly IDynamoDBContext _context;

  public UserRepository(IDynamoDBContext context)
  {
    _context = context;
  }

  public async Task<Result> CreateUser(UserEntity user)
  {
    try
    {
      bool isIdUnique = await IsIdUnique(user.Id);

      if (isIdUnique == false) return Result.Fail().WithGeneralError(HttpStatusCode.Conflict);

      await _context.SaveAsync(user);
      return Result.Succeed();
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error while creating user: {ex.Message}");
      return Result.Fail().WithGeneralError(HttpStatusCode.InternalServerError, "An unexpected error occurred while connecting to the database.");
    }
    
  }

  public Task<Result> DeleteUser(string id)
  {
    throw new NotImplementedException();
  }

  public async Task<Result<UserEntity>> GetUserByDisplayNameAndTag(string displayName, string tag)
  {
    DynamoDBOperationConfig config = new()
    {
      IndexName = "DisplayName-Tag-index"
    };

    try
    {
      AsyncSearch<UserEntity> asyncSearch = _context.QueryAsync<UserEntity>(displayName, QueryOperator.Equal, new List<object>(){ tag }, config);
      List<UserEntity> users = await asyncSearch.GetRemainingAsync();

      if (users.IsNullOrEmpty()) return Result.Fail().WithGeneralError(HttpStatusCode.NotFound);

      return Result.Succeed().WithValue(users[0]);
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error while searching for user by display-name / tag: {ex.Message}");
      return Result.Fail().WithGeneralError(HttpStatusCode.InternalServerError, "An unexpected error occurred while connecting to the database.");
    }
  }

  public async Task<Result<UserEntity>> GetUserByEmailAddress(string emailAddress)
  {
    DynamoDBOperationConfig config = new()
    {
      IndexName = "EmailAddress-index"
    };

    try
    {
      List<UserEntity> users = await _context.QueryAsync<UserEntity>(emailAddress, config).GetRemainingAsync();

      if (users.IsNullOrEmpty()) return Result.Fail().WithGeneralError(HttpStatusCode.NotFound);

      return Result.Succeed().WithValue(users[0]);
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error while searching for user by email: {ex.Message}");
      return Result.Fail().WithGeneralError(HttpStatusCode.InternalServerError, "An unexpected error occurred while connecting to the database.");
    }
  }

  public async Task<Result<UserEntity>> GetUserById(string id)
  {
    UserEntity? user = await _context.LoadAsync<UserEntity>(id);

    if (user is null) return Result.Fail().WithGeneralError(HttpStatusCode.NotFound);

    return Result.Succeed().WithValue(user);
  }

  public async Task<Result> UpdateUser(UserEntity user)
  {
    try
    {
      bool isIdUnique = await IsIdUnique(user.Id);
      if (isIdUnique == true) return Result.Fail().WithGeneralError(HttpStatusCode.NotFound);

      await _context.SaveAsync(user);
      return Result.Succeed();
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error while updating user: {ex.Message}");
      return Result.Fail().WithGeneralError(HttpStatusCode.InternalServerError, "An unexpected error occurred while connecting to the database.");
    }
  }

  private async Task<bool> IsIdUnique(string id)
  {
    Result result = await GetUserById(id);
    return result.WasSuccess == false;
  }
}