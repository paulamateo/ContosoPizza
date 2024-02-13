using ContosoPizza.Data;
using ContosoPizza.Models;

namespace ContosoPizza.Business {

    public class UserService : IUserService {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) {
            _userRepository = userRepository;
        }


        //USERS
        public List<User> GetAllUsers() => _userRepository.GetAllUsers();

        public User? GetUser(int userId) => _userRepository.GetUser(userId);

        public void CreateUser(User newUser) {
            List<User> _users = GetAllUsers();
            newUser.UserId = _users.Count > 0 ? _users.Max (u => u.UserId) + 1 : 1;
            _userRepository.AddUser(newUser);
        }

        public void DeleteUser(int userId) => _userRepository.DeleteUser(userId);

        public void UpdateUser(User user) => _userRepository.UpdateUser(user);


        //ORDERS
        public List<Order> GetAllOrders() => _userRepository.GetAllOrders();
        public Order? GetOrder(int orderId) => _userRepository.GetOrder(orderId);

        public void CreateOrder(int userId, Order order) {
            try {
                _userRepository.AddOrder(userId, order);
            }catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        public void DeleteOrder(int orderId) {
            try {
                _userRepository.DeleteOrder(orderId);
            }catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

    }

}