# WebAPI - Create a web API RESTful with ASP.NET Core

Create an **API RESTful** with ASP.NET Core that supports create, read, update, delete **(CRUD) operations** based on the Microsoft Learn module [Create a web API with ASP.NET Core controllers](https://learn.microsoft.com/en-us/training/modules/build-web-api-aspnet-core/).

Learning objectives:
- Create a web **API project with layers**: ASP.NET Core controllers, Services...
- Create an in-memory database for persisting products.
- Add support for **CRUD** operations in a **RESTful** way.
- Test web API action methods from the command shell, Postman, Hoppscotch...

You must implement **best practices RESTful web API design** according to [this page](https://learn.microsoft.com/en-us/azure/architecture/best-practices/api-design).

### Tete Pizza
Now, you need to add (at least) the following entities:
- Ingredients → A pizza has a list of ingredients.
- Orders → An order consists of one or more pizzas, price, user (_tetes_)...
- User → A _tete_ places an order and it contains its full name, address...

Containerize API (internal port 80).


## Uso del programa
### Users
| POST  | DELETE | UPDATE | GET ALL | GET BY ID
| ------------- | ------------- | ------------- | ------------- | ------------- |
| `/Users` | `/Users/{uId}` | `/Users/{uId}` | `/Users` | `/Users/{uId}` | 

**1º Crear un usuario**. Se le asignará un ID automáticamente.

      {
            "Name": ,
            "Lastname": ,
            "Address": ,
            "Email": ,
            "PhoneNumber": ,
            "Orders": []
      }

### Orders
| POST  | DELETE | UPDATE | GET ALL | GET BY ID
| ------------- | ------------- | ------------- | ------------- | ------------- |
| `/Orders` | `/Orders/{oId}` |  | `/Orders` | `/Orders/{oId}` | 

**2º Crear un pedido**. Se le asignará un ID automáticamente. Necesitamos obligatoriamente poner el ID del usuario al que va a pertenecer el pedido (gracias a esto, los campos 'UserName' y 'UserAddress' se rellenarán automáticamente).

      {
            "UserId":
      }

### Pizzas
| POST | DELETE | UPDATE | GET ALL | GET BY ID
| ------------- | ------------- | ------------- | ------------- | ------------- |
| `/Orders/{oId}/Pizzas` | `/Pizzas/{pId}` | `/Pizzas/{pId}` | `/Pizzas` | `/Pizzas/{pId}`

**3º Crear una pizza**. Se le asignará un ID automáticamente. El precio empezará en 5€, y se irá incrementando conforme se añadan ingredientes.

      {
            "Name": ,
            "IsGlutenFree": ,
            "Ingredients": []
      }

### Ingredients
| POST | DELETE | UPDATE | GET ALL | GET BY ID
| ------------- | ------------- | ------------- | ------------- | ------------- |
| `/Pizzas/{pId}/Ing.` | `/Pizzas/{pId}/Ing./{iId}` | `/Pizzas/{pId}/Ing./{iId}` | `/Pizzas/{pId}/Ing.` | `/Pizzas/{pId}/Ing./{iId}`

**4º Crear un ingrediente.** Se le asignará un ID automáticamente.

      {
            "Name": ,
            "Price": ,
            "Calories": ,
            "Carbohydrates": ,
            "Proteins": ,
            "Fats": ,
            "Fiber": 
      }











## Commands
Create MODELS, DATA, BUSINESS and API layers:

      dotnet new classlib -n ContosoPizza.Models -o Models -f net6.0
      dotnet new classlib -n ContosoPizza.Data -o Data -f net6.0
      dotnet new classlib -n ContosoPizza.Business -o Business -f net6.0
      dotnet new classlib -n ContosoPizza.API -o API -f net6.0
      
Create the .sln file:

      dotnet new sln -n ContosoPizza

Referencing the layers in the `ContosoPizza.sln` file:

      dotnet sln add Models/ContosoPizza.Models.csproj
      dotnet sln add Data/ContosoPizza.Data.csproj
      dotnet sln add Business/ContosoPizza.Business.csproj
      dotnet sln add API/ContosoPizza.API.csproj

Referencing layers on each other:

      dotnet add Data/ContosoPizza.Data.csproj reference Models/ContosoPizza.Models.csproj
      dotnet add Business/ContosoPizza.Business.csproj reference Models/ContosoPizza.Models.csproj
      dotnet add API/ContosoPizza.API.csproj reference Business/ContosoPizza.Business.csproj
      dotnet add API/ContosoPizza.API.csproj reference Data/ContosoPizza.Data.csproj
      dotnet add API/ContosoPizza.API.csproj reference Models/ContosoPizza.Models.csproj

Compilation of the .NET project:

      dotnet build

Compilation and execution of the .NET project:

      dotnet run

Restore project dependencies:

      dotnet restore

Delete files created during compilation:

      dotnet clean
