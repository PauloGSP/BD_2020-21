USE [p6g2]
GO
/****** Object:  StoredProcedure [projeto].[AtualizarPergunta]    Script Date: 6/25/2021 9:01:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [projeto].[AtualizarPergunta] @IdentificadorPergunta INT, @NumCCProfessor INT, @Enunciado VARCHAR(250), @CodigoTipoPergunta VARCHAR(15) AS
BEGIN
	IF NOT EXISTS(SELECT * FROM projeto.Perguntas WHERE Identificador = @IdentificadorPergunta AND NumCCProfessor = @NumCCProfessor)
	BEGIN
		RAISERROR('Apenas o professor que criou a pergunta a pode modificar!', 16, 1);
		RETURN;
	END

	BEGIN TRAN;
	
	IF @Enunciado IS NOT NULL
		UPDATE projeto.Perguntas SET Enunciado = @Enunciado WHERE Identificador = @IdentificadorPergunta;
	
	IF @CodigoTipoPergunta IS NOT NULL
		UPDATE projeto.Perguntas SET CodigoTipoPergunta = @CodigoTipoPergunta WHERE Identificador = @IdentificadorPergunta;

	COMMIT;
END
GO
/****** Object:  StoredProcedure [projeto].[AtualizarPerguntaImagem]    Script Date: 6/25/2021 9:01:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [projeto].[AtualizarPerguntaImagem] @IdentificadorPergunta INT, @NumCCProfessor INT, @IdentificadorImagem INT, @Descricao VARCHAR(50), @Link VARCHAR(250) AS
BEGIN
	IF NOT EXISTS(SELECT * FROM projeto.Perguntas WHERE Identificador = @IdentificadorPergunta AND NumCCProfessor = @NumCCProfessor)
	BEGIN
		RAISERROR('Apenas o professor que criou a pergunta a pode modificar!', 16, 1);
		RETURN;
	END
	
	BEGIN TRAN;
	
	IF @Descricao IS NOT NULL
		UPDATE projeto.Imagens SET Descricao = @Descricao WHERE Identificador = @IdentificadorImagem;
	
	IF @Link IS NOT NULL
		UPDATE projeto.Imagens SET Link = @Link WHERE Identificador = @IdentificadorImagem;

	COMMIT;
END
GO
/****** Object:  StoredProcedure [projeto].[AtualizarPerguntaOpcao]    Script Date: 6/25/2021 9:01:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [projeto].[AtualizarPerguntaOpcao] @IdentificadorPergunta INT, @NumCCProfessor INT, @IdentificadorOpcao INT, @Texto VARCHAR(250), @Cotacao INT AS
BEGIN
	IF NOT EXISTS(SELECT * FROM projeto.Perguntas WHERE Identificador = @IdentificadorPergunta AND NumCCProfessor = @NumCCProfessor)
	BEGIN
		RAISERROR('Apenas o professor que criou a pergunta a pode modificar!', 16, 1);
		RETURN;
	END
	
	BEGIN TRAN;
	
	IF @Texto IS NOT NULL
		UPDATE projeto.Opcoes SET Texto = @Texto WHERE Identificador = @IdentificadorOpcao;
	
	IF @Cotacao IS NOT NULL
		UPDATE projeto.Opcoes SET Cotacao = @Cotacao WHERE Identificador = @IdentificadorOpcao;

	COMMIT;
END
GO
/****** Object:  StoredProcedure [projeto].[createPessoa]    Script Date: 6/25/2021 9:01:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [projeto].[createPessoa] @NumCC INT, @Email VARCHAR(45), @Telemovel INT, @DataNasc DATE, @Nome VARCHAR(45), @Morada VARCHAR(250), @DataMatricula DATE, @CodigoArea CHAR(2) AS
BEGIN
	IF @DataMatricula IS NULL AND @CodigoArea IS NULL
		RAISERROR('Pessoa tem de ser pelo menos professor ou aluno!', 16, 1);

	IF NOT EXISTS(SELECT NumCC FROM projeto.Pessoas WHERE NumCC = @NumCC)
		INSERT INTO projeto.Pessoas VALUES(@NumCC, @Email, @Telemovel, @DataNasc, @Nome, @Morada) 
	IF @DataMatricula IS NOT NULL
		INSERT INTO projeto.Alunos VALUES(@NumCC, @DataMatricula) 
	IF @CodigoArea IS NOT NULL
		INSERT INTO projeto.Professores VALUES(@NumCC, @CodigoArea) 
END
GO
/****** Object:  StoredProcedure [projeto].[createResposta]    Script Date: 6/25/2021 9:01:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [projeto].[createResposta] @NumCC INT, @CodigoTeste VARCHAR(25), @IdentificadorPergunta INT, @IdentificadorOpcao INT AS
BEGIN
	IF EXISTS(SELECT NumCC FROM projeto.Alunos WHERE NumCC = @NumCC) 
	BEGIN
		DECLARE @GrupoDesignacao VARCHAR(25);
		DECLARE @DataInicio DATETIME;
		DECLARE @DataFim DATETIME;
		DECLARE @Duracao TIME;
		DECLARE @Visivel BIT;

		SELECT @GrupoDesignacao = te.DesignacaoGrupo, @DataInicio = te.DataInicio, @DataFim = te.DataFim, @Duracao = te.Duracao, @Visivel = te.Visivel FROM projeto.Testes te INNER JOIN projeto.AlunoGrupo ag ON te.DesignacaoGrupo = ag.DesignacaoGrupo WHERE ag.NumCCAluno = @NumCC AND ag.DesignacaoGrupo = te.DesignacaoGrupo AND te.Codigo = @CodigoTeste

		IF @GrupoDesignacao IS NULL
		BEGIN
			RAISERROR('Aluno não tem acesso ao teste!', 16, 1);
			RETURN 0;
		END

		IF @DataInicio > GETDATE() OR @DataFim < GETDATE() OR @Visivel = 0
		BEGIN
			RAISERROR('Teste não está disponível!', 16, 1);
			RETURN 0;
		END

		DECLARE @StartTime DATETIME;
		SELECT TOP 1 @StartTime = DataHora FROM projeto.Respostas WHERE NumCC = @NumCC ORDER BY DataHora;

		IF @StartTime IS NOT NULL AND CAST(GETDATE() - @StartTime AS TIME) > @Duracao
		BEGIN
			RAISERROR('Tempo do teste terminou!', 16, 1);
			RETURN 0;
		END

		DECLARE @IdentificadorResposta INT;
		SELECT @IdentificadorResposta = Identificador FROM projeto.Respostas WHERE NumCC = @NumCC AND IdentificadorPergunta = @IdentificadorPergunta AND CodigoTeste = @CodigoTeste;
				
		IF @IdentificadorResposta is null 
		BEGIN
			INSERT INTO projeto.Respostas(NumCC, IdentificadorPergunta, CodigoTeste) VALUES(@NumCC, @IdentificadorPergunta, @CodigoTeste);
			SELECT @IdentificadorResposta = Identificador FROM projeto.Respostas WHERE NumCC = @NumCC AND IdentificadorPergunta = @IdentificadorPergunta AND CodigoTeste = @CodigoTeste;
		END
		
		IF @IdentificadorOpcao IS NOT NULL
		BEGIN
			DECLARE @TipoPergunta VARCHAR(15);
			SELECT @TipoPergunta = CodigoTipopergunta FROM projeto.Perguntas WHERE Identificador = @IdentificadorPergunta;
		
			IF @TipoPergunta = 'UNICA' AND EXISTS(SELECT IdentificadorResposta FROM projeto.RespostaOpcao WHERE IdentificadorResposta = @IdentificadorResposta)
				DELETE FROM projeto.RespostaOpcao WHERE IdentificadorResposta = @IdentificadorResposta;
		
			IF NOT EXISTS(SELECT IdentificadorResposta FROM projeto.RespostaOpcao WHERE IdentificadorResposta = @IdentificadorResposta AND IdentificadorOpcao = @IdentificadorOpcao)
				INSERT INTO projeto.RespostaOpcao(IdentificadorResposta, IdentificadorOpcao) VALUES(@IdentificadorResposta, @IdentificadorOpcao);
			ELSE IF @TipoPergunta = 'MULTIPLA'
				DELETE FROM projeto.RespostaOpcao WHERE IdentificadorResposta = @IdentificadorResposta AND IdentificadorOpcao = @IdentificadorOpcao;
		END
	END
	ELSE
		RAISERROR('Aluno não existe!', 16, 1);

	RETURN 1;
END
GO
/****** Object:  StoredProcedure [projeto].[CriarPergunta]    Script Date: 6/25/2021 9:01:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [projeto].[CriarPergunta] @Enunciado VARCHAR(250), @CodigoTipoPergunta VARCHAR(15), @NumCCProfessor INT AS
	INSERT INTO projeto.Perguntas(Enunciado, CodigoTipoPergunta, NumCCProfessor) VALUES(@Enunciado, @CodigoTipoPergunta, @NumCCProfessor);
GO
/****** Object:  StoredProcedure [projeto].[CriarPerguntaImagem]    Script Date: 6/25/2021 9:01:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [projeto].[CriarPerguntaImagem] @IdentificadorPergunta INT, @Descricao VARCHAR(50), @Link VARCHAR(250), @NumCCProfessor INT AS
BEGIN
	IF NOT EXISTS(SELECT * FROM projeto.Perguntas WHERE Identificador = @IdentificadorPergunta AND NumCCProfessor = @NumCCProfessor)
	BEGIN
		RAISERROR('Apenas o professor que criou a pergunta a pode modificar!', 16, 1);
		RETURN;
	END

	INSERT INTO projeto.Imagens(IdentificadorPergunta, Descricao, Link) VALUES(@IdentificadorPergunta, @Descricao, @Link);
END
GO
/****** Object:  StoredProcedure [projeto].[CriarPerguntaOpcao]    Script Date: 6/25/2021 9:01:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [projeto].[CriarPerguntaOpcao] @IdentificadorPergunta INT, @Texto VARCHAR(250), @Cotacao INT, @NumCCProfessor INT AS
BEGIN
	IF NOT EXISTS(SELECT * FROM projeto.Perguntas WHERE Identificador = @IdentificadorPergunta AND NumCCProfessor = @NumCCProfessor)
	BEGIN
		RAISERROR('Apenas o professor que criou a pergunta a pode modificar!', 16, 1);
		RETURN;
	END

	INSERT INTO projeto.Opcoes(IdentificadorPergunta, Texto, Cotacao) VALUES(@IdentificadorPergunta, @Texto, @Cotacao);
END
GO
/****** Object:  StoredProcedure [projeto].[CriarTeste]    Script Date: 6/25/2021 9:01:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [projeto].[CriarTeste] @NumCCProfessor INT, @DesignacaoGrupo VARCHAR(25), @Codigo VARCHAR(25), @CotacaoMax INT, @DataInicio DATETIME, @DataFim DATETIME, @Duracao TIME, @Visivel BIT, @Perguntas projeto.ListaPerguntaIds READONLY AS
BEGIN
	BEGIN TRAN;
	INSERT INTO projeto.Testes(Codigo, CotacaoMaxima, DataFim, DataInicio, Duracao, Visivel, NumCCProf, DesignacaoGrupo) 
	VALUES(@Codigo, @CotacaoMax, @DataFim, @DataInicio, @Duracao, @Visivel, @NumCCProfessor, @DesignacaoGrupo);
	
	DECLARE @IdPergunta INT;
	DECLARE PerguntasCursor CURSOR FOR SELECT * FROM @Perguntas;
	OPEN PerguntasCursor;
	FETCH NEXT FROM PerguntasCursor INTO @IdPergunta;

	WHILE @@FETCH_STATUS = 0
	BEGIN
		PRINT 1;
		INSERT INTO projeto.PerguntasTeste(IdentificadorPergunta, CodigoTeste) VALUES (@IdPergunta, @Codigo);

		IF @@ROWCOUNT = 0
		BEGIN
			ROLLBACK;
			RAISERROR('Erro a adicionar uma pergunta!', 16, 1);
			RETURN;
		END
		FETCH NEXT FROM PerguntasCursor INTO @IdPergunta;
	END

	CLOSE PerguntasCursor;  
	DEALLOCATE PerguntasCursor;

	COMMIT;
END
GO
/****** Object:  StoredProcedure [projeto].[ToggleTesteVisibilidade]    Script Date: 6/26/2021 9:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [projeto].[ToggleTesteVisibilidade] @CodigoTeste VARCHAR(25), @NumCCProfessor INT AS
BEGIN
	DECLARE @Visivel BIT;
	SELECT @Visivel = Visivel FROM projeto.Testes WHERE Codigo = @CodigoTeste AND NumCCProf = @NumCCProfessor;

	IF @Visivel IS NULL
		RAISERROR('Teste não existe!', 16, 1);
	ELSE IF @Visivel = 1
		UPDATE projeto.Testes SET Visivel = 0 WHERE Codigo = @CodigoTeste;
	ELSE IF @Visivel = 0
		UPDATE projeto.Testes SET Visivel = 1 WHERE Codigo = @CodigoTeste;
END
GO
