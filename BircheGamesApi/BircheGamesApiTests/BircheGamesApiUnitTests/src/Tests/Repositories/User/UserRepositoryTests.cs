using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using BircheGamesApi;
using BircheGamesApi.Models;
using BircheGamesApi.Repositories;
using BircheGamesApiUnitTests.Mocks.ThirdParty;
using Xunit;

namespace BircheGamesApiUnitTests.Tests.Repositories;

 public class UserRepositoryTests
 {

  #region CreateUser

  [Fact]
  public async Task CreateUser_Fails_WhenId_NotUnique()
  {
    DynamoDBContextMock dBContext = new DynamoDBContextMockBuilder()
      .WithLoadAsync_UserEntity_Succeeds()
      .Build();
    UserRepository userRepository = new(dBContext);

    string id = "id";
    UserEntity user = new(){ Id = id };

    Result result = await userRepository.CreateUser(user);

    Assert.False(result.WasSuccess);
    Assert.DoesNotContain(dBContext.MethodsCalled, m => m.Item1 == "SaveAsync");
  }

  [Fact]
  public async Task CreateUser_Succeeds_WhenId_IsUnique()
  {
    // Remember to check that the correct function to create a user on DynamoDBContextMock was called
    // Not just that the repository reported the result as a success
  }

  #endregion CreateUser

  #region UpdateUser

  [Fact]
  public async Task UpdateUser_Fails_WhenUserId_NotFound()
  {
    // Check that the update user method on context was not called
  }

  [Fact]
  public async Task UpdateUser_Succeeds_WhenId_Found()
  {
    // Remember to check that the correct function to update a user on DynamoDBContextMock was called
    // Not just that the repository reported the result as a success
  }

  #endregion UpdateUser
 }