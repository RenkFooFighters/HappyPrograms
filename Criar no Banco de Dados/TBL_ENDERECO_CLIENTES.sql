USE [CONTEC]
GO

/****** Object:  Table [dbo].[ENDERECO_CLIENTES]    Script Date: 17/05/2019 12:11:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ENDERECO_CLIENTES](
	[ID] [int] NOT NULL,
	[Logradouro] [varchar](20) NOT NULL,
	[Endereco] [varchar](100) NOT NULL,
	[Numero] [varchar](4) NOT NULL,
	[Complemento] [varchar](100) NULL,
	[CEP] [varchar](20) NOT NULL,
	[Bairro] [varchar](30) NOT NULL,
	[Cidade] [varchar](30) NOT NULL,
	[UF] [char](2) NOT NULL,
	[ID_CLI] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ENDERECO_CLIENTES]  WITH CHECK ADD  CONSTRAINT [FK_ENDERECO_CLIENTES] FOREIGN KEY([ID_CLI])
REFERENCES [dbo].[CLIENTES] ([ID])
GO

ALTER TABLE [dbo].[ENDERECO_CLIENTES] CHECK CONSTRAINT [FK_ENDERECO_CLIENTES]
GO
