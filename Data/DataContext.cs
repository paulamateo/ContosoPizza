using Microsoft.EntityFrameworkCore;
using ContosoPizza.Models;
using Microsoft.Extensions.Configuration;

namespace ContosoPizza.Data {
    public class DataContext : DbContext {

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, UserName = "Paula", UserLastname = "Mateo", Address = "Zaragoza", Email = "a26619@svalero.com", PhoneNumber = "123456789" },
                new User { UserId = 2, UserName = "Eva", UserLastname = "Martin", Address = "Zaragoza", Email = "a26611@svalero.com", PhoneNumber = "123456789" }
            );
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, TotalPrice = 22.60M, UserName = "Paula", UserAddress = "Zaragoza", UserId = 1 },
                new Order { OrderId = 2, TotalPrice = 15.70M, UserName = "Eva", UserAddress = "Zaragoza", UserId = 2 }
            );
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza { PizzaId = 1, PizzaName = "Margherita", IsGlutenFree = false, PizzaPrice = 11.90M, OrderId = 1 },
                new Pizza { PizzaId = 2, PizzaName = "Pepperoni", IsGlutenFree = true, PizzaPrice = 10.70M, OrderId = 1 },
                new Pizza { PizzaId = 3, PizzaName = "Four cheese", IsGlutenFree = false, PizzaPrice = 15.70M, OrderId = 2 }
            );
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { IngredientId = 1, IngredientName = "Tomato sauce", IngredientPrice = 1.30M, Calories = 20, Carbohydrates = 5, Proteins = 1, Fats = 0, Fiber = 2, PizzaId = 1 },
                new Ingredient { IngredientId = 2, IngredientName = "Mozzarella cheese", IngredientPrice = 2, Calories = 80, Carbohydrates = 1, Proteins = 6, Fats = 6, Fiber = 0, PizzaId = 1 },
                new Ingredient { IngredientId = 3, IngredientName = "Tomatoes", IngredientPrice = 2.60M, Calories = 18, Carbohydrates = 4, Proteins = 1, Fats = 0, Fiber = 1, PizzaId = 1 },
                new Ingredient { IngredientId = 4, IngredientName = "Basil", IngredientPrice = 1, Calories = 1, Carbohydrates = 0, Proteins = 0, Fats = 0, Fiber = 0, PizzaId = 1 },
                new Ingredient { IngredientId = 5, IngredientName = "Neapolitan dough", IngredientPrice = 5, Calories = 260, Carbohydrates = 50, Proteins = 8, Fats = 3, Fiber = 2, PizzaId = 1 },
                new Ingredient { IngredientId = 6, IngredientName = "Tomato sauce", IngredientPrice = 1.30M, Calories = 20, Carbohydrates = 5, Proteins = 1, Fats = 0, Fiber = 2, PizzaId = 2 },
                new Ingredient { IngredientId = 7, IngredientName = "Mozzarella cheese", IngredientPrice = 2, Calories = 80, Carbohydrates = 1, Proteins = 6, Fats = 6, Fiber = 0, PizzaId = 2 },
                new Ingredient { IngredientId = 8, IngredientName = "Pepperoni", IngredientPrice = 2.40M, Calories = 140, Carbohydrates = 1, Proteins = 5, Fats = 12, Fiber = 0, PizzaId = 2 },
                new Ingredient { IngredientId = 9, IngredientName = "Courgette dough", IngredientPrice = 5, Calories = 25, Carbohydrates = 6, Proteins = 2, Fats = 1, Fiber = 2, PizzaId = 2 },
                new Ingredient { IngredientId = 10, IngredientName = "Tomato sauce", IngredientPrice = 1.30M, Calories = 20, Carbohydrates = 5, Proteins = 1, Fats = 0, Fiber = 2, PizzaId = 3 },
                new Ingredient { IngredientId = 11, IngredientName = "Mozzarella cheese", IngredientPrice = 2, Calories = 80, Carbohydrates = 1, Proteins = 6, Fats = 6, Fiber = 0, PizzaId = 3 },
                new Ingredient { IngredientId = 12, IngredientName = "Parmesan cheese", IngredientPrice = 2.50M, Calories = 100, Carbohydrates = 10, Proteins = 25, Fats = 27, Fiber = 0, PizzaId = 3 },
                new Ingredient { IngredientId = 13, IngredientName = "Gorgonzola cheese", IngredientPrice = 2.30M, Calories = 70, Carbohydrates = 2, Proteins = 18, Fats = 20, Fiber = 0, PizzaId = 3 },
                new Ingredient { IngredientId = 14, IngredientName = "Provolone cheese", IngredientPrice = 2.60M, Calories = 110, Carbohydrates = 1, Proteins = 20, Fats = 18, Fiber = 0, PizzaId = 3 },
                new Ingredient { IngredientId = 15, IngredientName = "Thin-crust dough", IngredientPrice = 5, Calories = 300, Carbohydrates = 55, Proteins = 8, Fats = 3, Fiber = 3, PizzaId= 3 }
            );
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
    
    }
}