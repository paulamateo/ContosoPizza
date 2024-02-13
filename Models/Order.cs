using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoPizza.Models {

    public class Order {
        [Key]
        public int OrderId { get; set; }
        public decimal TotalPrice {get; set; }
        // public decimal TotalPrice => Pizzas.Sum(pizza => pizza.PizzaPrice);
        public string? UserName { get; set; } 
        public string? UserAddress { get; set; }
        public List<Pizza> Pizzas { get; set; } = new List<Pizza>();
        
        [ForeignKey("User")]
        public int UserId { get; set; }
    }

}