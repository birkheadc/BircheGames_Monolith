using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.SimpleEmail.Model;
using BircheGamesApi;
using BircheGamesApi.Services;
using BircheGamesApiUnitTests.Mocks.Exceptions;
using Newtonsoft.Json;

namespace BircheGamesApiUnitTests.Mocks.Services;

public class EmailServiceMock : BasicMock, IEmailService
{
  public Task<Result> SendEmail(string from, IEnumerable<string> to, Message message)
  {
    MethodCalls.Add(new(){ MethodName = "SendEmail", Arguments = new[]{"from", JsonConvert.SerializeObject(to), JsonConvert.SerializeObject(message)} } );
    
    MethodResponse response = GetMethodResponse("SendEmail");

    switch (response)
    {
      case MethodResponse.THROW:
        throw new IntentionalException();

      case MethodResponse.FAILURE:
        return Task.FromResult(new ResultBuilder()
          .Fail()
          .Build());
      
      case MethodResponse.SUCCESS:
        return Task.FromResult(new ResultBuilder()
          .Succeed()
          .Build());

      default:
        throw new NotImplementedException();
    }
  }
}