using System.Data.SqlClient;
using ContosoPizza.Models;

namespace ContosoPizza.Data {

    public class PizzaSqlRepository : IPizzaRepository {
        private readonly string _connectionString;

        public PizzaSqlRepository(string connectionString) {
            _connectionString = connectionString;
        }


        //PIZZAS
        public List<Pizza> GetAllPizzas() {
            List<Pizza> pizzas = new List<Pizza>();
            using (var connection = new SqlConnection(_connectionString)) {
                try {
                    connection.Open();
                    string sqlString = @"SELECT P.PizzaId, P.PizzaName, P.PizzaPrice, P.IsGlutenFree, P.OrderId FROM Pizzas P INNER JOIN OrdersPizza OP ON P.PizzaId = OP.PizzaId INNER JOIN Orders O ON OP.OrderId = O.OrderId INNER JOIN Users U ON O.UserId = U.UserId";
                                
                    var command = new SqlCommand(sqlString, connection);
                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            Pizza pizza = new Pizza {
                                PizzaId = (int)reader["PizzaId"],
                                PizzaName = reader["PizzaName"].ToString(),
                                IsGlutenFree = (bool)reader["IsGlutenFree"],
                                PizzaPrice = (decimal)reader["PizzaPrice"],
                                OrderId = (int)reader["OrderId"]
                            };
                            pizzas.Add(pizza);
                        }
                    }
                }catch (Exception e) {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
            return pizzas;
        }

        public Pizza? GetPizza(int pizzaId) {
            using (var connection = new SqlConnection(_connectionString)) {
                try {
                    connection.Open();
                    string sqlString = @"SELECT PizzaId, PizzaName, PizzaPrice, IsGlutenFree, OrderId FROM Pizzas WHERE PizzaId = @PizzaId";   
                    var command = new SqlCommand(sqlString, connection);
                    command.Parameters.AddWithValue("@PizzaId", pizzaId);
                    using (var reader = command.ExecuteReader()) {
                        if (reader.Read()) {
                            Pizza pizza = new Pizza {
                                PizzaId = (int)reader["PizzaId"],
                                PizzaName = reader["PizzaName"].ToString(),
                                IsGlutenFree = (bool)reader["IsGlutenFree"],
                                PizzaPrice = (decimal)reader["PizzaPrice"],
                                OrderId = (int)reader["OrderId"]
                            };
                            return pizza;
                        }
                    }
                }catch (Exception e) {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
            return null;
        }

        public List<Pizza> GetAllPizzasByOrder(int orderId) {
            List<Pizza> pizzas = new List<Pizza>();
            using (var connection = new SqlConnection(_connectionString)) {
                try {
                    connection.Open();
                    string sqlString = @"SELECT P.PizzaId, P.PizzaName, P.PizzaPrice, P.IsGlutenFree, P.OrderId FROM Pizzas P INNER JOIN OrdersPizza OP ON P.PizzaId = OP.PizzaId WHERE OP.OrderId = @OrderId";  
                    var command = new SqlCommand(sqlString, connection);
                    command.Parameters.AddWithValue("@OrderId", orderId);
                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            Pizza pizza = new Pizza {
                                PizzaId = (int)reader["PizzaId"],
                                PizzaName = reader["PizzaName"].ToString(),
                                IsGlutenFree = (bool)reader["IsGlutenFree"],
                                PizzaPrice = (decimal)reader["PizzaPrice"],
                                OrderId = (int)reader["OrderId"]
                            };
                            pizzas.Add(pizza);
                        }
                    }
                } catch (Exception e) {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
            return pizzas;
        }

    }

}