using ContosoPizza.Models;

namespace ContosoPizza.Data {

    public interface IPizzaRepository {
        void SaveToJson(List<Pizza> pizzas);
        List<Pizza> LoadFromJson();
    }   

}