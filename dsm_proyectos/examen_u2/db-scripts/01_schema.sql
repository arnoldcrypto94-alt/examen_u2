/*
    SISTEMA: FoodCampus - Delivery Universitario
    PLATAFORMA: SQL Server (Optimizado para Somee.com - 30MB)
    FECHA: 06/03/2026
    DESCRIPCIÓN: Script DDL para la creación de tablas con menú de platillos.
*/

-- 0. Limpieza de tablas (Eliminar en orden inverso a la creación por FK)
IF OBJECT_ID('DetallePedido', 'U') IS NOT NULL DROP TABLE DetallePedido;
IF OBJECT_ID('Platillo', 'U') IS NOT NULL DROP TABLE Platillo;
IF OBJECT_ID('Pedido', 'U') IS NOT NULL DROP TABLE Pedido;
IF OBJECT_ID('Restaurante', 'U') IS NOT NULL DROP TABLE Restaurante;

-- 1. Tabla Restaurante
-- Representa el establecimiento que ofrece los platillos.
CREATE TABLE Restaurante (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Especialidad NVARCHAR(100) NULL,
    HorarioApertura TIME NOT NULL,
    HorarioCierre TIME NOT NULL
);

-- 2. Tabla Platillo
-- Define el menú de cada restaurante.
CREATE TABLE Platillo (
    IdPlatillo INT IDENTITY(1,1) PRIMARY KEY,
    IdRestaurante INT NOT NULL,
    Nombre NVARCHAR(100) NOT NULL,
    Precio DECIMAL(18,2) NOT NULL,
    
    -- Integridad Referencial
    CONSTRAINT FK_Platillo_Restaurante FOREIGN KEY (IdRestaurante)
        REFERENCES Restaurante(Id) ON DELETE CASCADE,
        
    -- Restricción: Precio mayor a 0
    CONSTRAINT CHK_Platillo_Precio CHECK (Precio > 0)
);

-- 3. Tabla Pedido
-- Cabecera del pedido realizado por un usuario.
CREATE TABLE Pedido (
    IdPedido INT IDENTITY(1,1) PRIMARY KEY,
    IdUsuario INT NOT NULL,
    FechaHora DATETIME DEFAULT GETDATE() NOT NULL,
    CostoEnvio DECIMAL(18,2) NOT NULL,
    
    -- Restricción: Costo de envío no negativo
    CONSTRAINT CHK_Pedido_CostoEnvio CHECK (CostoEnvio >= 0)
);

-- 4. Tabla DetallePedido
-- Relación de platillos seleccionados en cada pedido.
CREATE TABLE DetallePedido (
    IdDetalle INT IDENTITY(1,1) PRIMARY KEY,
    IdPedido INT NOT NULL,
    IdPlatillo INT NOT NULL,
    Cantidad INT NOT NULL,
    Subtotal DECIMAL(18,2) NOT NULL,
    
    -- Integridad Referencial
    CONSTRAINT FK_DetallePedido_Pedido FOREIGN KEY (IdPedido) 
        REFERENCES Pedido(IdPedido) ON DELETE CASCADE,
    
    CONSTRAINT FK_DetallePedido_Platillo FOREIGN KEY (IdPlatillo)
        REFERENCES Platillo(IdPlatillo) ON DELETE NO ACTION, -- Evitar cascadas múltiples si es necesario
        
    -- Restricciones de Validación
    CONSTRAINT CHK_DetallePedido_Cantidad CHECK (Cantidad > 0),
    CONSTRAINT CHK_DetallePedido_Subtotal CHECK (Subtotal >= 0)
);

-- Índices para optimización
CREATE INDEX IX_Platillo_IdRestaurante ON Platillo(IdRestaurante);
CREATE INDEX IX_Pedido_IdUsuario ON Pedido(IdUsuario);
CREATE INDEX IX_DetallePedido_IdPedido ON DetallePedido(IdPedido);
CREATE INDEX IX_DetallePedido_IdPlatillo ON DetallePedido(IdPlatillo);
