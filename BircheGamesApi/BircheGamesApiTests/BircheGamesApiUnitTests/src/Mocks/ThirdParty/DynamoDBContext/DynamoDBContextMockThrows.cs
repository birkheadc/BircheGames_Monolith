using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;

namespace BircheGamesApiUnitTests.Mocks.ThirdParty;

#pragma warning disable CS8625, CS8619, CS8600

public class DynamoDBContextMockThrows : DynamoDBContextMock, IDynamoDBContext
{
  public new BatchGet<T> CreateBatchGet<T>(DynamoDBOperationConfig operationConfig = null)
  {
    throw new NotImplementedException();
  }

  public new BatchWrite<T> CreateBatchWrite<T>(DynamoDBOperationConfig operationConfig = null)
  {
    throw new NotImplementedException();
  }

  public new BatchWrite<object> CreateBatchWrite(Type valuesType, DynamoDBOperationConfig operationConfig = null)
  {
    throw new NotImplementedException();
  }

  public new MultiTableBatchGet CreateMultiTableBatchGet(params BatchGet[] batches)
  {
    throw new NotImplementedException();
  }

  public new MultiTableBatchWrite CreateMultiTableBatchWrite(params BatchWrite[] batches)
  {
    throw new NotImplementedException();
  }

  public new MultiTableTransactGet CreateMultiTableTransactGet(params TransactGet[] transactionParts)
  {
    throw new NotImplementedException();
  }

  public new MultiTableTransactWrite CreateMultiTableTransactWrite(params TransactWrite[] transactionParts)
  {
    throw new NotImplementedException();
  }

  public new TransactGet<T> CreateTransactGet<T>(DynamoDBOperationConfig operationConfig = null)
  {
    throw new NotImplementedException();
  }

  public new TransactWrite<T> CreateTransactWrite<T>(DynamoDBOperationConfig operationConfig = null)
  {
    throw new NotImplementedException();
  }

  public new Task DeleteAsync<T>(T value, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public new Task DeleteAsync<T>(T value, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public new Task DeleteAsync<T>(object hashKey, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public new Task DeleteAsync<T>(object hashKey, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public new Task DeleteAsync<T>(object hashKey, object rangeKey, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public new Task DeleteAsync<T>(object hashKey, object rangeKey, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public new void Dispose()
  {
    throw new NotImplementedException();
  }

  public new Task ExecuteBatchGetAsync(BatchGet[] batches, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public new Task ExecuteBatchWriteAsync(BatchWrite[] batches, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public new Task ExecuteTransactGetAsync(TransactGet[] transactionParts, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public new Task ExecuteTransactWriteAsync(TransactWrite[] transactionParts, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public new T FromDocument<T>(Document document)
  {
    throw new NotImplementedException();
  }

  public new T FromDocument<T>(Document document, DynamoDBOperationConfig operationConfig)
  {
    throw new NotImplementedException();
  }

  public new IEnumerable<T> FromDocuments<T>(IEnumerable<Document> documents)
  {
    throw new NotImplementedException();
  }

  public new IEnumerable<T> FromDocuments<T>(IEnumerable<Document> documents, DynamoDBOperationConfig operationConfig)
  {
    throw new NotImplementedException();
  }

  public new AsyncSearch<T> FromQueryAsync<T>(QueryOperationConfig queryConfig, DynamoDBOperationConfig operationConfig = null)
  {
    throw new NotImplementedException();
  }

  public new AsyncSearch<T> FromScanAsync<T>(ScanOperationConfig scanConfig, DynamoDBOperationConfig operationConfig = null)
  {
    throw new NotImplementedException();
  }

  public new Table GetTargetTable<T>(DynamoDBOperationConfig operationConfig = null)
  {
    throw new NotImplementedException();
  }

  public new Task<T> LoadAsync<T>(object hashKey, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public new Task<T> LoadAsync<T>(object hashKey, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public new Task<T> LoadAsync<T>(object hashKey, object rangeKey, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public new Task<T> LoadAsync<T>(object hashKey, object rangeKey, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public new Task<T> LoadAsync<T>(T keyObject, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public new Task<T> LoadAsync<T>(T keyObject, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public new AsyncSearch<T> QueryAsync<T>(object hashKeyValue, DynamoDBOperationConfig operationConfig = null)
  {
    throw new NotImplementedException();
  }

  public new AsyncSearch<T> QueryAsync<T>(object hashKeyValue, QueryOperator op, IEnumerable<object> values, DynamoDBOperationConfig operationConfig = null)
  {
    throw new NotImplementedException();
  }

  public new void RegisterTableDefinition(Table table)
  {
    throw new NotImplementedException();
  }

  public new Task SaveAsync<T>(T value, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public new Task SaveAsync<T>(T value, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public new Task SaveAsync(Type valueType, object value, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public new Task SaveAsync(Type valueType, object value, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public new AsyncSearch<T> ScanAsync<T>(IEnumerable<ScanCondition> conditions, DynamoDBOperationConfig operationConfig = null)
  {
    throw new NotImplementedException();
  }

  public new Document ToDocument<T>(T value)
  {
    throw new NotImplementedException();
  }

  public new Document ToDocument<T>(T value, DynamoDBOperationConfig operationConfig)
  {
    throw new NotImplementedException();
  }
}