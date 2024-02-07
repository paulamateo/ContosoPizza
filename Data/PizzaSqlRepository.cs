using ContosoPizza.Models;
using ContosoPizza.Data;
using System.Data.SqlClient;

namespace ContosoPizza.Data { 

    public class PizzaSqlRepository {

        private readonly string _connectionString;

        public PizzaSqlRepository(string connectionString) {
            _connectionString = connectionString;
        }


        public User GetUser(string id) {
            var user = new User();

            using (var connection = new SqlConnection(_connectionString)) {
                connection.Open();

                var sqlString = "SELECT UserId, Name FROM Users WHERE UserId=" + id;
                var command = new SqlCommand(sqlString, connection);

                using (var reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        user = new User {
                            UserId = Convert.ToInt32(reader["UserId"]),
                            Name = reader["Name"].ToString(),
                        };
                    }
                }    
            }
            return user;
        }

    }

}
