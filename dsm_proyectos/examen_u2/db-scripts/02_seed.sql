/*
    SISTEMA: FoodCampus - Delivery Universitario
    PLATAFORMA: SQL Server (Optimizado para Somee.com)
    FECHA: 06/03/2026
    DESCRIPCIÓN: Script de Seeding (DML) para poblar la base de datos con datos de prueba.
*/

-- 1. Limpieza de datos previa (En orden inverso a las dependencias)
DELETE FROM DetallePedido;
DELETE FROM Pedido;
DELETE FROM Platillo;
DELETE FROM Restaurante;

-- 2. Reseteo de Identidades
DBCC CHECKIDENT ('DetallePedido', RESEED, 0);
DBCC CHECKIDENT ('Pedido', RESEED, 0);
DBCC CHECKIDENT ('Platillo', RESEED, 0);
DBCC CHECKIDENT ('Restaurante', RESEED, 0);

-- Variables para IDs
DECLARE @IdRest INT, @IdPlat1 INT, @IdPlat2 INT, @IdPlat3 INT;
DECLARE @IdPedido INT;

-- 3. Inserción de 10 Restaurantes con sus respectivos 3 Platillos c/u
-- Restaurante 1: Pizza
INSERT INTO Restaurante (Nombre, Especialidad, HorarioApertura, HorarioCierre) VALUES ('Pizzería Romana', 'Italiana', '10:00:00', '22:00:00');
SET @IdRest = SCOPE_IDENTITY();
INSERT INTO Platillo (IdRestaurante, Nombre, Precio) VALUES (@IdRest, 'Pizza Margarita', 120.00), (@IdRest, 'Pizza Pepperoni', 150.00), (@IdRest, 'Pizza Hawaiana', 140.00);

-- Restaurante 2: Sushi
INSERT INTO Restaurante (Nombre, Especialidad, HorarioApertura, HorarioCierre) VALUES ('Sushi Zen', 'Japonesa', '12:00:00', '23:00:00');
SET @IdRest = SCOPE_IDENTITY();
INSERT INTO Platillo (IdRestaurante, Nombre, Precio) VALUES (@IdRest, 'Roll California', 95.00), (@IdRest, 'Roll Philadelphia', 110.00), (@IdRest, 'Sashimi Salmón', 180.00);

-- Restaurante 3: Tacos
INSERT INTO Restaurante (Nombre, Especialidad, HorarioApertura, HorarioCierre) VALUES ('Taquería Los Amigos', 'Mexicana', '08:00:00', '20:00:00');
SET @IdRest = SCOPE_IDENTITY();
INSERT INTO Platillo (IdRestaurante, Nombre, Precio) VALUES (@IdRest, 'Tacos al Pastor', 60.00), (@IdRest, 'Tacos de Asada', 75.00), (@IdRest, 'Quesadilla Especial', 85.00);

-- Restaurante 4: Hamburguesas
INSERT INTO Restaurante (Nombre, Especialidad, HorarioApertura, HorarioCierre) VALUES ('Burger House', 'Americana', '11:00:00', '22:00:00');
SET @IdRest = SCOPE_IDENTITY();
INSERT INTO Platillo (IdRestaurante, Nombre, Precio) VALUES (@IdRest, 'Clásica Cheese', 110.00), (@IdRest, 'Doble Tocino', 160.00), (@IdRest, 'Veggie Burger', 130.00);

-- Restaurante 5: Ensaladas
INSERT INTO Restaurante (Nombre, Especialidad, HorarioApertura, HorarioCierre) VALUES ('Green Garden', 'Saludable', '09:00:00', '19:00:00');
SET @IdRest = SCOPE_IDENTITY();
INSERT INTO Platillo (IdRestaurante, Nombre, Precio) VALUES (@IdRest, 'César Pollo', 90.00), (@IdRest, 'Ensalada Griega', 85.00), (@IdRest, 'Bowl de Quinoa', 105.00);

-- Restaurante 6: Pastas
INSERT INTO Restaurante (Nombre, Especialidad, HorarioApertura, HorarioCierre) VALUES ('La Pasta Loca', 'Italiana', '13:00:00', '22:00:00');
SET @IdRest = SCOPE_IDENTITY();
INSERT INTO Platillo (IdRestaurante, Nombre, Precio) VALUES (@IdRest, 'Espagueti Carbonara', 135.00), (@IdRest, 'Lasaña Boloniesa', 155.00), (@IdRest, 'Fettuccine Alfredo', 145.00);

-- Restaurante 7: Pollo Frito
INSERT INTO Restaurante (Nombre, Especialidad, HorarioApertura, HorarioCierre) VALUES ('Crispy Chicken', 'Rápida', '10:00:00', '21:00:00');
SET @IdRest = SCOPE_IDENTITY();
INSERT INTO Platillo (IdRestaurante, Nombre, Precio) VALUES (@IdRest, 'Cubeta 8 Piezas', 220.00), (@IdRest, 'Sándwich Spicy', 95.00), (@IdRest, 'Alitas BBQ', 130.00);

-- Restaurante 8: Comida China
INSERT INTO Restaurante (Nombre, Especialidad, HorarioApertura, HorarioCierre) VALUES ('Dragón Dorado', 'Oriental', '12:00:00', '22:00:00');
SET @IdRest = SCOPE_IDENTITY();
INSERT INTO Platillo (IdRestaurante, Nombre, Precio) VALUES (@IdRest, 'Arroz Frito Especial', 110.00), (@IdRest, 'Pollo Agridulce', 140.00), (@IdRest, 'Rollitos Primavera', 70.00);

-- Restaurante 9: Cafetería
INSERT INTO Restaurante (Nombre, Especialidad, HorarioApertura, HorarioCierre) VALUES ('Coffee Break', 'Cafetería', '07:00:00', '18:00:00');
SET @IdRest = SCOPE_IDENTITY();
INSERT INTO Platillo (IdRestaurante, Nombre, Precio) VALUES (@IdRest, 'Capuccino Grande', 55.00), (@IdRest, 'Bagel de Pavo', 85.00), (@IdRest, 'Muffin Chocolate', 45.00);

-- Restaurante 10: Postres
INSERT INTO Restaurante (Nombre, Especialidad, HorarioApertura, HorarioCierre) VALUES ('Dulce Capricho', 'Repostería', '11:00:00', '20:00:00');
SET @IdRest = SCOPE_IDENTITY();
INSERT INTO Platillo (IdRestaurante, Nombre, Precio) VALUES (@IdRest, 'Cheesecake Fresa', 75.00), (@IdRest, 'Brownie con Helado', 65.00), (@IdRest, 'Pay de Limón', 55.00);


-- 4. Inserción de 5 Pedidos Iniciales
-- Pedido 1
INSERT INTO Pedido (IdUsuario, FechaHora, CostoEnvio) VALUES (101, GETDATE(), 25.00);
SET @IdPedido = SCOPE_IDENTITY();
-- Obtener IDs de platillos existentes (Pizzería Romana: Margarita y Pepperoni)
SELECT TOP 1 @IdPlat1 = IdPlatillo FROM Platillo WHERE Nombre = 'Pizza Margarita';
SELECT TOP 1 @IdPlat2 = IdPlatillo FROM Platillo WHERE Nombre = 'Pizza Pepperoni';
INSERT INTO DetallePedido (IdPedido, IdPlatillo, Cantidad, Subtotal) VALUES (@IdPedido, @IdPlat1, 1, 120.00), (@IdPedido, @IdPlat2, 1, 150.00);

-- Pedido 2
INSERT INTO Pedido (IdUsuario, FechaHora, CostoEnvio) VALUES (102, GETDATE(), 30.00);
SET @IdPedido = SCOPE_IDENTITY();
SELECT TOP 1 @IdPlat1 = IdPlatillo FROM Platillo WHERE Nombre = 'Roll California';
SELECT TOP 1 @IdPlat2 = IdPlatillo FROM Platillo WHERE Nombre = 'Roll Philadelphia';
INSERT INTO DetallePedido (IdPedido, IdPlatillo, Cantidad, Subtotal) VALUES (@IdPedido, @IdPlat1, 2, 190.00), (@IdPedido, @IdPlat2, 1, 110.00);

-- Pedido 3
INSERT INTO Pedido (IdUsuario, FechaHora, CostoEnvio) VALUES (103, GETDATE(), 20.00);
SET @IdPedido = SCOPE_IDENTITY();
SELECT TOP 1 @IdPlat1 = IdPlatillo FROM Platillo WHERE Nombre = 'Tacos al Pastor';
SELECT TOP 1 @IdPlat2 = IdPlatillo FROM Platillo WHERE Nombre = 'Quesadilla Especial';
INSERT INTO DetallePedido (IdPedido, IdPlatillo, Cantidad, Subtotal) VALUES (@IdPedido, @IdPlat1, 5, 300.00), (@IdPedido, @IdPlat2, 2, 170.00);

-- Pedido 4
INSERT INTO Pedido (IdUsuario, FechaHora, CostoEnvio) VALUES (104, GETDATE(), 35.00);
SET @IdPedido = SCOPE_IDENTITY();
SELECT TOP 1 @IdPlat1 = IdPlatillo FROM Platillo WHERE Nombre = 'Doble Tocino';
SELECT TOP 1 @IdPlat2 = IdPlatillo FROM Platillo WHERE Nombre = 'Clásica Cheese';
INSERT INTO DetallePedido (IdPedido, IdPlatillo, Cantidad, Subtotal) VALUES (@IdPedido, @IdPlat1, 1, 160.00), (@IdPedido, @IdPlat2, 1, 110.00);

-- Pedido 5
INSERT INTO Pedido (IdUsuario, FechaHora, CostoEnvio) VALUES (105, GETDATE(), 15.00);
SET @IdPedido = SCOPE_IDENTITY();
SELECT TOP 1 @IdPlat1 = IdPlatillo FROM Platillo WHERE Nombre = 'Capuccino Grande';
SELECT TOP 1 @IdPlat2 = IdPlatillo FROM Platillo WHERE Nombre = 'Muffin Chocolate';
INSERT INTO DetallePedido (IdPedido, IdPlatillo, Cantidad, Subtotal) VALUES (@IdPedido, @IdPlat1, 2, 110.00), (@IdPedido, @IdPlat2, 3, 135.00);
