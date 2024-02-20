using ContosoPizza.Models;
using System.Data.SqlClient;

namespace ContosoPizza.Data {

    public class PizzaSQLRepository : IPizzaRepository {
        private readonly string _connectionString;

        public PizzaSQLRepository(string connectionString) {
            _connectionString = connectionString;
        }


        //PIZZAS
        public List<Pizza> GetAllPizzas() {
            List<Pizza> pizzas = new List<Pizza>();
            using (var connection = new SqlConnection(_connectionString)) {
                connection.Open();
                string sqlString = "SELECT PizzaId, PizzaName, IsGlutenFree, PizzaPrice FROM Pizzas";
                var command = new SqlCommand(sqlString, connection);
                using (var reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        Pizza pizza = new Pizza {
                            PizzaId = (int)reader["PizzaId"],
                            PizzaName = reader["PizzaName"].ToString(),
                            IsGlutenFree = (bool)reader["IsGlutenFree"],
                            PizzaPrice = (decimal)reader["Address"]
                        };
                        pizzas.Add(pizza);
                    }
                }
            }
            return pizzas;
        }

        public Pizza? GetPizza(int pizzaId) {
            using (var connection = new SqlConnection(_connectionString)) {
                connection.Open();
                string sqlString = "SELECT PizzaId, PizzaName, IsGlutenFree, PizzaPrice FROM Pizzas WHERE PizzaId = @PizzaId";
                var command = new SqlCommand(sqlString, connection);
                command.Parameters.AddWithValue("@PizzaId", pizzaId);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader()) {
                    if (reader.Read()) {
                        Pizza pizza = new Pizza {
                            PizzaId = (int)reader["PizzaId"],
                            PizzaName = reader["PizzaName"].ToString(),
                            IsGlutenFree = (bool)reader["IsGlutenFree"],
                            PizzaPrice = (decimal)reader["Address"]
                        };
                        return pizza;
                    }
                }
            }
            return null;
        }

        public void AddPizza(Pizza pizza) {
            using (var connection = new SqlConnection(_connectionString)) {
                try {
                    connection.Open();
                    string sqlString = "INSERT INTO Pizzas (PizzaId, PizzaName, IsGlutenFree, PizzaPrice) VALUES (@PizzaId, @PizzaName, @IsGlutenFree, @PizzaPrice)";
                    var command = new SqlCommand(sqlString, connection);
                    command.Parameters.AddWithValue("@PizzaId", pizza.PizzaId);
                    command.Parameters.AddWithValue("@PizzaName", pizza.PizzaName);
                    command.Parameters.AddWithValue("@IsGlutenFree", pizza.IsGlutenFree);
                    command.Parameters.AddWithValue("@PizzaPrice", pizza.PizzaPrice);
                    command.ExecuteNonQuery();
                }catch (Exception e) {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

        public void DeletePizza(int pizzaId) {
            using (var connection = new SqlConnection(_connectionString)) {
                try {
                    connection.Open();
                    string sqlString = "DELETE FROM Pizzas WHERE PizzaId = @PizzaId";
                    var command = new SqlCommand(sqlString, connection);
                    command.Parameters.AddWithValue("@PizzaId", pizzaId);
                    command.ExecuteNonQuery();
                }catch (Exception e) {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

        public void UpdatePizza(Pizza pizza) {
            using (var connection = new SqlConnection(_connectionString)) {
                try {
                    connection.Open();
                    string sqlString = "UPDATE Pizzas SET PizzaId = @PizzaId, PizzaName = @PizzaName, IsGlutenFree = @IsGlutenFree, PizzaPrice = @PizzaPrice WHERE PizzaId = @PizzaId";
                    var command = new SqlCommand(sqlString, connection);
                    command.Parameters.AddWithValue("@PizzaId", pizza.PizzaId);
                    command.Parameters.AddWithValue("@PizzaName", pizza.PizzaName);
                    command.Parameters.AddWithValue("@IsGlutenFree", pizza.IsGlutenFree);
                    command.Parameters.AddWithValue("@PizzaPrice", pizza.PizzaPrice);
                    command.ExecuteNonQuery();
                }catch (Exception e) {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

        public List<Pizza> GetPizzasForOrder(int orderId) {
            List<Pizza> pizzas = new List<Pizza>();
            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                connection.Open();
                string sqlString = "SELECT P.* FROM Pizzas P JOIN Orders O ON P.OrderId = O.OrderId WHERE O.OrderId = @OrderId";
                var command = new SqlCommand(sqlString, connection);
                command.Parameters.AddWithValue("@OrderId", orderId);
                using (SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        Pizza pizza = new Pizza {
                            PizzaId = (int)reader["PizzaId"],
                            PizzaName = reader["PizzaName"].ToString(),
                            IsGlutenFree = (bool)reader["IsGlutenFree"],
                            PizzaPrice = (decimal)reader["Address"]
                        };
                        pizzas.Add(pizza);
                    }
                }
            }
            return pizzas;
        }

         public List<Order> GetOrdersForUser(int userId) {
            List<Order> orders = new List<Order>();
            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                connection.Open();
                string sqlString = "SELECT O.* FROM Orders O JOIN Users U ON O.UserId = U.UserId WHERE U.UserId = @UserId";
                var command = new SqlCommand(sqlString, connection);
                command.Parameters.AddWithValue("@UserId", userId);
                using (SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        Order order = new Order {
                            OrderId = (int)reader["OrderId"],
                            TotalPrice = (decimal)reader["TotalPrice"],
                            UserName = reader["UserName"].ToString(),
                            UserAddress = reader["Address"].ToString(),
                            UserId = (int)reader["UserId"]
                        };
                        orders.Add(order);
                    }
                }
            }
            return orders;
        }

        public void AddPizzaToOrder(int orderId, int pizzaId) {
            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                connection.Open();
                string sqlString = "INSERT INTO OrdersPizzas (OrderId, PizzaId) VALUES (@OrderId, @PizzaId)";
                var command = new SqlCommand(sqlString, connection);
                command.Parameters.AddWithValue("@OrderId", orderId);
                command.Parameters.AddWithValue("@PizzaId", pizzaId);
                command.ExecuteNonQuery();
            }
        }


        //INGREDIENTS
        public List<Ingredient> GetAllIngredients() {
            List<Ingredient> ingredients = new List<Ingredient>();
            using (var connection = new SqlConnection(_connectionString)) {
                connection.Open();
                string sqlString = "SELECT IngredientId, IngredientName, IngredientPrice, Calories, Carbohydrates, Proteins, Fats, Fiber FROM Ingredients";
                var command = new SqlCommand(sqlString, connection);
                using (var reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        Ingredient ingredient = new Ingredient {
                            IngredientId = (int)reader["IngredientId"],
                            IngredientName = reader["IngredientName"].ToString(),
                            IngredientPrice = (decimal)reader["IngredientPrice"],
                            Calories = (int)reader["Calories"],
                            Carbohydrates = (int)reader["Carbohydrates"],
                            Proteins = (int)reader["Proteins"],
                            Fats = (int)reader["Fats"],
                            Fiber = (int)reader["Fiber"]
                        };
                        ingredients.Add(ingredient);
                    }
                }
            }
            return ingredients;
        }

        public Ingredient? GetIngredient(int ingredientId) {
            using (var connection = new SqlConnection(_connectionString)) {
                connection.Open();
                string sqlString = "SELECT IngredientId, IngredientName, IngredientPrice, Calories, Carbohydrates, Proteins, Fats, Fiber FROM Ingredients WHERE IngredientId = @IngredientId";
                var command = new SqlCommand(sqlString, connection);
                command.Parameters.AddWithValue("@IngredientId", ingredientId);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader()) {
                    if (reader.Read()) {
                        Ingredient ingredient = new Ingredient {
                            IngredientId = (int)reader["IngredientId"],
                            IngredientName = reader["IngredientName"].ToString(),
                            IngredientPrice = (decimal)reader["IngredientPrice"],
                            Calories = (int)reader["Calories"],
                            Carbohydrates = (int)reader["Carbohydrates"],
                            Proteins = (int)reader["Proteins"],
                            Fats = (int)reader["Fats"],
                            Fiber = (int)reader["Fiber"]
                        };
                        return ingredient;
                    }
                }
            }
            return null;
        }

        public void AddIngredient(Ingredient ingredient) {
            using (var connection = new SqlConnection(_connectionString)) {
                try {
                    connection.Open();
                    string sqlString = "INSERT INTO Ingredients (IngredientId, IngredientName, IngredientPrice, Calories, Carbohydrates, Proteins, Fats, Fiber) VALUES (@IngredientId, @IngredientName, @IngredientPrice, @Calories, @Carbohydrates, @Proteins, @Fats, @Fiber)";
                    var command = new SqlCommand(sqlString, connection);
                    command.Parameters.AddWithValue("@IngredientId", ingredient.IngredientId);
                    command.Parameters.AddWithValue("@IngredientName", ingredient.IngredientName);
                    command.Parameters.AddWithValue("@IngredientPrice", ingredient.IngredientPrice);
                    command.Parameters.AddWithValue("@Calories", ingredient.Calories);
                    command.Parameters.AddWithValue("@Carbohydrates", ingredient.Carbohydrates);
                    command.Parameters.AddWithValue("@Proteins", ingredient.Proteins);
                    command.Parameters.AddWithValue("@Fats", ingredient.Fats);
                    command.Parameters.AddWithValue("@Fiber", ingredient.Fiber);
                    command.ExecuteNonQuery();
                }catch (Exception e) {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

        public void DeleteIngredient(int ingredientId) {
            using (var connection = new SqlConnection(_connectionString)) {
                try {
                    connection.Open();
                    string sqlString = "DELETE FROM Ingredients WHERE Ingredient = @IngredientId";
                    var command = new SqlCommand(sqlString, connection);
                    command.Parameters.AddWithValue("@IngredientId", ingredientId);
                    command.ExecuteNonQuery();
                }catch (Exception e) {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

        public void UpdateIngredient(Ingredient ingredient) {
            using (var connection = new SqlConnection(_connectionString)) {
                try {
                    connection.Open();
                    string sqlString = "UPDATE Ingredients SET IngredientId = @IngredientId, IngredientName = @IngredientName, IngredientPrice = @IngredientPrice, Calories = @Calories, Carbohydrates = @Carbohydrates, Proteins = @Proteins, Fats = @Fats, Fiber = @Fiber WHERE IngredientId = @IngredientId";
                    var command = new SqlCommand(sqlString, connection);
                    command.Parameters.AddWithValue("@IngredientId", ingredient.IngredientId);
                    command.Parameters.AddWithValue("@IngredientName", ingredient.IngredientName);
                    command.Parameters.AddWithValue("@IngredientPrice", ingredient.IngredientPrice);
                    command.Parameters.AddWithValue("@Calories", ingredient.Calories);
                    command.Parameters.AddWithValue("@Carbohydrates", ingredient.Carbohydrates);
                    command.Parameters.AddWithValue("@Proteins", ingredient.Proteins);
                    command.Parameters.AddWithValue("@Fats", ingredient.Fats);
                    command.Parameters.AddWithValue("@Fiber", ingredient.Fiber);
                    command.ExecuteNonQuery();
                }catch (Exception e) {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

        public List<Ingredient> GetIngredientsForPizza(int pizzaId) {
            List<Ingredient> ingredients = new List<Ingredient>();
            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                connection.Open();
                string sqlString = "SELECT IngredientId, IngredientName, IngredientPrice, Calories, Carbohydrates, Proteins, Fats, Fiber FROM Ingredients WHERE PizzaId = @PizzaId";
                var command = new SqlCommand(sqlString, connection);
                command.Parameters.AddWithValue("@PizzaId", pizzaId);
                using (var reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        Ingredient ingredient = new Ingredient {
                            IngredientId = (int)reader["IngredientId"],
                            IngredientName = reader["IngredientName"].ToString(),
                            IngredientPrice = (decimal)reader["IngredientPrice"],
                            Calories = (int)reader["Calories"],
                            Carbohydrates = (int)reader["Carbohydrates"],
                            Proteins = (int)reader["Proteins"],
                            Fats = (int)reader["Fats"],
                            Fiber = (int)reader["Fiber"]
                        };
                        ingredients.Add(ingredient);
                    }
                }
            }
            return ingredients;
        }

        public void AddIngredientToPizza(int orderId, int pizzaId) {
            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                connection.Open();
                string sqlString = "INSERT INTO IngredientsPizzas (OrderId, PizzaId) VALUES (@OrderId, @PizzaId)";
                var command = new SqlCommand(sqlString, connection);
                command.Parameters.AddWithValue("@OrderId", orderId);
                command.Parameters.AddWithValue("@PizzaId", pizzaId);
                command.ExecuteNonQuery();
            }
        }

        //ORDERS
        public List<Order> GetAllOrders() {
            List<Order> orders = new List<Order>();
            using (var connection = new SqlConnection(_connectionString)) {
                try {
                    connection.Open();
                    string sqlString = "SELECT OrderId, TotalPrice, UserName, UserAddress, UserId FROM Orders";
                    var command = new SqlCommand(sqlString, connection);
                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            Order order = new Order {
                                OrderId = (int)reader["OrderId"],
                                TotalPrice = (decimal)reader["TotalPrice"],
                                UserName = reader["UserName"].ToString(),
                                UserAddress = reader["Address"].ToString(),
                                UserId = (int)reader["UserId"]
                            };
                            orders.Add(order);
                        }
                    }
                }catch (Exception e) {
                    Console.WriteLine($"Error: {e.Message}");
                }
            return orders;
            }
        }

        public Order? GetOrder(int orderId) {
            using (var connection = new SqlConnection(_connectionString)) {
                try {
                    connection.Open();
                    string sqlString = "SELECT OrderId, TotalPrice, UserName, UserAddress, UserId FROM Orders WHERE OrderId = @OrderId";
                    var command = new SqlCommand(sqlString, connection);
                    command.Parameters.AddWithValue("@OrderId", orderId);
                    using (var reader = command.ExecuteReader()) {
                        if (reader.Read()) {
                            Order order = new Order {
                                OrderId = (int)reader["OrderId"],
                                TotalPrice = (decimal)reader["TotalPrice"],
                                UserName = reader["UserName"].ToString(),
                                UserAddress = reader["Address"].ToString(),
                                UserId = (int)reader["UserId"]
                            };
                            return order;
                        }
                    }
                }catch (Exception e) {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
            return null;
        }

        public void AddOrder(Order order) {
            using (var connection = new SqlConnection(_connectionString)) {
                try {
                    connection.Open();
                    string sqlString = "INSERT INTO Orders (OrderId, TotalPrice, UserName, UserAddress, UserId) VALUES (@OrderId, @TotalPrice, @UserName, @UserAddress, @UserId)";
                    var command = new SqlCommand(sqlString, connection);
                    command.Parameters.AddWithValue("@OrderId", order.OrderId);
                    command.Parameters.AddWithValue("@TotalPrice", order.TotalPrice);
                    command.Parameters.AddWithValue("@UserName", order.UserName);
                    command.Parameters.AddWithValue("@UserAddress", order.UserAddress);
                    command.Parameters.AddWithValue("@UserId", order.UserId);
                    command.ExecuteNonQuery();
                }catch (Exception e) {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

        public void DeleteOrder(int orderId) {
            using (var connection = new SqlConnection(_connectionString)) {
                try {
                    connection.Open();
                    string sqlString = "DELETE FROM Orders WHERE OrderId = @OrderId";
                    var command = new SqlCommand(sqlString, connection);
                    command.Parameters.AddWithValue("@OrderId", orderId);
                    command.ExecuteNonQuery();
                }catch (Exception e) {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

        public void UpdateOrder(Order order) {
            using (var connection = new SqlConnection(_connectionString)) {
                try {
                    connection.Open();
                    string sqlString = "UPDATE Orders SET OrderId = @OrderId, TotalPrice = @TotalPrice, UserId = @UserId, UserName = @UserName, UserAddress = @UserAddress WHERE OrderId = @OrderId";
                    var command = new SqlCommand(sqlString, connection);
                    command.Parameters.AddWithValue("@OrderId", order.OrderId);
                    command.Parameters.AddWithValue("@TotalPrice", order.TotalPrice);
                    command.Parameters.AddWithValue("@UserId", order.UserId);
                    command.Parameters.AddWithValue("@UserName", order.UserName);
                    command.Parameters.AddWithValue("@UserAddress", order.UserAddress);
                    command.ExecuteNonQuery();
                }catch (Exception e) {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

        public void AddOrderToUser(int userId, int orderId) {
            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                connection.Open();
                string sqlString = "INSERT INTO OrdersUsers (UserId, OrderId) VALUES (@UserId, @OrderId)";
                var command = new SqlCommand(sqlString, connection);
                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@OrderId", orderId);
                command.ExecuteNonQuery();
            }
        }

        //USERS
        public List<User> GetAllUsers() {
            List<User> users = new List<User>();
            using (var connection = new SqlConnection(_connectionString)) {
                connection.Open();
                string sqlString = "SELECT UserId, UserName, UserLastname, Address, Email, PhoneNumber FROM Users";
                var command = new SqlCommand(sqlString, connection);
                using (var reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        User user = new User {
                            UserId = (int)reader["UserId"],
                            UserName = reader["UserName"].ToString(),
                            UserLastname = reader["UserLastname"].ToString(),
                            Address = reader["Address"].ToString(),
                            Email = reader["Email"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString()
                        };
                        users.Add(user);
                    }
                }
            }
            return users;
        }

        public User? GetUser(int userId) {
            using (var connection = new SqlConnection(_connectionString)) {
                connection.Open();
                string sqlString = "SELECT UserId, UserName, UserLastname, Address, Email, PhoneNumber FROM Users WHERE UserId = @UserId"; 
                var command = new SqlCommand(sqlString, connection);
                command.Parameters.AddWithValue("@UserId", userId);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader()) {
                    if (reader.Read()) {
                        User user = new User {
                            UserId = (int)reader["UserId"],
                            UserName = reader["UserName"].ToString(),
                            Address = reader["Address"].ToString(),
                            Email = reader["Email"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString()
                        };
                        return user;
                    }
                }
            }
            return null;
        }

        public void AddUser(User user) {
            using (var connection = new SqlConnection(_connectionString)) {
                try {
                    connection.Open();
                    string sqlString = "INSERT INTO Users (UserId, UserName, Address, Email, PhoneNumber) VALUES (@UserId, @UserName, @Address, @Email, @PhoneNumber)";
                    var command = new SqlCommand(sqlString, connection);
                    command.Parameters.AddWithValue("@UserId", user.UserId);
                    command.Parameters.AddWithValue("@UserName", user.UserName);
                    command.Parameters.AddWithValue("@Address", user.Address);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                    command.ExecuteNonQuery();
                }catch (Exception e) {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

        public void DeleteUser(int userId) {
            using (var connection = new SqlConnection(_connectionString)) {
                try {
                    connection.Open();
                    string sqlString = "DELETE FROM Users WHERE UserId = @UserId";
                    var command = new SqlCommand(sqlString, connection);
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.ExecuteNonQuery();
                }catch (Exception e) {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

        public void UpdateUser(User user) {
            using (var connection = new SqlConnection(_connectionString)) {
                try {
                    connection.Open();
                    string sqlString = "UPDATE Users SET UserName = @UserName, Address = @Address, Email = @Email, PhoneNumber = @PhoneNumber WHERE UserId = @UserId";
                    var command = new SqlCommand(sqlString, connection);
                    command.Parameters.AddWithValue("@UserId", user.UserId);
                    command.Parameters.AddWithValue("@UserName", user.UserName);
                    command.Parameters.AddWithValue("@Address", user.Address);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                    command.ExecuteNonQuery();
                }catch (Exception e) {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }
    }
}