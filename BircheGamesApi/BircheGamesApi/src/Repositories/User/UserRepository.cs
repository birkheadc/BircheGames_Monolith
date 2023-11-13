using BircheGamesApi.Models;

namespace BircheGamesApi.Repositories;

public class UserRepository : IUserRepository
{
  public Task<Result> CreateUser(UserEntity user)
  {
    throw new NotImplementedException();
  }

  public Task<Result> DeleteUser(string id)
  {
    throw new NotImplementedException();
  }

  public Task<Result<UserEntity>> GetUserByDisplayNameAndTag(string displayName, string tag)
  {
    throw new NotImplementedException();
  }

  public Task<Result<UserEntity>> GetUserById(string id)
  {
    throw new NotImplementedException();
  }

  public Task<Result> UpdateUser(UserEntity user)
  {
    throw new NotImplementedException();
  }
}