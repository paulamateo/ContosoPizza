using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Data {

    public class UserEFRepository : IUserRepository {
        private readonly DataContext _context;

        public UserEFRepository(DataContext context) {
            _context = context;
        }

        // public void SaveToJson(List<User> users) {
        //     _context.SaveToJson();
        // }

        // public List<User> LoadFromJson() {
        //     _context.LoadFromJson();
        // }

        //USERS
        // public List<User> GetAllUsers() {
        //     return LoadFromJson();
        // }

        public void AddUser(User user) {
            _context.Users.Add(user);
            // SaveToJson();
        }

        public User? GetUser(int userId) {
            return _context.Users.FirstOrDefault(u => u.UserId == userId);
        }

        public void UpdateUser(User user) {
            _context.Entry(user).State = EntityState.Modified;
        }

        public void DeleteUser(int userId) {
            var user = GetUser(userId);
            if (user is null) {
                throw new KeyNotFoundException("User not found.");
            }
            _context.Users.Remove(user);
            SaveToJson();
        }

        //ORDERS
        public List<Order> GetAllOrders() {
            return _context.Orders();
        }

        public void AddOrder(int userId, Order order) {
            var user = GetUser(userId);
            if (user is null) {
                throw new KeyNotFoundException("User not found.");
            }else {
                _context.Orders.Add(order);
                SaveToJson();
            }
        }

        public Order? GetOrder(int orderId) {
            return _context.Orders.FirstOrDefault(o => o.OrderId == orderId);
        }

        public void DeleteOrder(int orderId) {
            var order = GetOrder(orderId);
            if (order is null) {
                throw new KeyNotFoundException("Order not found.");
            }
            _context.Orders.Remove(order);
            SaveToJson();
        }

    }

}