-- Crear la base de datos
CREATE DATABASE SistemaReservas;


-- Usar la base de datos
USE SistemaReservas;


-- Crear la tabla Clientes
CREATE TABLE Clientes (
    ClienteId INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Telefono NVARCHAR(15)
);


-- Crear la tabla Servicios
CREATE TABLE Servicios (
    ServicioId INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255),
    Precio DECIMAL(18, 2) NOT NULL
);


-- Crear la tabla Reservas
CREATE TABLE Reservas (
    ReservaId INT PRIMARY KEY IDENTITY(1,1),
    ClienteId INT NOT NULL,
    ServicioId INT NOT NULL,
    Fecha DATETIME NOT NULL,
    FOREIGN KEY (ClienteId) REFERENCES Clientes(ClienteId),
    FOREIGN KEY (ServicioId) REFERENCES Servicios(ServicioId)
);



INSERT INTO Clientes (Nombre, Apellido, Email, Telefono) VALUES ('Juan', 'Perez', 'juan.perez@example.com', '123456789');
INSERT INTO Clientes (Nombre, Apellido, Email, Telefono) VALUES ('Maria', 'Gomez', 'maria.gomez@example.com', '987654321');


-- Insertar datos de ejemplo en la tabla Servicios
INSERT INTO Servicios (Nombre, Descripcion, Precio) VALUES ('Servicio 1', 'Descripción del Servicio 1', 100.00);
INSERT INTO Servicios (Nombre, Descripcion, Precio) VALUES ('Servicio 2', 'Descripción del Servicio 2', 200.00);

-- Insertar datos de ejemplo en la tabla Reservas
INSERT INTO Reservas (ClienteId, ServicioId, Fecha) VALUES (1, 1, '2024-08-29 10:00:00');
INSERT INTO Reservas (ClienteId, ServicioId, Fecha) VALUES (2, 2, '2024-08-30 11:00:00');

