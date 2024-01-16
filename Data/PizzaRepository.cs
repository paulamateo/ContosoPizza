using ContosoPizza.Models;
using System.Text.Json;

namespace ContosoPizza.Data {

    public class PizzaRepository : IPizzaRepository {
        private List<Pizza> Pizzas { get; set; }
        private readonly string _dataFile = "inventory.json";
        
        public PizzaRepository() {
            Pizzas = new List<Pizza>();
            LoadFromJson();

            AppDomain.CurrentDomain.ProcessExit += EndProgram;
        }

        public void SaveToJson(List<Pizza> pizzas) {
            try {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(pizzas, options);
                File.WriteAllText(_dataFile, jsonString);
            }catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        public List<Pizza> LoadFromJson() {
            try {
                if (File.Exists(_dataFile)) {
                    var jsonString = File.ReadAllText(_dataFile);
                    return JsonSerializer.Deserialize<List<Pizza>>(jsonString) ?? new List<Pizza>();
                }else {
                    return new List<Pizza>();
                }
            }catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
                return new List<Pizza>();
            }
        }

        private void EndProgram(object? sender, EventArgs e) {
            SaveToJson(new List<Pizza>());
        }


    }
  
}