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

IF (OBJECT_ID('CargoLista') IS NOT NULL)
  DROP PROCEDURE CargoLista
GO
CREATE PROCEDURE CargoLista 
AS   

    SET NOCOUNT ON;  
    SELECT * FROM Cargo  
GO

IF (OBJECT_ID('NivelLista') IS NOT NULL)
  DROP PROCEDURE NivelLista
GO
CREATE PROCEDURE NivelLista 
AS   

    SET NOCOUNT ON;  
    SELECT * FROM Nivel  
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

IF (OBJECT_ID('EliminarTipoSolucion') IS NOT NULL)
  DROP PROCEDURE EliminarTipoSolucion
GO
CREATE PROCEDURE EliminarTipoSolucion
@SOl_ID int
AS
BEGIN
    SET NOCOUNT ON;  
    UPDATE TipoSolucion SET SOL_FlagActivo=0 WHERE SOl_ID=@SOl_ID
END 
GO

IF (OBJECT_ID('InsertarUsuarioResponsable') IS NOT NULL)
  DROP PROCEDURE InsertarUsuarioResponsable
GO
CREATE PROCEDURE InsertarUsuarioResponsable
@RES_Login	VARCHAR(45),
@RES_Nombre	Varchar(80),
@RES_ApellidoPaterno VARCHAR(80),
@RES_ApellidoMaterno VARCHAR(80),
@RES_Email Varchar(60),
@RES_CAR_ID int,
@RES_NIV_ID int
AS
BEGIN
    SET NOCOUNT ON;  
    INSERT INTO [dbo].[UsuarioResponsable](RES_Login,RES_Nombre, RES_ApellidoPaterno, RES_ApellidoMaterno,RES_Email,RES_CAR_ID,RES_NIV_ID)
	values(@RES_Login,@RES_Nombre,@RES_ApellidoPaterno, @RES_ApellidoMaterno,@RES_Email,@RES_CAR_ID,@RES_NIV_ID)
END 
GO

IF (OBJECT_ID('EditarUsuarioResponsable') IS NOT NULL)
  DROP PROCEDURE EditarUsuarioResponsable
GO
CREATE PROCEDURE EditarUsuarioResponsable
@RES_ID int
AS
BEGIN   

    SET NOCOUNT ON;  
    SELECT * FROM UsuarioResponsable WHERE RES_ID=@RES_ID
END 
GO


IF (OBJECT_ID('ActualizarUsuarioResponsable') IS NOT NULL)
  DROP PROCEDURE ActualizarUsuarioResponsable
GO
CREATE PROCEDURE ActualizarUsuarioResponsable
@RES_ID int,
@RES_Login	VARCHAR(45),
@RES_Nombre	Varchar(80),
@RES_ApellidoPaterno VARCHAR(80),
@RES_ApellidoMaterno VARCHAR(80),
@RES_Email Varchar(60),
@RES_CAR_ID int,
@RES_NIV_ID int
AS
BEGIN
    SET NOCOUNT ON;  
    UPDATE [dbo].[UsuarioResponsable] SET
	RES_Login = @RES_Login,
	RES_Nombre=@RES_Nombre,
	RES_ApellidoPaterno=@RES_ApellidoPaterno,
	RES_ApellidoMaterno=@RES_ApellidoMaterno,
	RES_Email=@RES_Email,
	RES_CAR_ID=@RES_CAR_ID,
	RES_NIV_ID=@RES_NIV_ID
	WHERE RES_ID=@RES_ID
END 
GO

IF (OBJECT_ID('EliminarUsuarioResponsable') IS NOT NULL)
  DROP PROCEDURE EliminarUsuarioResponsable
GO
CREATE PROCEDURE EliminarUsuarioResponsable
@RES_ID int
AS
BEGIN   

    SET NOCOUNT ON;
	UPDATE UsuarioResponsable SET RES_FlagActivo=0 WHERE RES_ID=@RES_ID
END 
GO
 
 /**Actualizar tipo de encuesta**/
IF (OBJECT_ID('InsertarTipoEncuesta') IS NOT NULL)
  DROP PROCEDURE InsertarTipoEncuesta
GO
CREATE PROCEDURE InsertarTipoEncuesta
@TEN_Nombre	VARCHAR(45),
@TEN_Descripcion	TEXT,
@TEN_AnioVigencia	INT,
@TEN_FechaCrecion datetime,
@TEN_UsuarioCreacion VARCHAR(25)
AS
BEGIN
    SET NOCOUNT ON;  
    INSERT INTO [dbo].[TipoEncuesta](TEN_Nombre,TEN_Descripcion, TEN_AnioVigencia, TEN_FechaCrecion, TEN_UsuarioCreacion)
	values(@TEN_Nombre,@TEN_Descripcion,@TEN_AnioVigencia, @TEN_FechaCrecion, @TEN_UsuarioCreacion)
END 
GO

IF (OBJECT_ID('EditarTipoEncuesta') IS NOT NULL)
  DROP PROCEDURE EditarTipoEncuesta
GO
CREATE PROCEDURE EditarTipoEncuesta
@TEN_ID int
AS
BEGIN
    SET NOCOUNT ON;  
    SELECT * FROM TipoEncuesta WHERE TEN_ID=@TEN_ID
END 
GO

IF (OBJECT_ID('ActualizarTipoEncuesta') IS NOT NULL)
  DROP PROCEDURE ActualizarTipoEncuesta
GO
CREATE PROCEDURE ActualizarTipoEncuesta
@TEN_ID	INT,
@TEN_Nombre	VARCHAR(45),
@TEN_Descripcion	TEXT,
@TEN_AnioVigencia	INT,
@TEN_FechaModificacion datetime,
@TEN_UsuarioModificacion VARCHAR(25)
AS
BEGIN
    SET NOCOUNT ON;  
    UPDATE [dbo].[TipoEncuesta] SET
	TEN_Nombre = @TEN_Nombre,
	TEN_Descripcion=@TEN_Descripcion,
	TEN_AnioVigencia=@TEN_AnioVigencia,
	TEN_FechaModificacion=@TEN_FechaModificacion,
	TEN_UsuarioModificacion=@TEN_UsuarioModificacion
	WHERE TEN_ID=@TEN_ID
END 
GO

IF (OBJECT_ID('EliminarTipoEncuesta') IS NOT NULL)
  DROP PROCEDURE EliminarTipoEncuesta
GO
CREATE PROCEDURE EliminarTipoEncuesta
@TEN_ID int
AS
BEGIN   

    SET NOCOUNT ON;
	UPDATE TipoEncuesta SET TEN_FlagActivo=0 WHERE TEN_ID=@TEN_ID
END 
GO
