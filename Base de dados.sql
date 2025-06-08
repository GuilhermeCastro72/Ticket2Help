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
(0, 'maria', 'maria', 'maria');

SELECT * FROM Colaboradores

INSERT INTO Ticket ( Colaborador_ID_Maker, tipo, data_criacao, status_ticket, task_ticket, info_ticket, Colaborador_ID_Atend, data_atendimento, status_atend, info_atend )
VALUES
( 2, 'software', '2025-06-04 10:10:10', 'atendido', 'Photoshop', 'Preciso de instalar o Photoshop para cumprir tarefa dada.' , 1, '2025-06-04 12:12:12', 'resolvido', 'Instala  o de Photoshop foi feita.'),
( 2, 'hardware', '2025-06-04 11:11:11', 'porAtender', 'fonte de alimentação', null, null , null, 'naoResolvido', null),
( 3, 'hardware', '2025-06-04 11:11:11', 'porAtender', 'placa gráfica', null, null , null, 'naoResolvido', null)

SELECT * FROM Ticket
WHERE status_ticket = 'porAtender' order by data_criacao

SELECT * FROM Ticket WHERE Colaborador_ID_Maker = 2 order by data_criacao

drop table Colaboradores
drop table Ticket
