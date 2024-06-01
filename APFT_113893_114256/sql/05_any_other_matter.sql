-- Script para dar insert á tabela pessoa e testar o search
DECLARE @start_time DATETIME, @end_time DATETIME;
SET @start_time = GETDATE();
PRINT @start_time

DECLARE @val as int = 1;
DECLARE @nelem as int = 100000;

SET nocount ON

WHILE @val <= @nelem
BEGIN
	DBCC DROPCLEANBUFFERS;
	INSERT Pessoa(nif, nome, sexo, email, telefone, rua, codigo_postal, localidade, tipo, salario)
	SELECT cast((RAND()*@nelem*40000) as NUMERIC(9,0)), 'nome', 'M', 'email', '963369963', 'rua', '1234-123', 'localidade','Efetivo', 800.00;
	SET @val = @val + 1
END
PRINT 'Inserted ' + str(@nelem) + ' total records'

SET @end_time = GETDATE()
PRINT 'Miliseconds used: ' + CONVERT(VARCHAR(20), DATEDIFF(MILLISECOND, @start_time, @end_time));

EXEC SearchPessoa @nome_pessoa = '', @tipo = 'Efetivo', @nome_subempresa = 'Con', @id_loja = 1;