using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using BircheGamesApi.Models;
using Newtonsoft.Json;

#pragma warning disable CS8625, CS8619, CS8600
namespace BircheGamesApiUnitTests.Mocks.ThirdParty;

public class DynamoDBContextMock : IDynamoDBContext
{
  public Task<UserEntity?>? LoadAsync_UserEntity_Result = null;
  public AsyncSearchMock<UserEntity>? QueryAsync_UserEntity_Result = null;
  public readonly List<(string, string[])> MethodsCalled = new();
  public BatchGet<T> CreateBatchGet<T>(DynamoDBOperationConfig operationConfig = null)
  {
    throw new NotImplementedException();
  }

  public BatchWrite<T> CreateBatchWrite<T>(DynamoDBOperationConfig operationConfig = null)
  {
    throw new NotImplementedException();
  }

  public BatchWrite<object> CreateBatchWrite(Type valuesType, DynamoDBOperationConfig operationConfig = null)
  {
    throw new NotImplementedException();
  }

  public MultiTableBatchGet CreateMultiTableBatchGet(params BatchGet[] batches)
  {
    throw new NotImplementedException();
  }

  public MultiTableBatchWrite CreateMultiTableBatchWrite(params BatchWrite[] batches)
  {
    throw new NotImplementedException();
  }

  public MultiTableTransactGet CreateMultiTableTransactGet(params TransactGet[] transactionParts)
  {
    throw new NotImplementedException();
  }

  public MultiTableTransactWrite CreateMultiTableTransactWrite(params TransactWrite[] transactionParts)
  {
    throw new NotImplementedException();
  }

  public TransactGet<T> CreateTransactGet<T>(DynamoDBOperationConfig operationConfig = null)
  {
    throw new NotImplementedException();
  }

  public TransactWrite<T> CreateTransactWrite<T>(DynamoDBOperationConfig operationConfig = null)
  {
    throw new NotImplementedException();
  }

  public Task DeleteAsync<T>(T value, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task DeleteAsync<T>(T value, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task DeleteAsync<T>(object hashKey, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task DeleteAsync<T>(object hashKey, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task DeleteAsync<T>(object hashKey, object rangeKey, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task DeleteAsync<T>(object hashKey, object rangeKey, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public void Dispose()
  {
    throw new NotImplementedException();
  }

  public Task ExecuteBatchGetAsync(BatchGet[] batches, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task ExecuteBatchWriteAsync(BatchWrite[] batches, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task ExecuteTransactGetAsync(TransactGet[] transactionParts, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task ExecuteTransactWriteAsync(TransactWrite[] transactionParts, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public T FromDocument<T>(Document document)
  {
    throw new NotImplementedException();
  }

  public T FromDocument<T>(Document document, DynamoDBOperationConfig operationConfig)
  {
    throw new NotImplementedException();
  }

  public IEnumerable<T> FromDocuments<T>(IEnumerable<Document> documents)
  {
    throw new NotImplementedException();
  }

  public IEnumerable<T> FromDocuments<T>(IEnumerable<Document> documents, DynamoDBOperationConfig operationConfig)
  {
    throw new NotImplementedException();
  }

  public AsyncSearch<T> FromQueryAsync<T>(QueryOperationConfig queryConfig, DynamoDBOperationConfig operationConfig = null)
  {
    throw new NotImplementedException();
  }

  public AsyncSearch<T> FromScanAsync<T>(ScanOperationConfig scanConfig, DynamoDBOperationConfig operationConfig = null)
  {
    throw new NotImplementedException();
  }

  public Table GetTargetTable<T>(DynamoDBOperationConfig operationConfig = null)
  {
    throw new NotImplementedException();
  }

  public Task<T> LoadAsync<T>(object hashKey, CancellationToken cancellationToken = default)
  {
    if (LoadAsync_UserEntity_Result is null)
    {
      throw new ArgumentNullException();
    }
    if (typeof(T) != typeof(UserEntity))
    {
      throw new ArgumentException();
    }

    UserEntity? user = LoadAsync_UserEntity_Result.Result;
    if (user is null)
    {
      return Task.FromResult((T)(object)null);
    }
    user.Id = hashKey.ToString() ?? "";
    return Task.FromResult((T)(object)user);
  }

  public Task<T> LoadAsync<T>(object hashKey, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task<T> LoadAsync<T>(object hashKey, object rangeKey, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task<T> LoadAsync<T>(object hashKey, object rangeKey, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task<T> LoadAsync<T>(T keyObject, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task<T> LoadAsync<T>(T keyObject, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public AsyncSearch<T> QueryAsync<T>(object hashKeyValue, DynamoDBOperationConfig operationConfig = null)
  {
    if (QueryAsync_UserEntity_Result is null)
    {
      throw new ArgumentNullException();
    }
    if (typeof(T) != typeof(UserEntity))
    {
      throw new ArgumentException();
    }
    return (AsyncSearch<T>)(object)QueryAsync_UserEntity_Result;
  }

  public AsyncSearch<T> QueryAsync<T>(object hashKeyValue, QueryOperator op, IEnumerable<object> values, DynamoDBOperationConfig operationConfig = null)
  {
    if (QueryAsync_UserEntity_Result is null)
    {
      throw new ArgumentNullException();
    }
    if (typeof(T) != typeof(UserEntity))
    {
      throw new ArgumentException();
    }
    return (AsyncSearch<T>)(object)QueryAsync_UserEntity_Result;
  }

  public void RegisterTableDefinition(Table table)
  {
    throw new NotImplementedException();
  }

  public Task SaveAsync<T>(T value, CancellationToken cancellationToken = default)
  {
    MethodsCalled.Add(("SaveAsync", new[]{JsonConvert.SerializeObject(value)}));
    return Task.CompletedTask;
  }

  public Task SaveAsync<T>(T value, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task SaveAsync(Type valueType, object value, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task SaveAsync(Type valueType, object value, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public AsyncSearch<T> ScanAsync<T>(IEnumerable<ScanCondition> conditions, DynamoDBOperationConfig operationConfig = null)
  {
    throw new NotImplementedException();
  }

  public Document ToDocument<T>(T value)
  {
    throw new NotImplementedException();
  }

  public Document ToDocument<T>(T value, DynamoDBOperationConfig operationConfig)
  {
    throw new NotImplementedException();
  }
}