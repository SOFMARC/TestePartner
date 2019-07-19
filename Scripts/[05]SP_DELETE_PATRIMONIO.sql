USE [TestePartner]
GO

CREATE PROCEDURE [dbo].[spDeletePatrimonio]
	@PartrimonioId int

AS 
BEGIN


DELETE FROM [dbo].[Patrimonio]
      WHERE Patrimonio.PatrimonioId = @PartrimonioId;
END
