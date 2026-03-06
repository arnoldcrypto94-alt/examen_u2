/*
    SISTEMA: FoodCampus - Script de Población de Datos (DML Seeding)
    OBJETIVO: Poblar datos iniciales cumpliendo integridad referencial y optimización Cloud.
    UBICACIÓN: /db-scripts/02_seed.sql
*/

-- 1. BLOQUE DE LIMPIEZA: Eliminación en orden inverso para evitar conflictos de Foreign Key
DELETE FROM DetallePedido;
DELETE FROM Pedido;
DELETE FROM Restaurante;

-- 2. REINICIO DE CONTADORES IDENTITY a 0 (el siguiente será 1)
DBCC CHECKIDENT ('DetallePedido', RESEED, 0);
DBCC CHECKIDENT ('Pedido', RESEED, 0);
DBCC CHECKIDENT ('Restaurante', RESEED, 0);

-- 3. INSERTAR 10 RESTAURANTES CON HORARIOS REALISTAS
INSERT INTO Restaurante (Nombre, Especialidad, HorarioApertura, HorarioCierre) VALUES 
('Pizza Universitaria', 'Pizzas', '10:00:00', '22:00:00'),
('Sushi Campus', 'Comida Japonesa', '12:00:00', '23:00:00'),
('Tacos El Profe', 'Comida Mexicana', '08:00:00', '20:00:00'),
('Burgers & Fries', 'Hamburguesas', '11:00:00', '22:00:00'),
('Ensaladas Fresh', 'Saludable', '09:00:00', '18:00:00'),
('Pasta Place', 'Italiana', '12:00:00', '21:00:00'),
('Wok & Roll', 'Asiática', '12:00:00', '22:00:00'),
('Coffee Break', 'Cafetería', '07:00:00', '19:00:00'),
('Donas Deli', 'Postres', '08:00:00', '21:00:00'),
('Sándwich Master', 'Lonches', '09:00:00', '22:00:00');

-- 4. INSERTAR 5 PEDIDOS CON EXACTAMENTE 2 REGISTROS EN DETALLEPEDIDO CADA UNO
DECLARE @IdP1 INT, @IdP2 INT, @IdP3 INT, @IdP4 INT, @IdP5 INT;

-- Pedido 1
INSERT INTO Pedido (IdUsuario, FechaHora, CostoEnvio) VALUES (101, GETDATE(), 15.00);
SET @IdP1 = SCOPE_IDENTITY();
INSERT INTO DetallePedido (IdPedido, IdPlatillo, Cantidad, Subtotal) VALUES (@IdP1, 10, 2, 120.50);
INSERT INTO DetallePedido (IdPedido, IdPlatillo, Cantidad, Subtotal) VALUES (@IdP1, 15, 1, 45.00);

-- Pedido 2
INSERT INTO Pedido (IdUsuario, FechaHora, CostoEnvio) VALUES (102, GETDATE(), 10.00);
SET @IdP2 = SCOPE_IDENTITY();
INSERT INTO DetallePedido (IdPedido, IdPlatillo, Cantidad, Subtotal) VALUES (@IdP2, 22, 3, 75.00);
INSERT INTO DetallePedido (IdPedido, IdPlatillo, Cantidad, Subtotal) VALUES (@IdP2, 28, 1, 110.00);

-- Pedido 3
INSERT INTO Pedido (IdUsuario, FechaHora, CostoEnvio) VALUES (103, GETDATE(), 12.50);
SET @IdP3 = SCOPE_IDENTITY();
INSERT INTO DetallePedido (IdPedido, IdPlatillo, Cantidad, Subtotal) VALUES (@IdP3, 35, 1, 200.00);
INSERT INTO DetallePedido (IdPedido, IdPlatillo, Cantidad, Subtotal) VALUES (@IdP3, 38, 2, 80.00);

-- Pedido 4
INSERT INTO Pedido (IdUsuario, FechaHora, CostoEnvio) VALUES (104, GETDATE(), 0.00);
SET @IdP4 = SCOPE_IDENTITY();
INSERT INTO DetallePedido (IdPedido, IdPlatillo, Cantidad, Subtotal) VALUES (@IdP4, 44, 4, 160.00);
INSERT INTO DetallePedido (IdPedido, IdPlatillo, Cantidad, Subtotal) VALUES (@IdP4, 46, 1, 55.00);

-- Pedido 5
INSERT INTO Pedido (IdUsuario, FechaHora, CostoEnvio) VALUES (105, GETDATE(), 20.00);
SET @IdP5 = SCOPE_IDENTITY();
INSERT INTO DetallePedido (IdPedido, IdPlatillo, Cantidad, Subtotal) VALUES (@IdP5, 50, 1, 150.00);
INSERT INTO DetallePedido (IdPedido, IdPlatillo, Cantidad, Subtotal) VALUES (@IdP5, 55, 2, 90.00);

PRINT 'Sembrado (Seeding) de FoodCampus completado correctamente.';
