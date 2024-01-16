using ContosoPizza.Models;
using ContosoPizza.Data;

namespace ContosoPizza.Services {

    public class PizzaService : IPizzaService {
        private readonly IPizzaRepository _repository;

        public PizzaService(IPizzaRepository repository) {
            _repository = repository;
        }

        public List<Pizza> GetAll() => _repository.LoadFromJson();

        public Pizza? Get(int id) => _repository.LoadFromJson().FirstOrDefault(p => p.Id == id);

        public void Add(Pizza pizza) {
            var pizzas = _repository.LoadFromJson();
            pizza.Id = pizzas.Count > 0 ? pizzas.Max(p => p.Id) + 1 : 1;
            pizzas.Add(pizza);
            _repository.SaveToJson(pizzas);
        }

        public void Delete(int id) {
            var pizzas = _repository.LoadFromJson();
            var pizza = pizzas.FirstOrDefault(p => p.Id == id);
            if (pizza != null) {
                pizzas.Remove(pizza);
                _repository.SaveToJson(pizzas);
            }
        }

        public void Update(Pizza pizza) {
            var pizzas = _repository.LoadFromJson();
            var index = pizzas.FindIndex(p => p.Id == pizza.Id);
            if (index != -1) {
                pizzas[index] = pizza;
                _repository.SaveToJson(pizzas);
            }
        }

    }
  
}