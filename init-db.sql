CREATE DATABASE PizzaDB;

USE PizzaDB;

CREATE TABLE Users (
    UserId INTEGER PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    Lastname NVARCHAR(100) NOT NULL,
    Address NVARCHAR(200) NOT NULL,
    Email NVARCHAR(50) NOT NULL,
    PhoneNumber NVARCHAR(10) NOT NULL
);

CREATE TABLE Orders (
    OrderId INTEGER PRIMARY KEY,
    TotalPrice DECIMAL(10,2) NOT NULL,
    UserId INTEGER NOT NULL,
    UserName  NVARCHAR(50) NOT NULL,
    UserAddress NVARCHAR(200) NOT NULL,
    CONSTRAINT FK_Orders_Users FOREIGN KEY (UserId) REFERENCES Users(UserId)
    -- CONSTRAINT FK_Orders_Users FOREIGN KEY (UserName) REFERENCES Users(Name),
    -- CONSTRAINT FK_Orders_Users FOREIGN KEY (UserAddress) REFERENCES Users(Address)
);

CREATE TABLE Pizzas (
    PizzaId INTEGER PRIMARY KEY,
    PizzaName NVARCHAR(100) NOT NULL,
    IsGlutenFree BIT NOT NULL,
    Price DECIMAL(3,2) NOT NULL,
    OrderId INTEGER NOT NULL,
    CONSTRAINT FK_Pizzas_Orders FOREIGN KEY (OrderId) REFERENCES Orders(OrderId)
);

CREATE TABLE Ingredients (
    IngredientId INTEGER PRIMARY KEY,
    IngredientName NVARCHAR(50) NOT NULL,
    IngredientPrice DECIMAL(2,2) NOT NULL,
    Calories INT NOT NULL,
    Carbohydrates INT NOT NULL,
    Proteins INT NOT NULL,
    Fats INT NOT NULL,
    Fiber INT NOT NULL,
    PizzaId INTEGER NOT NULL,
    CONSTRAINT FK_Ingredients_Pizzas FOREIGN KEY (PizzaId) REFERENCES Pizzas(PizzaId)
);