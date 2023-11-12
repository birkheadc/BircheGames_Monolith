using Amazon.DynamoDBv2.DataModel;
using BircheGamesApi.Requests;

namespace BircheGamesApi.Models;

[DynamoDBTable("BircheGames_Users")]
public class UserEntity
{
  [DynamoDBHashKey]
  public string Id { get; init; } = "";

  [DynamoDBGlobalSecondaryIndexHashKey]
  public string EmailAddress { get; init; } = "";

  [DynamoDBGlobalSecondaryIndexHashKey]
  public string DisplayName { get; set; } = "";
  [DynamoDBGlobalSecondaryIndexRangeKey]
  public string Tag { get; set; } = "";
  [DynamoDBProperty]
  public string CreationDateTime { get; init; } = "";
  [DynamoDBProperty]
  public string PasswordHash { get; set; } = "";

  [DynamoDBProperty]
  public UserRole Role { get; set; }
  
  [DynamoDBProperty]
  public bool IsEmailVerified { get; set; }
  [DynamoDBProperty]
  public bool IsDisplayNameChosen { get; set; }

  public UserEntity()
  {
    
  }

  public UserEntity(RegisterUserRequest request)
  {
    Id = Guid.NewGuid().ToString();
    EmailAddress = request.EmailAddress;
    DisplayName = Guid.NewGuid().ToString();
    Tag = "######";
    CreationDateTime = DateTime.Now.ToString();
    PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
    Role = UserRole.USER;
    IsEmailVerified = false;
    IsDisplayNameChosen = false;
  }
}