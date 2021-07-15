CREATE SCHEMA confe;
CREATE TABLE confe.instituicao(
    Endereco VARCHAR(15) PRIMARY KEY NOT NULL,
    nome VARCHAR(15)
);

CREATE TABLE confe.conferencia(
    Num INT PRIMARY KEY NOT NULL
);
CREATE TABLE confe.pessoa(
    Email VARCHAR(20) PRIMARY KEY NOT NULL,
    nome VARCHAR(15),
    instituicaoEndereco VARCHAR(15) FOREIGN KEY (instituicaoEndereco) REFERENCES confe.instituicao(Endereco) NOT NULL
);
CREATE TABLE confe.participante(
    Email VARCHAR(20) PRIMARY KEY NOT NULL,
    morada VARCHAR(15),
    dataInsc VARCHAR(8),
    Numconfe INT FOREIGN KEY (Numconfe) REFERENCES confe.conferencia (Num) NOT NULL

);
CREATE TABLE confe.autor(
    Email VARCHAR(20) PRIMARY KEY FOREIGN KEY (Email) REFERENCES confe.pessoa(Email) NOT NULL,
);
CREATE TABLE confe.estudante(
    Email VARCHAR(20) PRIMARY KEY FOREIGN KEY (Email) REFERENCES confe.participante(Email) NOT NULL,
    LocalComprov VARCHAR(15)
);

CREATE TABLE confe.nestudante(
    Email VARCHAR(20) PRIMARY KEY FOREIGN KEY (Email) REFERENCES confe.participante(Email) NOT NULL,
    Referencia  INT 
    
);
CREATE TABLE confe.artigo(
    Num INT PRIMARY KEY NOT NULL,
    Titulo VARCHAR(35)

);



CREATE TABLE confe.confeartigo(
    NumConfe INT,
    NumArtg INT ,
    PRIMARY KEY(NumConfe,NumArtg),
    FOREIGN KEY (Numconfe) REFERENCES confe.conferencia(Num) ,
     
    FOREIGN KEY (NumArtg) REFERENCES confe.artigo(Num)

);

CREATE TABLE confe.autorartigo(
    EmailAuth VARCHAR(20),
    Numart INT,
    PRIMARY KEY (EmailAuth,Numart), 
    FOREIGN KEY (EmailAuth) REFERENCES confe.autor(Email) ,
    FOREIGN KEY (Numart) REFERENCES confe.artigo(Num) 
);