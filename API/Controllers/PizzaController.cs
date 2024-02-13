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


    //PIZZAS
    [HttpGet]
    public ActionResult<List<Pizza>> GetAllPizzas() => _pizzaService.GetAllPizzas();

    [HttpGet("{pizzaId}")]
    public ActionResult<Pizza> GetPizza(int pizzaId) {
        var pizza = _pizzaService.GetPizza(pizzaId);

        if (pizza == null)
            return NotFound();

        return pizza;
    }

    [HttpGet("/Order/{orderId}/Pizza")]
    public ActionResult GetPizzasByOrder(int orderId) {
        try {
            var pizzas = _pizzaService.GetAllPizzasByOrder(orderId);
            return Ok(pizzas);
        }catch (Exception e) {
            return BadRequest($"Error: {e.Message}");
        }
    }

    [HttpPost]
    public IActionResult AddPizza(Pizza pizza) {
        try{
            var order = _userService.GetOrder(pizza.OrderId);
            if (order == null) 
                return NotFound();
            _pizzaService.CreatePizza(pizza.OrderId, pizza);
            return Ok("Pizza created");
        }catch (Exception e) {
            return BadRequest($"Error: {e.Message}");
        }
    }

    [HttpDelete("{pizzaId}")]
    public IActionResult DeletePizza(int pizzaId) {    
        var pizza = _pizzaService.GetPizza(pizzaId);

        if (pizza is null) 
            return NotFound();

        _pizzaService.DeletePizza(pizzaId);

        return Ok("Pizza deleted");
    }

    [HttpPut("{pizzaId}")]
    public IActionResult UpdatePizza(int pizzaId, Pizza pizza) {
        if (pizzaId != pizza.PizzaId)
            return BadRequest();

        var existingPizza = _pizzaService.GetPizza(pizzaId);
        if (existingPizza is null)
            return NotFound();

        _pizzaService.UpdatePizza(pizza);

        return Ok("Pizza updated");
    }


    //INGREDIENTS
    [HttpGet("/Ingredient")]
    public ActionResult<List<Ingredient>> GetAllIngredients() => _pizzaService.GetAllIngredients();
    
    [HttpGet("{pizzaId}/Ingredient")]
    public ActionResult<List<Ingredient>> GetAllIngredientsByPizza(int pizzaId) => _pizzaService.GetAllIngredientsByPizza(pizzaId);

    [HttpGet("/Ingredient/{ingredientId}")]
     public ActionResult<Ingredient> GetIngredientById(int ingredientId) {
        var ingredient = _pizzaService.GetIngredient(ingredientId);

        if (ingredient == null)
            return NotFound();

        return ingredient;
    }

    [HttpPost("/Ingredient")]
    public IActionResult AddIngredient(Ingredient ingredient) {
        try{
            var pizza = _pizzaService.GetPizza(ingredient.IngredientId);
            _pizzaService.AddIngredient(ingredient.PizzaId, ingredient);
            return Ok("Ingredient created");
        }catch (Exception e) {
            return BadRequest($"Error: {e.Message}");
        }
    }

    [HttpDelete("/Ingredient/{ingredientId}")]
    public IActionResult DeleteIngredient(int ingredientId) {
        try {
            _pizzaService.DeleteIngredient(ingredientId);
            return Ok("Ingredient deleted");
        }catch (Exception e) {
            return BadRequest($"Error: {e.Message}");
        }
    }

    [HttpPut("/Ingredient/{ingredientId}")]
    public IActionResult UpdateIngredient(int ingredientId, Ingredient ingredient) {
        try {
            _pizzaService.UpdateIngredient(ingredientId, ingredient);
            return Ok("Ingredient updated");
        }catch (Exception e) {
            return BadRequest($"Error: {e.Message}");
        }
    }

}