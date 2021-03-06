USE [p6g2]
GO
/****** Object:  Table [projeto].[AlunoGrupo]    Script Date: 6/25/2021 8:58:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [projeto].[AlunoGrupo](
	[NumCCAluno] [int] NOT NULL,
	[DesignacaoGrupo] [varchar](25) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NumCCAluno] ASC,
	[DesignacaoGrupo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [projeto].[Alunos]    Script Date: 6/25/2021 8:58:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [projeto].[Alunos](
	[NumCC] [int] NOT NULL,
	[DataMatricula] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[NumCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [projeto].[Areas]    Script Date: 6/25/2021 8:58:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [projeto].[Areas](
	[Codigo] [char](2) NOT NULL,
	[Designacao] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [projeto].[GrupoAluno]    Script Date: 6/25/2021 8:58:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [projeto].[GrupoAluno](
	[Designacao] [varchar](25) NOT NULL,
	[NumMax] [tinyint] NOT NULL,
	[NumCCProfessor] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Designacao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [projeto].[Imagens]    Script Date: 6/25/2021 8:58:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [projeto].[Imagens](
	[Identificador] [int] IDENTITY(1,1) NOT NULL,
	[Link] [varchar](250) NOT NULL,
	[Descricao] [varchar](50) NULL,
	[IdentificadorPergunta] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Identificador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [projeto].[Opcoes]    Script Date: 6/25/2021 8:58:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [projeto].[Opcoes](
	[Identificador] [int] IDENTITY(1,1) NOT NULL,
	[Cotacao] [int] NOT NULL,
	[Texto] [varchar](250) NOT NULL,
	[IdentificadorPergunta] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Identificador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [projeto].[Perguntas]    Script Date: 6/25/2021 8:58:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [projeto].[Perguntas](
	[Identificador] [int] IDENTITY(1,1) NOT NULL,
	[Enunciado] [varchar](250) NULL,
	[CodigoTipoPergunta] [varchar](15) NOT NULL,
	[NumCCProfessor] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Identificador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [projeto].[PerguntasTeste]    Script Date: 6/25/2021 8:58:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [projeto].[PerguntasTeste](
	[IdentificadorPergunta] [int] NOT NULL,
	[CodigoTeste] [varchar](25) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdentificadorPergunta] ASC,
	[CodigoTeste] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [projeto].[Pessoas]    Script Date: 6/25/2021 8:58:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [projeto].[Pessoas](
	[NumCC] [int] NOT NULL,
	[Email] [varchar](45) NOT NULL,
	[Telemovel] [int] NULL,
	[DataNasc] [date] NULL,
	[Nome] [varchar](45) NOT NULL,
	[Morada] [varchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[NumCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [projeto].[Professores]    Script Date: 6/25/2021 8:58:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [projeto].[Professores](
	[NumCC] [int] NOT NULL,
	[CodigoArea] [char](2) NULL,
PRIMARY KEY CLUSTERED 
(
	[NumCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [projeto].[RespostaOpcao]    Script Date: 6/25/2021 8:58:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [projeto].[RespostaOpcao](
	[IdentificadorOpcao] [int] NOT NULL,
	[IdentificadorResposta] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdentificadorOpcao] ASC,
	[IdentificadorResposta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [projeto].[Respostas]    Script Date: 6/25/2021 8:58:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [projeto].[Respostas](
	[Identificador] [int] IDENTITY(1,1) NOT NULL,
	[DataHora] [datetime] NOT NULL,
	[NumCC] [int] NOT NULL,
	[IdentificadorPergunta] [int] NOT NULL,
	[CodigoTeste] [varchar](25) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Identificador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [projeto].[Testes]    Script Date: 6/25/2021 8:58:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [projeto].[Testes](
	[Codigo] [varchar](25) NOT NULL,
	[CotacaoMaxima] [int] NOT NULL,
	[DataFim] [datetime] NOT NULL,
	[DataInicio] [datetime] NOT NULL,
	[Duracao] [time](7) NULL,
	[Visivel] [bit] NOT NULL,
	[NumCCProf] [int] NOT NULL,
	[DesignacaoGrupo] [varchar](25) NULL,
PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [projeto].[TipoPergunta]    Script Date: 6/25/2021 8:58:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [projeto].[TipoPergunta](
	[Codigo] [varchar](15) NOT NULL,
	[TemplateOpt] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [projeto].[Alunos] ADD  DEFAULT (getdate()) FOR [DataMatricula]
GO
ALTER TABLE [projeto].[GrupoAluno] ADD  DEFAULT ((25)) FOR [NumMax]
GO
ALTER TABLE [projeto].[Respostas] ADD  DEFAULT (getdate()) FOR [DataHora]
GO
ALTER TABLE [projeto].[Testes] ADD  DEFAULT ((20)) FOR [CotacaoMaxima]
GO
ALTER TABLE [projeto].[Testes] ADD  DEFAULT (getdate()) FOR [DataInicio]
GO
ALTER TABLE [projeto].[Testes] ADD  DEFAULT ((1)) FOR [Visivel]
GO
ALTER TABLE [projeto].[AlunoGrupo]  WITH CHECK ADD FOREIGN KEY([DesignacaoGrupo])
REFERENCES [projeto].[GrupoAluno] ([Designacao])
ON DELETE CASCADE
GO
ALTER TABLE [projeto].[AlunoGrupo]  WITH CHECK ADD FOREIGN KEY([NumCCAluno])
REFERENCES [projeto].[Alunos] ([NumCC])
ON DELETE CASCADE
GO
ALTER TABLE [projeto].[Alunos]  WITH CHECK ADD FOREIGN KEY([NumCC])
REFERENCES [projeto].[Pessoas] ([NumCC])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [projeto].[GrupoAluno]  WITH CHECK ADD FOREIGN KEY([NumCCProfessor])
REFERENCES [projeto].[Professores] ([NumCC])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [projeto].[Imagens]  WITH CHECK ADD FOREIGN KEY([IdentificadorPergunta])
REFERENCES [projeto].[Perguntas] ([Identificador])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [projeto].[Opcoes]  WITH CHECK ADD FOREIGN KEY([IdentificadorPergunta])
REFERENCES [projeto].[Perguntas] ([Identificador])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [projeto].[Perguntas]  WITH CHECK ADD FOREIGN KEY([CodigoTipoPergunta])
REFERENCES [projeto].[TipoPergunta] ([Codigo])
ON UPDATE CASCADE
GO
ALTER TABLE [projeto].[Perguntas]  WITH CHECK ADD FOREIGN KEY([NumCCProfessor])
REFERENCES [projeto].[Professores] ([NumCC])
GO
ALTER TABLE [projeto].[PerguntasTeste]  WITH CHECK ADD FOREIGN KEY([CodigoTeste])
REFERENCES [projeto].[Testes] ([Codigo])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [projeto].[PerguntasTeste]  WITH CHECK ADD FOREIGN KEY([IdentificadorPergunta])
REFERENCES [projeto].[Perguntas] ([Identificador])
ON UPDATE CASCADE
GO
ALTER TABLE [projeto].[Professores]  WITH CHECK ADD FOREIGN KEY([CodigoArea])
REFERENCES [projeto].[Areas] ([Codigo])
ON UPDATE SET NULL
ON DELETE SET NULL
GO
ALTER TABLE [projeto].[Professores]  WITH CHECK ADD FOREIGN KEY([NumCC])
REFERENCES [projeto].[Pessoas] ([NumCC])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [projeto].[RespostaOpcao]  WITH CHECK ADD FOREIGN KEY([IdentificadorOpcao])
REFERENCES [projeto].[Opcoes] ([Identificador])
GO
ALTER TABLE [projeto].[RespostaOpcao]  WITH CHECK ADD FOREIGN KEY([IdentificadorResposta])
REFERENCES [projeto].[Respostas] ([Identificador])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [projeto].[Respostas]  WITH CHECK ADD FOREIGN KEY([IdentificadorPergunta], [CodigoTeste])
REFERENCES [projeto].[PerguntasTeste] ([IdentificadorPergunta], [CodigoTeste])
ON UPDATE CASCADE
GO
ALTER TABLE [projeto].[Respostas]  WITH CHECK ADD FOREIGN KEY([NumCC])
REFERENCES [projeto].[Alunos] ([NumCC])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [projeto].[Testes]  WITH CHECK ADD FOREIGN KEY([DesignacaoGrupo])
REFERENCES [projeto].[GrupoAluno] ([Designacao])
ON DELETE SET NULL
GO
ALTER TABLE [projeto].[Testes]  WITH CHECK ADD FOREIGN KEY([NumCCProf])
REFERENCES [projeto].[Professores] ([NumCC])
ON DELETE CASCADE
GO
ALTER TABLE [projeto].[Pessoas]  WITH CHECK ADD CHECK  (([DataNasc]<=getdate()))
GO
ALTER TABLE [projeto].[Testes]  WITH CHECK ADD CHECK  (([DataFim]>[DataInicio]))
GO
ALTER TABLE [projeto].[Testes]  WITH CHECK ADD CHECK  (([DataFim]>=getdate()))
GO
