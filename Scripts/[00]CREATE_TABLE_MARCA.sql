USE [TestePartner]
GO

IF OBJECT_ID ('dbo.Marca', 'U') IS NOT NULL  
   DROP TABLE Marca;
GO  

/****** Object:  Table [dbo].[Marca]    Script Date: 18/07/2019 20:08:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Marca](
	[MarcaId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[MarcaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

