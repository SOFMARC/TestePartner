USE [TestePartner]
GO

CREATE PROCEDURE [dbo].[spGetAllMarcas]

AS 
BEGIN

SELECT [MarcaId]
      ,[Nome]      
  FROM [dbo].[Marca]
END

