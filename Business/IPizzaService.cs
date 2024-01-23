using ContosoPizza.Models;

namespace ContosoPizza.Business {

    public interface IPizzaService {

        //INGREDIENTS
        List<Ingredient> GetAllIngredients();
        void AddIngredient(Ingredient ingredient);
        Ingredient? GetIngredient(int id);
        void DeleteIngredient(int id);
        void UpdateIngredient(Ingredient ingredient);
        void AddIngredientsToPizza(int pizzaId, List<Ingredient> ingredients);

        //ORDERS
        List<Order> GetAllOrders();
        Order? GetOrder(int id);
        List<Order> GetOrdersByUserId(int userId);
        void AddOrder(int userId, Order order);
        void DeleteOrder(int orderId);
        void UpdateOrder(Order order);

        //PIZZAS
        List<Pizza> GetPizzasByOrderId(int pedidoId);
        void AddPizzasToOrder(int orderId, List<Pizza> pizzas);
        List<Pizza> GetAll();
        Pizza? Get(int id);
        void Add(Pizza pizza);
        void Delete(int id);
        void Update(Pizza pizza);

    }

}