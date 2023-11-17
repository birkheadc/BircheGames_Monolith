using System;

namespace BircheGamesApiUnitTests.Mocks.Exceptions;

public class IntentionalException : Exception
{
  public new string Message = "This Exception was thrown intentionally.";
}