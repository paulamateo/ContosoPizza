using ContosoPizza.Models;
using ContosoPizza.Data;

namespace ContosoPizza.Business {

    public class UserService : IUserService {

        private readonly IPizzaRepository _repository;

        public UserService(IPizzaRepository repository) {
            _repository = repository;
        }


        public List<User> GetAllUsers() => _repository.LoadUsers();
        public User? GetUser(int id) => _repository.LoadUsers().FirstOrDefault(p => p.Id == id);

        public void AddUser(User user) {
            var users = _repository.LoadUsers();
            user.Id = users.Count > 0 ? users.Max(p => p.Id) + 1 : 1;
            users.Add(user);
            _repository.SaveUsers(users);
        }

        public void DeleteUser(int id) {
            var users = _repository.LoadUsers();
            var user = users.FirstOrDefault(i => i.Id == id);
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

    }

}