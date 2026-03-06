/*
    SISTEMA: FoodCampus - Delivery Universitario
    PLATAFORMA: SQL Server (Optimizado para Somee.com - 30MB)
    FECHA: 06/03/2026
*/

-- Tabla de Restaurantes
CREATE TABLE Restaurante (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Especialidad NVARCHAR(100) NULL,
    HorarioApertura TIME NOT NULL,
    HorarioCierre TIME NOT NULL
);

-- Tabla de Pedidos
CREATE TABLE Pedido (
    IdPedido INT IDENTITY(1,1) PRIMARY KEY,
    IdUsuario INT NOT NULL, -- Relación conceptual con tabla de usuarios
    FechaHora DATETIME DEFAULT GETDATE() NOT NULL,
    CostoEnvio DECIMAL(10,2) NOT NULL,
    
    -- Restricción: Costo de envío no negativo
    CONSTRAINT CHK_Pedido_CostoEnvio CHECK (CostoEnvio >= 0)
);

-- Tabla de Detalle del Pedido
CREATE TABLE DetallePedido (
    IdDetalle INT IDENTITY(1,1) PRIMARY KEY,
    IdPedido INT NOT NULL,
    IdPlatillo INT NOT NULL,
    Cantidad INT NOT NULL,
    Subtotal DECIMAL(10,2) NOT NULL,
    
    -- Integridad Referencial
    CONSTRAINT FK_DetallePedido_Pedido FOREIGN KEY (IdPedido) 
        REFERENCES Pedido(IdPedido) ON DELETE CASCADE,
        
    -- Restricciones de Validación
    CONSTRAINT CHK_DetallePedido_Cantidad CHECK (Cantidad > 0),
    CONSTRAINT CHK_DetallePedido_Subtotal CHECK (Subtotal >= 0)
);

-- Índices para mejorar rendimiento con poco espacio
CREATE INDEX IX_Pedido_IdUsuario ON Pedido(IdUsuario);
CREATE INDEX IX_DetallePedido_IdPedido ON DetallePedido(IdPedido);
