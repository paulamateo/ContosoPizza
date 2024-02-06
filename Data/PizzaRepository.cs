using ContosoPizza.Models;
using System.Text.Json;

namespace ContosoPizza.Data {

    public class PizzaRepository : IPizzaRepository {
        private List<Pizza> Pizzas { get; set; }
        private readonly string _filePizzas = "DATA_pizzas.json";
        private readonly string _fileUsers = "DATA_users.json";

        public PizzaRepository() {
            Pizzas = new List<Pizza>();
            LoadPizzas();
            LoadUsers();

            // AppDomain.CurrentDomain.ProcessExit += EndProgram;
        }


        //PIZZAS
        public void SavePizzas(List<Pizza> pizzas) {
            try {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(pizzas, options);
                File.WriteAllText(_filePizzas, jsonString);
            }catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        public List<Pizza> LoadPizzas() {
            try {
                if (File.Exists(_filePizzas)) {
                    var jsonString = File.ReadAllText(_filePizzas);
                    return JsonSerializer.Deserialize<List<Pizza>>(jsonString) ?? new List<Pizza>();
                }else {
                    return new List<Pizza>();
                }
            }catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
                return new List<Pizza>();
            }
        }


        //USERS
        public void SaveUsers(List<User> users) {
            try {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(users, options);
                File.WriteAllText(_fileUsers, jsonString);
            }catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        public List<User> LoadUsers() {
            try {
                if (File.Exists(_fileUsers)) {
                    var jsonString = File.ReadAllText(_fileUsers);
                    return JsonSerializer.Deserialize<List<User>>(jsonString) ?? new List<User>();
                }else {
                    return new List<User>();
                }
            }catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
                return new List<User>();
            }
        }

        // private void EndProgram(object? sender, EventArgs e) {
        //     if (File.Exists(_filePizzas)) {
        //         File.Delete(_filePizzas);
        //     }
        // }

    }

}