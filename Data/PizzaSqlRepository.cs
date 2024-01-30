using ContosoPizza.Models;
using System.Data.SqlClient;
using System.Text.Json;
using System.Data;


namespace ContosoPizza.Data {

    public class PizzaSqlRepository {
        private readonly string _connectionString;

        public PizzaSqlRepository(string connectionString) {
            _connectionString = connectionString;
        }

        public void AddPizza(Pizza pizza) {
            //INSERT INTO SQL STRING
            using (var connection = new SqlConnection(_connectionString)) {
                connection.Open();

                var sqlString = "INSERT INTO Pizzas(Id, Name, IsGlutenFree, Price) VALUES (Id, Name, IsGlutenFree, Price)";
                var command = new SqlCommand(sqlString, connection);


            }

        }

        public Pizza GetPizza(string id) {
            var pizza = new Pizza();

            using (var connection = new SqlConnection(_connectionString)) {
                connection.Open();

                var sqlString = "SELECT Id, Name FROM Pizzas WHERE Id=" + id;
                var command = new SqlCommand(sqlString, connection);

                using (var reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        pizza = new Pizza {
                            Id = (int)reader["Id"],
                            Name = reader["Name"].ToString()
                        };
                    }
                }

            }

            return pizza;
        }


        // public Pizza GetPizza(string ) {
    
        // }

        public void UpdatePizza(Pizza pizza) {
            //UPDATE SQL STRING
        }

        public void SaveChanges() {
            //DO NOTHING (BY NOW)
        }

    }

}