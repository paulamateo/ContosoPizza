using ContosoPizza.Models;
using ContosoPizza.Data;

namespace ContosoPizza.Business {

    public class PizzaService : IPizzaService {
        private readonly IPizzaRepository _repository;
        private readonly IUserService _userService;

        public PizzaService(IPizzaRepository repository, IUserService userService) {
            _repository = repository;
            _userService = userService;
        }


        //ORDERS
        public List<Order> GetAllOrders() => _repository.LoadOrders(); //GET all

        public Order? GetOrder(int id) => _repository.LoadOrders().FirstOrDefault(p => p.Id == id); //GET by Id
        public List<Order> GetOrdersByUserId(int userId) { //GET by User Id
            var user = _userService.GetUser(userId);
            return user?.Orders ?? new List<Order>();
        }

        public void AddOrder(int userId, Order order) { //ADD
            var user = _userService.GetUser(userId);
            if (user != null) {
                var orders = _repository.LoadOrders();
                order.Id = orders.Count > 0 ? orders.Max(o => o.Id) + 1 : 1;
                order.UserName = user.Name; 
                order.UserAddress = user.Address;

                foreach (var pizza in order.Pizzas) {
                    pizza.Id = order.Pizzas.Count > 0 ? order.Pizzas.Max(p => p.Id) + 1 : 1;
                }

                user.Orders.Add(order);
                orders.Add(order);
                _userService.UpdateUser(user);
                _repository.SaveOrders(orders);
                _repository.SaveUserPizzas(user, order.Pizzas);
            }
        }

        public void DeleteOrder(int orderId) { //DELETE
            var orders = _repository.LoadOrders();
            var order = orders.FirstOrDefault(o => o.Id == orderId);
            if (order != null) {
                orders.Remove(order);
                _repository.SaveOrders(orders);
            }
        }

        public void UpdateOrder(Order order) {
            var orders = _repository.LoadOrders();
            var index = orders.FindIndex(o => o.Id == order.Id);
            if (index != -1) {
                orders[index] = order;
                _repository.SaveOrders(orders);
            }
        }


        //INGREDIENTS
        public List<Ingredient> GetAllIngredients() => _repository.LoadIngredients();
        public Ingredient? GetIngredient(int id) => _repository.LoadIngredients().FirstOrDefault(p => p.Id == id);
        public void AddIngredient(Ingredient ingredient) {
            var ingredients = _repository.LoadIngredients();
            ingredient.Id = ingredients.Count > 0 ? ingredients.Max(p => p.Id) + 1 : 1;
            ingredients.Add(ingredient);
            _repository.SaveIngredients(ingredients);
        }

        public void DeleteIngredient(int id) {
            var ingredients = _repository.LoadIngredients();
            var ingredient = ingredients.FirstOrDefault(i => i.Id == id);
            if (ingredient != null) {
                ingredients.Remove(ingredient);
                _repository.SaveIngredients(ingredients);
            }
        }

        public void UpdateIngredient(Ingredient ingredient) {
            var ingredients = _repository.LoadIngredients();
            var index = ingredients.FindIndex(p => p.Id == ingredient.Id);
            if (index != -1) {
                ingredients[index] = ingredient;
                _repository.SaveIngredients(ingredients);
            }
        }


        //PIZZAS
        public List<Pizza> GetPizzasByOrderId(int orderId) {
            var order = GetOrder(orderId);

            if (order != null) {
                return order.Pizzas;
            }

            return new List<Pizza>();
        }

        public void AddPizzasToOrder(int orderId, List<Pizza> pizzas) {
            var order = GetOrder(orderId);

            if (order != null) {
                var allPizzas = _repository.LoadFromJson();
                var existingPizzas = order.Pizzas;
                int nextPizzaId = allPizzas.Count > 0 ? allPizzas.Max(p => p.Id) + 1 : 1;

                var allIngredients = _repository.LoadIngredients();

                foreach (var pizza in pizzas) {
                    int nextIngredientId = allIngredients.Count > 0 ? allIngredients.Max(ingredient => ingredient.Id) + 1 : 1;

                    foreach (var ingredient in pizza.Ingredients) {
                        ingredient.Id = nextIngredientId++;
                    }

                    pizza.Id = nextPizzaId++;
                    pizza.Price = pizza.Ingredients.Sum(ingredient => ingredient.Price);
                }

                order.Pizzas.AddRange(pizzas);

                var orders = _repository.LoadOrders();
                var existingOrder = orders.FirstOrDefault(o => o.Id == orderId);

                if (existingOrder != null) {
                    existingOrder.Pizzas.AddRange(pizzas);
                    existingOrder.TotalPrice += pizzas.Sum(p => p.Price);
                    _repository.SaveOrders(orders);
                }

                allIngredients.AddRange(pizzas.SelectMany(pizza => pizza.Ingredients));
                _repository.SaveIngredients(allIngredients);

                _repository.SavePizzas(pizzas);
                _repository.SaveToJson(allPizzas.Concat(pizzas).ToList());
            }
        }

        public void AddIngredientsToPizza(int pizzaId, List<Ingredient> ingredients) {
            var allPizzas = _repository.LoadFromJson();
            var allIngredients = _repository.LoadIngredients();
            var allOrders = _repository.LoadOrders();

        
            var pizzaToUpdate = allPizzas.FirstOrDefault(pizza => pizza.Id == pizzaId);

            var pizzaInOrders = allOrders.SelectMany(order => order.Pizzas.Where(pizza => pizza.Id == pizzaId)).ToList();

            if (pizzaInOrders.Any()) {
                pizzaInOrders.ForEach(pizza => pizza.Ingredients.AddRange(ingredients));
                _repository.SaveOrders(allOrders);
            }

            if (pizzaToUpdate != null) {
                pizzaToUpdate.Ingredients.AddRange(ingredients);
                pizzaToUpdate.Price = pizzaToUpdate.Ingredients.Sum(ingredient => ingredient.Price);
                allIngredients.AddRange(ingredients);
                _repository.SaveToJson(allPizzas);
                _repository.SaveIngredients(allIngredients);
            }
        }

        public List<Pizza> GetAll() => _repository.LoadFromJson();

        public Pizza? Get(int id) => _repository.LoadFromJson().FirstOrDefault(p => p.Id == id);

        public void Add(Pizza pizza) {
            var pizzas = _repository.LoadFromJson();
            pizza.Id = pizzas.Count > 0 ? pizzas.Max(p => p.Id) + 1 : 1;
            pizzas.Add(pizza);
            _repository.SaveToJson(pizzas);
        }

        public void Delete(int id) {
            var pizzas = _repository.LoadFromJson();
            var pizza = pizzas.FirstOrDefault(p => p.Id == id);
            if (pizza != null) {
                pizzas.Remove(pizza);
                _repository.SaveToJson(pizzas);
            }
        }

        public void Update(Pizza pizza) {
            var pizzas = _repository.LoadFromJson();
            var index = pizzas.FindIndex(p => p.Id == pizza.Id);
            if (index != -1) {
                pizzas[index] = pizza;
                _repository.SaveToJson(pizzas);
            }
        }

    }

}