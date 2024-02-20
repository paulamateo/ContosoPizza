namespace ContosoPizza.Models;

public class PizzaDTO {
    public int PizzaId { get; set; }
    public string? PizzaName { get; set; }
    public List<IngredientDTO>? Ingredients { get; set; }
}