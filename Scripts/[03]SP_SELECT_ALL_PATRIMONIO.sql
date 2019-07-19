USE [TestePartner]
GO

CREATE PROCEDURE [dbo].[spGetAllPatrimonio]

AS 
BEGIN

SELECT [PatrimonioId]
      ,[NumTombo]
      ,[MarcaId]
      ,[Nome]
      ,[Descricao]
  FROM [dbo].[Patrimonio]
END


