using ContosoPizza.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoPizza.Data {

    public class PizzaRepository : IPizzaRepository {
        private List<Pizza> Pizzas { get; set; }
        private List<Ingredient> Ingredients { get; set; }
        private readonly string _filePizzas = "../Data/INFO/pizzas.json";
        private readonly string _fileIngredients = "../Data/INFO/ingredients.json";
        private readonly string _fileOrders = "../Data/INFO/orders.json";
        private readonly string _fileUsers = "../Data/INFO/users.json";
        private readonly string _folderPathUsers = "../Data/INFO/USERS/";

        public PizzaRepository() {
            Pizzas = new List<Pizza>();
            Ingredients = new List<Ingredient>();
            LoadFromJson();
            LoadIngredients();
            LoadOrders();
            LoadUsers();

            // AppDomain.CurrentDomain.ProcessExit += EndProgram;
        }

        // private void EndProgram(object? sender, EventArgs e) {
        //     ClearAllFiles();
        // }

        // private void ClearAllFiles() {
        //     try {
        //         File.Delete(_filePizzas);
        //         File.Delete(_fileIngredients);
        //         File.Delete(_fileOrders);
        //         File.Delete(_fileUsers);
        //     } catch (Exception e) {
        //         Console.WriteLine($"Error clearing data: {e.Message}");
        //     }
        // }



public void SaveUserPizzas(User user, List<Pizza> pizzas) {
    try {
        if (!Directory.Exists(_folderPathUsers)) {
            Directory.CreateDirectory(_folderPathUsers);
        }

        string fileName = $"{user.Email}.json"; // Nombre del archivo de pizzas del usuario
        string fullPath = Path.Combine(_folderPathUsers, fileName);

        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(pizzas, options);
        File.WriteAllText(fullPath, jsonString);
    } catch (Exception e) {
        Console.WriteLine($"Error saving user pizzas: {e.Message}");
    }
}

public List<Pizza> LoadUserPizzas(User user) {
    List<Pizza> userPizzas = new List<Pizza>();

    try {
        string fileName = $"{user.Email}.json";
        string fullPath = Path.Combine(_folderPathUsers, fileName);

        if (File.Exists(fullPath)) {
            var jsonString = File.ReadAllText(fullPath);
            userPizzas = JsonSerializer.Deserialize<List<Pizza>>(jsonString) ?? new List<Pizza>();
        }
    } catch (Exception e) {
        Console.WriteLine($"Error loading user pizzas: {e.Message}");
    }

    return userPizzas;
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
            var jsonString = File.ReadAllText(_fileUsers);
            return JsonSerializer.Deserialize<List<User>>(jsonString) ?? new List<User>();
        }catch (Exception e) {
            Console.WriteLine($"Error: {e.Message}");
            return new List<User>();
        }
    }



    //INGREDIENTS
    public void SaveIngredients(List<Ingredient> ingredients) {
        try {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(ingredients, options);
            File.WriteAllText(_fileIngredients, jsonString);
        }catch (Exception e) {
            Console.WriteLine($"Error: {e.Message}");
        }
    }

    public List<Ingredient> LoadIngredients() {
        try {   
            var jsonString = File.ReadAllText(_fileIngredients);
            return JsonSerializer.Deserialize<List<Ingredient>>(jsonString) ?? new List<Ingredient>();
        }catch (Exception e) {
            Console.WriteLine($"Error: {e.Message}");
            return new List<Ingredient>();
        }
    }



    //ORDERS
    public void SaveOrders(List<Order> orders) {
        try {
            var options = new JsonSerializerOptions { WriteIndented = true};
            string jsonString = JsonSerializer.Serialize(orders, options);
            File.WriteAllText(_fileOrders, jsonString);
        }catch (Exception e) {
            Console.WriteLine($"Error: {e.Message}");
        }
    }

    public List<Order> LoadOrders() {
        try {  
            var jsonString = File.ReadAllText(_fileOrders);
            return JsonSerializer.Deserialize<List<Order>>(jsonString) ?? new List<Order>(); 
        }catch (Exception e) {
            Console.WriteLine($"Error: {e.Message}");
            return new List<Order>();
        }
    }



    //PIZZAS
    public void SaveToJson(List<Pizza> pizzas) {
            try {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(pizzas, options);
                File.WriteAllText(_filePizzas, jsonString);
            }catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        public List<Pizza> LoadFromJson() {
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

        public void SavePizzas(List<Pizza> pizzas) {
            try {
                var options = new JsonSerializerOptions { WriteIndented = true};
                string jsonString = JsonSerializer.Serialize(pizzas, options);
                File.WriteAllText(_filePizzas, jsonString);
            }catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        public List<Pizza> LoadPizzas() {
            try {
                if (File.Exists(_fileOrders)) {
                    var jsonString = File.ReadAllText(_fileOrders);
                    return JsonSerializer.Deserialize<List<Pizza>>(jsonString) ?? new List<Pizza>();
                }else {
                    return new List<Pizza>();
                }
            }catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
                return new List<Pizza>();
            }
        }












//   public void DeleteUserFile(User user) {
//         try {
//                 string fileName = $"{user.Email}.json";
//                 string fullPath = Path.Combine(_folderPathUsers, fileName);

//                 if (File.Exists(fullPath)) {
//                     File.Delete(fullPath);
//                 }
//             } catch (Exception e) {
//                 Console.WriteLine($"Error deleting user file: {e.Message}");
//             }
//         }



        //PIZZAS
        
        


        //PEDIDOS
    
        





        
        
        
        
        
        
        
        

       
    }

}