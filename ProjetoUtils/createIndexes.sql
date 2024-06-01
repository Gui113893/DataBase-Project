CREATE INDEX idx_Marca_marcaNome ON Marca(marcaNome);
CREATE INDEX idx_Produto_nome ON Produto(nome);
CREATE INDEX idx_Pessoa_tipoNome ON Pessoa(tipo, nome);
CREATE INDEX idx_SubEmpresa_nome ON SubEmpresa(nome);