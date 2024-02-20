// using System.Text.Json;
// using ContosoPizza.Models;

// namespace ContosoPizza.Data {

//     public class PizzaRepository : IPizzaRepository {
//         private readonly string _fileData = "data.json";
//         private List<Pizza> Pizzas = new List<Pizza>();
//         private List<Ingredient> Ingredients = new List<Ingredient>();
//         private List<Order> Orders = new List<Order>();
//         private List<User> Users = new List<User>();
//         private int nextId = 1;
//         private int nextIdIngredient = 1;
//         private int nextIdOrder = 1;
//         private int nextIdUser = 1;

//         public PizzaRepository() {
//             Pizzas = LoadFromJson<Pizza>();
//             Ingredients = LoadFromJson<Ingredient>();
//             Orders = LoadFromJson<Order>();
//             Users = LoadFromJson<User>();
//         }

//         private void SaveToJson<T>(List<T> data) {
//             try {
//                 var options = new JsonSerializerOptions { WriteIndented = true };
//                 string jsonString = JsonSerializer.Serialize(data, options);
//                 File.WriteAllText(_fileData, jsonString);
//             }catch (Exception e) {
//                 Console.WriteLine($"Error: {e.Message}");
//             }
//         }
     
//         private List<T> LoadFromJson<T>() {
//             try {
//                 if (File.Exists(_fileData)) {
//                     var jsonString = File.ReadAllText(_fileData);
//                     return JsonSerializer.Deserialize<List<T>>(jsonString) ?? new List<T>();
//                 }else {
//                     return new List<T>();
//                 }
//             }catch (Exception e) {
//                 Console.WriteLine($"Error: {e.Message}");
//                 return new List<T>();
//             }
//         }

//         public List<Pizza> GetAllPizzas() => Pizzas;

//         public Pizza? GetPizza(int pizzaId) => Pizzas.FirstOrDefault(p => p.PizzaId == pizzaId);

//         public List<Pizza> GetPizzasForOrder(int orderId) {
//         var order = GetOrder(orderId);
//             if (order is null)
//                 return  new List<Pizza>();
            
//             return order.Pizzas;
//         }

//         public void AddPizza(Pizza pizza) {
//             pizza.PizzaId = nextId++;
//             Pizzas.Add(pizza);
//         }

//         public void DeletePizza(int pizzaId) {
//             var pizza = GetPizza(pizzaId);
//             if (pizza is null)
//                 return;

//             Pizzas.Remove(pizza);
//         }

//         public void UpdatePizza(Pizza pizza) {
//             var index = GetAllPizzas().FindIndex(p => p.PizzaId == pizza.PizzaId);
//             if(index == -1)
//                 return;

//             Pizzas[index] = pizza;
//         }

//         public void AddPizzaToOrder(int orderId, int pizzaId) {
//             var order = GetOrder(orderId);
//             var pizza = GetPizza(pizzaId);
//             if (pizza == null || order == null) {
//                 return;
//             }
//             order.TotalPrice += pizza.PizzaPrice; 
//             order.Pizzas?.Add(pizza);
//             UpdateOrder(order);
//         }


//         //INGREDIENTS
//         public List<Ingredient> GetAllIngredients() => Ingredients;
//         public Ingredient? GetIngredient(int ingredientId) => Ingredients.FirstOrDefault(i => i.IngredientId == ingredientId);

//         public List<Ingredient> GetIngredientsForPizza(int pizzaId) {
//         var pizza = GetPizza(pizzaId);
//             if (pizza is null)
//                 return  new List<Ingredient>();
            
//             return pizza.Ingredients;
//         }

//         public void AddIngredient(Ingredient ingredient) {
//             ingredient.IngredientId = nextIdIngredient++;
//             Ingredients.Add(ingredient);
//         }

//         public void DeleteIngredient(int ingredientId) {
//             var ingredient = GetIngredient(ingredientId);
//             if (ingredient is null)
//                 return;
//             Ingredients.Remove(ingredient);
//         }

//         public void UpdateIngredient(Ingredient ingredient) {
//             var index = Ingredients.FindIndex(i => i.IngredientId == ingredient.IngredientId);
//             if(index == -1)
//                 return;

//             Ingredients[index] = ingredient;
//         }

//         public void AddIngredientToPizza(int pizzaId, int ingredientId) {
//             var pizza = GetPizza(pizzaId);
//             var ingredient = GetIngredient(ingredientId);
//             if (pizza == null || ingredient == null) {
//                 return;
//             }
//             pizza.PizzaPrice += ingredient.IngredientPrice; 
//             pizza.Ingredients?.Add(ingredient);
//             UpdatePizza(pizza);
//         }


//         //ORDERS
//         public List<Order> GetAllOrders() => Orders;
//         public Order? GetOrder(int orderId) => Orders.FirstOrDefault(o => o.OrderId == orderId);

//         public List<Order> GetOrdersForUser(int userId) {
//         var user = GetUser(userId);
//             if (user is null)
//                 return new List<Order>();
            
//             return user.Orders;
//         }

//         public void AddOrder(Order order) {
//             order.OrderId = nextIdOrder++;
//             Orders.Add(order);
//         }

//         public void DeleteOrder(int orderId) {
//             var order = GetOrder(orderId);
//             if (order is null)
//                 return;

//             Orders.Remove(order);
//         }

//         public void UpdateOrder(Order order) {
//             var index = Orders.FindIndex(o => o.OrderId == order.OrderId);
//             if(index == -1)
//                 return;

//             Orders[index] = order;
//         }

//          public void AddOrderToUser(int orderId, int userId) {
//             var order = GetOrder(orderId);
//             var user = GetUser(userId);
//             if (order == null || user == null) {
//                 return;
//             }
//             order.UserName = user.UserName;
//             order.UserAddress = user.Address;
//             order.UserId = user.UserId;
//             user.Orders?.Add(order);
//             UpdateUser(user);
//         }


//         //USERS
//         public List<User> GetAllUsers() => Users;
//         public User? GetUser(int userId) => Users.FirstOrDefault(u => u.UserId == userId);

//         public void AddUser(User user) {
//             user.UserId = nextIdUser++;
//             Users.Add(user);
//             SaveToJson(Users);
//         }

//         public void DeleteUser(int userId) {
//             var user = GetUser(userId);
//             if (user is null)
//                 return;

//             Users.Remove(user);
//             SaveToJson(Users);
//         }

//         public void UpdateUser(User user) {
//             var index = Users.FindIndex(u => u.UserId == user.UserId);
//             if(index == -1)
//                 return;

//             Users[index] = user;
//             SaveToJson(Users);
//         }

//     }

// }