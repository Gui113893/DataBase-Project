INSERT INTO Pessoa (nif, nome, sexo, email, telefone, rua, codigo_postal, localidade, tipo, salario) VALUES
(123456789, 'Manuel Silva', 'M', NULL, '912345678', 'Rua da Alegria 123', '1234-567', 'Porto', 'Diretor' , 900.00),
(234567890, 'Maria Santos', 'F', NUll, '923456789', 'Rua da Tristeza 234', '2345-678', 'Lisboa', 'Diretor', 900.00),
(345678901, 'Carlos Santos', 'M', NULL, '934567890', 'Rua da Alegria 345', '3456-789', 'Porto', 'Part-Time' , 800.00),
(456789012, 'Ana Silva', 'F', NULL, '945678901', 'Rua da Tristeza 456', '4567-890', 'Lisboa', 'Part-Time' ,800.00),
(567890123, 'Joao Santos', 'M', NULL, '956789012', 'Rua da Alegria 567', '5678-901', 'Porto', 'Part-Time' ,750.00),
(678901234, 'Luis Silva', 'M', NULL, '967890123', 'Rua da Tristeza 678', '6789-012', 'Lisboa', 'Part-Time' ,750.00),
(789012345, 'Rita Santos', 'F', NULL, '978901234', 'Rua da Alegria 789', '7890-123', 'Porto', 'Part-Time' ,750.00),
(890123456, 'Marta Silva', 'F', NULL, '989012345', 'Rua da Tristeza 890', '8901-234', 'Lisboa', 'Part-Time' ,750.00),
(901234567, 'Pedro Santos', 'M', NULL, '900123456', 'Rua da Alegria 901', '9012-345', 'Porto', 'Part-Time' ,750.00),
(123456780, 'Mariana Silva', 'F', NULL, '912345670', 'Rua da Tristeza 123', '1234-567', 'Lisboa', 'Part-Time' ,750.00);

INSERT INTO Diretor (nif) VALUES
(123456789),
(234567890);

INSERT INTO SubEmpresa (nome, diretor) VALUES
('SubEmpresa 1', 123456789),
('SubEmpresa 2', 234567890);


INSERT INTO Loja (telefone, rua, codigo_postal, localidade, subempresa, gerente) VALUES
('912345678', 'Rua da Alegria 123', '1234-567', 'Porto', 1, NULL),
('923456789', 'Rua da Tristeza 234', '2345-678', 'Lisboa', 1, NULL),
('934567890', 'Rua da Alegria 345', '3456-789', 'Porto', 1, NULL),
('945678901', 'Rua da Tristeza 456', '4567-890', 'Lisboa', 1, NULL),
('956789012', 'Rua da Alegria 567', '5678-901', 'Porto', 1, NULL),
('967890123', 'Rua da Tristeza 678', '6789-012', 'Lisboa', 1, NULL),
('978901234', 'Rua da Alegria 789', '7890-123', 'Porto', 1, NULL),
('989012345', 'Rua da Tristeza 890', '8901-234', 'Lisboa', 1, NULL),
('900123456', 'Rua da Alegria 901', '9012-345', 'Porto', 1, NULL),
('912345670', 'Rua da Tristeza 123', '1234-567', 'Lisboa', 1, NULL);

INSERT INTO Funcionario (nif, loja) VALUES
(123456789, 1),
(234567890, 1),
(345678901, 2),
(456789012, 3),
(567890123, 1),
(678901234, 6),
(789012345, 1),
(890123456, 2),
(901234567, 1),
(123456780, 3);

INSERT INTO Part_Time (nif, horas_semanais) VALUES
(123456789, 20),
(234567890, 20),
(345678901, 20),
(456789012, 30),
(567890123, 20),
(678901234, 15),
(789012345, 20),
(890123456, 23),
(901234567, 20),
(123456780, 12);