using System.Text.Json;
using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

namespace BircheGamesApi.Config;

public static class AmazonSecretsRetriever
{
  public static string GetAuthenticationSecret()
  {
    return GetSecrets().AuthenticationSecretKey;
  }
  public static string GetEmailVerificationSecret()
  {
    return GetSecrets().EmailVerificationSecretKey;
  }

  public static AmazonSecrets GetSecrets()
  {
    return GetSecrets("ap-southeast-2", "BircheGames/Authentication/SecurityTokenConfig/SecretKey");
  }
  public static AmazonSecrets GetSecrets(string region, string secretName)
  {
    IAmazonSecretsManager client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(region));
    GetSecretValueRequest request = new()
    {
      SecretId = secretName,
      VersionStage = "AWSCURRENT"
    };

    AmazonSecrets secrets = new();

    try
    {
      GetSecretValueResponse response = client.GetSecretValueAsync(request).Result;
      if (response.SecretString is not null)
      {
        secrets = JsonSerializer.Deserialize<AmazonSecrets>(response.SecretString) ?? secrets;
      }
      return secrets;
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Encountered exception while attempting to retrieve amazon secret: {ex.Message}");
      return secrets;
    }
  }
}