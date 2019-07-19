USE [TestePartner]
GO

CREATE PROCEDURE [dbo].[spUpdateMarca]
	@Nome nvarchar(50),
	@MarcaId int
AS 
BEGIN

UPDATE [dbo].[Marca]
   SET
      [Nome] = @Nome     
 WHERE Marca.MarcaId = @MarcaId;
END


