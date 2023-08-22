CREATE DATABASE Filmes_Gabriel
USE Filmes_Gabriel

CREATE TABLE Genero
(
	IdGenero INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(50)
)

CREATE TABLE Filme
(
	IdFilme INT PRIMARY KEY IDENTITY,
	IdGenero INT FOREIGN KEY REFERENCES Genero(IdGenero),
	Titulo VARCHAR(50)
)

INSERT INTO Genero
VALUES
('Comédia'),
('Ação'),
('Suspense');

SELECT * FROM Genero

INSERT INTO Filme
VALUES
(1,'Golpe Baixo'), 
(2, 'Velozes e Furiosos'), 
(3, 'Um Lugar Silencioso');

SELECT * FROM Filme