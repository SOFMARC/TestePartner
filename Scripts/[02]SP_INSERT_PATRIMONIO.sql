USE [TestePartner]
GO

CREATE PROCEDURE [dbo].[spAddPatrimonio]
	@Nome nvarchar(50),
	@Descricao nvarchar(250),
	@MarcaId int
AS 
BEGIN

INSERT INTO [dbo].[Patrimonio]
           ([NumTombo]
           ,[MarcaId]
           ,[Nome]
           ,[Descricao])
     VALUES
           (NEXT VALUE FOR Seq.NumTombo
           ,@MarcaId
           ,@Nome
           ,@Descricao)
END