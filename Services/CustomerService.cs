using ContosoPizza.Models;
using ContosoPizza.Data;

namespace ContosoPizza.Services {

    public class CustomerService {
        private readonly IPizzaRepository _repository;
        public CustomerService(IPizzaRepository repository) {
            _repository = repository;
        }

        public List<User> GetAll() => _repository.LoadUsers();

        public void Add(User user) {
            var users = _repository.LoadUsers();
            users.Add(user);
            _repository.SaveUsers(users);
        }
    }

}