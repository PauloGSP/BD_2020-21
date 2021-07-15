CREATE INDEX PerguntaIdx ON projeto.Imagens(IdentificadorPergunta);
CREATE INDEX PerguntaIdx ON projeto.Opcoes(IdentificadorPergunta);
CREATE INDEX IdentProf ON projeto.Perguntas(Identificador, NumCCProfessor); 
