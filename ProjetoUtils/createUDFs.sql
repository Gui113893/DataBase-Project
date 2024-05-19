-- Função que devolve a quantidade em circulação de um produto
-- Usada posteriormente para validar a adição de produto em circulação
CREATE FUNCTION fn_QuantidadeProdutoLojas(@id_produto INT)
RETURNS INT
AS
BEGIN
    DECLARE @soma_quantidade INT;

    SELECT @soma_quantidade = SUM(quantidade)
    FROM Stock_Loja
    WHERE produto = @id_produto;

    IF @soma_quantidade IS NULL
    BEGIN
        SET @soma_quantidade = 0;
    END

    RETURN @soma_quantidade;
END;
GO
