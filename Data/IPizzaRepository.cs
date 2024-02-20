using ContosoPizza.Models;

namespace ContosoPizza.Data {

    public interface IPizzaRepository { 
        //PIZZAS
        List<Pizza> GetAllPizzas(); 
        Pizza? GetPizza(int pizzaId); 
        List<Pizza> GetPizzasForOrder(int orderId);
        void AddPizza(Pizza pizza); 
        void DeletePizza(int pizzaId); 
        void UpdatePizza(Pizza pizza); 
        void AddPizzaToOrder(int orderId, int pizzaId);

        //INGREDIENTS
        List<Ingredient> GetAllIngredients(); 
        Ingredient? GetIngredient(int ingredientId); 
        List<Ingredient> GetIngredientsForPizza(int pizzaId);
        void AddIngredient(Ingredient ingredient); 
        void DeleteIngredient(int ingredientId); 
        void UpdateIngredient(Ingredient ingredient);
        void AddIngredientToPizza(int pizzaId, int ingredientId);
    
        //ORDERS
        List<Order> GetAllOrders();
        Order? GetOrder(int orderId);
        List<Order> GetOrdersForUser(int userId);
        void AddOrder(Order order);
        void DeleteOrder(int orderId);
        void UpdateOrder(Order order);
        void AddOrderToUser(int orderId, int userId);

        //USERS
        List<User> GetAllUsers();
        User? GetUser(int userId);
        void AddUser(User user);
        void DeleteUser(int userId); 
        void UpdateUser(User user);
    }

}