USE Indra
go
/*Procedure Categoria*/
IF (OBJECT_ID('CategoriaLista') IS NOT NULL)
  DROP PROCEDURE CategoriaLista
GO
CREATE PROCEDURE CategoriaLista 
AS   

    SET NOCOUNT ON;  
    SELECT * FROM Categoria  
GO

IF (OBJECT_ID('TipoProblemaLista') IS NOT NULL)
  DROP PROCEDURE TipoProblemaLista
GO
CREATE PROCEDURE TipoProblemaLista 
AS   

    SET NOCOUNT ON;  
    SELECT * FROM TipoProblema  
GO

IF (OBJECT_ID('InsertarTipoSolucion') IS NOT NULL)
  DROP PROCEDURE InsertarTipoSolucion
GO
CREATE PROCEDURE InsertarTipoSolucion
@SOL_PROB_ID int,
@SOL_Nombre	nvarchar(250),
@SOL_RutaArchivo nvarchar(250),
@SOL_NombreArchivo nvarchar(250),
@SOL_Descripcion text,
@SOL_PalabraClave text,
@SOL_Comentario text,
@SOL_CAT_ID int,
@SOL_FechaCreacion datetime,
@SOL_UsuarioCreacion nvarchar(60)
AS
BEGIN   

    SET NOCOUNT ON;  
    INSERT INTO [dbo].[TipoSolucion](SOL_Nombre,SOL_RutaArchivo, SOL_NombreArchivo, SOL_Descripcion,SOL_PalabraClave,SOL_Comentario,SOL_FechaCreacion,SOL_UsuarioCreacion,SOL_CAT_ID, SOL_PROB_ID)
	values(@SOL_Nombre,@SOL_RutaArchivo,@SOL_NombreArchivo,@SOL_Descripcion,@SOL_PalabraClave,@SOL_Comentario,@SOL_FechaCreacion,@SOL_UsuarioCreacion,@SOL_CAT_ID,@SOL_PROB_ID)
END 
GO

IF (OBJECT_ID('EditarTipoSolucion') IS NOT NULL)
  DROP PROCEDURE EditarTipoSolucion
GO
CREATE PROCEDURE EditarTipoSolucion
@SOL_ID int
AS
BEGIN   

    SET NOCOUNT ON;  
    SELECT * FROM TipoSolucion WHERE SOL_ID=@SOL_ID
END 
GO

IF (OBJECT_ID('ActualizarTipoSolucion') IS NOT NULL)
  DROP PROCEDURE ActualizarTipoSolucion
GO
CREATE PROCEDURE ActualizarTipoSolucion
@SOL_ID int,
@SOL_PROB_ID int,
@SOL_Descripcion text,
@SOL_PalabraClave text,
@SOL_FechaModificacion datetime,
@SOL_UsuarioModificacion varchar(50),
@SOL_CAT_ID int
AS
BEGIN
    SET NOCOUNT ON;
	UPDATE [dbo].[TipoSolucion] SET 
	SOL_Descripcion=@SOL_Descripcion,
	SOL_PalabraClave=@SOL_PalabraClave,
	SOL_FechaModificacion=@SOL_FechaModificacion,
	SOL_UsuarioModificacion=@SOL_UsuarioModificacion,
	SOL_CAT_ID=@SOL_CAT_ID,
	SOL_PROB_ID=@SOL_PROB_ID
	WHERE SOL_ID=@SOL_ID
END 
GO


select * from Categoria;
SELECT * FROM dbo.TipoSolucion ts INNER JOIN Categoria c ON(ts.SOL_CAT_ID=c.CAT_ID) WHERE ts.SOL_Id <> 0 AND ts.SOL_Id = 0

