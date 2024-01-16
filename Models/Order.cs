namespace ContosoPizza.Models;

public class Order {
    public int Id { get; set; }
    public decimal TotalPrice { get; set; }
    public List<Pizza> Pizzas { get; set; } = new List<Pizza>();
    
}