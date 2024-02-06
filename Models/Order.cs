namespace ContosoPizza.Models;

public class Order {
    public int Id { get; set; }
    public decimal TotalPrice => Pizzas.Sum(pizza => pizza.Price);
    public int UserId { get; set; }
    public string? UserName { get; set; } 
    public string? UserAddress { get; set; }
    public List<Pizza> Pizzas { get; set; } = new List<Pizza>();

}