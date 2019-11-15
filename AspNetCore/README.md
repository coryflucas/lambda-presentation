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
```

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
cd src/AspNetCore
dotnet lambda deploy-serverless
```


