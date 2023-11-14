using System.Threading;
using System.Threading.Tasks;
using BircheGamesApi.Models;

namespace BircheGamesApiUnitTests.Mocks.ThirdParty;

public class DynamoDBContextMockBuilder
{
  private readonly DynamoDBContextMock _dynamoDBContextMock = new();

  public DynamoDBContextMock Build()
  {
    return _dynamoDBContextMock;
  }

  public DynamoDBContextMockBuilder WithLoadAsync_UserEntity_Succeeds()
  {
    _dynamoDBContextMock.LoadAsync_UserEntity_Result = Task.FromResult<UserEntity>(new());
    return this;
  }

  public DynamoDBContextMockBuilder WithLoadAsync_UserEntity_Fails()
  {
    _dynamoDBContextMock.LoadAsync_UserEntity_Result = Task.FromCanceled<UserEntity>(new CancellationToken());
    return this;
  }

  public DynamoDBContextMockBuilder WithQueryAsync_UserEntity_ReturnsN(int n)
  {

    return this;
  }
}