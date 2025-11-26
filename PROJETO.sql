CREATE DATABASE projeto;
 
USE projeto;
 
CREATE TABLE Usuario(
	id INT PRIMARY KEY IDENTITY,
	email VARCHAR(120) UNIQUE,
	nome VARCHAR(120),
	senha VARCHAR(15),
);
 
DROP TABLE Usuario;
 
CREATE TABLE cliente(
	id INT PRIMARY KEY IDENTITY,
	Usuario_id INT,
	FOREIGN KEY (Usuario_id) REFERENCES Usuario(id),
	email VARCHAR(120),
	Codcliente VARCHAR (10),
	Razaosocial VARCHAR (80),
	CNPJ VARCHAR (14)
);
DROP TABLE cliente;
 
 
CREATE TABLE pedido(
	id INT PRIMARY KEY IDENTITY,

	Usuario_id INT,	
	FOREIGN KEY (Usuario_id) REFERENCES Usuario(id),

	cliente_id INT,
	FOREIGN KEY (cliente_id) REFERENCES cliente(id),

	Produto_id INT,
	FOREIGN KEY (Produto_id) REFERENCES Produto(id),

	codpedido INT,
	quantidade VARCHAR(100)
);
DROP TABLE pedido;
 
CREATE TABLE Produto(
	id INT PRIMARY KEY IDENTITY,
	nomeproduto VARCHAR(100),
	preco NUMERIC(5,2),
	quantidade VARCHAR(100),

);
DROP TABLE Produto;

CREATE TABLE Funcionario(
id INT PRIMARY KEY IDENTITY,
ADMIN BIT,
Usuario_id INT,	
FOREIGN KEY (Usuario_id) REFERENCES Usuario(id),
);
 
 
SELECT * FROM Usuario ;
SELECT * FROM cliente ;
SELECT * FROM pedido ;
SELECT * FROM Produto ;
SELECT * FROM Funcionario ;

-----------------------------------------------------------------------------
-- USUARIO --
INSERT INTO Usuario (email, nome, senha) VALUES
('joao.silva@email.com', 'João Silva', 'senha123'),
('maria.oliveira@email.com', 'Maria Oliveira', 'senha456'),
('carlos.souza@email.com', 'Carlos Souza', 'senha789');
 
-- CLIENTE --
INSERT INTO cliente (Usuario_id, email,Codcliente,Razaosocial,CNPJ ) VALUES
(1, 'cliente.joao@email.com', 'A7X3B9','Lima Alimentos','12345678000190'),
(2, 'cliente.maria@email.com', 'K3M9T2','TechNova Digital','98765432000101'),
(3, 'cliente.carlos@email.com', 'K3M9T2','EcoVida Verde','45678912000155');
 
-- PEDIDO --
CREATE DATABASE projeto;
 
USE projeto;
 
CREATE TABLE Usuario(
	id INT PRIMARY KEY IDENTITY,
	email VARCHAR(120) UNIQUE,
	nome VARCHAR(120),
	senha VARCHAR(15),
);
 
DROP TABLE Usuario;
 
CREATE TABLE cliente(
	id INT PRIMARY KEY IDENTITY,
	Usuario_id INT,
	FOREIGN KEY (Usuario_id) REFERENCES Usuario(id),
	email VARCHAR(120),
	Codcliente VARCHAR (10),
	Razaosocial VARCHAR (80),
	CNPJ VARCHAR (14)
);
DROP TABLE cliente;
 
 
CREATE TABLE pedido(
	id INT PRIMARY KEY IDENTITY,

	Usuario_id INT,	
	FOREIGN KEY (Usuario_id) REFERENCES Usuario(id),

	cliente_id INT,
	FOREIGN KEY (cliente_id) REFERENCES cliente(id),

	Produto_id INT,
	FOREIGN KEY (Produto_id) REFERENCES Produto(id),

	codpedido INT,
	quantidade VARCHAR(100)
);
DROP TABLE pedido;
 
CREATE TABLE Produto(
	id INT PRIMARY KEY IDENTITY,
	nomeproduto VARCHAR(100),
	preco DECIMAL(10,2),
	quantidade INT,

);
DROP TABLE Produto;

CREATE TABLE Funcionario(
id INT PRIMARY KEY IDENTITY,
ADMIN BIT,
Usuario_id INT,	
FOREIGN KEY (Usuario_id) REFERENCES Usuario(id),
);
 
 
SELECT * FROM Usuario ;
SELECT * FROM cliente ;
SELECT * FROM pedido ;
SELECT * FROM Produto ;
SELECT * FROM Funcionario ;

-----------------------------------------------------------------------------
-- USUARIO --
INSERT INTO Usuario (email, nome, senha) VALUES
('joao.silva@email.com', 'João Silva', 'senha123'),
('maria.oliveira@email.com', 'Maria Oliveira', 'senha456'),
('carlos.souza@email.com', 'Carlos Souza', 'senha789');
 
-- CLIENTE --
INSERT INTO cliente (Usuario_id, email,Codcliente,Razaosocial,CNPJ ) VALUES
(1, 'cliente.joao@email.com', 'A7X3B9','Lima Alimentos','12345678000190'),
(2, 'cliente.maria@email.com', 'K3M9T2','TechNova Digital','98765432000101'),
(3, 'cliente.carlos@email.com', 'K3M9T2','EcoVida Verde','45678912000155');
 
-- PEDIDO --

INSERT INTO Pedido (Usuario_id, cliente_id, Produto_id, codpedido, quantidade) VALUES
(1, 1, 7,  201, 1),   -- Notebook Gamer
(1, 1, 9,  202, 2),   -- RTX 4060
(2, 2, 14, 203, 1),   -- Smartphone Android
(2, 2, 3,  204, 2),   -- Monitor LED 24"
(2, 2, 12, 205, 3),   -- Memória RAM 16GB
(3, 3, 10, 206, 1),   -- Fonte 750W
(3, 3, 5,  207, 1),   -- Webcam Full HD
(1, 1, 13, 208, 1),   -- Impressora Multifuncional
(1, 1, 1,  209, 3),   -- Teclado Mecânico
(2, 2, 8,  210, 1),   -- SSD 1TB NVMe
(3, 3, 18, 211, 2),   -- Projetor Full HD
(3, 3, 6,  212, 1);   -- Cadeira Gamer
 
-- PRODUTO --
INSERT INTO Produto (nomeproduto, preco, quantidade) 
VALUES
('Teclado Mecânico RGB', 199.99, 5),
('Servidor Rack Dell PowerEdge', 15999.00,  2),
('Mouse Gamer 7200 DPI', 149.50, 3),
('Monitor LED 24"', 899.90, 2),
('Headset com Microfone', 249.90, 4),
('Webcam Full HD', 179.99, 6),
('Cadeira Gamer', 999.00, 1);


INSERT INTO Produto (nomeproduto, preco, quantidade) 
VALUES
('Switch Gerenciável 48 Portas', 4999.90, 4),
('Roteador Wi-Fi 6 AX6000', 1299.00, 6),
('Firewall Fortinet FG-60F', 3499.00, 3),
('Notebook Ultrafino Intel i7', 6999.00, 5),
('Monitor Curvo 34" UltraWide', 2999.00, 2),
('Placa-Mãe ASUS ROG', 1499.00, 7),
('Processador AMD Ryzen 9 7900X', 2999.00, 4),
('No-Break 1500VA', 899.90, 8),
('Impressora Laser Colorida', 1599.00, 3),
('Scanner Profissional A3', 2499.00, 2),
('Projetor Full HD 4000 Lumens', 1999.00, 3);
 
 
-- PRODUTO --


 
SELECT * FROM Usuario ;
SELECT * FROM cliente ;
SELECT * FROM pedido ;
SELECT * FROM Produto ;