using ContosoPizza.Models;
using ContosoPizza.Data;

namespace ContosoPizza.Business {

    public class UserService : IUserService {

        private readonly IPizzaRepository _repository;

        public UserService(IPizzaRepository repository) {
            _repository = repository;
        }


        //USERS
        // public List<User> GetAllUsers() => _repository.LoadUsers();
        // public User? GetUserById(int id) => _repository.LoadUsers().FirstOrDefault(u => u.Id == id);
        // public void AddUser(User user) {
        //     var users = _repository.LoadUsers();
        //     user.Id = users.Count > 0 ? users.Max(u => u.Id) + 1 : 1;
        //     users.Add(user);
        //     _repository.SaveUsers(users);
        // }

        public List<User> GetAllUsers() {
            return _repository.GetUsers();
        }

        public User? GetUserById(int id) {
            return _repository.GetUserById(id);
        }

        public void CreateUser(User user) {
            _repository.AddUser(user);
        }
        


        

 

        public void DeleteUser(int id) {
            var users = _repository.LoadUsers();
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user != null) {
                users.Remove(user);
                _repository.SaveUsers(users);
            }
        }

        public void UpdateUser(User user) {
            var users = _repository.LoadUsers();
            var index = users.FindIndex(u => u.Id == user.Id);
            if (index != -1) {
                users[index] = user;
                _repository.SaveUsers(users);
            }
        }


        //ORDERS
        public List<Order> GetAllOrders() {
            var users = _repository.LoadUsers();
            var allOrders = users.SelectMany(u => u.Orders).ToList();
            return allOrders;
        }

        public Order? GetOrderById(int orderId) {
            var users = _repository.LoadUsers();
            var order = users.SelectMany(u => u.Orders).FirstOrDefault(o => o.Id == orderId);

            return order;
        }

        public void AddOrder(int userId, Order order) {
            var users = _repository.LoadUsers();
            var user = users.FirstOrDefault(u => u.Id == userId);

            if (user != null) {
                order.Id = user.Orders.Count > 0 ? user.Orders.Max(o => o.Id) + 1 : 1;
                order.UserName = user.Name;
                order.UserAddress = user.Address;
                user.Orders.Add(order);
                _repository.SaveUsers(users);
            }else {
                throw new InvalidOperationException("User not found");
            }
        }

        public void DeleteOrder(int orderId) {
            var users = _repository.LoadUsers();
            var userWithOrder = users.FirstOrDefault(u => u.Orders.Any(o => o.Id == orderId));

            if (userWithOrder != null) {
                var orderToRemove = userWithOrder.Orders.First(o => o.Id == orderId);
                userWithOrder.Orders.Remove(orderToRemove);
                _repository.SaveUsers(users);
            }else {
                throw new InvalidOperationException("Order not found");
            }
        }

    }

}