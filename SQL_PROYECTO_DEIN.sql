DROP database if exists proyecto_dein;

CREATE DATABASE IF NOT EXISTS proyecto_dein;
USE proyecto_dein;

CREATE TABLE IF NOT EXISTS Usuarios (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Usuario VARCHAR(50) NOT NULL UNIQUE,
    Contrasena VARCHAR(50) NOT NULL
);

INSERT INTO Usuarios (Usuario, Contrasena)
VALUES ('admin', '1234');