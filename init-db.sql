CREATE DATABASE PizzaDB;

USE PizzaDB;

CREATE TABLE Users (
    UserId INT PRIMARY KEY,
    UserName NVARCHAR(50) NOT NULL,
    UserLastname NVARCHAR(100) NOT NULL,
    Address NVARCHAR(100) NOT NULL,
    Email NVARCHAR(50) NOT NULL,
    PhoneNumber NVARCHAR(9)
);

CREATE TABLE Orders (
    OrderId INT PRIMARY KEY,
    TotalPrice DECIMAL(10,2) NOT NULL,
    UserId INT NOT NULL,
    UserName NVARCHAR(100) NOT NULL,
    UserAddress NVARCHAR(200) NOT NULL
);

CREATE TABLE Pizzas(
    PizzaId INT PRIMARY KEY,
    PizzaName NVARCHAR(50) NOT NULL,
    IsGlutenFree BIT NOT NULL,
    PizzaPrice DECIMAL(10,2) NOT NULL
);

CREATE TABLE OrdersPizzas (
  OrderId INT,
  PizzaId INT,
  FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),
  FOREIGN KEY (PizzaId) REFERENCES Pizzas(PizzaId)
);

CREATE TABLE Ingredients(
    IngredientId INT PRIMARY KEY,
    IngredientName NVARCHAR(100) NOT NULL,
    IngredientPrice DECIMAL(10,2) NOT NULL,
    Calories INT NOT NULL,
    Carbohydrates INT NOT NULL,
    Proteins INT NOT NULL,
    Fats INT NOT NULL,
    Fiber INT NOT NULL,
    PizzaId INT NOT NULL
);


INSERT INTO Users (UserId, UserName, UserLastname, Address, Email, PhoneNumber) VALUES
    (1, "Paula", "Mateo", "Zaragoza", "a26619@svalero.com", "123456789");

INSERT INTO Orders (OrderId, TotalPrice) VALUES
    (1,  22.60);

INSERT INTO Pizzas (PizzaId, PizzaName, IsGlutenFree, PizzaPrice) VALUES
    (1, "Margherita", false, 11.90);

INSERT INTO Ingredients (IngredientId, IngredientName, IngredientPrice, Calories, Carbohydrates, Proteins, Fats, Fiber) VALUES
    (1, "Tomato sauce", 1.30, 20, 5, 1, 0, 2),
    (2, "Mozzarella cheese", 2, 80, 1, 6, 6, 0),
    (3, "Tomatoes", 2.60, 18, 4, 1, 0, 1),
    (4, "Basil", 1, 1, 0, 0, 0, 0),
    (5, "Neapolitan dough", 5, 260, 50, 8, 3, 2);