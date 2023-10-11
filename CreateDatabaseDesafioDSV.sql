USE [desafiodsv]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 10/10/2023 22:22:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Cidade] [varchar](50) NOT NULL,
	[UF] [varchar](2) NOT NULL,
	[CEP] [varchar](8) NOT NULL,
	[CPF] [varchar](14) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Debitos]    Script Date: 10/10/2023 22:22:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Debitos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Fatura] [varchar](7) NOT NULL,
	[Cliente] [int] NOT NULL,
	[Emissao] [datetime] NOT NULL,
	[Vencimento] [datetime] NOT NULL,
	[Valor] [decimal](8, 2) NOT NULL,
	[Juros] [decimal](8, 2) NULL,
	[Descontos] [decimal](8, 2) NULL,
	[Pagamento] [datetime] NULL,
	[ValorPago] [decimal](8, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Debitos]  WITH CHECK ADD FOREIGN KEY([Cliente])
REFERENCES [dbo].[Cliente] ([ID])
GO
