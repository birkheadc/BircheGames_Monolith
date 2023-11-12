# Birche Games API

This is the repository for the API used by Birche Games. It's main purpose at the moment is to facilitate user registration and management, while also providing authentication services to be consumed by other applications in the future that those users might interact with.

## Deployment

Deployment is done on AWS Lambda.
  - Configure AWS with the necessary sub-services:
    - DynamoDB
    - API Gateway
  - Move to the BircheGamesApi subdirectory
  - Execute `dotnet lambda deploy-function`