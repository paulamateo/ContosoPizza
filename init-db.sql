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
    CONSTRAINT FK_Orders_Users FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

CREATE TABLE Pizzas(
    PizzaId INT PRIMARY KEY,
    PizzaName NVARCHAR(50) NOT NULL,
    IsGlutenFree BIT NOT NULL,
    PizzaPrice DECIMAL(10,2) NOT NULL,
    OrderId INT NOT NULL,
    CONSTRAINT FK_Pizzas_Orders FOREIGN KEY (OrderId) REFERENCES Orders(OrderId)
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
    PizzaId INT NOT NULL,
    CONSTRAINT FK_Ingredients_Pizzas FOREIGN KEY (PizzaId) REFERENCES Pizzas(PizzaId)
);

-- CREATE TABLE PizzaIngredient(

-- );

INSERT INTO Users (UserId, UserName, UserLastname, Address, Email, PhoneNumber) VALUES
    (1, "Paula", "Mateo", "Zaragoza", "a26619@svalero.com", "123456789"),
    (2, "Eva", "Martin", "Zaragoza", "a26611@svalero.com", "123456789");

INSERT INTO Orders (OrderId, TotalPrice, UserId) VALUES
    (1,  22.60, 1),
    (2, 15.70, 2);

INSERT INTO Pizzas (PizzaId, PizzaName, IsGlutenFree, PizzaPrice, OrderId) VALUES
    (1, "Margherita", false, 11.90, 1),
    (2, "Pepperoni", true, 10.70, 1),
    (3, "Four cheese", false, 15.70, 2);

-- INSERT INTO Ingredients (IngredientId, IngredientName, IngredientPrice, Calories, Carbohydrates, Proteins, Fats, Fiber, PizzaId) VALUES
--     ()

SELECT * FROM Users;

SELECT * FROM Orders;

SELECT * FROM Pizzas;

SELECT * FROM Ingredients;