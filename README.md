# WebAPI - Create a web API RESTful with ASP.NET Core

Create an **API RESTful** with ASP.NET Core that supports create, read, update, delete **(CRUD) operations** based on the Microsoft Learn module [Create a web API with ASP.NET Core controllers](https://learn.microsoft.com/en-us/training/modules/build-web-api-aspnet-core/).

Learning objectives:
- Create a web **API project with layers**: ASP.NET Core controllers, Services...
- Create an in-memory database for persisting products.
- Add support for **CRUD** operations in a **RESTful** way.
- Test web API action methods from the command shell, Postman, Hoppscotch...

You must implement **best practices RESTful web API design** according to [this page](https://learn.microsoft.com/en-us/azure/architecture/best-practices/api-design).

## Hoppscotch: Web API Testing
**GET all action**
![image](https://github.com/paulamateo/ContosoPizza/assets/118843344/4fd5fbc8-59b6-4b8c-99fa-f5cbb02ca2dc)

**GET by Id action**
![image](https://github.com/paulamateo/ContosoPizza/assets/118843344/4bc3e577-68e0-40b5-b666-696c5293dc15)

**POST action**
![image](https://github.com/paulamateo/ContosoPizza/assets/118843344/886bdb5a-ea25-4bba-bdc3-4fb03f0b75be)

**PUT action**
![image](https://github.com/paulamateo/ContosoPizza/assets/118843344/391facd3-222a-490a-a307-1fbe5b4f7fd1)

**DELETE action**
![image](https://github.com/paulamateo/ContosoPizza/assets/118843344/98178754-1f90-423d-afba-0d4844ea3528)

## Commands
Create the API:

      dotnet new webapi -n ContosoPizza.API -o API -f net6.0

Create MODELS, DATA and SERVICES layers:

      dotnet new classlib -n ContosoPizza.Models -o Models -f net6.0
      dotnet new classlib -n ContosoPizza.Data -o Data -f net6.0
      dotnet new classlib -n ContosoPizza.Services -o Services -f net6.0

Referencing layers on each other:

      dotnet add Data/ContosoPizza.Data.csproj reference Models/ContosoPizza.Models.csproj
      dotnet add Services/ContosoPizza.Services.csproj reference Models/ContosoPizza.Models.csproj

Create the .sln file:

      dotnet new sln -n ContosoPizza

Referencing the layers in the `ContosoPizza.sln` file:

      dotnet sln add Models/ContosoPizza.Models.csproj
      dotnet sln add Data/ContosoPizza.Data.csproj
      dotnet sln add Services/ContosoPizza.Services.csproj

Compilation of the .NET project:

      dotnet build

Compilation and execution of the .NET project:

      dotnet run

Restore project dependencies:

      dotnet restore

Delete files created during compilation:

      dotnet clean
