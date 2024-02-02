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


## CRUD operations
### Pizzas
| CRUD operation  | HTTP action verb | ASP.NET Core attribute + route (controller) | Description
| ------------- | ------------- | ------------- | ------------- |
| Read | `GET` | `[HttpGet("/Pizzas")]` | Get all pizzas
| Read | `GET` | `[HttpGet("/Pizzas/{id}")]` | Get pizza by id
| Create | `POST` | `[HttpPost("/Pizzas")]` | Create pizza
| Delete | `DELETE` | `[HttpDelete("/Pizzas/{id}")]` | Delete pizza
| Update | `PUT` | `[HttpPut("/Pizzas/{id}")]` | Update pizza

### Ingredients
| CRUD operation  | HTTP action verb | ASP.NET Core attribute + route (controller) | Description
| ------------- | ------------- | ------------- | ------------- |
| Read | `GET` | `[HttpGet("/Pizzas/{pizzaId}/Ingredients")]` | Get all ingredients for a pizza
| Read | `GET` | `[HttpGet("/Pizzas/{pizzaId}/Ingredients/{ingredientId}")]` | Get ingredient by id
| Create | `POST` | `[HttpPost("/Pizzas/{pizzaId}/Ingredients")]` | Create ingredient
| Delete | `DELETE` | `[HttpDelete("/Pizzas/{pizzaId}/Ingredients/{ingredientId}")]` | Delete ingredient


| Delete | `DELETE` | `[HttpDelete("/Ingredients/{id}")] ` | Delete ingredient
| Update | `PUT` | `[HttpPut("/Ingredients/{id}")] ` | Update ingredient
| Read | `GET` | `[HttpGet("/Ingredients")]` | Get all ingredients
| Read | `GET` | `[HttpGet("/Ingredients/{id}")]` | Get ingredient by id

### Users
| CRUD operation  | HTTP action verb | ASP.NET Core attribute + route (controller) | Description
| ------------- | ------------- | ------------- | ------------- |
| Create | `POST` | `[HttpPost("/Users")]` | Create user |
| Delete | `DELETE` | `[HttpDelete("/Users/{id}")]` | Delete user |
| Update | `PUT` | `[HttpPut("/Users/{id}")]` | Update user |
| Read | `GET` | `[HttpGet("/Users")]` | Get all users |
| Read | `GET` | `[HttpGet("/Users/{id}")]` | Get users by id |

### Orders
| CRUD operation  | HTTP action verb | ASP.NET Core attribute + route (controller) | Description
| ------------- | ------------- | ------------- | ------------- |
| Create | `POST` | `[HttpPost("/Users/{userId}/Orders")]` | Create order
| Delete | `DELETE` | `HttpGet("/Orders/{orderId}")]` | Delete order
| Update | `PUT` | `[HttpPut("/Orders/{id}")]` | Update order
| Read | `GET` | `[HttpGet("/Orders")]` | Get all orders
| Read | `GET` | `[HttpGet("/Orders/{orderId}")]` | Get order by id
| Read | `GET` | `[HttpGet("/Users/{userId}/Orders")]` | Get all orders by the user






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
