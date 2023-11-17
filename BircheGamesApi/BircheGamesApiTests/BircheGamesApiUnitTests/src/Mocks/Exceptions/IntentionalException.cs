using System;

namespace BircheGamesApiUnitTests.Mocks.Exceptions;

[Serializable]
public class IntentionalException : Exception
{
  public IntentionalException() : base("This exception was thrown intentionally.") { }
  public IntentionalException(string message) : base(message) { }
  public IntentionalException(string message, Exception inner) : base(message, inner) { }
}