Hello World AWS Lambda with .NET Core

## Steps to create project:
```
dotnet new classlib
dotnet add package Amazon.Lambda.Core
dotnet add package Amazon.Lambda.Serialization.Json
rm Class1.cs
```

Edit `HelloWorld.csproj`:
- Change `TargetFramework` to `netcoreapp2.1`
- Add `<GenerateRuntimeConfigurationFiles>true</GenerateRuntimeConfigurationFiles>`

## Steps to package project:
```
dotnet publish -c Release -o out
cd out
zip ../HelloWorld.zip *
```

## Steps to publish:
From Lambda page in console:
- Create Function
- Author from scratch
  - Function Name: HelloWorld
  - Runtime: .NET Core 2.1
- From function screen:
  - Upload: select zip from package step
  - Handler: `HelloWorld::HelloWorld.Function::FunctionHandler`
  - Click "Save"
  - Click "Test"
    - Event Name: HelloWorld
    - Input `"world"`
    - Click "Create"
  - Click "Test"



