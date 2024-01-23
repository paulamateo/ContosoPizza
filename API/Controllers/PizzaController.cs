using ContosoPizza.Models;
using ContosoPizza.Business;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers {
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
        [HttpPost("/Users")] //CREATE
        public IActionResult CreateUser(User user) {
            _userService.AddUser(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        [HttpDelete("/Users/{id}")] //DELETE
        public IActionResult DeleteUsers(int id) {
            var user = _userService.GetUser(id);

            if (user is null)
                return NotFound();

            _userService.DeleteUser(id);

            return NoContent();
        }

        [HttpPut("/Users/{id}")] //UPDATE
        public IActionResult UpdateUsers(int id, User user) {
            if (id != user.Id)
                return BadRequest();

            var existingUser = _userService.GetUser(id);
            if (existingUser is null)
                return NotFound();

            _userService.UpdateUser(user);

            return NoContent();
        }

        [HttpGet("/Users")] //GET all
        public ActionResult<List<User>> GetAllUsers() =>
            _userService.GetAllUsers();  
        
        [HttpGet("/Users/{id}")] //GET by Id
        public ActionResult<User> GetUser(int id) {
            var user = _userService.GetUser(id);

            if (user == null)
                return NotFound();

            return user;
        }



        //ORDERS
        [HttpPost("/Users/{userId}/Orders")] //CREATE
        public IActionResult CreateOrder(int userId, [FromBody] Order order) {
            _pizzaService.AddOrder(userId, order);
            return CreatedAtAction(nameof(GetOrdersByUser), new { userId = userId }, order);
        }
        
        [HttpDelete("/Orders/{id}")] //DELETE
        public IActionResult DeleteOrder(int id) {
            var order = _pizzaService.GetOrder(id);

            if (order is null)
                return NotFound();

            _pizzaService.DeleteOrder(id);

            return NoContent();
        }

        [HttpPut("/Orders/{id}")] //UPDATE
        public IActionResult UpdateOrder(int id, Order order) {
            if (id != order.Id)
                return BadRequest();
            
            var existingOrder = _pizzaService.GetOrder(id);
            if (existingOrder is null) 
                return NotFound();
            
            _pizzaService.UpdateOrder(order);
            return NoContent();
        }

        [HttpGet("/Orders")] //GET all
        public ActionResult<List<Order>> GetAllOrders() =>
            _pizzaService.GetAllOrders();  
        
        [HttpGet("/Orders/{id}")] //GET by Id
        public ActionResult<Order> GetOrder(int id) {
            var order = _pizzaService.GetOrder(id);

            if (order == null)
                return NotFound();

            return order;
        }

        [HttpGet("/Users/{userId}/Orders")] //GET all orders from a user
        public List<Order> GetOrdersByUser(int userId) {
            return _pizzaService.GetOrdersByUserId(userId);
        }



        //PIZZAS
        [HttpPost("/Orders/{orderId}/Pizzas")] //CREATE
        public IActionResult AddPizzasToOrder(int orderId, [FromBody] List<Pizza> pizzas) {
            try {
                // Call the service method to add pizzas to the order
                _pizzaService.AddPizzasToOrder(orderId, pizzas);

                // You can return a success response if needed
                return Ok("Pizzas added to the order successfully");
            } catch (Exception ex) {
                // Handle any exceptions and return an error response
                return BadRequest($"Error adding pizzas to the order: {ex.Message}");
            }
        }

        [HttpDelete("/Pizzas/{id}")] //DELETE
        public IActionResult Delete(int id) {
            var pizza = _pizzaService.Get(id);

            if (pizza is null)
                return NotFound();

            _pizzaService.Delete(id);

            return NoContent();
        }

        [HttpGet("/Pizzas")] //GET all
        public ActionResult<List<Pizza>> GetAll() =>
            _pizzaService.GetAll();
        
        [HttpGet("/Pizzas/{id}")] //GET by Id
        public ActionResult<Pizza> Get(int id) {
            var pizza = _pizzaService.Get(id);

            if (pizza == null)
                return NotFound();

            return pizza;
        }

        [HttpGet("/Orders/{orderId}/Pizzas")] //GET all pizzas from an order
        public ActionResult<List<Pizza>> GetPizzasByOrderId(int orderId) {
            var order = _pizzaService.GetOrder(orderId);

            if (order == null) {
                return NotFound(); // Devuelve 404 si no se encuentra el pedido.
            }

            return order.Pizzas;
        }

        [HttpPut("/Pizzas/{id}")] //UPDATE
        public IActionResult Update(int id, Pizza pizza) {
            if (id != pizza.Id)
                return BadRequest();

            var existingPizza = _pizzaService.Get(id);
            if (existingPizza is null)
                return NotFound();

            _pizzaService.Update(pizza);

            return NoContent();
        }



        //INGREDIENTS
        [HttpPost("/Pizzas/{pizzaId}/Ingredients")] //CREATE
        public IActionResult CreateIngredientToPizza(int pizzaId, List<Ingredient> ingredients) {
            try {
                _pizzaService.AddIngredientsToPizza(pizzaId, ingredients);
                return Ok("Ingredients added to the pizza successfully");
            }catch (Exception ex) {
                return BadRequest($"Error adding pizzas to the order: {ex.Message}");
            }
        }
        
        [HttpDelete("/Ingredients/{id}")] //DELETE
        public IActionResult DeleteIngredient(int id) {
            var ingredient = _pizzaService.GetIngredient(id);

            if (ingredient is null)
                return NotFound();

            _pizzaService.Delete(id);

            return NoContent();
        }
        
        [HttpPut("/Ingredients/{id}")] //UPDATE
        public IActionResult UpdateIngredient(int id, Ingredient ingredient) {
            if (id != ingredient.Id)
                return BadRequest();

            var existingIngredient = _pizzaService.GetIngredient(id);
            if (existingIngredient is null)
                return NotFound();

            _pizzaService.UpdateIngredient(ingredient);

            return NoContent();
        }

        [HttpGet("/Ingredients")] //GET all
        public ActionResult<List<Ingredient>> GetAllIngredients() =>
            _pizzaService.GetAllIngredients();  
        
        [HttpGet("/Ingredients/{id}")] //GET by Id
        public ActionResult<Ingredient> GetIngredient(int id) {
            var ingredient = _pizzaService.GetIngredient(id);

            if (ingredient == null)
                return NotFound();

            return ingredient;
        }

        

        // POST action
        // [HttpPost("/Pizzas")]
        // public IActionResult Create(Pizza pizza) {
        //     _pizzaService.Add(pizza);
        //     return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
        // }

    }
}