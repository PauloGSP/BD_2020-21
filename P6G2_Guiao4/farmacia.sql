CREATE SCHEMA farmacia;

CREATE TABLE farmacia.Farmaceutica (
    Numero_Registo INT,
    Nome VARCHAR(25) NOT NULL,
    Endereco VARCHAR(50),
    Telefone VARCHAR(20),
    
    PRIMARY KEY (Numero_Registo)
);

CREATE TABLE farmacia.Farmacia (
    NIF VARCHAR(20),
    Nome VARCHAR(25) NOT NULL,
    Endereco VARCHAR(50),
    Telefone VARCHAR(20),
    
    PRIMARY KEY (NIF)
);

CREATE TABLE farmacia.Utente (
    Num_Utente INT,
    Data_Nascimento DATE,
    Endereco VARCHAR(100),
    Nome VARCHAR(50) NOT NULL,
    
    PRIMARY KEY (Num_Utente)
);


CREATE TABLE farmacia.Medico (
    ID_SNS INT,
    Nome VARCHAR(50) NOT NULL,
    Especialidade VARCHAR(100),
    
    PRIMARY KEY (ID_SNS)
);

CREATE TABLE farmacia.Farmaco (
    Nome_Unico VARCHAR(25),
    Formula VARCHAR(50),
    Nome_Comercial VARCHAR(25),
    Numero_Registo_Farmaceutica INT NOT NULL,
    
    PRIMARY KEY (Nome_Unico),
    FOREIGN KEY (Numero_Registo_Farmaceutica) REFERENCES farmacia.Farmaceutica(Numero_Registo)
);

CREATE TABLE farmacia.Prescricao (
    Numero INT,
    Data_Emissao Date NOT NULL,
    Data_Processamento Date,
    Num_Utente INT NOT NULL,
    ID_SNS_Medico INT NOT NULL,
    NIF_Farmacia VARCHAR(20) NOT NULL,
    
    PRIMARY KEY (Numero),
    FOREIGN KEY (Num_Utente) REFERENCES farmacia.Utente(Num_Utente),
    FOREIGN KEY (ID_SNS_Medico) REFERENCES farmacia.Medico(ID_SNS),
    FOREIGN KEY (NIF_Farmacia) REFERENCES farmacia.Farmacia(NIF)
);

CREATE TABLE farmacia.Farmaco_Prescricao (
    Farmaco_Nome_Unico VARCHAR(25),
    Prescricao_Numero INT,
    
    PRIMARY KEY (Farmaco_Nome_Unico, Prescricao_Numero),
    FOREIGN KEY (Farmaco_Nome_Unico) REFERENCES farmacia.Farmaco(Nome_Unico),
    FOREIGN KEY (Prescricao_Numero) REFERENCES farmacia.Prescricao(Numero)
);

CREATE TABLE farmacia.Vende_Farmaco (
    Farmaco_Nome_Unico VARCHAR(25),
    Farmacia_NIF VARCHAR(20),
    
    PRIMARY KEY (Farmaco_Nome_Unico, Farmacia_NIF),
    FOREIGN KEY (Farmaco_Nome_Unico) REFERENCES farmacia.Farmaco(Nome_Unico),
    FOREIGN KEY (Farmacia_NIF) REFERENCES farmacia.Farmacia(NIF)
);