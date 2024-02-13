using ContosoPizza.Data;
using ContosoPizza.Models;

namespace ContosoPizza.Business {

    public class PizzaService : IPizzaService {
        private readonly IPizzaRepository _pizzaRepository;

        public PizzaService(IPizzaRepository pizzaRepository) {
            _pizzaRepository = pizzaRepository;
        }


        //PIZZAS
        public List<Pizza> GetAllPizzas() => _pizzaRepository.GetAllPizzas();

        public Pizza? GetPizza(int pizzaId) => _pizzaRepository.GetPizza(pizzaId);

        public List<Pizza> GetAllPizzasByOrder(int orderId) => _pizzaRepository.GetAllPizzasByOrder(orderId);

        public void CreatePizza(int orderId, Pizza pizza) {
            try {
                _pizzaRepository.AddPizza(orderId, pizza);
            }catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        public void DeletePizza(int pizzaId) {
            try {
                _pizzaRepository.DeletePizza(pizzaId);
            }catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        public void UpdatePizza(Pizza pizza) {
            try {
                _pizzaRepository.UpdatePizza(pizza);
            }catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
            }
        }


        //INGREDIENTS
        public List<Ingredient> GetAllIngredientsByPizza(int pizzaId) => _pizzaRepository.GetAllIngredientsByPizza(pizzaId);

        public List<Ingredient> GetAllIngredients() => _pizzaRepository.GetAllIngredients();

        public Ingredient? GetIngredient(int ingredientId) => _pizzaRepository.GetIngredient(ingredientId);

        public void AddIngredient(int pizzaId, Ingredient ingredient) {
            try {
                _pizzaRepository.AddIngredient(pizzaId, ingredient);
            }catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        public void DeleteIngredient(int ingredientId) {
            try {
                _pizzaRepository.DeleteIngredient(ingredientId);
            }catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        public void UpdateIngredient(int ingredientId, Ingredient ingredient) {
            try {
                _pizzaRepository.UpdateIngredient(ingredientId, ingredient);
            }catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

    }
}