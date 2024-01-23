using ContosoPizza.Models;

namespace ContosoPizza.Business {

    public interface IUserService {
        List<User> GetAllUsers();
        User? GetUser(int id);
        void AddUser(User user);
        void DeleteUser(int id);
        void UpdateUser(User user);
    }

}