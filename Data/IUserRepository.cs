using ContosoPizza.Models;

namespace ContosoPizza.Data {

    public interface IUserRepository {
        void SaveToJson(List<User> users);
        List<User> LoadFromJson();
        List<User> GetAllUsers();
        User? GetUser(int userId);
        void AddUser(User user);
        void DeleteUser(int userId);
        void UpdateUser(User user);
        List<Order> GetAllOrders();
        Order? GetOrder(int orderId);
        void AddOrder(int userId, Order order);
        void DeleteOrder(int orderId);

    }

}