USE [TestePartner]
GO

CREATE PROCEDURE [dbo].[spDeleteMarca]
	@MarcaId int

AS 
BEGIN


DELETE FROM [dbo].[Marca]
      WHERE Marca.MarcaId = @MarcaId;
END