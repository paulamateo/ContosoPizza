using ContosoPizza.Models;

namespace ContosoPizza.Business {

    public interface IPizzaService {
        List<Pizza> GetAllPizzas();
        Pizza? GetPizza(int pizzaId);
        List<Pizza> GetAllPizzasByOrder(int orderId);
        void CreatePizza(int orderId, Pizza pizza);
        void DeletePizza(int pizzaId);
        void UpdatePizza(Pizza pizza);
        List<Ingredient> GetAllIngredientsByPizza(int pizzaId);
        List<Ingredient> GetAllIngredients();
        Ingredient? GetIngredient(int ingredientId);
        void AddIngredient(int pizzaId, Ingredient ingredient);
        void DeleteIngredient(int ingredientId);
        void UpdateIngredient(int ingredientId, Ingredient ingredient);
    }

}