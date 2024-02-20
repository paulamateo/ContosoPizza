using System.ComponentModel.DataAnnotations;

namespace ContosoPizza.Models;

public class Ingredient {
    [Key]
    public int IngredientId { get; set; }
    public string? IngredientName { get; set; }
    public decimal IngredientPrice { get; set; }
    public decimal Calories { get; set; }
    public decimal Carbohydrates { get; set; }
    public decimal Proteins { get; set; }
    public decimal Fats { get; set; }
    public decimal Fiber { get; set; }
}