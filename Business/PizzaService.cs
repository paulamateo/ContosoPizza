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
        public List<Pizza> GetPizzasForOrder(int orderId) => _pizzaRepository.GetPizzasForOrder(orderId);
        public void AddPizza(Pizza pizza) => _pizzaRepository.AddPizza(pizza);
        public void DeletePizza(int pizzaId) => _pizzaRepository.DeletePizza(pizzaId);
        public void UpdatePizza(Pizza pizza) => _pizzaRepository.UpdatePizza(pizza);
        public void AddPizzaToOrder(int orderId, int pizzaId) => _pizzaRepository.AddPizzaToOrder(orderId, pizzaId);

        //INGREDIENTS
        public List<Ingredient> GetAllIngredients() => _pizzaRepository.GetAllIngredients();
        public Ingredient? GetIngredient(int ingredientId) => _pizzaRepository.GetIngredient(ingredientId);
        public List<Ingredient> GetIngredientsForPizza(int pizzaId) => _pizzaRepository.GetIngredientsForPizza(pizzaId);
        public void AddIngredient(Ingredient ingredient) => _pizzaRepository.AddIngredient(ingredient);
        public void DeleteIngredient(int ingredientId) => _pizzaRepository.DeleteIngredient(ingredientId);
        public void UpdateIngredient(Ingredient ingredient) => _pizzaRepository.UpdateIngredient(ingredient);
        public void AddIngredientToPizza(int pizzaId, int ingredientId) => _pizzaRepository.AddIngredientToPizza(pizzaId, ingredientId);

        //ORDERS
        public List<Order> GetAllOrders() => _pizzaRepository.GetAllOrders();
        public Order? GetOrder(int orderId) => _pizzaRepository.GetOrder(orderId);
        public List<Order> GetOrdersForUser(int userId) => _pizzaRepository.GetOrdersForUser(userId);
        public void AddOrder(Order order) => _pizzaRepository.AddOrder(order);
        public void DeleteOrder(int orderId) => _pizzaRepository.DeleteOrder(orderId);
        public void UpdateOrder(Order order) => _pizzaRepository.UpdateOrder(order);
        public void AddOrderToUser(int orderId, int userId) => _pizzaRepository.AddOrderToUser(orderId, userId);

        //USERS
        public List<User> GetAllUsers() => _pizzaRepository.GetAllUsers();
        public User? GetUser(int userId) => _pizzaRepository.GetUser(userId);
        public void AddUser(User user) => _pizzaRepository.AddUser(user);
        public void DeleteUser(int userId) => _pizzaRepository.DeleteUser(userId);
        public void UpdateUser(User user) => _pizzaRepository.UpdateUser(user);
    }

}