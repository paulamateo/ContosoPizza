using ContosoPizza.Models;

namespace ContosoPizza.Data {

    public class PizzaEFRepository : IPizzaRepository {
        private readonly DataContext _context;

        public PizzaEFRepository(DataContext context) {
            _context = context;
        }

        //GET ALL
        public List<Pizza> GetAllPizzas() => _context.Pizzas.ToList();
        public List<Ingredient> GetAllIngredients() => _context.Ingredients.ToList();
        public List<Order> GetAllOrders() => _context.Orders.ToList();
        public List<User> GetAllUsers() => _context.Users.ToList();

        //GET BY ID
        public Pizza? GetPizza(int pizzaId) {
            var pizza = _context.Pizzas.FirstOrDefault(p => p.PizzaId == pizzaId) ?? throw new KeyNotFoundException($"Pizza not found");
            return pizza;
        }

        public Ingredient? GetIngredient(int ingredientId) {
            var ingredient = _context.Ingredients.FirstOrDefault(i => i.IngredientId == ingredientId) ?? throw new KeyNotFoundException($"Ingredient not found");
            return ingredient;
        }

        public Order? GetOrder(int orderId) {
            var order = _context.Orders.FirstOrDefault(o => o.OrderId == orderId) ?? throw new KeyNotFoundException($"Order not found");
            return order;
        }

        public User? GetUser(int userId) {
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId) ?? throw new KeyNotFoundException($"User not found");
            return user;
        }

        //ADD
        public void AddPizza(Pizza pizza) => _context.Pizzas.Add(pizza);
        public void AddIngredient(Ingredient ingredient) => _context.Ingredients.Add(ingredient);
        public void AddOrder(Order order) => _context.Orders.Add(order);
        public void AddUser(User user) => _context.Users.Add(user);

        //DELETE
        public void DeletePizza(int pizzaId) {
            var pizza = GetPizza(pizzaId) ?? throw new KeyNotFoundException($"Pizza not found");
            _context.Pizzas.Remove(pizza);
        }

        public void DeleteIngredient(int ingredientId) {
            var ingredient = GetIngredient(ingredientId) ?? throw new KeyNotFoundException($"Pizza not found");
            _context.Ingredients.Remove(ingredient);
        }

        public void DeleteOrder(int orderId) {
            var order = GetOrder(orderId) ?? throw new KeyNotFoundException($"Order not found");
            _context.Orders.Remove(order);
        }

        public void DeleteUser(int userId) {
            var user = GetUser(userId) ?? throw new KeyNotFoundException($"User not found");
            _context.Users.Remove(user);
        }

        //UPDATE
        public void UpdatePizza(Pizza pizza) {
            var index = GetAllPizzas().FindIndex(p => p.PizzaId == pizza.PizzaId);
            var pizzas = GetAllPizzas().ToList();
            if(index == -1)
                return;

            pizzas[index] = pizza;
        }

        public void UpdateIngredient(Ingredient ingredient) {
            var index = GetAllIngredients().FindIndex(i => i.IngredientId == ingredient.IngredientId);
            if(index == -1)
                return;

            Ingredients[index] = ingredient;
        }



    }
}