using ContosoPizza.Models;
using ContosoPizza.Business;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase {
    private readonly IPizzaService _pizzaService;

    public PizzaController(IPizzaService pizzaService) {
        _pizzaService = pizzaService;
    }

    //PIZZAS
    [HttpGet]
    public ActionResult<List<Pizza>> GetAllPizzas() =>
        _pizzaService.GetAllPizzas();

    [HttpGet("{pizzaId}")]
    public ActionResult<Pizza> GetPizza(int pizzaId) {
        var pizza = _pizzaService.GetPizza(pizzaId);

        if(pizza == null)
            return NotFound();

        return pizza;
    }

    [HttpPost]
    public IActionResult CreatePizza(Pizza pizza) {            
        _pizzaService.AddPizza(pizza);
        return CreatedAtAction(nameof(GetPizza), new { pizza.PizzaId }, pizza);
    }

    [HttpPut("{pizzaId}")]
    public IActionResult UpdatePizza(int pizzaId, Pizza pizza) {
        if (pizzaId != pizza.PizzaId)
            return BadRequest();
            
        var existingPizza = _pizzaService.GetPizza(pizzaId);
        if(existingPizza is null)
            return NotFound();
    
        _pizzaService.UpdatePizza(pizza);           
    
        return Ok("Pizza updated");
    }

    [HttpDelete("{pizzaId}")]
    public IActionResult DeletePizza(int pizzaId) {
        var pizza = _pizzaService.GetPizza(pizzaId);
    
        if (pizza is null)
            return NotFound();
        
        _pizzaService.DeletePizza(pizzaId);
    
        return Ok("Pizza deleted");
    }

    [HttpPost("/Order/{orderId}/Pizza/{pizzaId}")]
    public IActionResult AddPizzaToOrder(int orderId, int pizzaId) {
        var order = _pizzaService.GetOrder(orderId);
        var pizza = _pizzaService.GetPizza(pizzaId);

        if (order is null || pizza is null )
            return NotFound();
        
        _pizzaService.AddPizzaToOrder(orderId, pizzaId);
        return Ok("Pizza added to order");
    }

    //INGREDIENTS
    [HttpGet("/Ingredient")]
    public ActionResult<List<Ingredient>> GetAllIngredients() =>
        _pizzaService.GetAllIngredients();

    [HttpGet("/Ingredient/{ingredientId}")]
    public ActionResult<Ingredient> GetIngredient(int ingredientId) {
        var ingredient = _pizzaService.GetIngredient(ingredientId);

        if(ingredient == null)
            return NotFound();

        return ingredient;
    }

    [HttpGet("{pizzaId}/Ingredient")]
    public ActionResult<List<Ingredient>> GetIngredientForPizza(int pizzaId) {
        var pizza = _pizzaService.GetPizza(pizzaId);

        if(pizza == null)
            return NotFound();
        
        var ingredients = _pizzaService.GetIngredientsForPizza(pizzaId);
        return ingredients;
    }

    [HttpPost("/Ingredient")]
    public IActionResult CreateIngredient(Ingredient ingredient) {            
        _pizzaService.AddIngredient(ingredient);
        return CreatedAtAction(nameof(GetIngredient), new { ingredient.IngredientId }, ingredient);
    }

    [HttpPut("/Ingredient/{ingredientId}")]
    public IActionResult UpdateIngredient(int ingredientId, Ingredient ingredient) {
        if (ingredientId != ingredient.IngredientId)
            return BadRequest();
            
        var existingIngredient = _pizzaService.GetIngredient(ingredientId);
        if(existingIngredient is null)
            return NotFound();
    
        _pizzaService.UpdateIngredient(ingredient);           
    
        return Ok("Ingredient updated");
    }

    [HttpDelete("/Ingredient/{ingredientId}")]
    public IActionResult DeleteIngredient(int ingredientId) {
        var ingredient = _pizzaService.GetIngredient(ingredientId);
    
        if (ingredient is null)
            return NotFound();
        
        _pizzaService.DeleteIngredient(ingredientId);
    
        return Ok("Ingredient deleted");
    }

    [HttpPost("{pizzaId}/ingredient/{ingredientId}")]
    public IActionResult AddIngredientToPizza(int pizzaId, int ingredientId) {
        var pizza = _pizzaService.GetPizza(pizzaId);
        var ingredient = _pizzaService.GetIngredient(ingredientId);

        if (ingredient is null || pizza is null )
            return NotFound();
        
        _pizzaService.AddIngredientToPizza(pizzaId, ingredientId);
        return Ok("Ingredient added to pizza"); 
    }
   
}