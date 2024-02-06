using ContosoPizza.Models;
using ContosoPizza.Business;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase {
    private readonly IPizzaService _pizzaService;
    private readonly IUserService _userService;

    public PizzaController(IPizzaService pizzaService, IUserService userService) {
        _pizzaService = pizzaService;
        _userService = userService;
    }


    //USERS
    [HttpGet("/Users")]
    public ActionResult<List<User>> GetAllUsers() => _userService.GetAllUsers();

    [HttpGet("/Users/{id}")]
    public ActionResult<User> GetUserbyId(int id) {
        var user = _userService.GetUserById(id);

        if (user == null)
            return NotFound();

        return user;
    }

    [HttpPost("/Users")]
    public IActionResult AddUser(User user) {
        try {
            _userService.AddUser(user);
            return Ok("User created");
        }catch (Exception e) {
            return BadRequest($"Error: {e.Message}");
        }
    }

    [HttpDelete("/Users/{id}")]
    public IActionResult DeleteUser(int id) {
        var user = _userService.GetUserById(id);

        if (user is null)
            return NotFound();
            
        _userService.DeleteUser(id);

        return Ok("User deleted");
    }

    [HttpPut("/Users/{id}")]
    public IActionResult UpdateUser(int id, User user) {
        if (id != user.Id)
            return BadRequest();

        var existingUser = _userService.GetUserById(id);
        if (existingUser is null)
            return NotFound();

        _userService.UpdateUser(user);

        return Ok("User updated");
    }


    //ORDERS
    [HttpGet("/Orders")]
    public ActionResult<List<Order>> GetAllOrders() => _userService.GetAllOrders();

    [HttpGet("/Orders/{id}")]
    public ActionResult<Order> GetOrderById(int id) {
        var order = _userService.GetOrderById(id);

        if (order == null)
            return NotFound();

        return order;
    }

    [HttpPost("/Orders")]
    public IActionResult AddOrder(Order order) {
        try {
            var user = _userService.GetUserById(order.UserId);
            _userService.AddOrder(order.UserId, order);
            return Ok("Order created");
        }catch (Exception e) {
            return BadRequest($"Error: {e.Message}");
        }
    }

    [HttpDelete("/Orders/{id}")]
    public IActionResult DeleteOrder(int id) {
        try {
            _userService.DeleteOrder(id);
            return Ok("Order deleted");
        } catch (Exception e) {
            return BadRequest($"Error: {e.Message}");
        }
    }


    //PIZZAS
    [HttpGet("/Pizzas")]
    public ActionResult<List<Pizza>> GetAllPizzas() => _pizzaService.GetAllPizzas();
        
    [HttpGet("/Pizzas/{id}")]
    public ActionResult<Pizza> GetPizzabyId(int id) {
        var pizza = _pizzaService.GetPizzaById(id);

        if (pizza == null)
            return NotFound();

        return pizza;
    }

    [HttpPost("/Orders/{id}/Pizzas")]
    public ActionResult AddPizza(int id, Pizza pizza) {
        try {
            _pizzaService.AddPizza(id, pizza);
            return Ok("Pizza created");
        }catch (InvalidOperationException ex) {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("/Pizzas/{id}")]
    public IActionResult DeletePizza(int id) {    
        var pizza = _pizzaService.GetPizzaById(id);

        if (pizza is null) 
            return NotFound();

        _pizzaService.DeletePizza(id);

        return Ok("Pizza deleted");
    }

    [HttpPut("/Pizzas/{id}")]
    public IActionResult UpdatePizza(int id, Pizza pizza) {
        if (id != pizza.Id)
            return BadRequest();

        var existingPizza = _pizzaService.GetPizzaById(id);
        if (existingPizza is null)
            return NotFound();

        _pizzaService.UpdatePizza(pizza);

        return Ok("Pizza updated");
    }


    //INGREDIENTS
    [HttpGet("/Pizzas/{id}/Ingredients")]
    public ActionResult<List<Ingredient>> GetAllIngredients(int id) => _pizzaService.GetAllIngredients(id);

    [HttpGet("/Pizzas/{id}/Ingredients/{ingredientId}")]
    public ActionResult<Ingredient> GetIngredientById(int id, int ingredientId) {
        var ingredient = _pizzaService.GetIngredientById(id, ingredientId);

        if (ingredient == null) 
            return NotFound();
        
        return ingredient;
    }

    [HttpPost("/Pizzas/{id}/Ingredients")]
    public IActionResult AddIngredient(int id, Ingredient ingredient) {
        try {
            _pizzaService.AddIngredient(id, ingredient);
            return Ok("Ingredient added");
        }catch (Exception e) {
            return BadRequest($"Error: {e.Message}");
        }
    }

    [HttpDelete("/Pizzas/{id}/Ingredients/{ingredientId}")]
    public IActionResult DeleteIngredient(int id, int ingredientId) {
        try {
            _pizzaService.DeleteIngredient(id, ingredientId);
            return Ok("Ingredient deleted");
        }catch (Exception e) {
            return BadRequest($"Error: {e.Message}");
        }

    }

    [HttpPut("/Pizzas/{id}/Ingredients/{ingredientId}")]
    public IActionResult UpdateIngredient(int id, int ingredientId, Ingredient ingredient) {
        try {
            _pizzaService.UpdateIngredient(id, ingredientId, ingredient);
            return Ok("Ingredient updated");
        }catch (Exception e) {
            return BadRequest($"Error: {e.Message}");
        }
    }

}