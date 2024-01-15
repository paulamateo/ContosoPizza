# WebAPI - Create a web API RESTful with ASP.NET Core

Create an **API RESTful** with ASP.NET Core that supports create, read, update, delete **(CRUD) operations** based on the Microsoft Learn module [Create a web API with ASP.NET Core controllers](https://learn.microsoft.com/en-us/training/modules/build-web-api-aspnet-core/).

Learning objectives:
- Create a web **API project with layers**: ASP.NET Core controllers, Services...
- Create an in-memory database for persisting products.
- Add support for **CRUD** operations in a **RESTful** way.
- Test web API action methods from the command shell, Postman, Hoppscotch...

You must implement **best practices RESTful web API design** according to [this page](https://learn.microsoft.com/en-us/azure/architecture/best-practices/api-design).

## Layered architecture: Commands
Create the API:

      dotnet new webapi -n ContosoPizza.API -o API -f net6.0

Create the MODELS and SERVICES layers:

      dotnet new classlib -n ContosoPizza.Models -o Models -f net6.0
      dotnet new classlib -n ContosoPizza.Services -o Services -f net6.0

Referencing layers on each other:

      dotnet add Services/ContosoPizza.Services.csproj reference Models/ContosoPizza.Models.csproj

Create the .sln file:

      dotnet new sln -n ContosoPizza

Referencing the layers in the `ContosoPizza.sln` file:

      dotnet sln add Models/ContosoPizza.Models.csproj
      dotnet sln add Services/ContosoPizza.Services.csproj

Compilation of the .NET project:

      dotnet build

Compilation and execution of the .NET project:

      dotnet run