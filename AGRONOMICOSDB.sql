create database AGRONOMICOSDB
go
use AGRONOMICOSDB
go
CREATE TABLE [Analisis] (

[IdAnalisis] int NOT NULL,

[Nombre] varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,

[Categoria] varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,

[Descripcion] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,

[UsuarioCreacion] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,

[FechaCreacion] date NOT NULL,

[UsuarioActualizacion] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,

[FechaActualizacion] date NULL,

CONSTRAINT [PK__Analisis__EFD67EA6AB5CA0F7] PRIMARY KEY ([IdAnalisis]) 

)

GO



CREATE TABLE [Factura] (

[IdFactura] int NOT NULL,

[Fecha] date NOT NULL,

[Costo] int NOT NULL,

[IdCliente] int NOT NULL,

[UsuarioCreacion] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,

[FechaCreacion] date NOT NULL,

[UsuarioActualizacion] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,

[FechaActualizacion] date NULL,

CONSTRAINT [PK__Factura__50E7BAF19CB964D0] PRIMARY KEY ([IdFactura]) 

)

GO



CREATE TABLE [Muestra] (

[Codigo] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,

[Campo] varchar(40) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,

[IdCliente] int NOT NULL,

[Provincia] varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,

[Canton] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,

[Distrito] varchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,

[Direccion] varchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,

[UsuarioCracion] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,

[FechaCreacion] date NOT NULL,

[UsuarioActualizacion] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,

[FechaActualizacion] date NULL,

CONSTRAINT [PK__Muestra__06370DAD588A101A] PRIMARY KEY ([Codigo]) 

)

GO



CREATE TABLE [Muestra_analisis] (

[IdMuestraAnalisis] int NOT NULL,

[Nombre] varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,

[Costo] int NOT NULL,

[Codigo] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,

[IdFactura] int NOT NULL,

[IdAnalisis] int NOT NULL,

[Estado] tinyint NOT NULL,

[UsuarioCreacion] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,

[FechaCreacion] date NOT NULL,

[UsuarioActualizacion] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,

[FechaActualizacion] date NULL,

CONSTRAINT [PK__Muestra___87760CC557EB1FBB] PRIMARY KEY ([IdMuestraAnalisis]) 

)

GO



CREATE TABLE [Persona] (

[ID_Persona] int NOT NULL IDENTITY(1,1),

[Nombre] varchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,

[Apellido1] varchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,

[Apellido2] varchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,

[Correo] varchar(40) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,

[Clave] varchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,

[FechaCreacion] date NULL,

[UsuarioCreacion] varchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,

[Telefono1] varchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,

[Telefono2] varchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,

[FechaActualizacion] date NULL,

[UsuarioActualizacion] varchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,

[Estado] tinyint NOT NULL,

[Tipo] tinyint NOT NULL,

[NombreUsuario] varchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL UNIQUE,

CONSTRAINT [PK__Persona__E9916EC112BC7DDC] PRIMARY KEY ([ID_Persona]) 

)

GO



CREATE TABLE [Reporte] (

[IdReporte] int NOT NULL,

[Fecha] date NULL,

[Metodologia] varchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,

[Observaciones] varchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,

[IdUsuario] int NOT NULL,

[IdCliente] int NOT NULL,

CONSTRAINT [PK__Reporte__F95611366D7F251C] PRIMARY KEY ([IdReporte]) 

)

GO



CREATE TABLE [Resultado_analisis] (

[IdResultadoAnalisis] int NOT NULL,

[IdMuestraAnalisis] int NOT NULL,

[IdReporte] int NOT NULL,

[Estado] tinyint NOT NULL,

[UsuarioCreacion] int NOT NULL,

[FechaCreacion] date NOT NULL,

[UsuarioActualizacion] int NULL,

[FechaActualizacion] date NULL,

CONSTRAINT [PK__Resultad__B07F1E58888EAD77] PRIMARY KEY ([IdResultadoAnalisis]) 

)

GO



CREATE TABLE [Resultado_elemento] (

[IdResultadoElemento] int NOT NULL,

[Nombre] varchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,

[Resultado] varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,

[IdResultadoAnalisis] int NOT NULL,

[UsuarioCreacion] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,

[FechaCracion] date NOT NULL,

[UsuarioModificacion] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,

[FechaModificacion] date NULL,

CONSTRAINT [PK__Resultad__5934520D9D4C47C0] PRIMARY KEY ([IdResultadoElemento]) 

)

GO










ALTER TABLE [Factura] ADD CONSTRAINT [idClienteFactura] FOREIGN KEY ([IdCliente]) REFERENCES [Persona] ([ID_Persona])

GO

ALTER TABLE [Muestra] ADD CONSTRAINT [idClienteMuestra] FOREIGN KEY ([IdCliente]) REFERENCES [Persona] ([ID_Persona])

GO

ALTER TABLE [Muestra_analisis] ADD CONSTRAINT [IdAnalisi] FOREIGN KEY ([IdAnalisis]) REFERENCES [Analisis] ([IdAnalisis])

GO

ALTER TABLE [Muestra_analisis] ADD CONSTRAINT [IdFactura] FOREIGN KEY ([IdFactura]) REFERENCES [Factura] ([IdFactura])

GO

ALTER TABLE [Muestra_analisis] ADD CONSTRAINT [MuestraCodigo] FOREIGN KEY ([Codigo]) REFERENCES [Muestra] ([Codigo])

GO

ALTER TABLE [Reporte] ADD CONSTRAINT [IdCliente] FOREIGN KEY ([IdCliente]) REFERENCES [Persona] ([ID_Persona])

GO

ALTER TABLE [Resultado_analisis] ADD CONSTRAINT [IdMuestraAnalisis] FOREIGN KEY ([IdMuestraAnalisis]) REFERENCES [Muestra_analisis] ([IdMuestraAnalisis])

GO

ALTER TABLE [Resultado_analisis] ADD CONSTRAINT [IdReporte] FOREIGN KEY ([IdReporte]) REFERENCES [Reporte] ([IdReporte])

GO

ALTER TABLE [Resultado_elemento] ADD CONSTRAINT [idResultadoAnalisis] FOREIGN KEY ([IdResultadoAnalisis]) REFERENCES [Resultado_analisis] ([IdResultadoAnalisis])

GO


