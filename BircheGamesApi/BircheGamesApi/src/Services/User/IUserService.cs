using BircheGamesApi.Models;
using BircheGamesApi.Requests;

namespace BircheGamesApi.Services;

public interface IUserService
{
  public Task<Result> RegisterUser(RegisterUserRequest request);
  public Task<Result> PatchUserDisplayNameAndTag(string id, ChangeDisplayNameAndTagRequest request);
  public Task<Result<UserEntity>> GetUser(string id);
  public Task<Result<UserEntity>> GetUserByEmailAddress(string emailAddress);
}