USE [p6g2]
GO
/****** Object:  UserDefinedFunction [projeto].[ListagemAlunos]    Script Date: 6/25/2021 9:02:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [projeto].[ListagemAlunos] (@DesignacaoGrupo VARCHAR(25)) RETURNS TABLE AS
RETURN (
	SELECT NumCC, Nome FROM projeto.AlunoGrupo ag INNER JOIN projeto.Pessoas pe ON ag.NumCCAluno = pe.NumCC WHERE DesignacaoGrupo = @DesignacaoGrupo
)
GO
/****** Object:  UserDefinedFunction [projeto].[ListagemGrupos]    Script Date: 6/25/2021 9:02:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [projeto].[ListagemGrupos](@NumCC INT) RETURNS TABLE AS
    RETURN (
        SELECT DesignacaoGrupo, Participantes, NumMax, NumCCProfessor, Nome, Prof FROM (
            SELECT DesignacaoGrupo, 0 Prof FROM projeto.AlunoGrupo WHERE NumCCAluno = @NumCC
            UNION 
            SELECT Designacao DesignacaoGrupo, 1 Prof FROM projeto.GrupoAluno WHERE NumCCProfessor = @NumCC
        ) grupoParticipantes
        INNER JOIN (
            SELECT Designacao, COUNT(*) Participantes, NumMax, NumCCProfessor FROM projeto.GrupoAluno ga 
            LEFT OUTER JOIN projeto.AlunoGrupo ag ON ga.Designacao = ag.DesignacaoGrupo GROUP BY Designacao, NumMax, NumCCProfessor
        ) grupoData ON grupoParticipantes.DesignacaoGrupo = grupoData.Designacao
        INNER JOIN projeto.Pessoas p ON p.NumCC = grupoData.NumCCProfessor
    )
GO
/****** Object:  UserDefinedFunction [projeto].[OpcoesDesordenadas]    Script Date: 6/25/2021 9:02:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [projeto].[OpcoesDesordenadas] (@IdentificadorPergunta INT) RETURNS @Opcoes TABLE (Identificador INT, Texto VARCHAR(250)) AS
BEGIN
	DECLARE @TempTable TABLE (Identificador INT, Texto VARCHAR(250));

	INSERT INTO @TempTable SELECT Identificador, Texto FROM projeto.Opcoes WHERE IdentificadorPergunta = @IdentificadorPergunta;
	DECLARE @Size INT;
	SELECT @Size = COUNT(*) FROM @TempTable;

	INSERT INTO @Opcoes SELECT TOP(@Size) * FROM @TempTable ORDER BY (SELECT ID FROM projeto.Random);
	RETURN;
END
GO
/****** Object:  UserDefinedFunction [projeto].[PautaTeste]    Script Date: 6/25/2021 9:02:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [projeto].[PautaTeste] (@CodigoTeste VARCHAR(25)) RETURNS @pauta TABLE(NumCC INT, Nome VARCHAR(25), Nota FLOAT) AS
BEGIN
	DECLARE @DesignacaoGrupo VARCHAR(25);
	SELECT @DesignacaoGrupo = DesignacaoGrupo FROM projeto.Testes WHERE Codigo = @CodigoTeste;

	INSERT INTO @pauta SELECT NumCC, Nome, projeto.pontuacaoTeste(NumCC, @CodigoTeste) Nota FROM projeto.ListagemAlunos(@DesignacaoGrupo);
	RETURN;
END
GO
/****** Object:  UserDefinedFunction [projeto].[PerguntaImagens]    Script Date: 6/25/2021 9:02:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [projeto].[PerguntaImagens] (@IdentificadorPergunta INT) RETURNS TABLE AS
RETURN (SELECT Identificador, Descricao, Link FROM projeto.Imagens WHERE IdentificadorPergunta = @IdentificadorPergunta )
GO
/****** Object:  UserDefinedFunction [projeto].[PerguntaOpcoes]    Script Date: 6/25/2021 9:02:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [projeto].[PerguntaOpcoes] (@IdentificadorPergunta INT) RETURNS TABLE AS
RETURN (SELECT Identificador, Texto, Cotacao FROM projeto.Opcoes WHERE IdentificadorPergunta = @IdentificadorPergunta )
GO
/****** Object:  UserDefinedFunction [projeto].[PessoaInfo]    Script Date: 6/25/2021 9:02:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE FUNCTION [projeto].[PessoaInfo] (@NumCC INT) RETURNS TABLE AS
	RETURN (
		SELECT p.NumCC, Email, Telemovel, DataNasc, Nome, Morada, CodigoArea, Designacao DesignacaoArea, DataMatricula, ISNULL(pr.NumCC, -1) isProf, ISNULL(a.NumCC, -1) isAluno FROM projeto.Pessoas p 
		LEFT OUTER JOIN projeto.Professores pr ON p.NumCC = pr.NumCC 
		LEFT OUTER JOIN projeto.Alunos a ON p.NumCC = a.NumCC 
		LEFT OUTER JOIN projeto.Areas ar ON ar.Codigo = pr.CodigoArea
		WHERE p.NumCC = @NumCC
	)
GO
/****** Object:  UserDefinedFunction [projeto].[pontuacaoTeste]    Script Date: 6/25/2021 9:02:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [projeto].[pontuacaoTeste] (@NumCC INT, @CodigoTeste VARCHAR(25)) RETURNS FLOAT AS
BEGIN
	DECLARE @Cotacao FLOAT;
	SELECT @Cotacao = c.Cotacao * t.CotacaoMaxima / ct.CotacaoMax FROM (
		SELECT SUM(Cotacao) Cotacao, NumCC, CodigoTeste FROM projeto.Respostas r 
		LEFT OUTER JOIN projeto.RespostaOpcao ro ON r.Identificador = ro.IdentificadorResposta 
		INNER JOIN projeto.Opcoes op ON op.Identificador = ro.IdentificadorOpcao 
		GROUP BY NumCC, CodigoTeste
		HAVING NumCC = @NumCC AND CodigoTeste = @CodigoTeste
	) c
	INNER JOIN projeto.Testes t ON c.CodigoTeste = t.Codigo
	INNER JOIN projeto.CotacaoTeste ct ON ct.Codigo = t.Codigo; 
	
	IF @Cotacao IS NULL
		SET @Cotacao = -1;
	ELSE IF @Cotacao < 0
		SET @Cotacao = 0;

	RETURN @Cotacao
END
GO
/****** Object:  UserDefinedFunction [projeto].[ProfPerguntas]    Script Date: 6/25/2021 9:02:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [projeto].[ProfPerguntas] (@NumCC INT) RETURNS TABLE AS
RETURN (SELECT Identificador, Enunciado, CodigoTipoPergunta FROM projeto.Perguntas WHERE NumCCProfessor = @NumCC )
GO
/****** Object:  UserDefinedFunction [projeto].[ProximaPergunta]    Script Date: 6/25/2021 9:02:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [projeto].[ProximaPergunta] (@NumCC INT, @CodigoTeste VARCHAR(25)) RETURNS TABLE AS
	RETURN 
	(
		SELECT TOP 1 IdentificadorPergunta, Enunciado, TemplateOpt FROM projeto.PerguntasTeste pt 
			INNER JOIN projeto.Perguntas pe ON pt.IdentificadorPergunta = pe.Identificador 
			INNER JOIN projeto.TipoPergunta tp ON pe.CodigoTipoPergunta = tp.Codigo 
			WHERE CodigoTeste = @CodigoTeste AND IdentificadorPergunta NOT IN (
				SELECT IdentificadorPergunta FROM projeto.Respostas 
				WHERE NumCC = @NumCC AND CodigoTeste = @CodigoTeste
			) ORDER BY (SELECT ID FROM projeto.Random)
	);
GO
/****** Object:  UserDefinedFunction [projeto].[TestesInfo]    Script Date: 6/25/2021 9:02:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [projeto].[TestesInfo] (@NumCC INT, @DesignacaoGrupo VARCHAR(25)) RETURNS TABLE AS
RETURN (
	SELECT Codigo, DataInicio, DataFim, Duracao, DataComeco, CotacaoMaxima, 
	CASE WHEN GETDATE() > DataFim THEN projeto.pontuacaoTeste(@NumCC, Codigo) ELSE 0 END Nota FROM projeto.Testes te 
	OUTER APPLY (SELECT CodigoTeste, NumCC, MIN(DataHora) DataComeco FROM projeto.Respostas GROUP BY CodigoTeste, NumCC HAVING CodigoTeste = te.Codigo AND NumCC = @NumCC) h
	WHERE (Visivel = 1 OR NumCCProf = @NumCC) AND DesignacaoGrupo = @DesignacaoGrupo
)
GO
