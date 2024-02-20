using ContosoPizza.Models;
using ContosoPizza.Business;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase {
    private readonly IPizzaService _pizzaService;

    public UserController(IPizzaService pizzaService) {
        _pizzaService = pizzaService;
    }


    //USERS
    [HttpGet]
    public ActionResult<List<User>> GetAllUsers() =>
        _pizzaService.GetAllUsers();

    [HttpGet("{userId}")]
    public ActionResult<User> GetUser(int userId) {
        var user = _pizzaService.GetUser(userId);

        if(user == null)
            return NotFound();

        return user;
    }

    [HttpPost]
    public IActionResult CreateUser(User user) {            
        _pizzaService.AddUser(user);
        return CreatedAtAction(nameof(GetUser), new { user.UserId }, user);
    }

    [HttpPut("{userId}")]
    public IActionResult UpdateUser(int userId, User user) {
        if (userId != user.UserId)
            return BadRequest();
            
        var existingUser = _pizzaService.GetUser(userId);
        if(existingUser is null)
            return NotFound();
    
        _pizzaService.UpdateUser(user);           
    
        return Ok("User updated");
    }

    [HttpDelete("{userId}")]
    public IActionResult DeleteUser(int userId) {
        var user = _pizzaService.GetUser(userId);
    
        if (user is null)
            return NotFound();
        
        _pizzaService.DeleteUser(userId);
    
        return Ok("User deleted");
    }


    //ORDERS
    [HttpGet("/Order")]
    public ActionResult<List<Order>> GetAllOrders() =>
        _pizzaService.GetAllOrders();

    [HttpGet("/Order/{orderId}")]
    public ActionResult<Order> GetOrder(int orderId) {
        var order = _pizzaService.GetOrder(orderId);

        if(order == null)
            return NotFound();

        return order;
    }

    [HttpGet("{userId}/Order")]
    public ActionResult<List<Order>> GetOrdersForUser(int userId) {
        var user = _pizzaService.GetUser(userId);

        if(user == null)
            return NotFound();
        
        var orders = _pizzaService.GetOrdersForUser(userId);
        return orders;
    }

    [HttpPost("/Order")]
    public IActionResult CreateOrder(Order order) {            
        _pizzaService.AddOrder(order);
        return CreatedAtAction(nameof(GetOrder), new { order.OrderId }, order);
    }

    [HttpDelete("/Order/{orderId}")]
    public IActionResult DeleteOrder(int orderId) {
        var order = _pizzaService.GetOrder(orderId);
    
        if (order is null)
            return NotFound();
        
        _pizzaService.DeleteOrder(orderId);
    
        return Ok("Order deleted");
    }

    [HttpPut("/Order/{orderId}")]
    public IActionResult UpdateOrder(int orderId, Order order) {
        if (orderId != order.OrderId)
            return BadRequest();
            
        var existingOrder = _pizzaService.GetOrder(orderId);
        if(existingOrder is null)
            return NotFound();
    
        _pizzaService.UpdateOrder(order);           
    
        return Ok("Order updated");
    }

    [HttpPost("{userId}/Order/{orderId}")]
    public IActionResult AddOrderToUser(int userId, int orderId) {
        var user = _pizzaService.GetUser(userId);
        var order = _pizzaService.GetOrder(orderId);

        if (user is null || order is null )
            return NotFound();
        
        _pizzaService.AddOrderToUser(userId, orderId);
        return Ok("Order added to user");
    }

}