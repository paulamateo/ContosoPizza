using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Data {

    public class PizzaEFRepository : IPizzaRepository {
        private readonly DataContext _context;
        private readonly UserEFRepository _userContext;


        public PizzaEFRepository(DataContext context, UserEFRepository userContext) {
            _context = context;
            _userContext = userContext;
        }

        //PIZZAS    
        public void AddPizza(int orderId, Pizza pizza) {
            var order = _userContext.GetOrder(orderId);
            if (order is null) {
                throw new KeyNotFoundException("Order not found.");
            }
            _context.Pizzas.Add(pizza);
            _userContext.SaveToJson();
        }

        public Pizza? GetPizza(int pizzaId) {
            return _context.Pizzas.FirstOrDefault(p => p.PizzaId == pizzaId);
        }
        
        public void UpdatePizza(Pizza pizza) {
            _context.Entry(pizza).State = EntityState.Modified;
        }

        public void DeletePizza(int pizzaId) {
            var pizza = GetPizza(pizzaId);
            if (pizza is null) {
                throw new KeyNotFoundException("Pizza not found.");
            }
            _context.Pizzas.Remove(pizza);
            SaveToJson();
        }

        public List<Pizza> GetAllPizzasByOrder(int orderId) {
            return _context.Pizzas
                                .Where(p => p.OrderId == orderId)
                                .Include(p => p.PizzaId)
                                .ToList();
        }


        //INGREDIENTS
        public void GetAllIngredients() {

        }

        public void AddIngredient(int pizzaId, Ingredient ingredient) {
            var pizza = GetPizza(pizzaId);
            if (pizza is null) {
                throw new KeyNotFoundException("Pizza not found.");
            }
            _context.Ingredients.Add(ingredient);
            SaveToJson();
        }

        public Ingredient GetIngredient(int ingredientId) {
            return _context.Ingredients.FirstOrDefault(i => i.IngredientId == ingredientId);
        }

        public void UpdateIngredient(int ingredientId, Ingredient updatedIngredient) {
            var ingredient = GetIngredient(ingredientId);
            if (ingredient is null) {
                throw new KeyNotFoundException("Ingredient not found.");
            }
            _context.Entry(ingredient).State = EntityState.Modified;
            SaveToJson();
        }

        public void DeleteIngredient(int ingredientId) {
            var ingredient = GetIngredient(ingredientId);
            if (ingredient is null) {
                throw new KeyNotFoundException("Ingredient not found.");
            }
            _context.Ingredients.Remove(ingredient);
            SaveToJson();
        }

        public List<Ingredient> GetAllIngredientsByPizza(int pizzaId) {
            return _context.Ingredients
                                .Where(i => i.PizzaId == pizzaId)
                                .Include(i => i.IngredientId)
                                .ToList();
        }

    }

}