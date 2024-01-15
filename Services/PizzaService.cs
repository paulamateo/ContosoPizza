using ContosoPizza.Models;
using System.Text.Json;

namespace ContosoPizza.Services {

    public class PizzaService {
        private List<Pizza> Pizzas { get; set; }
        public int nextId = 1;

        public PizzaService() {
            Pizzas = new List<Pizza>();
            LoadFromJson();
        }

        public List<Pizza> GetAll() => Pizzas;

        public Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

        public void Add(Pizza pizza) {
            pizza.Id = nextId++;
            Pizzas.Add(pizza);
            SaveToJson();
        }

        public void Delete(int id) {
            var pizza = Get(id);
            if(pizza is null)
                return;

            Pizzas.Remove(pizza);
            SaveToJson();
        }

        public void Update(Pizza pizza) {
            var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
            if(index == -1)
                return;

            Pizzas[index] = pizza;
            SaveToJson();
        }

        private void SaveToJson() {
            try {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(Pizzas, options);
                File.WriteAllText("inventory.json", jsonString);
            }catch (FileNotFoundException e) {
                Console.WriteLine($"Error: {e.Message}");
            }catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        private void LoadFromJson() {
            try {
                if (File.Exists("inventory.json")) {
                    var jsonString = File.ReadAllText("inventory.json");
                    Pizzas = JsonSerializer.Deserialize<List<Pizza>>(jsonString) ?? new List<Pizza>();
                    nextId = Pizzas.Any() ? Pizzas.Max(p => p.Id) + 1 : 1;
                }else {
                    Pizzas = new List<Pizza>();
                    nextId = 1;
                }
            }catch (FileNotFoundException e) {
                Console.WriteLine($"Error: {e.Message}");
            }catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }

}