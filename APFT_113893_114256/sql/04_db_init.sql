INSERT INTO Pessoa (nif, nome, sexo, email, telefone, rua, codigo_postal, localidade, tipo, salario) VALUES
(123456789, 'Manuel Silva', 'M', NULL, '912345678', 'Rua da Alegria 123', '1234-567', 'Porto', 'Diretor' , 900.00),
(234567890, 'Maria Santos', 'F', NUll, '923456789', 'Rua da Tristeza 234', '2345-678', 'Lisboa', 'Diretor', 900.00),
(345678901, 'Carlos Santos', 'M', NULL, '934567890', 'Rua da Alegria 345', '3456-789', 'Porto', 'Efetivo' , 800.00),
(456789012, 'Ana Silva', 'F', NULL, '945678901', 'Rua da Tristeza 456', '4567-890', 'Lisboa', 'Efetivo' ,800.00),
(567890123, 'Joao Santos', 'M', NULL, '956789012', 'Rua da Alegria 567', '5678-901', 'Porto', 'Part-Time' ,750.00),
(678901234, 'Luis Silva', 'M', NULL, '967890123', 'Rua da Tristeza 678', '6789-012', 'Lisboa', 'Efetivo' ,750.00),
(789012345, 'Rita Santos', 'F', NULL, '978901234', 'Rua da Alegria 789', '7890-123', 'Porto', 'Part-Time' ,750.00),
(890123456, 'Marta Silva', 'F', NULL, '989012345', 'Rua da Tristeza 890', '8901-234', 'Lisboa', 'Efetivo' ,750.00),
(901234567, 'Pedro Santos', 'M', NULL, '900123456', 'Rua da Alegria 901', '9012-345', 'Porto', 'Efetivo' ,750.00),
(123456780, 'Mariana Silva', 'F', NULL, '912345670', 'Rua da Tristeza 123', '1234-567', 'Lisboa', 'Part-Time' ,750.00),
(365145782, 'Mário Jorge', 'M', NULL, '912345670', 'Rua da Tristeza 123', '1234-567', 'Lisboa', 'Diretor' ,750.00),
(111111111, 'John Doe', 'M', NULL, '111111111', '123 Main St', '12345', 'New York', 'Part-Time' ,750.00),
(222222222, 'Jane Smith', 'F', NULL, '222222222', '456 Elm St', '67890', 'Los Angeles', 'Efetivo' ,750.00),
(333333333, 'Alice Johnson', 'F', NULL, '333333333', '789 Oak St', '13579', 'Chicago', 'Part-Time' ,750.00),
(444444444, 'Bob Brown', 'M', NULL, '444444444', '012 Pine St', '24680', 'Houston', 'Part-Time' ,750.00),
(555555555, 'Charlie White', 'M', NULL, '555555555', '345 Cedar St', '36912', 'Phoenix', 'Efetivo' ,750.00),
(666666666, 'David Black', 'M', NULL, '666666666', '678 Maple St', '25814', 'Philadelphia', 'Part-Time' ,750.00),
(777777777, 'Eve Green', 'F', NULL, '777777777', '901 Walnut St', '14736', 'San Antonio', 'Efetivo' ,750.00),
(888888888, 'Frank Grey', 'M', NULL, '888888888', '234 Birch St', '25814', 'San Diego', 'Part-Time' ,750.00),
(999999999, 'Grace Silver', 'F', NULL, '999999999', '567 Pine St', '36912', 'San Francisco', 'Part-Time' ,750.00);

INSERT INTO Diretor (nif) VALUES
(123456789),
(234567890),
(365145782);

INSERT INTO SubEmpresa (nome, diretor) VALUES
('Continente', 123456789),
('Sportzone', 234567890),
('Worten', 365145782);


INSERT INTO Loja (telefone, rua, codigo_postal, localidade, subempresa, gerente) VALUES
('912345678', 'Rua da Alegria 123', '1234-567', 'Porto', 1, NULL),
('923456789', 'Rua da Tristeza 234', '2345-678', 'Lisboa', 1, NULL),
('934567890', 'Rua da Alegria 345', '3456-789', 'Porto', 1, NULL),
('945678901', 'Rua da Tristeza 456', '4567-890', 'Lisboa', 2, NULL),
('956789012', 'Rua da Alegria 567', '5678-901', 'Porto', 1, NULL),
('967890123', 'Rua da Tristeza 678', '6789-012', 'Aveiro', 3, NULL),
('978901234', 'Rua da Alegria 789', '7890-123', 'Aveiro', 3, NULL),
('989012345', 'Rua da Tristeza 890', '8901-234', 'Lisboa', 2, NULL);

INSERT INTO Funcionario (nif, loja) VALUES

(345678901, 2),
(456789012, 3),
(567890123, 1),
(678901234, 6),
(789012345, 1),
(890123456, 2),
(901234567, 1),
(123456780, 3),
(111111111, 1),
(222222222, 2),
(333333333, 3),
(444444444, 6),
(555555555, 1),
(666666666, 2),
(777777777, 3),
(888888888, 6),
(999999999, 1);


INSERT INTO Contrato(data_inicio, data_fim) VALUES
('2023-05-16', '2025-09-28'),
('2023-05-16', '2025-09-07'),
('2023-05-16', '2025-09-07'),
('2023-05-16', '2025-09-07'),
('2023-05-16', '2025-09-07'),
('2023-05-16', '2025-09-07'),
('2023-05-16', '2025-09-07'),
('2023-05-16', '2025-09-07');


INSERT INTO Efetivo(nif, contrato) VALUES
(890123456, 1),
(901234567, 2),
(555555555, 3),
(777777777, 4),
(222222222, 5),
(345678901, 6),
(456789012, 7),
(678901234, 8);

INSERT INTO Part_Time (nif, horas_semanais) VALUES
(567890123, 20),
(789012345, 20),
(123456780, 12),
(111111111, 20),
(333333333, 30),
(444444444, 20),
(666666666, 15),
(888888888, 20),
(999999999, 12);

UPDATE Loja SET gerente = 901234567 WHERE id_loja = 1;
UPDATE Loja SET gerente = 345678901 WHERE id_loja = 2;
UPDATE Loja SET gerente = 456789012 WHERE id_loja = 3;
UPDATE Loja SET gerente = 678901234 WHERE id_loja = 6;

INSERT INTO Patente (data_registo, data_vencimento, logo) VALUES
('2023-05-16', '2025-09-28', 'logo1'),
('2023-05-16', '2025-09-07', 'logo2'),
('2023-05-16', '2025-09-07', 'logo3'),
('2023-05-16', '2025-09-07', 'logo4'),
('2023-05-16', '2025-09-07', 'logo5'),
('2023-05-16', '2025-09-07', 'logo6'),
('2023-05-16', '2025-09-07', 'logo7'),
('2023-05-16', '2025-09-07', 'logo8'),
('2023-05-16', '2025-09-07', 'logo9'),
('2023-05-16', '2025-09-07', 'logo10');

INSERT INTO Marca (patente, marcaNome) VALUES
(1, 'Nike'),
(2, 'Adidas'),
(3, 'Oreo'),
(4, 'NoteBook'),
(5, 'Apple'),
(6, 'Continente'),
(7, 'Prozis'),
(8, 'SuperBock'),
(9, 'ASUS'),
(10, 'Samsung');

INSERT INTO Pat_Locs (patente, Ploc) VALUES
(1, 'Porto'),
(1, 'Aveiro'),
(1, 'Lisboa'),
(2, 'Lisboa'),
(2, 'Porto'),
(3, 'Porto'),
(3, 'Aveiro'),
(3, 'Lisboa'),
(4, 'Porto'),
(4, 'Aveiro'),
(5, 'Lisboa'),
(5, 'Porto'),
(6, 'Porto'),
(6, 'Aveiro'),
(7, 'Aveiro'),
(7, 'Porto'),
(8, 'Lisboa'),
(8, 'Porto'),
(9, 'Porto'),
(9, 'Aveiro'),
(10, 'Porto'),
(10, 'Aveiro');

INSERT INTO Produto (preco, nome, marca) VALUES
(100.00, 'Sapatilhas', 1),
(50.00, 'T-Shirt', 2),
(1.00, 'Bolacha', 3),
(1000.00, 'Laptop', 4),
(1000.00, 'iPhone', 5),
(1.00, 'Pão', 6),
(1.00, 'Proteina', 7),
(1.00, 'Cerveja', 8),
(1000.00, 'Laptop', 9),
(1000.00, 'Smartphone', 10),
(55.00, 'T-Shirt', 1);

INSERT INTO Fornecedor (telefone, rua, codigo_postal, localidade) VALUES
( '912345678', 'Rua da Alegria 123', '1234-567', 'Porto'),
('923456789', 'Rua da Tristeza 234', '2345-678', 'Lisboa'),
('934567890', 'Rua da Alegria 345', '3456-789', 'Porto'),
( '945678901', 'Rua da Tristeza 456', '4567-890', 'Lisboa'),
('956789012', 'Rua da Alegria 567', '5678-901', 'Porto'),
('967890123', 'Rua da Tristeza 678', '6789-012', 'Aveiro'),
('978901234', 'Rua da Alegria 789', '7890-123', 'Aveiro'),
( '989012345', 'Rua da Tristeza 890', '8901-234', 'Lisboa'),
('900123456', 'Rua da Alegria 901', '9012-345', 'Porto'),
('912345670', 'Rua da Tristeza 123', '1234-567', 'Lisboa');

INSERT INTO Stock_Fornecido (fornecedor, produto, quantidade) VALUES
(1, 1, 200),
(2, 2, 150),
(3, 3, 210),
(1, 4, 300),
(5, 5, 124),
(6, 6, 280),
(7, 7, 150),
(8, 8, 180),
(9, 9, 220),
(6, 10, 200),
(1,11, 250);

INSERT INTO Stock_Loja (loja, produto, quantidade) VALUES
(1, 3, 10),
(2, 3, 50),
(3, 3, 20),
(5, 3, 5),
(1, 6, 10),
(3, 6, 20),
(5, 6, 5),
(1, 7, 10),
(3, 7, 20),
(5, 7, 5),
(1, 8, 10),
(2, 8, 50),
(3, 8, 20),
(5, 8, 5),
(4, 1, 100),
(4, 2, 120),
(6, 4, 100),
(7, 4, 60),
(6, 9, 20),
(7, 9, 60),
(6, 10, 20),
(7, 10, 60),
(4, 11, 100),
(8, 11, 100);
