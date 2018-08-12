
/*Procedure Categoria*/
IF (OBJECT_ID('CategoriaLista') IS NOT NULL)
  DROP PROCEDURE CategoriaLista
GO
CREATE PROCEDURE CategoriaLista 
AS   

    SET NOCOUNT ON;  
    SELECT * FROM Categoria  
GO
