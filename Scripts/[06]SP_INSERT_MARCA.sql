USE [TestePartner]
GO

CREATE PROCEDURE [dbo].[spAddMarca]
	@Nome nvarchar(50)

AS 
BEGIN

INSERT INTO [dbo].[Marca]
           ([Nome])
     VALUES
           (@Nome)
END