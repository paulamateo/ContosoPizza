using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoPizza.Models {

    public class Ingredient {
        [Key]
        public int IngredientId { get; set; }
        public string? IngredientName { get; set; }
        public decimal IngredientPrice { get; set; }
        public decimal Calories { get; set; }
        public decimal Carbohydrates {get; set; }
        public decimal Proteins {get; set; }
        public decimal Fats {get; set; }
        public decimal Fiber {get; set; }
        
        [ForeignKey("Pizza")]
        public int PizzaId { get; set; }
    }

}