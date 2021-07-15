CREATE SCHEMA encomendas;

CREATE TABLE encomendas.Fornecedor (
    NIF VARCHAR(20),
    Nome VARCHAR(25) NOT NULL,
    NFAX VARCHAR(20),
    Tipo_Pagamento VARCHAR(20) DEFAULT 'pronto',
    
    PRIMARY KEY (NIF)
);

CREATE TABLE encomendas.Tipo_Produto (
    Codigo CHAR(5),
    Designacao VARCHAR(25) NOT NULL,
    
    PRIMARY KEY (Codigo)
);

CREATE TABLE encomendas.Encomenda (
    Num_Encomenda INT,
    Data Date,
    NIF_Fornecedor VARCHAR(20) NOT NULL,
    
    PRIMARY KEY (Num_Encomenda),
    FOREIGN KEY (NIF_Fornecedor) REFERENCES encomendas.Fornecedor(NIF)
);

CREATE TABLE encomendas.Fornecedor_Tipo_Produtos (
    Codigo_Produto CHAR(5),
    NIF_Fornecedor VARCHAR(20),
    
    PRIMARY KEY (Codigo_Produto, NIF_Fornecedor),
    FOREIGN KEY (Codigo_Produto) REFERENCES encomendas.Tipo_Produto(Codigo),
    FOREIGN KEY (NIF_Fornecedor) REFERENCES encomendas.Fornecedor(NIF)
);

CREATE TABLE encomendas.Produto (
    Codigo CHAR(15),
    Num_Items INT DEFAULT 0,
    Nome VARCHAR(25) NOT NULL,
    IVA INT DEFAULT 23,
    Preco NUMERIC(7,2),
    Codigo_Tipo_Produto CHAR(5),
    
    PRIMARY KEY (Codigo),
    FOREIGN KEY (Codigo_Tipo_Produto) REFERENCES encomendas.Tipo_Produto(Codigo),
    
    CONSTRAINT CNSTR_IVA CHECK (IVA >= 0 AND IVA <= 100)
);

CREATE TABLE encomendas.Produto_Encomenda (
    Codigo_Produto CHAR(15),
    Num_Encomenda INT,
    Num_Items INT,
    
    PRIMARY KEY (Codigo_Produto, Num_Encomenda),
    FOREIGN KEY (Codigo_Produto) REFERENCES encomendas.Produto(Codigo),
    FOREIGN KEY (Num_Encomenda) REFERENCES encomendas.Encomenda(Num_Encomenda)
);