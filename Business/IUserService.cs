using ContosoPizza.Models;

namespace ContosoPizza.Business {

    public interface IUserService {
        List<User> GetAllUsers();
        User? GetUser(int userId);
        void CreateUser(User newUser);
        void DeleteUser(int userId);
        void UpdateUser(User user);
        List<Order> GetAllOrders();
        Order? GetOrder(int orderId);
        void CreateOrder(int userId, Order order);
        void DeleteOrder(int orderId);
    }

}