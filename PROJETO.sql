-- 1. Mude o contexto para um banco de dados que não será excluído (como 'master' ou 'tempdb')
USE master; 
GO 
-- O comando GO pode ser necessário dependendo do ambiente para garantir que o contexto mude imediatamente.

-- 2. Agora apague o banco de dados 'projeto'
DROP DATABASE projeto;


-------------------------------------------------------------------------------------------------------------------------------------
-- 1. CRIAÇÃO DO BANCO DE DADOS
CREATE DATABASE projeto;
USE projeto;

-- 2. CRIAÇÃO DAS TABELAS (na ordem correta de dependência)

-- USUARIO (Não depende de ninguém)
CREATE TABLE Usuario(
    id INT PRIMARY KEY IDENTITY,
    email VARCHAR(120) UNIQUE,
    nome VARCHAR(120),
    senha VARCHAR(15)
);
DROP TABLE Usuario;

-- CLIENTE (Depende de Usuario)
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

-- PRODUTO (Não depende de ninguém - Criada ANTES de Pedido)
CREATE TABLE Produto(
    id INT PRIMARY KEY IDENTITY,
    nomeproduto VARCHAR(100),
    preco NUMERIC(10,2), -- Usando NUMERIC(10,2) para valores monetários
    quantidade INT -- Usando INT para quantidade
);
DROP TABLE Produto;

-- PEDIDO (Depende de Usuario, Cliente e Produto)
CREATE TABLE pedido(
    id INT PRIMARY KEY IDENTITY,
    Usuario_id INT,    
    FOREIGN KEY (Usuario_id) REFERENCES Usuario(id),
    cliente_id INT,
    FOREIGN KEY (cliente_id) REFERENCES cliente(id),
    Produto_id INT,
    FOREIGN KEY (Produto_id) REFERENCES Produto(id),
    codpedido INT,
    quantidade INT -- Corrigido para INT
);
DROP TABLE pedido;

---

-- 3. INSERÇÃO DE DADOS (na ordem correta)

-- USUARIO
INSERT INTO Usuario (email, nome, senha) VALUES
('joao.silva@email.com', 'João Silva', 'senha123'),
('maria.oliveira@email.com', 'Maria Oliveira', 'senha456'),
('carlos.souza@email.com', 'Carlos Souza', 'senha789');
-- Os IDs gerados serão 1, 2 e 3.

-- CLIENTE
INSERT INTO cliente (Usuario_id, email, Codcliente, Razaosocial, CNPJ) VALUES
(1, 'cliente.joao@email.com', 'A7X3B9','Lima Alimentos','12345678000190'),
(2, 'cliente.maria@email.com', 'K3M9T2','TechNova Digital','98765432000101'),
(3, 'cliente.carlos@email.com', 'K3M9T2','EcoVida Verde','45678912000155');
-- Os IDs gerados serão 1, 2 e 3.

-- PRODUTO (Unificado e Corrigido)
INSERT INTO Produto (nomeproduto, preco, quantidade) VALUES
('Teclado Mecânico RGB', 199.99, 5),
('Servidor Rack Dell PowerEdge', 15999.00, 2),
('Mouse Gamer 7200 DPI', 149.50, 3),
('Monitor LED 24"', 899.90, 2),
('Headset com Microfone', 249.90, 4),
('Webcam Full HD', 179.99, 6),
('Cadeira Gamer', 999.00, 1),
('Switch Gerenciável 48 Portas', 4999.90, 4), -- ID 8
('Roteador Wi-Fi 6 AX6000', 1299.00, 6),     -- ID 9
('Firewall Fortinet FG-60F', 3499.00, 3),    -- ID 10
('Notebook Ultrafino Intel i7', 6999.00, 5), -- ID 11
('Monitor Curvo 34" UltraWide', 2999.00, 2), -- ID 12
('Placa-Mãe ASUS ROG', 1499.00, 7),          -- ID 13
('Processador AMD Ryzen 9 7900X', 2999.00, 4), -- ID 14
('No-Break 1500VA', 899.90, 8),             -- ID 15
('Impressora Laser Colorida', 1599.00, 3),   -- ID 16
('Scanner Profissional A3', 2499.00, 2),     -- ID 17
('Projetor Full HD 4000 Lumens', 1999.00, 3); -- ID 18

-- PEDIDO (Sintaxe Corrigida - Agora os IDs de Produto existem)
INSERT INTO pedido (Usuario_id, cliente_id, Produto_id, codpedido, quantidade) VALUES
-- Note que os valores de Produto_id (7, 9, 14, 3, 12, 10, 5, 13, 1, 8, 18, 6) agora correspondem aos IDs da tabela Produto
(1, 1, 7,  201, 1),    
(1, 1, 9,  202, 2),    
(2, 2, 14, 203, 1),    
(2, 2, 3,  204, 2),    
(2, 2, 12, 205, 3),    
(3, 3, 10, 206, 1),    
(3, 3, 5,  207, 1),    
(1, 1, 13, 208, 1),    
(1, 1, 1,  209, 3),    
(2, 2, 8,  210, 1),    
(3, 3, 18, 211, 2),    
(3, 3, 6,  212, 1);    

-- 4. CONSULTA DOS DADOS
SELECT * FROM Usuario;
SELECT * FROM cliente;
SELECT * FROM pedido;
SELECT * FROM Produto;