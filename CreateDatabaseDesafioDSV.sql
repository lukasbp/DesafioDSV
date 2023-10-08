CREATE DATABASE [DesafioDSV]
GO
USE [DesafioDSV]
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
CREATE TABLE [dbo].[Debitos](
	[Fatura] [varchar](7) NOT NULL,
	[Cliente] [int] NULL,
	[Emissao] [datetime] NOT NULL,
	[Vencimento] [datetime] NOT NULL,
	[Valor] [float] NOT NULL,
	[Juros] [float] NULL,
	[Descontos] [float] NULL,
	[Pagamento] [datetime] NULL,
	[ValorPago] [float] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Debitos]  WITH CHECK ADD FOREIGN KEY([Cliente])
REFERENCES [dbo].[Cliente] ([ID])

