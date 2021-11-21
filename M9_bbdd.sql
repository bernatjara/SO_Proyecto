DROP DATABASE IF EXISTS M9_BaseDatos;
CREATE DATABASE M9_BaseDatos;

USE M9_BaseDatos;

CREATE TABLE Jugador(
	ID INT NOT NULL AUTO_INCREMENT,
	Nombre VARCHAR(60),
	Password VARCHAR(60),
	Victoria INT NOT NULL,
	PRIMARY KEY (ID)
)ENGINE=InnoDB;

CREATE TABLE Partida(
	ID INT NOT NULL AUTO_INCREMENT,
	Fecha VARCHAR(10),	/*YYYY-MM-DD*/
	Hora VARCHAR(10),	/*HH: MM: SS*/
	Duracion INT,		/*Duración en minutos*/
	Ganador VARCHAR(60),
	PRIMARY KEY (ID)
)ENGINE=InnoDB;

CREATE TABLE Partidas(
	ID_J INT,
	ID_P INT,
	Puntuacion INT,
	FOREIGN KEY (ID_J) REFERENCES Jugador(ID),
	FOREIGN KEY (ID_P) REFERENCES Partida(ID)
)ENGINE=InnoDB;

INSERT INTO Jugador(Nombre, Password, Victoria) VALUES ('Bernat','12',1); 
INSERT INTO Jugador(Nombre, Password, Victoria) VALUES ('Jordi','34',1);
INSERT INTO Jugador(Nombre, Password, Victoria) VALUES ('Nil','56',1);
INSERT INTO Jugador(Nombre, Password, Victoria) VALUES ('Miguel','78',0);
INSERT INTO Jugador(Nombre, Password, Victoria) VALUES ('Eda','51',2);
INSERT INTO Jugador(Nombre, Password, Victoria) VALUES ('Pablo','88',0);
INSERT INTO Jugador(Nombre, Password, Victoria) VALUES ('Aitana','98',1);
INSERT INTO Jugador(Nombre, Password, Victoria) VALUES ('Aida','345',0);

INSERT INTO Partida(Fecha, Hora, Duracion, Ganador) VALUES ('2008-07-01','00: 01: 59',120,'Eda');
INSERT INTO Partida(Fecha, Hora, Duracion, Ganador) VALUES ('2010-08-22','10: 59: 59',60,'Aitana');
INSERT INTO Partida(Fecha, Hora, Duracion, Ganador) VALUES ('2005-05-05','22: 30: 15',14,'Bernat');
INSERT INTO Partida(Fecha, Hora, Duracion, Ganador) VALUES ('2020-07-01','00: 17: 00',40,'Nil');
INSERT INTO Partida(Fecha, Hora, Duracion, Ganador) VALUES ('2008-07-15','08: 00: 00',120,'Eda');
INSERT INTO Partida(Fecha, Hora, Duracion, Ganador) VALUES ('2009-01-01','20: 00: 00',120,'Jordi');

INSERT INTO Partidas(ID_J, ID_P, Puntuacion) VALUES (1,1,11);
INSERT INTO Partidas(ID_J, ID_P, Puntuacion) VALUES (5,1,25);
INSERT INTO Partidas(ID_J, ID_P, Puntuacion) VALUES (7,2,60);
INSERT INTO Partidas(ID_J, ID_P, Puntuacion) VALUES (2,2,59);
INSERT INTO Partidas(ID_J, ID_P, Puntuacion) VALUES (1,3,14);
INSERT INTO Partidas(ID_J, ID_P, Puntuacion) VALUES (8,3,12);
INSERT INTO Partidas(ID_J, ID_P, Puntuacion) VALUES (3,4,40);
INSERT INTO Partidas(ID_J, ID_P, Puntuacion) VALUES (7,4,35);
INSERT INTO Partidas(ID_J, ID_P, Puntuacion) VALUES (7,5,11);
INSERT INTO Partidas(ID_J, ID_P, Puntuacion) VALUES (5,5,12);
INSERT INTO Partidas(ID_J, ID_P, Puntuacion) VALUES (2,6,11);
INSERT INTO Partidas(ID_J, ID_P, Puntuacion) VALUES (6,6,5);
