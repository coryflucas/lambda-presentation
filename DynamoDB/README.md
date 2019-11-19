AspNet Core API with AWS Lambda

## Steps to create project:
Install lambda templates and tools:
```
dotnet new -i Amazon.Lambda.Templates
dotnet tool install -g Amazon.Lambda.Tools
```

```
dotnet new serverless.AspNetCore30WebAPI
dotnet new gitignore
dotnet new sln
dotnet sln add */*/*.csproj
cd src/DynamoDB
rm Controllers/WeatherForecastController.cs WeatherForecast.cs
dotnet add package AWSSDK.DynamoDBv2
```

In the `ConfigureServices` method in `src/DynamoDB/Startup.cs` add:
```
services.AddSingleton<IAmazonDynamoDB>(new AmazonDynamoDBClient());
```

Add the `ShortUrlContoller`

Add the `DynamoDBTable` resource to the `serverless.tempate`

## To Run Local:
```
cd src/AspNetCore
dotnet run
```

## Steps to publish:
Edit `src/AspNetCore/aws-lambda-tools-defaults.json`:
- Change `s3-bucket` to the name of a bucket on your account
- Change `stack-name` to `demo` or something not in use on your account

```
cd src/DynamoDB
dotnet lambda deploy-serverless
```

## Example Requests:

```
BASE_URL=...
curl -v -k ${BASE_URL}/url -H "content-type: application/json" --data '{"url": "https://example.com"}'
```
