using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using BircheGamesApi.Models;
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
    ResultBuilder resultBuilder = new();

    try
    {
      bool isIdUnique = await IsIdUnique(user.Id);

      if (isIdUnique == false)
      {
        return resultBuilder
          .Fail()
          .WithGeneralError(409)
          .Build();
      }

      await _context.SaveAsync(user);
      return resultBuilder
        .Succeed()
        .Build();
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error while creating user: {ex.Message}");
      return resultBuilder
        .Fail()
        .WithGeneralError(500, "An unexpected error occurred while connecting to the database.")
        .Build();
    }
    
  }

  public Task<Result> DeleteUser(string id)
  {
    throw new NotImplementedException();
  }

  public async Task<Result<UserEntity>> GetUserByDisplayNameAndTag(string displayName, string tag)
  {
    ResultBuilder<UserEntity> resultBuilder = new();

    DynamoDBOperationConfig config = new()
    {
      IndexName = "DisplayName-Tag-index"
    };

    try
    {
      AsyncSearch<UserEntity> asyncSearch = _context.QueryAsync<UserEntity>(displayName, QueryOperator.Equal, new List<object>(){ tag }, config);
      List<UserEntity> users = await asyncSearch.GetRemainingAsync();
      if (users.IsNullOrEmpty())
      {
        return resultBuilder
          .Fail()
          .WithGeneralError(404)
          .Build();
      }
      return resultBuilder
        .Succeed()
        .WithValue(users[0])
        .Build();
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error while searching for user by display-name / tag: {ex.Message}");
      return resultBuilder
        .Fail()
        .WithGeneralError(500, "An unexpected error occurred while connecting to the database.")
        .Build();
    }
  }

  public async Task<Result<UserEntity>> GetUserByEmailAddress(string emailAddress)
  {
    ResultBuilder<UserEntity> resultBuilder = new();

    DynamoDBOperationConfig config = new()
    {
      IndexName = "EmailAddress-index"
    };

    try
    {
      List<UserEntity> users = await _context.QueryAsync<UserEntity>(emailAddress, config).GetRemainingAsync();
      if (users.IsNullOrEmpty())
      {
        return resultBuilder
          .Fail()
          .WithGeneralError(404)
          .Build();
      }
      return resultBuilder
        .Succeed()
        .WithValue(users[0])
        .Build();
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error while searching for user by email: {ex.Message}");
      return resultBuilder
        .Fail()
        .WithGeneralError(500, "An unexpected error occurred while connecting to the database.")
        .Build();
    }
  }

  public async Task<Result<UserEntity>> GetUserById(string id)
  {
    ResultBuilder<UserEntity> resultBuilder = new();

    UserEntity? user = await _context.LoadAsync<UserEntity>(id);

    if (user is null)
    {
      return resultBuilder
        .Fail()
        .WithGeneralError(404)
        .Build();
    }

    return resultBuilder
      .Succeed()
      .WithValue(user)
      .Build();
  }

  public async Task<Result> UpdateUser(UserEntity user)
  {
    ResultBuilder resultBuilder = new();
    try
    {
      bool isIdUnique = await IsIdUnique(user.Id);
      if (isIdUnique == true)
      {
        return resultBuilder
          .Fail()
          .WithGeneralError(404)
          .Build();
      }
      await _context.SaveAsync(user);
      return resultBuilder
        .Succeed()
        .Build();
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error while updating user: {ex.Message}");
      return resultBuilder
        .Fail()
        .WithGeneralError(500, "An unexpected error occurred while connecting to the database.")
        .Build();
    }
  }

  private async Task<bool> IsIdUnique(string id)
  {
    Result result = await GetUserById(id);
    return result.WasSuccess == false;
  }
}