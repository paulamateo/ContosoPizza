using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoPizza.Models;

public class Order {
    [Key]
    public int OrderId { get; set; }
    public decimal TotalPrice {get; set; }
    
    [ForeignKey("UserId")]
    public int UserId { get; set; }
    public string? UserName { get; set; } 
    public string? UserAddress { get; set; }
    public List<Pizza> Pizzas { get; set; } = new List<Pizza>();    
    public List<OrderPizza>? OrdersPizzas { get; set; }
}