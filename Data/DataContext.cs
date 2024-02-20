using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Data {

    public class DataContext : DbContext {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
            // modelBuilder.Entity<PizzaIngredient>()
            //     .HasKey(pi => new { pi.PizzaId, pi.IngredientId });

            // modelBuilder.Entity<PizzaIngredient>()
            //     .HasOne(pi => pi.Pizza)
            //     .WithMany(p => p.PizzaIngredients)
            //     .HasForeignKey(pi => pi.PizzaId);

            // modelBuilder.Entity<PizzaIngredient>()
            //     .HasOne(pi => pi.Ingredient)
            //     .WithMany(i => i.PizzaIngredientes)
            //     .HasForeignKey(pi => pi.IngredienteId);


            //PIZZA-INGREDIENT
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza { PizzaId = 1, PizzaName = "Margherita", IsGlutenFree = false, PizzaPrice = 11.90M }
            );

            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { IngredientId = 1, IngredientName = "Tomato sauce", IngredientPrice = 1.30M, Calories = 20, Carbohydrates = 5, Proteins = 1, Fats = 0, Fiber = 2 },
                new Ingredient { IngredientId = 2, IngredientName = "Mozzarella cheese", IngredientPrice = 2, Calories = 80, Carbohydrates = 1, Proteins = 6, Fats = 6, Fiber = 0 },
                new Ingredient { IngredientId = 3, IngredientName = "Tomatoes", IngredientPrice = 2.60M, Calories = 18, Carbohydrates = 4, Proteins = 1, Fats = 0, Fiber = 1 },
                new Ingredient { IngredientId = 4, IngredientName = "Basil", IngredientPrice = 1, Calories = 1, Carbohydrates = 0, Proteins = 0, Fats = 0, Fiber = 0 },
                new Ingredient { IngredientId = 5, IngredientName = "Neapolitan dough", IngredientPrice = 5, Calories = 260, Carbohydrates = 50, Proteins = 8, Fats = 3, Fiber = 2 }
            );

            modelBuilder.Entity<PizzaIngredient>().HasData(
                new PizzaIngredient { PizzaId = 1, IngredientId = 1 },
                new PizzaIngredient { PizzaId = 1, IngredientId = 2 },
                new PizzaIngredient { PizzaId = 1, IngredientId = 3 },
                new PizzaIngredient { PizzaId = 1, IngredientId = 4 },
                new PizzaIngredient { PizzaId = 1, IngredientId = 5 }
            );

            //PIZZA-ORDER
            modelBuilder.Entity<OrderPizza>().HasData(
                new OrderPizza { PizzaId = 1, OrderId = 1 }
            );

            //USER-ORDER
            var user = new User { UserId = 1, UserName = "Paula", UserLastname = "Mateo", Address = "Zaragoza", Email = "a26619@svalero.com", PhoneNumber = "123456789" };
            modelBuilder.Entity<User>().HasData(user);

            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, UserId = user.UserId, UserName = user.UserName, UserAddress = user.Address }
            );

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<PizzaIngredient> PizzasIngredients { get; set; }

    }
   
}