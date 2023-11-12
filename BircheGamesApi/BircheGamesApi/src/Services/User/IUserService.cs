using BircheGamesApi.Requests;

namespace BircheGamesApi.Services;

public interface IUserService
{
  public Task<Result> RegisterUser(RegisterUserRequest request);
}