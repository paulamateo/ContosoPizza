using System.ComponentModel.DataAnnotations;

namespace ContosoPizza.Models;

public class Pizza {
    [Key]
    public int PizzaId { get; set; }
    public string? PizzaName { get; set; }
    public bool IsGlutenFree { get; set; }
    public decimal PizzaPrice { get; set; }
    public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
}