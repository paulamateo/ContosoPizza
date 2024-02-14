using ContosoPizza.Models;

namespace ContosoPizza.Data {

    public class PizzaRepository : IPizzaRepository {
        private readonly IUserRepository _userRepository;

        public PizzaRepository(IUserRepository userRepository) {
            _userRepository = userRepository;
        }


        //PIZZAS
        public List<Pizza> GetAllPizzas() {
            List<User> users = _userRepository.GetAllUsers();
            var pizzas = new List<Pizza>();
            foreach (var user in users) {
                foreach (var order in user.Orders) {
                    pizzas.AddRange(order.Pizzas);
                }
            }
            return pizzas;
        }

        public Pizza? GetPizza(int pizzaId) => GetAllPizzas().FirstOrDefault(p => p.PizzaId == pizzaId);

        public List<Pizza> GetAllPizzasByOrder(int orderId) {
            List<User> users = _userRepository.GetAllUsers();
            var order = users.SelectMany(u => u.Orders).FirstOrDefault(o => o.OrderId == orderId);

            if (order != null) {
                return order.Pizzas;
            }else {
                throw new InvalidOperationException("Order not found");
            }
        }

        public void AddPizza(int orderId, Pizza pizza) {
            List<User> users = _userRepository.GetAllUsers();
            var order = users.SelectMany(u => u.Orders).FirstOrDefault(o => o.OrderId == orderId);

            if (order != null) {
                var pizzas = users.SelectMany(u => u.Orders.SelectMany(o => o.Pizzas.Select(p => p.PizzaId)));
                int maxId = pizzas.Any() ? pizzas.Max() : 0;
                pizza.PizzaId = ++maxId;
                // pizza.PizzaPrice = 5;
                order.Pizzas.Add(pizza);
                _userRepository.SaveToJson(users);
            }
        }

        public void DeletePizza(int pizzaId) {
            List<User> users = _userRepository.GetAllUsers();
            foreach (var user in users) {
                foreach (var order in user.Orders) {
                    var pizzaToRemove = order.Pizzas.FirstOrDefault(p => p.PizzaId == pizzaId);

                    if (pizzaToRemove != null) {
                        order.Pizzas.Remove(pizzaToRemove);
                    }
                }
            }
            _userRepository.SaveToJson(users);
        }

        public void UpdatePizza(Pizza pizza) {
            List<User> users = _userRepository.GetAllUsers();
            foreach (var user in users) {
                foreach (var order in user.Orders) {
                    var index = order.Pizzas.FindIndex(p => p.PizzaId == pizza.PizzaId);
                    if (index != -1) {
                        order.Pizzas[index] = pizza;
                    }
                }
            }

            _userRepository.SaveToJson(users);
        }


        //INGREDIENTS
        public List<Ingredient> GetAllIngredientsByPizza(int pizzaId) {
            var pizza = GetPizza(pizzaId);  
            return pizza?.Ingredients ?? new List<Ingredient>();
        }
        
        public List<Ingredient> GetAllIngredients() {
            List<User> users = _userRepository.GetAllUsers();
            var ingredients = users.SelectMany(u => u.Orders.SelectMany(o => o.Pizzas.SelectMany(p => p.Ingredients))).ToList();
            return ingredients;
        }

        public Ingredient GetIngredient(int ingredientId) {
            List<Ingredient> ingredients = GetAllIngredients();
            var ingredient = ingredients.FirstOrDefault(i => i.IngredientId == ingredientId);
    
            if (ingredient != null) {
                return ingredient;
            }else {
                throw new InvalidOperationException("Ingredient not found");
            }
        }

        public void AddIngredient(int pizzaId, Ingredient ingredient) {
            List<User> users = _userRepository.GetAllUsers();
            var pizzas = users.SelectMany(u => u.Orders.SelectMany(o => o.Pizzas)).ToList();
            var allIngredients = users.SelectMany(u => u.Orders.SelectMany(o => o.Pizzas.SelectMany(p => p.Ingredients))).ToList();
            var pizza = pizzas.FirstOrDefault(p => p.PizzaId == pizzaId);

            if (pizza != null) {
                var allIngredientIds = allIngredients.Select(i => i.IngredientId);
                int maxId = allIngredientIds.Any() ? allIngredientIds.Max() : 0;
                ingredient.IngredientId = ++maxId;
                pizza.PizzaPrice += ingredient.IngredientPrice;
                pizza.Ingredients.Add(ingredient);
                _userRepository.SaveToJson(users);
            }else {
                throw new InvalidOperationException("Pizza not found");
            }
        }

        public void DeleteIngredient(int ingredientId) {
            List<User> users = _userRepository.GetAllUsers();
            var pizza = users.SelectMany(u => u.Orders.SelectMany(o => o.Pizzas)).FirstOrDefault(p => p.Ingredients.Any(i => i.IngredientId == ingredientId));
            if (pizza != null) {
                var ingredient = pizza.Ingredients.FirstOrDefault(i => i.IngredientId == ingredientId);
                if (ingredient != null) {
                    pizza.PizzaPrice -= ingredient.IngredientPrice;
                    pizza.Ingredients.Remove(ingredient);
                    _userRepository.SaveToJson(users);
                } else {
                    throw new InvalidOperationException("Ingredient not found");
                }
            } else {
                throw new InvalidOperationException("Pizza not found");
            }
        }

        public void UpdateIngredient(int ingredientId, Ingredient updatedIngredient) {
            List<User> users = _userRepository.GetAllUsers();
            var pizza = users.SelectMany(u => u.Orders.SelectMany(o => o.Pizzas)).FirstOrDefault(p => p.Ingredients.Any(i => i.IngredientId == ingredientId));
            if (pizza != null) {
                var ingredient = pizza.Ingredients.FirstOrDefault(i => i.IngredientId == ingredientId);
                if (ingredient != null) {
                    ingredient.IngredientName = updatedIngredient.IngredientName;
                    ingredient.IngredientPrice = updatedIngredient.IngredientPrice;
                    pizza.PizzaPrice += ingredient.IngredientPrice;
                    ingredient.Calories = updatedIngredient.Calories;
                    ingredient.Carbohydrates = updatedIngredient.Carbohydrates;
                    ingredient.Proteins = updatedIngredient.Proteins;
                    ingredient.Fats = updatedIngredient.Fats;
                    ingredient.Fiber = updatedIngredient.Fiber;
                    ingredient.PizzaId = updatedIngredient.PizzaId;
                    _userRepository.SaveToJson(users);
                } else {
                    throw new InvalidOperationException("Ingredient not found in any pizza");
                }
            } else {
                throw new InvalidOperationException("Pizza not found");
            }
        }

    }
}