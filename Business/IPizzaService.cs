using ContosoPizza.Models;

namespace ContosoPizza.Business {

    public interface IPizzaService {
        //PIZZAS
        List<Pizza> GetAllPizzas();
        Pizza? GetPizzaById(int id);
        void AddPizza(int orderId, Pizza pizza);
        void DeletePizza(int id);
        void UpdatePizza(Pizza pizza);

        //INGREDIENTS
        List<Ingredient> GetAllIngredients(int pizzaId);
        Ingredient? GetIngredientById(int pizzaId, int ingredientId);
        void AddIngredient(int pizzaId, Ingredient ingredient);
        void DeleteIngredient(int pizzaId, int ingredientId);
        void UpdateIngredient(int pizzaId, int ingredientId, Ingredient updatedIngredient);
    }

}