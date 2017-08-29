/*
REFERENCIA : 
	https://social.msdn.microsoft.com/Forums/sqlserver/en-US/5364a7dd-b0c5-463a-9d4c-3ba057f99285/remove-duplicate-records-but-keep-at-least-1-record?forum=transactsql
*/

WITH g AS (
	SELECT email, ROW_NUMBER() OVER(PARTITION BY email ORDER BY email) AS row
	FROM AssociadoSet) 
SELECT * FROM g
WHERE row > 1;

/*

WITH g AS (
	SELECT email, ROW_NUMBER() OVER(PARTITION BY email ORDER BY email) AS row
	FROM AssociadoSet) 
DELETE FROM g
WHERE row > 1;

*/