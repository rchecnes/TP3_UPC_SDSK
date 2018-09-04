/*create database Indra
go*/

USE Indra;
GO

drop table ContratoSLA;
drop table Contrato;
drop table SLA;
drop table HistorialTicket;
drop table Atencion;
drop table Resultado;
drop table Ticket;
drop table EncuestaRespuesta;
drop table Encuesta;
drop table TipoEncuestaPregunta;
drop table Pregunta;
drop table TipoEncuesta;
drop table estado;
drop table UsuarioResponsable;
drop table Nivel;
drop table Cargo;
drop table UsuarioCliente;
drop table Empresa;
drop table TipoSolucion;
drop table Categoria;
drop table TipoProblema;
drop table Servicio;
drop table Prioridad;
drop table TipoUsuario;


CREATE TABLE Prioridad
(
PRI_ID INTEGER PRIMARY KEY,
PRI_Descripcion VARCHAR(45)
)
go

CREATE TABLE Servicio
(
SER_ID	INTEGER IDENTITY(1,1) PRIMARY KEY,
SER_Descripcion	VARCHAR(45)
)
go

CREATE TABLE TipoProblema
(
PROB_ID	INTEGER IDENTITY(1,1) PRIMARY KEY,
PROB_Descripcion	VARCHAR(45),
SER_ID INTEGER FOREIGN KEY REFERENCES Servicio(SER_ID)
)
go

CREATE TABLE Categoria
(
CAT_ID	INTEGER IDENTITY(1,1) PRIMARY KEY,
CAT_Descripcion	VARCHAR(150)
)
go

CREATE TABLE TipoSolucion
(
SOL_ID INTEGER IDENTITY(1,1) PRIMARY KEY,
SOL_PROB_ID	INTEGER FOREIGN KEY REFERENCES TipoProblema(PROB_ID) NOT NULL,
SOL_Nombre	VARCHAR(45),
SOL_RutaArchivo	VARCHAR(250),
SOL_NombreArchivo	VARCHAR(250),
SOL_Descripcion	TEXT,
SOL_PalabraClave TEXT,
SOL_Comentario TEXT,
SOL_CAT_ID INTEGER FOREIGN KEY REFERENCES Categoria(CAT_ID) NOT NULL,
SOL_FechaCreacion	DATETIME,
SOL_FechaModificacion DATETIME,
SOL_UsuarioCreacion	VARCHAR(50),
SOL_UsuarioModificacion VARCHAR(50),
SOL_FlagActivo BIT DEFAULT 1
)
go

CREATE TABLE Empresa
(
EMP_ID	INTEGER IDENTITY(1,1) PRIMARY KEY,
EMP_RUC	varchar(20),
EMP_RazonSocial	VARCHAR(250) NOT NULL
)
go

CREATE TABLE UsuarioCliente
(
USU_ID INTEGER IDENTITY PRIMARY KEY,
USU_Login VARCHAR(50),
USU_Password VARCHAR(100),
USU_EMP_ID	INTEGER FOREIGN KEY REFERENCES Empresa(EMP_ID),
USU_Nombre	VARCHAR(80),
USU_ApellidoPaterno	VARCHAR(80),
USU_ApellidoMaterno	VARCHAR(80),
USU_Telefono	Varchar(15),
USU_Email		Varchar(60)
)
go

CREATE TABLE Cargo
(
CAR_ID INTEGER PRIMARY KEY,
CAR_Descripcion	VARCHAR(80)
)
go

CREATE TABLE Nivel
(
NIV_ID INTEGER IDENTITY(1,1) PRIMARY KEY,
NIV_Descripcion	VARCHAR(80)
)
go

CREATE TABLE UsuarioResponsable
(
RES_ID	INTEGER IDENTITY PRIMARY KEY,
RES_Login	VARCHAR(45),
RES_Password VARCHAR(100),
RES_CAR_ID	INTEGER FOREIGN KEY REFERENCES Cargo(CAR_ID) NOT NULL,
RES_Nombre	Varchar(80),
RES_ApellidoPaterno	VARCHAR(80),
RES_ApellidoMaterno	VARCHAR(80),
RES_Email		Varchar(60),
RES_NIV_ID	INTEGER FOREIGN KEY REFERENCES Nivel(NIV_ID) NOT NULL,
RES_FlagActivo BIT DEFAULT 1
)
go

CREATE TABLE Estado
(
EST_ID INT PRIMARY KEY,
EST_Descripcion	Varchar(50)
);
go

CREATE TABLE TipoEncuesta
(
TEN_ID	INTEGER IDENTITY(1,1) PRIMARY KEY,
TEN_Nombre	VARCHAR(45),
TEN_AnioVigencia	INT,
TEN_Descripcion	VARCHAR(500),
TEN_FechaCrecion	DATETIME,
TEN_UsuarioCreacion	VARCHAR(25),
TEN_FechaModificacion	DATETIME,
TEN_UsuarioModificacion	VARCHAR(25),
TEN_FlagActivo	BIT DEFAULT 1,
TEN_FlagEnvio BIT DEFAULT 0
)
go

CREATE TABLE Pregunta
(
PRE_ID	INTEGER IDENTITY(1,1) PRIMARY KEY,
PRE_Descripcion VARCHAR(200),
PRE_TipoControl INT,
PRE_FlagActivo	BIT DEFAULT 1
)
go

CREATE TABLE TipoEncuestaPregunta
(
TEP_ID	INTEGER IDENTITY(1,1) PRIMARY KEY,
TEP_PRE_ID INTEGER FOREIGN KEY REFERENCES Pregunta(PRE_ID),
TEP_TEN_ID INTEGER FOREIGN KEY REFERENCES TipoEncuesta(TEN_ID),
TEP_FlagActivo	BIT DEFAULT 1
)
go

CREATE TABLE TipoUsuario
(
TUS_ID INTEGER PRIMARY KEY,
TUS_Descripcion	VARCHAR(100)
)
go

CREATE TABLE Encuesta
(
ENC_ID INTEGER IDENTITY(1,1) PRIMARY KEY,
ENC_Titulo VARCHAR(120),
ENC_Descripcion TEXT,
ENC_TEN_Id INTEGER FOREIGN KEY REFERENCES TipoEncuesta(TEN_Id),
ENC_TUS_ID INTEGER FOREIGN KEY REFERENCES TipoUsuario(TUS_ID),
ENC_EMP_ID INTEGER FOREIGN KEY REFERENCES Empresa(EMP_Id),
ENC_FlagEnvio BIT DEFAULT 0,
ENC_FlagActivo BIT DEFAULT 1,
ENC_FechaCrecion	DATETIME,
ENC_FechaModificacion	DATETIME NULL,
ENC_UsuarioCreacion	VARCHAR(25),
ENC_UsuarioModificacion	VARCHAR(25) NULL
)
go

CREATE TABLE Ticket
(
TIC_ID	INTEGER IDENTITY(1,1) PRIMARY KEY,
TIC_PRI_ID	INTEGER FOREIGN KEY REFERENCES Prioridad(PRI_ID),
TIC_PROB_ID INTEGER FOREIGN KEY REFERENCES TipoProblema(PROB_ID),
TIC_SOL_ID	INTEGER NULL FOREIGN KEY REFERENCES TipoSolucion(SOL_ID),
TIC_SER_ID	INTEGER	FOREIGN KEY REFERENCES Servicio(SER_ID),
TIC_EMP_ID	INTEGER	FOREIGN KEY REFERENCES Empresa(EMP_ID),
TIC_USU_ID	INTEGER	FOREIGN KEY REFERENCES UsuarioCliente(USU_ID),
TIC_RES_ID	INTEGER	FOREIGN KEY REFERENCES UsuarioResponsable(RES_ID),
TIC_Descripcion VARCHAR(5000),
TIC_FechaRegistro	DATETIME,
TIC_FechaCierre	DATETIME NULL,
TIC_EST_ID	INT FOREIGN KEY REFERENCES Estado(EST_ID),
TIC_ENC_ID	INT NULL FOREIGN KEY REFERENCES Encuesta,
TIC_FlagActivo	BIT DEFAULT 1
)
go

CREATE TABLE EncuestaRespuesta
(
ERE_ID INT identity(1,1) Primary Key,
ERE_ENC_ID int Foreign Key References Encuesta(ENC_ID),
ERE_TEP_Id int Foreign Key References TipoEncuestaPregunta(TEP_Id),
ERE_Respuesta SMALLINT,
ERE_FechaRespuesta DATETIME
)
go

CREATE TABLE Resultado
(
RST_ID	INT	IDENTITY(1,1) PRIMARY KEY,
RST_Descripcion	VARCHAR(5000),
RST_FlagExito	BIT
)
go

CREATE TABLE Atencion
(
ATE_ID		INTEGER IDENTITY(1,1),
ATE_TIC_ID	INTEGER FOREIGN KEY REFERENCES Ticket(TIC_ID),
ATE_RES_ID	INTEGER FOREIGN KEY REFERENCES UsuarioResponsable(RES_ID),
ATE_RST_ID	INTEGER,
ATE_FechaAsignacion	DATETIME NULL,
ATE_FechaInicio	DATETIME,
ATE_FechaFin	DATETIME,
ATE_FechaCierre	DATETIME NULL,
ATE_FechaAtencion	DATETIME,
ATE_PRI_ID	INTEGER,
ATE_TIC_Descripcion VARCHAR(5000),
ATE_FechaRegistro	DATETIME
PRIMARY KEY(ATE_ID,ATE_TIC_ID,ATE_RES_ID)
)
go

CREATE TABLE HistorialTicket
(
HIS_ID		INTEGER IDENTITY(1,1),
HIS_TIC_ID	INTEGER FOREIGN KEY REFERENCES Ticket(TIC_ID),
HIS_PRI_ID	INTEGER FOREIGN KEY REFERENCES Prioridad(PRI_ID),
HIS_RES_ID	INTEGER FOREIGN KEY REFERENCES UsuarioResponsable(RES_ID),
HIS_FechaCambio	DATETIME,
HIS_Descripcion VARCHAR(500),
HIS_RutaInforme	VARCHAR(100) NULL
)
go
CREATE TABLE Contrato
(
CON_ID	INTEGER IDENTITY(1,1) PRIMARY KEY,
CON_EMP_ID	INTEGER FOREIGN KEY REFERENCES Empresa(EMP_ID),
CON_FechaInicioContrato DATETIME,
CON_FechaFinContrato	DATETIME,
CON_FechaCreacion DATETIME,
CON_FechaModificacion	DATETIME NULL,
CON_UsuarioCreacion	VARCHAR(25),
CON_UsuarioModificacion	VARCHAR(25) NULL,
CON_FlagActivo BIT DEFAULT 1
)
go
CREATE TABLE SLA
(
SLA_ID INTEGER IDENTITY(1,1) PRIMARY KEY,
SLA_Descripcion	VARCHAR(200),
SLA_NomSistema VARCHAR(50)
)
go
CREATE TABLE ContratoSLA
(
CSL_ID	INTEGER IDENTITY(1,1) PRIMARY KEY,
CSL_CON_ID INTEGER FOREIGN KEY REFERENCES Contrato(CON_ID),
CSL_SLA_ID INTEGER FOREIGN KEY REFERENCES SLA(SLA_ID),
CSL_SER_ID INTEGER FOREIGN KEY REFERENCES Servicio(SER_ID),
CSL_PorcentajeMedicion	DECIMAL,
CSL_Penalidad			DECIMAL,
CSL_FechaCreacion DATETIME,
CSL_FechaModificacion	DATETIME NULL,
CSL_UsuarioCreacion	VARCHAR(25),
CSL_UsuarioModificacion	VARCHAR(25) NULL
)
