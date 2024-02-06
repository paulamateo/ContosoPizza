using ContosoPizza.Models;
using ContosoPizza.Data;

namespace ContosoPizza.Business {

    public interface IUserService {
        //USERS
        List<User> GetAllUsers();
        User? GetUserById(int id);
        // void AddUser(User user);
        void DeleteUser(int id);
        void UpdateUser(User user);

        //ORDERS
        void AddOrder(int userId, Order order);
        List<Order> GetAllOrders();
        Order? GetOrderById(int orderId);
        void DeleteOrder(int orderId);


        //pruebas
        void CreateUser(User user);
    }

}