# Overall


https://www.youtube.com/watch?v=fhM0V2N1GpY&list=PLzYkqgWkHPKBcDIP5gzLfASkQyTdy0t4k&index=1&t=0s

https://www.youtube.com/watch?v=tLk4pZZtiDY

# Some commands

## Build / Run / Test the solution

```bash
dotnet build
dotnet run
dotnet test
```

## Add a nuget package to a project

```bash
dotnet add ./Naomi.Application/ package  Microsoft.Extensions.DependencyInjection.Abstractions
dotnet add ./Naomi.Infrastructure/ package  Microsoft.Extensions.DependencyInjection.Abstractions
dotnet add ./Naomi.Api/ package  Microsoft.Extensions.DependencyInjection.Abstractions
dotnet add package Microsoft.Extensions.DependencyInjection
```

## Run a project

```bash
dotnet run --project ./Naomi.Api/
```

## Add a project reference

```bash
dotnet add ./Naomi.Api/ reference ./Naomi.Infrastructure/
```

## Add a webapi project

```bash
dotnet new webapi -o Naomi.Api
```

## Add a library project

```bash
dotnet new classlib -o Naomi.Contracts
```

## Add a project to a solution

```bash
dotnet sln add `ls -r **/*.csproj`
```

# Setup the clean architecture solution

The Clean Architecture is:
* Presentation
* Application (this is where the use cases live)
* Domain (this is where the business entities and business logic live)


```bash
mkdir src
cd src
```

## Create the Domain project and add it to the solution

```bash
dotnet new classlib -o cleanDDD.Domain
dotnet sln add ./src/cleanDDD.Domain/cleanDDD.Domain.csproj 
```

## Create the Application project and add it to the solution, make it depend on the Domain layer (but Domain layer cannot depend on another layer)

```bash
dotnet new classlib -o cleanDDD.Application
dotnet sln add ./src/cleanDDD.Application/cleanDDD.Application.csproj 
dotnet add ./src/cleanDDD.Application/ reference ./src/cleanDDD.Domain/
```

### Add MediatR and FluentValidation to the Application layer

```bash
cd src/cleanDDD.Application/
dotnet add package MediatR
dotnet add package FluentValidation.DependencyInjectionExtensions
```

