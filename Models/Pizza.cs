using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoPizza.Models {

    public class Pizza {
        [Key]
        public int PizzaId { get; set; }
        public string? Name { get; set; }
        public bool IsGlutenFree { get; set; }
        public decimal Price { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        [ForeignKey("Order")]
        public int OrderId { get; set; }
    }

}