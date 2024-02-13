using System.Data.SqlClient;
using ContosoPizza.Models;

namespace ContosoPizza.Data {

    public class UserSqlRepository : IUserRepository {
        private readonly string _connectionString;

        public UserSqlRepository(string connectionString) {
            _connectionString = connectionString;
        }


        //USERS
        public List<User> GetAllUsers() {
            List<User> users = new List<User>();
            using (var connection = new SqlConnection(_connectionString)) {
                connection.Open();
                string sqlString = "SELECT * FROM Users";
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
                string sqlString = "SELECT * FROM Users WHERE UserId = @UserId";
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
                    Console.WriteLine($"Error to add user: {e.Message}");
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
                    Console.WriteLine($"Error to delete user: {e.Message}");
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
                    Console.WriteLine($"Error to update user: {e.Message}");
                }
            }
        }

        public List<Order> GetAllOrders() {
            List<Order> orders = new List<Order>();
            using (var connection = new SqlConnection(_connectionString)) {
                try {
                    connection.Open();
                    string sqlString = "SELECT * FROM Orders";
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
                    string sqlString = "SELECT * FROM Orders WHERE OrderId = @OrderId";
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

        public void AddOrder(int userId, Order order) {
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
                    Console.WriteLine($"Error to add order: {e.Message}");
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
                    Console.WriteLine($"Error to delete order: {e.Message}");
                }
            }
        }

        public void SaveToJson(List<User> users) {
        }

        public List<User> LoadFromJson() {
            return new List<User>();
        }

    }
}