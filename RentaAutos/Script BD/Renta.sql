CREATE DATABASE DB_RENTA_AUTO;
USE DB_RENTA_AUTO;

CREATE TABLE MARCA(
ID_MARCA BIGINT PRIMARY KEY IDENTITY(1,1),
NOMBRE_MARCA VARCHAR(MAX) NOT NULL,
FECHA_CREACION DATETIME NOT NULL,
ACTIVO BIT NOT NULL
);

CREATE TABLE TIPO(
ID_TIPO BIGINT PRIMARY KEY IDENTITY(1,1),
NOMBRE_TIPO VARCHAR(MAX) NOT NULL,
FECHA_CREACION DATETIME NOT NULL,
ACTIVO BIT NOT NULL
);

CREATE TABLE AUTOMOVIL (
ID_AUTOMOVIL BIGINT PRIMARY KEY IDENTITY (1,1),
GAMA VARCHAR(MAX) NOT NULL,
FECHA_CREACION DATETIME NOT NULL,
PRECIO BIGINT NOT NULL,
OCUPADO BIT NOT NULL,
ACTIVO BIT NOT NULL,
ID_MARCA BIGINT NOT NULL,
ID_TIPO BIGINT NOT NULL,
FOREIGN KEY (ID_MARCA) REFERENCES MARCA(ID_MARCA),
FOREIGN KEY (ID_TIPO) REFERENCES TIPO(ID_TIPO)
);

CREATE TABLE ROL (
ID_ROL BIGINT PRIMARY KEY IDENTITY (1,1),
NOMBRE_ROL VARCHAR(MAX) NOT NULL,
FECHA_CREACION DATETIME NOT NULL,
ACTIVO BIT NOT NULL
);

CREATE TABLE USUARIO(
ID_USUARIO  BIGINT PRIMARY KEY IDENTITY (1,1),
USUARIO VARCHAR(MAX) NOT NULL,
CONTRASENA VARCHAR(MAX) NOT NULL,
NOMBRE_USUARIO VARCHAR(MAX) NOT NULL,
APELLIDO_USUARIO VARCHAR(MAX) NOT NULL,
FECHA_NACIMIENTO DATETIME NOT NULL,
DIRECCION VARCHAR(MAX) NOT NULL,
TELEFONO VARCHAR(MAX) NOT NULL,
CORREO VARCHAR(MAX) NOT NULL,
ID_ROL BIGINT NOT NULL,
FOREIGN KEY (ID_ROL) REFERENCES ROL(ID_ROL)
);

CREATE TABLE RENTA (
ID_RENTA  BIGINT PRIMARY KEY IDENTITY (1,1),
PRECIO BIGINT NOT NULL,
FECHA_ALQUILER DATETIME NOT NULL,
ID_AUTOMOVIL BIGINT NOT NULL,
ID_USUARIO BIGINT NOT NULL,
FOREIGN KEY (ID_AUTOMOVIL) REFERENCES AUTOMOVIL(ID_AUTOMOVIL),
FOREIGN KEY (ID_USUARIO) REFERENCES USUARIO(ID_USUARIO)
);