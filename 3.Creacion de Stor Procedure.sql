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

IF (OBJECT_ID('EstadoLista') IS NOT NULL)
  DROP PROCEDURE EstadoLista
GO
CREATE PROCEDURE EstadoLista 
AS   

    SET NOCOUNT ON;  
    SELECT * FROM Estado  
GO

IF (OBJECT_ID('SolucionLista') IS NOT NULL)
  DROP PROCEDURE SolucionLista
GO
CREATE PROCEDURE SolucionLista 
AS   

    SET NOCOUNT ON;  
    SELECT * FROM TipoSolucion  
GO

IF (OBJECT_ID('PrioridadLista') IS NOT NULL)
  DROP PROCEDURE PrioridadLista
GO
CREATE PROCEDURE PrioridadLista 
AS   

    SET NOCOUNT ON;  
    SELECT * FROM Prioridad  
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
@SOL_CAT_ID int,
@SOL_RutaArchivo nvarchar(250),
@SOL_NombreArchivo nvarchar(250)
AS
BEGIN
    SET NOCOUNT ON;
	UPDATE [dbo].[TipoSolucion] SET 
	SOL_Descripcion=@SOL_Descripcion,
	SOL_PalabraClave=@SOL_PalabraClave,
	SOL_FechaModificacion=@SOL_FechaModificacion,
	SOL_UsuarioModificacion=@SOL_UsuarioModificacion,
	SOL_CAT_ID=@SOL_CAT_ID,
	SOL_PROB_ID=@SOL_PROB_ID,
	SOL_RutaArchivo=@SOL_RutaArchivo,
	SOL_NombreArchivo=@SOL_NombreArchivo
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

/**TICKET**/
IF (OBJECT_ID('InsertarTicket') IS NOT NULL)
  DROP PROCEDURE InsertarTicket
GO
CREATE PROCEDURE InsertarTicket
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

IF (OBJECT_ID('EditarTicket') IS NOT NULL)
  DROP PROCEDURE EditarTicket
GO
CREATE PROCEDURE EditarTicket
@TEN_ID int
AS
BEGIN
    SET NOCOUNT ON;  
    SELECT * FROM TipoEncuesta WHERE TEN_ID=@TEN_ID
END 
GO

IF (OBJECT_ID('ActualizarTicket') IS NOT NULL)
  DROP PROCEDURE ActualizarTicket
GO
CREATE PROCEDURE ActualizarTicket
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


IF (OBJECT_ID('ConsultarHistorialTicket') IS NOT NULL)
  DROP PROCEDURE ConsultarHistorialTicket
GO
CREATE PROCEDURE ConsultarHistorialTicket
@TIC_ID	INT
AS
BEGIN
    SET NOCOUNT ON;  
    SELECT RIGHT( '000000000' + RTRIM(LTRIM(t.TIC_Id)),9) AS TIC_Code, T.TIC_Id, A.ATE_ID, RES.RES_Nombre + ' ' + RES.RES_ApellidoPaterno as RES_Nombre,
		   P.Pri_Descripcion, A.ATE_FechaRegistro,A.ATE_FechaRegistro, A.ATE_TIC_Descripcion AS TIC_Descripcion, ISNULL(A.ATE_RST_Id,0) AS ATE_RST_Id
	FROM Ticket T LEFT JOIN Atencion A
	ON A.ATE_TIC_Id = T.TIC_Id LEFT JOIN Prioridad P
	ON P.PRI_Id = A.ATE_PRI_Id LEFT JOIN UsuarioResponsable RES
	ON RES.RES_Id = A.ATE_RES_Id LEFT JOIN Resultado R
	ON R.RST_Id = A.ATE_RST_Id
	WHERE (A.ATE_TIC_Id = @TIC_ID OR @TIC_ID IS NULL)
END 
GO

/**MONITOREO NUEVO**/
IF (OBJECT_ID('MonitoreoSLA') IS NOT NULL)
  DROP PROCEDURE MonitoreoSLA
GO
Create Procedure MonitoreoSLA
@IdContrato INT,
@SlaNomSistema VARCHAR(60),
@Anio VARCHAR(4),
@Mes VARCHAR(2)
AS

DECLARE @EMP_ID INT
DECLARE @CON_FechaInicio DATE
DECLARE @CON_FechaFin DATE
DECLARE @Medicion DECIMAL;
DECLARE      @TotalTicket int;

SELECT @EMP_ID = CON_EMP_ID,@CON_FechaInicio=format(C.CON_FechaInicioContrato,'yyyy-MM-dd'),@CON_FechaFin=format(C.CON_FechaFinContrato,'yyyy-MM-dd')  FROM Contrato C WHERE C.CON_ID = @IdContrato;
SELECT @TotalTicket = COUNT(1) FROM Ticket WHERE TIC_FlagActivo = 1 AND TIC_EMP_ID=@EMP_ID AND format(TIC_FechaRegistro,'yyyy-MM-dd') BETWEEN @CON_FechaInicio AND @CON_FechaFin AND YEAR(TIC_FechaRegistro)=@Anio AND MONTH(TIC_FechaRegistro)=@Mes;

IF @SlaNomSistema = 'TEMP_ATE_M10M'
       BEGIN
             DECLARE @CUMPLE_10M INT;
             SELECT @CUMPLE_10M=COUNT(T.TIC_ID) FROM Ticket T 
             INNER JOIN Atencion A ON(T.TIC_ID = A.ATE_TIC_ID AND A.ATE_RST_ID=1 AND A.ATE_ID = (SELECT TOP 1 AT.ATE_ID FROM Atencion AT WHERE AT.ATE_TIC_ID = T.TIC_ID ORDER BY AT.ATE_ID DESC))
             INNER JOIN Contrato CC ON(T.TIC_EMP_ID=CC.CON_EMP_ID)
             WHERE T.TIC_EST_ID = 3
             AND format(T.TIC_FechaRegistro,'yyyy-MM-dd') BETWEEN @CON_FechaInicio AND @CON_FechaFin
             AND CC.CON_ID=@IdContrato
             AND YEAR(T.TIC_FechaRegistro)=@Anio
             AND MONTH(T.TIC_FechaRegistro)=@Mes
             AND DATEDIFF(MI,A.ATE_FechaInicio, A.ATE_FechaFin)<=10

             SELECT (@CUMPLE_10M/CONVERT(decimal(3,2), @TotalTicket)*100) AS Porcentaje 
             
       END
ELSE IF @SlaNomSistema = 'NRESOL_PRI_CONTACTO'
       BEGIN
             DECLARE @CUMPLE_1ROC INT;
             SELECT @CUMPLE_1ROC=COUNT(T.TIC_ID) FROM Ticket T 
             INNER JOIN Atencion A ON(T.TIC_ID = A.ATE_TIC_ID AND A.ATE_RST_ID=1)
             INNER JOIN Contrato CC ON(T.TIC_EMP_ID=CC.CON_EMP_ID)
             WHERE T.TIC_EST_ID = 3
             AND format(T.TIC_FechaRegistro,'yyyy-MM-dd') BETWEEN @CON_FechaInicio AND @CON_FechaFin
             AND CC.CON_ID=@IdContrato
             AND YEAR(T.TIC_FechaRegistro)=@Anio
             AND MONTH(T.TIC_FechaRegistro)=@Mes
             AND (SELECT TOP 1 ATE_RST_ID FROM Atencion AT WHERE AT.ATE_TIC_ID = T.TIC_ID ORDER BY AT.ATE_ID ASC)=1;

             SELECT (@CUMPLE_1ROC/CONVERT(decimal(3,2), @TotalTicket)*100) AS Porcentaje
       END
ELSE IF @SlaNomSistema = 'TIC_ATE_24H'
       BEGIN
             DECLARE @CUMPLE_24H INT;
             SELECT @CUMPLE_24H=COUNT(T.TIC_ID) FROM Ticket T 
             INNER JOIN Atencion A ON(T.TIC_ID = A.ATE_TIC_ID AND A.ATE_RST_ID=1 AND A.ATE_ID = (SELECT TOP 1 AT.ATE_ID FROM Atencion AT WHERE AT.ATE_TIC_ID = T.TIC_ID ORDER BY AT.ATE_ID DESC))
             INNER JOIN Contrato CC ON(T.TIC_EMP_ID=CC.CON_EMP_ID)
             WHERE T.TIC_EST_ID = 3
             AND format(T.TIC_FechaRegistro,'yyyy-MM-dd') BETWEEN @CON_FechaInicio AND @CON_FechaFin
             AND CC.CON_ID=@IdContrato
             AND YEAR(T.TIC_FechaRegistro)=@Anio
             AND MONTH(T.TIC_FechaRegistro)=@Mes
             AND DATEDIFF(MI,A.ATE_FechaInicio, A.ATE_FechaFin)<=1440

             SELECT (@CUMPLE_24H/CONVERT(decimal(3,2), @TotalTicket)*100) AS Porcentaje
       END
ELSE
       BEGIN
             SELECT 0 AS Porcentaje
       END
GO
