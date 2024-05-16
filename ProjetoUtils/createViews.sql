GO
CREATE VIEW FuncionariosDaLoja AS
SELECT f.*
FROM Funcionario f
JOIN Loja l ON f.loja = l.id_loja
WHERE l.gerente = f.nif;
GO

GO
CREATE VIEW InformacoesFuncionario AS
SELECT f.nif, p.nome, f.tipo, p.email, p.telefone, l.id_loja, l.telefone AS telefone_loja
FROM Funcionario f
JOIN Pessoa p ON f.nif = p.nif
LEFT JOIN Loja l ON f.loja = l.id_loja;
GO

GO
CREATE VIEW StockPorLoja AS
SELECT l.id_loja, l.nome AS nome_loja, p.id_produto, p.nome AS nome_produto, sf.quantidade AS quantidade_stock
FROM Loja l
JOIN Stock_Loja sf ON l.id_loja = sf.loja
JOIN Produto p ON sf.produto = p.id_produto;
GO

GO
CREATE VIEW ContratosAtivos AS
SELECT f.nif, p.nome, c.id_contrato, c.data_inicio, c.data_fim
FROM Funcionario f
JOIN Pessoa p ON f.nif = p.nif
JOIN Contrato c ON f.nif = c.nif
WHERE c.data_fim IS NULL OR c.data_fim > CURDATE();
GO