USE Indra
GO

INSERT INTO Prioridad(PRI_ID, Pri_Descripcion)VALUES (1,'Alta')
INSERT INTO Prioridad(PRI_ID, Pri_Descripcion)VALUES (2,'Media')
INSERT INTO Prioridad(PRI_ID, Pri_Descripcion)VALUES (3,'Baja')
GO
SELECT * FROM Prioridad
go
INSERT INTO ESTADO(EST_ID, EST_Descripcion) Values(1,'Pendiente')
INSERT INTO ESTADO(EST_ID, EST_Descripcion) Values(2,'En Proceso')
INSERT INTO ESTADO(EST_ID, EST_Descripcion) Values(3,'Atendido')
INSERT INTO ESTADO(EST_ID, EST_Descripcion) Values(4,'Cerrado')
go
SELECT * FROM ESTADO
go

INSERT INTO Servicio(SER_Descripcion) VALUES('Instalación de Software')
INSERT INTO Servicio(SER_Descripcion) VALUES('Mantenimiento de Software')
INSERT INTO Servicio(SER_Descripcion) VALUES('Diagnóstico de Base de Datos')
INSERT INTO Servicio(SER_Descripcion) VALUES('Protección y Licenciamiento')
go
SELECT * FROM Servicio
go
INSERT INTO TipoProblema(PROB_Descripcion,SER_ID) VALUES ('Office',1)
INSERT INTO TipoProblema(PROB_Descripcion,SER_ID) VALUES ('Administrativo',1)
INSERT INTO TipoProblema(PROB_Descripcion,SER_ID) VALUES ('CRM',1)
INSERT INTO TipoProblema(PROB_Descripcion,SER_ID) VALUES ('Otros',2)
go
SELECT * FROM TipoProblema
go

INSERT INTO CATEGORIA(CAT_Descripcion) VALUES('Impresora')
INSERT INTO CATEGORIA(CAT_Descripcion) VALUES('Router')
INSERT INTO CATEGORIA(CAT_Descripcion) VALUES('Otros')
go

INSERT INTO TipoSolucion(SOL_PROB_ID, SOL_Nombre, SOL_Descripcion, SOL_NombreArchivo, SOL_RutaArchivo,SOL_CAT_ID,SOL_FechaCreacion,SOL_UsuarioCreacion) 
VALUES(1,'Instalación de Microsoft Word','Procedimiento para realizar la instalación de Word','office','File/Office.pdf',3, getdate(),'JCaceres')
go
select * from TipoSolucion
go

INSERT INTO Empresa(EMP_RUC,EMP_RazonSocial)
VALUES(205621546932,'Pacifico Seguros de Vida')
go
select * from Empresa
go

INSERT INTO USUARIOCLIENTE(USU_IDLogin,USU_EMP_ID, USU_Nombre, USU_ApellidoPaterno, USU_ApellidoMaterno, USU_Telefono, USU_Email)
values('RMiranda',1, 'Ricardo', 'Miranda', 'Galvez', '2523495','Ricardo.Miranda@PacificoVida.com.pe')
go
SELECT * FROM UsuarioCliente
go

INSERT INTO Cargo(CAR_Descripcion) VALUES('Especialista TI')
INSERT INTO Cargo(CAR_Descripcion) VALUES('Técnico Operador')
INSERT INTO Cargo(CAR_Descripcion) VALUES('Técnico TI')
go
SELECT * FROM Cargo
go

INSERT INTO NIVEL(NIV_Descripcion) VALUES('Junior')
INSERT INTO NIVEL(NIV_Descripcion) VALUES('Pleno')
INSERT INTO NIVEL(NIV_Descripcion) VALUES('Sennior')
go
SELECT * FROM NIVEL
go

INSERT INTO UsuarioResponsable(RES_IDLogin, RES_CAR_ID,RES_Nombre, RES_ApellidoPaterno, RES_ApellidoMaterno, RES_Email,RES_NIV_ID)
values('JCaceres', 2, 'Javier', 'Caceres', 'Gonzales', 'JavierCaceres@indra.com.pe',1)
INSERT INTO UsuarioResponsable(RES_IDLogin, RES_CAR_ID,RES_Nombre, RES_ApellidoPaterno, RES_ApellidoMaterno, RES_Email,RES_NIV_ID)
values('JCampos', 2, 'Jorge', 'Campos', 'Medina', 'JorgeCampos@indra.com.pe',2)
go
SELECT * FROM UsuarioResponsable
go

INSERT INTO TipoEncuesta(TEN_Nombre) VALUES('Encuesta General')
INSERT INTO TipoEncuesta(TEN_Nombre) VALUES('Encuesta de Satisfacción')
go
INSERT INTO Pregunta(PRE_Descripcion,PRE_TipoControl,PRE_TEN_ID,PRE_FlagActivo) VALUES('¿Que tan satisfecho está con la atención?',1,1,1)
INSERT INTO Pregunta(PRE_Descripcion,PRE_TipoControl,PRE_TEN_ID,PRE_FlagActivo) VALUES('Volvería utilizar la mesa de ayuda?',2,1,1)
INSERT INTO Pregunta(PRE_Descripcion,PRE_TipoControl,PRE_TEN_ID,PRE_FlagActivo) VALUES('Que tan frecuente usa la mesa de ayuda?',3,2,1)
INSERT INTO Pregunta(PRE_Descripcion,PRE_TipoControl,PRE_TEN_ID,PRE_FlagActivo) VALUES('Que tan amable fue la atención de la mesa de ayuda?',4,2,1)
INSERT INTO Pregunta(PRE_Descripcion,PRE_TipoControl,PRE_TEN_ID,PRE_FlagActivo) VALUES('Cuantas veces ha utilizado la mesa de ayuda?',5,2,1)
go
INSERT INTO ENCUESTA(ENC_Nombre,ENC_Descripcion,ENC_FlagActivo,ENC_TEN_ID,ENC_FlagEnvio) VALUES('Encuesta 1','Encuesta de satisfacción generado después del ticket',1,2,NULL)
INSERT INTO ENCUESTA(ENC_Nombre,ENC_Descripcion,ENC_FlagActivo,ENC_TEN_ID,ENC_FlagEnvio) VALUES('Encuesta 2','Encuesta de satisfacción anual',1,1,0)
go

INSERT INTO Ticket(TIC_PRI_ID,TIC_PROB_ID,TIC_SOL_ID, TIC_SER_ID, TIC_EMP_ID, TIC_USU_ID, TIC_Descripcion, TIC_FechaRegistro, TIC_FechaCierre, TIC_CodigoEstado)
VALUES(1,1,1,1,1,1,'Prueba',GETDATE(),null,1)
go
SELECT * FROM Ticket
go

INSERT INTO Resultado(RST_Descripcion,RST_FlagExito)
VALUES('Se realizó la instalación del programa office sin mayores problemas',0)
go
select * from Resultado
go

INSERT INTO Atencion(ATE_TIC_ID, ATE_RES_ID, ATE_RST_ID,ATE_FechaAsignacion, ATE_FechaInicio, ATE_FechaFin, ATE_FechaCierre, ATE_FechaAtencion,ATE_FechaRegistro)
VALUES(1,1,1,GETDATE()-5, GETDATE()-4, GETDATE()-3,GETDATE(), GETDATE()-1, GETDATE())
go
UPDATE SHMC_USUA SET COD_USUA = 'JCaceres'
Where COD_USUA = 'ivelarde'