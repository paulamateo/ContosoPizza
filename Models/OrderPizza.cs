using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoPizza.Models;

public class OrderPizza {
    [ForeignKey("PizzaId")]
    public int PizzaId { get; set; }
    public Pizza? Pizza { get; set; }

    [ForeignKey("OrderId")]
    public int OrderId { get; set; }
    public Order? Order { get; set; }
}