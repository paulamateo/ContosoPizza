using ContosoPizza.Models;

namespace ContosoPizza.Data {

    public interface IPizzaRepository {
        //PIZZAS
        void SavePizzas(List<Pizza> pizzas);
        List<Pizza> LoadPizzas();

        //USERS
        void SaveUsers(List<User> users);
        List<User> LoadUsers();
    }

}