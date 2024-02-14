using System.Text.Json;
using ContosoPizza.Models;

namespace ContosoPizza.Data {

    public class UserRepository : IUserRepository {
        private readonly string _fileData = "data.json";

        public void SaveToJson(List<User> users) {
            try {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(users, options);
                File.WriteAllText(_fileData, jsonString);
            }catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        public List<User> LoadFromJson() {
            try {
                if (File.Exists(_fileData)) {
                    var jsonString = File.ReadAllText(_fileData);
                    return JsonSerializer.Deserialize<List<User>>(jsonString) ?? new List<User>();
                }else {
                    return new List<User>();
                }
            }catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
                return new List<User>();
            }
        }


        //USERS
        public List<User> GetAllUsers() => LoadFromJson();

        public User? GetUser(int userId) => LoadFromJson().FirstOrDefault(u => u.UserId == userId);

        public void AddUser(User user) {
            var users = LoadFromJson();
            users.Add(user);
            SaveToJson(users);
        }

        public void DeleteUser(int userId) {
            var users = LoadFromJson();
            var user = users.FirstOrDefault(u => u.UserId == userId);
            if (user != null)
                users.Remove(user);
            SaveToJson(users);
        }

        public void UpdateUser(User user) {
            var users = LoadFromJson();
            var index = users.FindIndex(u => u.UserId == user.UserId);
            if (index != -1) {
                users[index] = user;
                SaveToJson(users);
            }
        }


        //ORDERS
        public List<Order> GetAllOrders() {
            List<User> users = GetAllUsers();
            var orders = users.SelectMany(u => u.Orders).ToList();
            return orders;
        }

        public Order? GetOrder(int orderId) {
            List<User> users = GetAllUsers();
            var order = users.SelectMany(u => u.Orders).FirstOrDefault(o => o.OrderId == orderId);
            return order;
        }

        public void AddOrder(int userId, Order order) {
            var users = LoadFromJson();
            var user = users.FirstOrDefault(u => u.UserId == userId);
            
            if (user != null) {
                var orders = users.SelectMany(u => u.Orders.Select(o => o.OrderId));
                int maxId = orders.Any() ? orders.Max() : 0;
                order.OrderId = ++maxId;
                order.UserName = user.UserName;
                order.UserAddress = user.Address;
                user.Orders.Add(order);
                SaveToJson(users);
            }else {
                throw new InvalidOperationException("User not found");
            }
        }

        public void DeleteOrder(int orderId) {
            var users = LoadFromJson();
            var user = users.FirstOrDefault(u => u.Orders.Any(o => o.OrderId == orderId));

            if (user != null) {
                var orderToRemove = user.Orders.First(o => o.OrderId == orderId);
                user.Orders.Remove(orderToRemove);
                SaveToJson(users);
            }else {
                throw new InvalidOperationException("Order not found");
            }
        }

    }

}