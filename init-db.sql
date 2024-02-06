CREATE DATABASE PizzaDB;

USE PizzaDB;

-- Crear la tabla 'Usuarios'
CREATE TABLE Users (
    Id INTEGER PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    Lastname NVARCHAR(100) NOT NULL,
    Address NVARCHAR(200) NOT NULL,
    Email NVARCHAR(50) NOT NULL,
    PhoneNumber NVARCHAR(10) NOT NULL
);

SELECT * FROM Users;