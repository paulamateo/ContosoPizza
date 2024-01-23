using ContosoPizza.Models;

namespace ContosoPizza.Data {

    public interface IPizzaRepository {

        //USERS
        void SaveUsers(List<User> users);
        List<User> LoadUsers();

        //INGREDIENTS
        void SaveIngredients(List<Ingredient> ingredients);
        List<Ingredient> LoadIngredients();

        //ORDERS
        void SaveOrders(List<Order> orders);
        List<Order> LoadOrders();

        //PIZZAS
        void SavePizzas(List<Pizza> pizzas);
        List<Pizza> LoadPizzas();

        void SaveUserPizzas(User user, List<Pizza> pizzas);
        List<Pizza> LoadUserPizzas(User user);

        void SaveToJson(List<Pizza> pizzas);
        List<Pizza> LoadFromJson();
    
    }   

}