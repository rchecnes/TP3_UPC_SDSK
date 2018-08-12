USE Indra
GO

SELECT * FROM Prioridad

INSERT INTO Prioridad(PRI_Id, Pri_Descripcion)
VALUES (1,'Alta')
INSERT INTO Prioridad(PRI_Id, Pri_Descripcion)
VALUES (2,'Media')
INSERT INTO Prioridad(PRI_Id, Pri_Descripcion)
VALUES (3,'Baja')

SELECT * FROM Prioridad

SELECT * FROM ESTADO
INSERT INTO ESTADO(EST_Id, EST_Descripcion) Values(1,'Pendiente')
INSERT INTO ESTADO(EST_Id, EST_Descripcion) Values(2,'En Proceso')
INSERT INTO ESTADO(EST_Id, EST_Descripcion) Values(3,'Atendido')
INSERT INTO ESTADO(EST_Id, EST_Descripcion) Values(4,'Cerrado')
SELECT * FROM ESTADO

SELECT * FROM Servicio
INSERT INTO Servicio(SER_Descripcion) VALUES('Instalación de Software')
INSERT INTO Servicio(SER_Descripcion) VALUES('Mantenimiento de Software')
INSERT INTO Servicio(SER_Descripcion) VALUES('Diagnóstico de Base de Datos')
INSERT INTO Servicio(SER_Descripcion) VALUES('Protección y Licenciamiento')
SELECT * FROM Servicio

SELECT * FROM TipoProblema
INSERT INTO TipoProblema(PRO_Descripcion,SER_Id) VALUES ('Office',1)
INSERT INTO TipoProblema(PRO_Descripcion,SER_Id) VALUES ('Administrativo',1)
INSERT INTO TipoProblema(PRO_Descripcion,SER_Id) VALUES ('CRM',1)
INSERT INTO TipoProblema(PRO_Descripcion,SER_Id) VALUES ('Otros',2)
SELECT * FROM TipoProblema

SELECT * FROM CATEGORIA
INSERT INTO CATEGORIA(CAT_Descripcion) VALUES('Impresora')
INSERT INTO CATEGORIA(CAT_Descripcion) VALUES('Router')
INSERT INTO CATEGORIA(CAT_Descripcion) VALUES('Otros')
SELECT * FROM CATEGORIA

select * from TipoSolucion
INSERT INTO TipoSolucion(SOL_PROD_ID,SOL_Descripcion, SOL_RutaArchivo,SOL_DescripcionLarga,SOL_CAT_ID,SOL_FechaCreacion,SOL_UsuarioCreacion) 
VALUES(1,'Instalación de Microsoft Word','File/Office.pdf','Procedimiento para realizar la instalación de Word', 3, getdate(),'JCaceres')
INSERT INTO TipoSolucion(SOL_PROD_ID,SOL_Descripcion, SOL_RutaArchivo,SOL_DescripcionLarga,SOL_CAT_ID,SOL_FechaCreacion,SOL_UsuarioCreacion) 
VALUES(1,'Instalación de Microsoft Excel','File/Office.pdf','Procedimiento para realizar la instalación de Excel', 3, getdate(),'JCaceres')
INSERT INTO TipoSolucion(SOL_PROD_ID,SOL_Descripcion, SOL_RutaArchivo,SOL_DescripcionLarga,SOL_CAT_ID,SOL_FechaCreacion,SOL_UsuarioCreacion) 
VALUES(1,'Instalación de Outlook','File/Outlook.pdf','Procedimiento para realizar la instalación de Outlook', 3, getdate(),'JCaceres')
INSERT INTO TipoSolucion(SOL_PROD_ID,SOL_Descripcion, SOL_RutaArchivo,SOL_DescripcionLarga,SOL_CAT_ID,SOL_FechaCreacion,SOL_UsuarioCreacion) 
VALUES(1,'Instalación de Power Point','File/Office.pdf','Procedimiento para realizar la instalación de Office', 3, getdate(),'JCaceres')
INSERT INTO TipoSolucion(SOL_PROD_ID,SOL_Descripcion, SOL_RutaArchivo,SOL_DescripcionLarga,SOL_CAT_ID,SOL_FechaCreacion,SOL_UsuarioCreacion) 
VALUES(1,'Instalación de Access','File/Office.pdf','Procedimiento para realizar la instalación de Acces', 3, getdate(),'JCaceres')
INSERT INTO TipoSolucion(SOL_PROD_ID,SOL_Descripcion, SOL_RutaArchivo,SOL_DescripcionLarga,SOL_CAT_ID,SOL_FechaCreacion,SOL_UsuarioCreacion) 
VALUES(2,'Instalación de Skype Empresarial','File/Office.pdf','Procedimiento para realizar la instalación de Skype', 1, getdate(),'JCaceres')
select * from TipoSolucion

select * from Empresa
INSERT INTO Empresa(EMP_RUC,EMP_RazonSocial)
VALUES(205621546932,'Pacifico Seguros de Vida')
select * from Empresa

SELECT * FROM UsuarioCliente
INSERT INTO USUARIOCLIENTE(USU_IdLogin,USU_EMP_ID, USU_Nombre, USU_ApellidoPaterno, USU_ApellidoMaterno, USU_Telefono, USU_Email)
values('RMiranda',1, 'Ricardo', 'Miranda', 'Galvez', '2523495','Ricardo.Miranda@PacificoVida.com.pe')
SELECT * FROM UsuarioCliente

SELECT * FROM Cargo
INSERT INTO Cargo(CAR_Descripcion) VALUES('Especialista TI')
INSERT INTO Cargo(CAR_Descripcion) VALUES('Técnico Operador')
INSERT INTO Cargo(CAR_Descripcion) VALUES('Técnico TI')
SELECT * FROM Cargo

SELECT * FROM NIVEL
INSERT INTO NIVEL(NIV_Descripcion) VALUES('Junior')
INSERT INTO NIVEL(NIV_Descripcion) VALUES('Pleno')
INSERT INTO NIVEL(NIV_Descripcion) VALUES('Sennior')
SELECT * FROM NIVEL

SELECT * FROM UsuarioResponsable
INSERT INTO UsuarioResponsable(RES_IDLogin, RES_CAR_Id,RES_Nombre, RES_ApellidoPaterno, RES_ApellidoMaterno, RES_Email,RES_NIV_Id)
values('JCaceres', 2, 'Javier', 'Caceres', 'Gonzales', 'JavierCaceres@indra.com.pe',1)
INSERT INTO UsuarioResponsable(RES_IDLogin, RES_CAR_Id,RES_Nombre, RES_ApellidoPaterno, RES_ApellidoMaterno, RES_Email,RES_NIV_Id)
values('JCampos', 2, 'Jorge', 'Campos', 'Medina', 'JorgeCampos@indra.com.pe',2)
SELECT * FROM UsuarioResponsable

INSERT INTO TipoEncuesta(TEN_Nombre) VALUES('Encuesta General')
INSERT INTO TipoEncuesta(TEN_Nombre) VALUES('Encuesta de Satisfacción')

INSERT INTO Pregunta(PRE_Descripcion,PRE_TipoControl,PRE_TEN_Id,PRE_FlagActivo) VALUES('¿Que tan satisfecho está con la atención?',1,1,1)
INSERT INTO Pregunta(PRE_Descripcion,PRE_TipoControl,PRE_TEN_Id,PRE_FlagActivo) VALUES('Volvería utilizar la mesa de ayuda?',2,1,1)
INSERT INTO Pregunta(PRE_Descripcion,PRE_TipoControl,PRE_TEN_Id,PRE_FlagActivo) VALUES('Que tan frecuente usa la mesa de ayuda?',3,2,1)
INSERT INTO Pregunta(PRE_Descripcion,PRE_TipoControl,PRE_TEN_Id,PRE_FlagActivo) VALUES('Que tan amable fue la atención de la mesa de ayuda?',4,2,1)
INSERT INTO Pregunta(PRE_Descripcion,PRE_TipoControl,PRE_TEN_Id,PRE_FlagActivo) VALUES('Cuantas veces ha utilizado la mesa de ayuda?',5,2,1)

INSERT INTO ENCUESTA(ENC_Nombre,ENC_Descripcion,ENC_FlagActivo,ENC_TEN_Id,ENC_FlagEnvio) VALUES('Encuesta 1','Encuesta de satisfacción generado después del ticket',1,2,NULL)
INSERT INTO ENCUESTA(ENC_Nombre,ENC_Descripcion,ENC_FlagActivo,ENC_TEN_Id,ENC_FlagEnvio) VALUES('Encuesta 2','Encuesta de satisfacción anual',1,1,0)


SELECT * FROM Ticket
INSERT INTO Ticket(TIC_PRI_Id,TIC_PRO_Id,TIC_SOL_Id, TIC_SER_Id, TIC_EMP_Id, TIC_USU_Id, TIC_Descripcion, TIC_FechaRegistro, TIC_FechaCierre, TIC_CodigoEstado)
VALUES(1,1,1,1,1,1,'Prueba',GETDATE(),null,1)
SELECT * FROM Ticket

select * from Resultado
INSERT INTO Resultado(RST_Descripcion,RST_FlagExito)
VALUES('Se realizó la instalación del programa office sin mayores problemas',0)
select * from Resultado

SELECT * FROM Atencion
INSERT INTO Atencion(ATE_TIC_Id, ATE_RES_Id, ATE_RST_Id,ATE_FechaAsignacion, ATE_FechaInicio, ATE_FechaFin, ATE_FechaCierre, ATE_FechaAtencion,ATE_FechaRegistro)
VALUES(1,1,1,GETDATE()-5, GETDATE()-4, GETDATE()-3,GETDATE(), GETDATE()-1, GETDATE())

UPDATE SHMC_USUA SET COD_USUA = 'JCaceres'
Where COD_USUA = 'ivelarde'