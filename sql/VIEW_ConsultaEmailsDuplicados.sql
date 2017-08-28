CREATE VIEW ConsultaEmailsDuplicados
AS

	SELECT a.email, 
		   COUNT(a.id) AS qtd 
	FROM   [dbo].[associadoset] AS a 
	GROUP  BY email 
	HAVING COUNT(a.id)>1
	--ORDER  BY Count(a.id) DESC;