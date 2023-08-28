CREATE DATABASE Filmes_Gabriel
USE Filmes_Gabriel

CREATE TABLE Genero
(
	IdGenero INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(50) NOT NULL
)

CREATE TABLE Filme
(
	IdFilme INT PRIMARY KEY IDENTITY,
	IdGenero INT FOREIGN KEY REFERENCES Genero(IdGenero),
	Titulo VARCHAR(50) NOT NULL
)

INSERT INTO Genero
VALUES
('Comédia'),
('Ação'),
('Suspense')
('Terror');

SELECT * FROM Genero

INSERT INTO Filme
VALUES
(1,'Golpe Baixo'), 
(2, 'Velozes e Furiosos'),
(4, 'Arnaldo Schwarzenegger, O Bodybuilder da JALL'), 
(3, 'Um Lugar Silencioso');

SELECT * FROM Filme

SELECT 
	Genero.Nome,
	Filme.Titulo
FROM
	Genero LEFT JOIN Filme ON Genero.IdGenero = Filme.IdGenero

UPDATE Genero
SET Nome = 'Comedia'
WHERE IdGenero = 6;

