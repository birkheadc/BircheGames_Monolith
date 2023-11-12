using BircheGamesApi.Requests;

namespace BircheGamesApi.Services;

public interface IUserService
{
  public Task<Result> RegisterUser(RegisterUserRequest request);
  public Task<Result> PatchUserDisplayNameAndTag(ChangeDisplayNameAndTagRequest request);
}