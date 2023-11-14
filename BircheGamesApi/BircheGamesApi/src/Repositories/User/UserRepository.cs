using Amazon.DynamoDBv2.DataModel;
using BircheGamesApi.Models;

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

    bool isIdUnique = await IsIdUnique(user.Id);

    if (isIdUnique == false)
    {
      return resultBuilder
        .Fail()
        .WithGeneralError(409)
        .Build();
    }

    return resultBuilder
      .Succeed()
      .Build();
  }

  public Task<Result> DeleteUser(string id)
  {
    throw new NotImplementedException();
  }

  public Task<Result<UserEntity>> GetUserByDisplayNameAndTag(string displayName, string tag)
  {
    throw new NotImplementedException();
  }

  public Task<Result<UserEntity>> GetUserByEmailAddress(string emailAddress)
  {
    throw new NotImplementedException();
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

  public Task<Result> UpdateUser(UserEntity user)
  {
    throw new NotImplementedException();
  }

  private async Task<bool> IsIdUnique(string id)
  {
    Result result = await GetUserById(id);
    return result.WasSuccess == false;
  }
}