# Overall


https://www.youtube.com/watch?v=fhM0V2N1GpY&list=PLzYkqgWkHPKBcDIP5gzLfASkQyTdy0t4k&index=1&t=0s

https://www.youtube.com/watch?v=tLk4pZZtiDY

https://www.youtube.com/watch?v=fO2T5tRu3DE

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

## Create the Domain (layer) project and add it to the solution

```bash
dotnet new classlib -o ./src/cleanDDD.Domain
dotnet sln add ./src/cleanDDD.Domain/cleanDDD.Domain.csproj 
```

## Create the Domain Unit Tests project and add it to the solution

```bash
dotnet new xunit -o ./tests/cleanDDD.DomainUnitTests
dotnet sln add ./tests/cleanDDD.DomainUnitTests/cleanDDD.DomainUnitTests.csproj
dotnet add ./tests/cleanDDD.DomainUnitTests/ reference ./src/cleanDDD.Domain/
```

Add a feature folder inside to match the feature / Aggregate Customers

```bash
mkdir ./tests/cleanDDD.DomainUnitTests/Customers
touch ./tests/cleanDDD.DomainUnitTests/Customers/CustomerTests.cs
```

## Create the Application (layer) project and add it to the solution, make it depend on the Domain layer (but Domain layer cannot depend on another layer)

```bash
dotnet new classlib -o ./src/cleanDDD.Application
dotnet sln add ./src/cleanDDD.Application/cleanDDD.Application.csproj 
dotnet add ./src/cleanDDD.Application/ reference ./src/cleanDDD.Domain/
```

### Add MediatR and FluentValidation to the Application layer

```bash
cd src/cleanDDD.Application/
dotnet add package MediatR
dotnet add package FluentValidation.DependencyInjectionExtensions
```

## Create the Infrastructure (layer) project and add it to the solution, make it depend on the Application layer and Domain layer

```bash
dotnet new classlib -o ./src/cleanDDD.Infrastructure
dotnet sln add ./src/cleanDDD.Infrastructure/cleanDDD.Infrastructure.csproj 
dotnet add ./src/cleanDDD.Infrastructure/ package Microsoft.Extensions.DependencyInjection.Abstractions
dotnet add ./src/cleanDDD.Infrastructure/ reference ./src/cleanDDD.Application/ ./src/cleanDDD.Domain/
```

## Create the Presentation (layer) project and add it to the solution, make it depend on the Application layer and Domain layer

```bash
dotnet new classlib -o ./src/cleanDDD.Presentation
dotnet sln add ./src/cleanDDD.Presentation/cleanDDD.Presentation.csproj
dotnet add ./src/cleanDDD.Presentation/ package Microsoft.Extensions.DependencyInjection.Abstractions
dotnet add ./src/cleanDDD.Presentation/ reference ./src/cleanDDD.Application/ ./src/cleanDDD.Domain/
```

## Create the WebAPI project and add it the to the solution

```bash
dotnet new webapi -o ./src/cleanDDD.WebApi
dotnet sln add ./src/cleanDDD.WebApi/cleanDDD.WebApi.csproj
dotnet add ./src/cleanDDD.WebApi/ reference ./src/cleanDDD.Presentation/ ./src/cleanDDD.Application/ ./src/cleanDDD.Infrastructure/
```

# Create a Domain model

We convert a domain model to classes to represent the entities.

We'll use tactical patterns to design our initial model and then impose some constraints:
* Aggregate (Orders, Products, Customers)
* Entity
* Value

Orders
* Order
* LineItem

Products
* Product
* Category

Customers
* Customer

We create a feature folder for each of our Aggregates to encapsulation our Entities and Values and other behaviours from our Domain model, in our Domain layer project. By organising our domain model around features / Aggregates we're going to have a much more cohesive domain model where everything that is tightly coupled is sitting together inside of the same folder.

We create an Entity to represent our Customer and provide it with a few attributes that can identify it as a Customer.