USE [p6g2]
GO
/****** Object:  View [projeto].[CotacaoPergunta]    Script Date: 6/25/2021 8:59:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [projeto].[CotacaoPergunta] AS 
SELECT IdentificadorPergunta, MAX(Cotacao) CotacaoMax FROM projeto.OpcoesInfo WHERE Cotacao > 0 AND CodigoTipoPergunta = 'UNICA' GROUP BY IdentificadorPergunta 
UNION 
SELECT IdentificadorPergunta, SUM(Cotacao) CotacaoMax FROM projeto.OpcoesInfo WHERE Cotacao > 0 AND CodigoTipoPergunta = 'MULTIPLA' GROUP BY IdentificadorPergunta
GO
/****** Object:  View [projeto].[CotacaoTeste]    Script Date: 6/25/2021 8:59:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [projeto].[CotacaoTeste] AS SELECT Codigo, Sum(CotacaoMax) CotacaoMax FROM projeto.Testes te LEFT OUTER JOIN projeto.PerguntasTeste pt ON te.Codigo = pt.CodigoTeste INNER JOIN projeto.CotacaoPergunta cp ON cp.IdentificadorPergunta = pt.IdentificadorPergunta GROUP BY Codigo
GO
/****** Object:  View [projeto].[OpcoesInfo]    Script Date: 6/25/2021 8:59:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [projeto].[OpcoesInfo] AS 	SELECT pr.Identificador IdentificadorPergunta, op.Texto, ISNULL(op.Cotacao, 0) Cotacao, pr.CodigoTipoPergunta FROM projeto.Opcoes op RIGHT OUTER JOIN projeto.Perguntas pr ON op.IdentificadorPergunta = pr.Identificador
GO
/****** Object:  View [projeto].[Random]    Script Date: 6/25/2021 8:59:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [projeto].[Random] as select newid() as ID;
GO
/****** Object:  View [projeto].[RespostasOpcoes]    Script Date: 6/25/2021 8:59:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [projeto].[RespostasOpcoes] AS SELECT NumCC, IdentificadorPergunta, CodigoTeste, IdentificadorOpcao FROM projeto.Respostas r LEFT OUTER JOIN projeto.RespostaOpcao ro ON r.Identificador = ro.IdentificadorResposta;
GO
