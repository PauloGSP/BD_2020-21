CREATE SCHEMA rentacar;

CREATE TABLE rentacar.Tipo_veiculo(
    cod INT PRIMARY KEY NOT NULL,
    designacao INT,
    arcond INT,

);
CREATE TABLE rentacar.veiculo(
    matricula VARCHAR(6) PRIMARY KEY NOT NULL,
    marca VARCHAR(15),
    ano INT,
    cod INT FOREIGN KEY (cod) REFERENCES rentacar.Tipo_veiculo(cod) NOT NULL

    
);
CREATE TABLE rentacar.Similaridade(
    cod1 INT,
    cod2 INT,
    PRIMARY KEY (cod1,cod2),
    FOREIGN KEY (cod1) REFERENCES rentacar.Tipo_veiculo(cod),
    FOREIGN KEY (cod2) REFERENCES rentacar.Tipo_veiculo(cod),
    );

CREATE TABLE rentacar.client(
    NIF INT PRIMARY KEY NOT NULL,
    Nome VARCHAR(15) NOT NULL,
    num_carta INT NOT NULL,
    Endereco VARCHAR(15),
);
CREATE TABLE rentacar.Ligeiro(
    cod INT PRIMARY KEY FOREIGN KEY (cod) REFERENCES rentacar.Tipo_veiculo(cod) NOT NULL,
    numlugares INT,
    portas INT,
    combustivel VARCHAR(8)
);
CREATE TABLE rentacar.Pesado (
    cod INT PRIMARY KEY FOREIGN KEY (cod) REFERENCES rentacar.Tipo_veiculo(cod) NOT NULL,
    peso INT,
    passageiros INT

);
CREATE TABLE rentacar.balcao(
    numero INT PRIMARY KEY NOT NULL, 
    nome VARCHAR(15) NOT NULL,
    endereco VARCHAR(15)
);


CREATE TABLE rentacar.Aluger(
    numero INT PRIMARY KEY NOT NULL,
    duracao INT,
    Data_fim VARCHAR(8),
    cliente INT FOREIGN KEY (cliente) REFERENCES rentacar.client(NIF) NOT NULL,
    balcao INT FOREIGN KEY (balcao) REFERENCES rentacar.balcao(numero) NOT NULL,
    matricula VARCHAR(6) FOREIGN KEY (matricula) REFERENCES rentacar.veiculo(matricula) NOT NULL,    
);