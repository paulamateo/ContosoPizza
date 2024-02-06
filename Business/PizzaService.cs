using ContosoPizza.Models;
using ContosoPizza.Data;

namespace ContosoPizza.Business {
    public class PizzaService : IPizzaService {

        private readonly IPizzaRepository _repository;

        public PizzaService(IPizzaRepository repository) {
            _repository = repository;

        }


        //PIZZAS
        public List<Pizza> GetAllPizzas() => _repository.LoadPizzas();

        public Pizza? GetPizzaById(int id) => _repository.LoadPizzas().FirstOrDefault(p => p.Id == id);

        public void AddPizza(int orderId, Pizza pizza) {
            var users = _repository.LoadUsers();
            var order = users.SelectMany(u => u.Orders).FirstOrDefault(o => o.Id == orderId);

            if (order != null) {
                pizza.Id = order.Pizzas.Count > 0 ? order.Pizzas.Max(p => p.Id) + 1 : 1;
                pizza.Price = 5;
                order.Pizzas.Add(pizza);
                _repository.SavePizzas(order.Pizzas);
                _repository.SaveUsers(users);
            }
        }

        public void DeletePizza(int id) {
            var users = _repository.LoadUsers();
            var pizzas = _repository.LoadPizzas();

            foreach (var user in users) {
                foreach (var order in user.Orders) {
                    var pizzaToRemove = order.Pizzas.FirstOrDefault(p => p.Id == id);

                    if (pizzaToRemove != null) {
                        order.Pizzas.Remove(pizzaToRemove);
                    }
                }
            }

            var pizza = pizzas.FirstOrDefault(p => p.Id == id);
            if (pizza != null) {
                foreach (var user in users) {
                    foreach (var order in user.Orders) {
                        order.Pizzas.Remove(pizza);
                    }
                }
                pizzas.Remove(pizza);
            }

            _repository.SavePizzas(pizzas);
            _repository.SaveUsers(users);
        }

        public void UpdatePizza(Pizza pizza) {
            var users = _repository.LoadUsers();
            var pizzas = _repository.LoadPizzas();

            foreach (var user in users) {
                foreach (var order in user.Orders) {
                    var index = order.Pizzas.FindIndex(p => p.Id == pizza.Id);
                    if (index != -1) {
                        order.Pizzas[index] = pizza;
                    }
                }
            }

            var pizzaIndex = pizzas.FindIndex(p => p.Id == pizza.Id);
            if (pizzaIndex != -1) {
                pizzas[pizzaIndex] = pizza;
                _repository.SavePizzas(pizzas);
                _repository.SaveUsers(users);
            }
        }


        //INGREDIENTS
        public List<Ingredient> GetAllIngredients(int pizzaId) {
            var pizza = GetPizzaById(pizzaId);  
            return pizza?.Ingredients ?? new List<Ingredient>();
        }

        public Ingredient? GetIngredientById(int pizzaId, int ingredientId) {
            var pizza = GetPizzaById(pizzaId);

            if (pizza != null) {
                var ingredient = pizza.Ingredients.FirstOrDefault(i => i.Id == ingredientId); 
                return ingredient;
            } else {
                return null;
            }
        }

        public void AddIngredient(int pizzaId, Ingredient ingredient) {
            var pizza = GetPizzaById(pizzaId);

            if (pizza != null) {
                ingredient.Id = pizza.Ingredients.Count > 0 ? pizza.Ingredients.Max(i => i.Id) + 1 : 1;
                pizza.Ingredients.Add(ingredient);
                pizza.Price += ingredient.Price;
                UpdatePizza(pizza);
            }
        }

        public void DeleteIngredient(int pizzaId, int ingredientId) {
            var pizza = GetPizzaById(pizzaId);

            if (pizza != null) {
                var ingredient = pizza.Ingredients.FirstOrDefault(i => i.Id == ingredientId);

                if (ingredient != null) {
                    pizza.Ingredients.Remove(ingredient);
                    pizza.Price -= ingredient.Price;
                    UpdatePizza(pizza);
                }
            }
        }
        
        public void UpdateIngredient(int pizzaId, int ingredientId, Ingredient updatedIngredient) {
            var pizza = GetPizzaById(pizzaId);

            if (pizza != null) {
                var existingIngredient = pizza.Ingredients.FirstOrDefault(i => i.Id == ingredientId);

                if (existingIngredient != null) {
                    existingIngredient.Name = updatedIngredient.Name;
                    existingIngredient.Price = updatedIngredient.Price;
                    existingIngredient.Calories = updatedIngredient.Calories;
                    existingIngredient.Carbohydrates = updatedIngredient.Carbohydrates;
                    existingIngredient.Proteins = updatedIngredient.Proteins;
                    existingIngredient.Fats = updatedIngredient.Fats;
                    existingIngredient.Fiber = updatedIngredient.Fiber;

                    UpdatePizza(pizza);
                }
            }
        }

    }
     
}