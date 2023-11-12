namespace BircheGamesApi.Validation;

public interface IUserValidatorFactory
{
  public IUserValidator Create();
}