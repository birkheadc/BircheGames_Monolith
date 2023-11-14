using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BircheGamesApi.Models;

namespace BircheGamesApiUnitTests.Mocks.ThirdParty;

public class DynamoDBContextMockBuilder
{
  private DynamoDBContextMock _dynamoDBContextMock = new();

  public DynamoDBContextMock Build()
  {
    return _dynamoDBContextMock;
  }

  public DynamoDBContextMockBuilder WithLoadAsync_UserEntity_Succeeds()
  {
    _dynamoDBContextMock.LoadAsync_UserEntity_Result = Task.FromResult<UserEntity?>(new());
    return this;
  }

  public DynamoDBContextMockBuilder WithLoadAsync_UserEntity_Fails()
  {
    _dynamoDBContextMock.LoadAsync_UserEntity_Result = Task.FromResult<UserEntity?>(null);
    return this;
  }

  public DynamoDBContextMockBuilder WithQueryAsync_UserEntity_ReturnsN(int n)
  {
    List<UserEntity> users = new();
    for (int i = 0; i < n; i++)
    {
      users.Add(new());
    }
    _dynamoDBContextMock.QueryAsync_UserEntity_Result = new AsyncSearchMock<UserEntity>(users);
    return this;
  }

  public DynamoDBContextMockBuilder WithEverythingThrows()
  {
    // (╯°□°)╯︵ ┻━┻
    _dynamoDBContextMock = new DynamoDBContextMockThrows();
    return this;
  }
}