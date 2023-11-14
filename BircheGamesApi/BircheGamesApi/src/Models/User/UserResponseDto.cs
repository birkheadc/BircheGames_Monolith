namespace BircheGamesApi.Models;

public record UserResponseDto
{
  public string Id { get; init; } = "";
  public string EmailAddress { get; init; } = "";
  public string DisplayName { get; init; } = "";
  public string Tag { get; init; } = "";
  public string CreationDateTime { get; init; } = "";
  public UserRole Role { get; init; }
  public bool IsEmailVerified { get; init; } = false;
  public bool IsDisplayNameChosen { get; init; } = false;
  public UserResponseDto()
  {

  }
  public UserResponseDto(UserEntity? entity)
  {
    if (entity is not null)
    {
      Id = entity.Id;
      EmailAddress = entity.EmailAddress;
      DisplayName = entity.DisplayName;
      Tag = entity.Tag;
      CreationDateTime = entity.CreationDateTime;
      Role = entity.Role;
      IsEmailVerified = entity.IsEmailVerified;
      IsDisplayNameChosen = entity.IsDisplayNameChosen;
    }
  }
}