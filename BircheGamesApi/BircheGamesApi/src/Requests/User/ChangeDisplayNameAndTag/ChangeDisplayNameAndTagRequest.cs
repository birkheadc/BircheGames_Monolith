using BircheGamesApi.Results;
using BircheGamesApi.Validation;

namespace BircheGamesApi.Requests;

public class ChangeDisplayNameAndTagRequest
{
  public string DisplayName { get; init; } = "";
  public string Tag { get; init; } = "";
  public Result Validate(IUserValidator validator)
  {
    return validator
      .WithDisplayName(DisplayName)
      .WithTag(Tag)
      .Validate();
  }
}