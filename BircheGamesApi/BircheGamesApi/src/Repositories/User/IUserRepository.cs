using BircheGamesApi.Models;
using BircheGamesApi.Results;

namespace BircheGamesApi.Repositories;

public interface IUserRepository
{
  public Task<Result> CreateUser(UserEntity user);
  public Task<Result<UserEntity>> GetUserById(string id);
  public Task<Result<UserEntity>> GetUserByDisplayNameAndTag(string displayName, string tag);
  public Task<Result<UserEntity>> GetUserByEmailAddress(string emailAddress);
  public Task<Result> UpdateUser(UserEntity user);
  public Task<Result> DeleteUser(string id);
}