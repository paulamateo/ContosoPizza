using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoPizza.Models {

    public class Pizza {
        [Key]
        public int PizzaId { get; set; }
        public string? PizzaName { get; set; }
        public bool IsGlutenFree { get; set; }
        public decimal PizzaPrice { get; set; }
        
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        // public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<PizzaIngredient>? PizzaIngredient { get; set; }
    }

}