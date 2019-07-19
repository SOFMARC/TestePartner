USE [TestePartner]
GO

CREATE PROCEDURE [dbo].[spUpdatePatrimonio]
	@Nome nvarchar(50), 
	@Descricao nvarchar(250) = null,
	@PartrimonioId int,
	@MarcaId int
AS 
BEGIN

UPDATE [dbo].[Patrimonio]
   SET [MarcaId] = @MarcaId
      ,[Nome] = @Nome
      ,[Descricao] = @Descricao
 WHERE Patrimonio.PatrimonioId = @PartrimonioId;
END


