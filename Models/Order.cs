namespace ContosoPizza.Models;

public class Order {
    public int Id { get; set; }
    public decimal TotalPrice { get; set; }
    public string? UserName { get; set; } 
    public string? UserAddress { get; set; }
    public List<Pizza> Pizzas { get; set; } = new List<Pizza>();

}