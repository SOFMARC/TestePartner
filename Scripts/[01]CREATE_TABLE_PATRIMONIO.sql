USE [TestePartner]
GO

IF OBJECT_ID ('dbo.Patrimonio', 'U') IS NOT NULL  
   DROP TABLE Patrimonio;
GO  

/****** Object:  Table [dbo].[Patrimonio]    Script Date: 18/07/2019 20:08:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Patrimonio](
	[PatrimonioId]  [int]IDENTITY(1,1) NOT NULL,
	[NumTombo] [int] NULL,
	[MarcaId] [int]  NOT NULL,
	[Nome] [nvarchar](50)  NOT NULL,
	[Descricao] [nvarchar](250) NULL,
 CONSTRAINT [PK_Patrimonio] PRIMARY KEY CLUSTERED 
(
	[PatrimonioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Patrimonio]  WITH CHECK ADD  CONSTRAINT [FK_Patrimonio_Marca1] FOREIGN KEY([MarcaId])
REFERENCES [dbo].[Marca] ([MarcaId])
GO

ALTER TABLE [dbo].[Patrimonio] CHECK CONSTRAINT [FK_Patrimonio_Marca1]
GO



