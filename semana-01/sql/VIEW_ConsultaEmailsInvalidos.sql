CREATE VIEW ConsultaEmailsInvalidos 
AS 
  SELECT * 
  FROM   [dbo].[associadoset] 
  WHERE  email NOT LIKE '%@%';