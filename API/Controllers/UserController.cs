using ContosoPizza.Models;
using ContosoPizza.Business;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase {
    private readonly IUserService _userService;

    public UserController(IUserService userService) {
        _userService = userService;
    }


    //USERS
    [HttpGet]
    public ActionResult<List<User>> GetAllUsers() => _userService.GetAllUsers();

    [HttpGet("{userId}")]
    public ActionResult<User> GetUser(int userId) {
        var user = _userService.GetUser(userId);

        if (user == null) 
            return NotFound();

        return user;
    }

    [HttpPost]
    public IActionResult AddUser(User user) {
        try {
            _userService.CreateUser(user);
            return Ok("User created");
        }catch (Exception e) {
            return BadRequest($"Error: {e.Message}");
        }
    }

    [HttpDelete("{userId}")]
    public IActionResult DeleteUser(int userId) {
        var user = _userService.GetUser(userId);

        if (user == null) 
            return NotFound();
        
        _userService.DeleteUser(userId);
        return Ok("User deleted");
    }

    [HttpPut("{userId}")]
    public IActionResult UpdateUser(int userId, User user) {
        if (userId != user.UserId)
            return BadRequest();
        
        var existingUser = _userService.GetUser(userId);
        if (existingUser == null) 
            return NotFound();
        
        _userService.UpdateUser(user);
        return Ok("User updated");
    }


    //ORDERS
    [HttpGet("/Order")]
    public ActionResult<List<Order>> GetAllOrders() => _userService.GetAllOrders();

    [HttpGet("/Order/{orderId}")]
    public ActionResult<Order> GetOrder(int orderId) {
        var order = _userService.GetOrder(orderId);

        if (order == null) 
            return NotFound();
        
        return order;
    }

    [HttpPost("/Order")]
    public IActionResult AddOrder(Order order) {
        try {
            var user = _userService.GetUser(order.UserId);
            _userService.CreateOrder(order.UserId, order);
            return Ok("Order created");
        }catch (Exception e) {
            return BadRequest($"Error: {e.Message}");
        }
    }

    [HttpDelete("/Order/{orderId}")]
    public IActionResult DeleteOrder(int orderId) {
        try {
            _userService.DeleteOrder(orderId);
            return Ok("Order deleted");
        } catch (Exception e) {
            return BadRequest($"Error: {e.Message}");
        }
    }

}