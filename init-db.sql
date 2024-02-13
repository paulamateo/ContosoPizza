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