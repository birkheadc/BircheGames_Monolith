using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;

namespace BircheGamesApiUnitTests.Mocks.ThirdParty;

public class AsyncSearchMock<T> : AsyncSearch<T>
{
  private readonly List<T> _values;
  public AsyncSearchMock(List<T> values)
  {
    _values = values;
  }

  public override Task<List<T>> GetRemainingAsync(CancellationToken cancellationToken = default(CancellationToken))
  {
    return Task.FromResult(_values);
  }
}