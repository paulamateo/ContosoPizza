namespace ContosoPizza.Models;

public class Ingredient {
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public decimal Calories { get; set; }
    public decimal Carbohydrates {get; set; }
    public decimal Proteins {get; set; }
    public decimal Fats {get; set; }
    public decimal Fiber {get; set; }
    
}