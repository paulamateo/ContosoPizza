using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoPizza.Models;

public class PizzaIngredient {
    [ForeignKey("PizzaId")]
    public int PizzaId { get; set; }
    public Pizza? Pizza { get; set; }

    [ForeignKey("IngredientId")]
    public int IngredientId { get; set; }
    public Ingredient? Ingredient { get; set; }
}