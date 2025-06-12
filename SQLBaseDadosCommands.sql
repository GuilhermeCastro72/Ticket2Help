CREATE DATABASE Ticket2Help

USE Ticket2Help
GO

CREATE TABLE Colaboradores(
ID int identity(1,1) primary key ,
admin bit,
nome nvarchar(30),
username nvarchar(20),
password nvarchar(20)
)

CREATE TABLE Ticket (
    ID int IDENTITY(1,1) PRIMARY KEY,
	Colaborador_ID_Maker int FOREIGN KEY REFERENCES Colaboradores(ID),
    tipo nvarchar(10) NOT NULL CHECK (tipo IN ('hardware', 'software')),
    data_criacao datetime,
	status_ticket nvarchar(15) NOT NULL CHECK (status_ticket IN ('porAtender', 'emAtendimento', 'atendido')) DEFAULT 'porAtender', task_ticket 	nvarchar(50), info_ticket nvarchar(2000),
	Colaborador_ID_Atend int FOREIGN KEY REFERENCES Colaboradores(ID),
	data_atendimento datetime,
    status_atend nvarchar(15) NOT NULL CHECK (status_atend IN ('aberto', 'resolvido', 'naoResolvido')) DEFAULT 'naoResolvido',
    info_atend nvarchar(2000),	
);

INSERT INTO Colaboradores (admin, nome, username, password)
VALUES
(1, 'Joao', 'admin', 'admin1'),
(0, 'Diogo', 'diogo', 'diogo1' ),
(0, 'maria', 'maria', 'maria1');

SELECT * FROM Colaboradores

SELECT * FROM Ticket

WHERE status_ticket = 'porAtender' order by data_criacao

SELECT * FROM Ticket WHERE Colaborador_ID_Maker = 2 order by data_criacao

drop table Colaboradores
drop table Ticket
