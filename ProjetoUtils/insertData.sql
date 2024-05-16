INSERT INTO Pessoa (nif, nome, sexo, email, telefone, rua, codigo_postal, localidade, salario) VALUES
(123456789, 'Manuel Silva', 'M', NULL, '912345678', 'Rua da Alegria 123', '1234-567', 'Porto', 1000.00),
(234567890, 'Maria Santos', 'F', NUll, '923456789', 'Rua da Tristeza 234', '2345-678', 'Lisboa', 900.00),
(345678901, 'Carlos Santos', 'M', NULL, '934567890', 'Rua da Alegria 345', '3456-789', 'Porto', 800.00),
(456789012, 'Ana Silva', 'F', NULL, '945678901', 'Rua da Tristeza 456', '4567-890', 'Lisboa', 800.00),
(567890123, 'Joao Santos', 'M', NULL, '956789012', 'Rua da Alegria 567', '5678-901', 'Porto', 750.00),
(678901234, 'Luis Silva', 'M', NULL, '967890123', 'Rua da Tristeza 678', '6789-012', 'Lisboa', 750.00),
(789012345, 'Rita Santos', 'F', NULL, '978901234', 'Rua da Alegria 789', '7890-123', 'Porto', 750.00),
(890123456, 'Marta Silva', 'F', NULL, '989012345', 'Rua da Tristeza 890', '8901-234', 'Lisboa', 750.00),
(901234567, 'Pedro Santos', 'M', NULL, '900123456', 'Rua da Alegria 901', '9012-345', 'Porto', 750.00),
(123456780, 'Mariana Silva', 'F', NULL, '912345670', 'Rua da Tristeza 123', '1234-567', 'Lisboa', 750.00);

INSERT INTO Diretor (nif) VALUES
(123456789);

INSERT INTO SubEmpresa (id, nome, diretor) VALUES
(1, 'SubEmpresa 1', 123456789);


INSERT INTO Loja (id_loja, telefone, rua, codigo_postal, localidade, subempresa, gerente) VALUES
(1, '912345678', 'Rua da Alegria 123', '1234-567', 'Porto', 1, NULL),
(2, '923456789', 'Rua da Tristeza 234', '2345-678', 'Lisboa', 1, NULL),
(3, '934567890', 'Rua da Alegria 345', '3456-789', 'Porto', 1, NULL),
(4, '945678901', 'Rua da Tristeza 456', '4567-890', 'Lisboa', 1, NULL),
(5, '956789012', 'Rua da Alegria 567', '5678-901', 'Porto', 1, NULL),
(6, '967890123', 'Rua da Tristeza 678', '6789-012', 'Lisboa', 1, NULL),
(7, '978901234', 'Rua da Alegria 789', '7890-123', 'Porto', 1, NULL),
(8, '989012345', 'Rua da Tristeza 890', '8901-234', 'Lisboa', 1, NULL),
(9, '900123456', 'Rua da Alegria 901', '9012-345', 'Porto', 1, NULL),
(10, '912345670', 'Rua da Tristeza 123', '1234-567', 'Lisboa', 1, NULL);