using System;

namespace BircheGamesApiUnitTests.Mocks.Exceptions;

[Serializable]
public class MethodResponseNotSetException : Exception
{
  public MethodResponseNotSetException() : base("This method was not mocked!") { }
  public MethodResponseNotSetException(string methodName) : base($"This method was not mocked: {methodName}") { }
  public MethodResponseNotSetException(string methodName, Exception inner) : base($"This method was not mocked: {methodName}", inner) { }
}