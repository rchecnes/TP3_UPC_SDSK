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

IF (OBJECT_ID('CrearTipoSolucion') IS NOT NULL)
  DROP PROCEDURE CrearTipoSolucion
GO
CREATE PROCEDURE CrearTipoSolucion
@SOL_PROB_ID int,
@SOL_Nombre	nvarchar(250),
@SOL_RutaArchivo nvarchar(250),
@SOL_NombreArchivo nvarchar(250),
@SOL_Descripcion text,
@SOL_PalabraClave text,
@SOL_Comentario text,
@SOL_CAT_ID int,
@SOL_FechaCreacion date,
@SOL_UsuarioCreacion date
AS
BEGIN   

    SET NOCOUNT ON;  
    INSERT INTO [dbo].[TipoSolucion](SOL_Nombre,SOL_RutaArchivo, SOL_NombreArchivo, SOL_Descripcion,SOL_PalabraClave,SOL_Comentario,SOL_FechaCreacion,SOL_UsuarioCreacion,SOL_CAT_ID, SOL_PROB_ID)
	values(@SOL_Nombre,@SOL_RutaArchivo,@SOL_NombreArchivo,@SOL_Descripcion,@SOL_PalabraClave,@SOL_Comentario,@SOL_FechaCreacion,@SOL_UsuarioCreacion,@SOL_CAT_ID,@SOL_PROB_ID)
END 
GO

IF (OBJECT_ID('ActualizarTipoSolucion') IS NOT NULL)
  DROP PROCEDURE ActualizarTipoSolucion
GO
CREATE PROCEDURE ActualizarTipoSolucion
@SOL_ID int,
@SOL_PROB_ID int,
@SOL_Nombre	nvarchar(250),
@SOL_RutaArchivo nvarchar(250),
@SOL_NombreArchivo nvarchar(250),
@SOL_Descripcion text,
@SOL_PalabraClave text,
@SOL_Comentario text,
@SOL_CAT_ID int,
@SOL_FechaCreacion date
AS
BEGIN   

    SET NOCOUNT ON;
	UPDATE [dbo].[TipoSolucion] SET SOL_Nombre=@SOL_Nombre,
	SOL_RutaArchivo=@SOL_RutaArchivo,
	SOL_NombreArchivo=@SOL_NombreArchivo,
	SOL_Descripcion=@SOL_Descripcion,
	SOL_PalabraClave=@SOL_PalabraClave,
	SOL_Comentario=@SOL_Comentario,
	SOL_FechaModificacion=@SOL_FechaCreacion,
	SOL_CAT_ID=@SOL_CAT_ID,
	SOL_PROB_ID=@SOL_PROB_ID
	WHERE SOL_ID=@SOL_ID

END 
GO

