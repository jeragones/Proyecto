USE [master]
GO
/****** Object:  Database [AGRONOMICOSDB]    Script Date: 12/10/2014 8:53:53 PM ******/
CREATE DATABASE [AGRONOMICOSDB]

USE [AGRONOMICOSDB]
GO
/****** Object:  Table [dbo].[Analisis]    Script Date: 12/10/2014 8:53:53 PM ******/

CREATE TABLE [dbo].[Analisis](
	[IdAnalisis] [int] identity(1,1) primary key,
	[Nombre] [varchar](30) NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[Costo] [money] NOT NULL,
	[Descripcion] [varchar](50) NULL
 )

GO
/****** Object:  Table [dbo].[Analisis_Dato]    Script Date: 12/10/2014 8:53:53 PM ******/
CREATE TABLE [dbo].[Analisis_Dato](
	[IdAnalisisDato] [int] IDENTITY(1,1) PRIMARY KEY,
	[IdAnalisis] [int] NOT NULL,
	[IdDato] [int] NOT NULL
)

GO
CREATE TABLE [dbo].[Canton](
	[ID_Canton] [int] IDENTITY(1,1) NOT NULL,
	[ID_Provincia] [int] NOT NULL,
	[nombre] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Canton] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
CREATE TABLE [dbo].[Distrito](
	[ID_Distrito] [int] IDENTITY(1,1) NOT NULL,
	[ID_Canton] [int] NOT NULL,
	[nombre] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Distrito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 12/10/2014 8:53:53 PM ******/
CREATE TABLE [dbo].[Categoria](
	[IdCategoria] [int] IDENTITY(1,1) primary key,
	[Nombre] [varchar](30) NOT NULL
	)
GO

/****** Object:  Table [dbo].[Dato]    Script Date: 12/10/2014 8:53:53 PM ******/
CREATE TABLE [dbo].[Dato](
	[IdDato] [int] identity(1,1)Primary key,
	[Nombre] [nchar](10) NOT NULL,
	[unidadMedida] [varchar](20)NOT NULL
) 
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 12/10/2014 8:53:53 PM ******/
CREATE TABLE [dbo].[Factura](
	[IdFactura] [int] identity(1,1) primary key,
	[Fecha] [date] NOT NULL,
	[Costo] [money] NOT NULL,
	[IdPersona] [int] NOT NULL
 )
GO
/****** Object:  Table [dbo].[Muestra]    Script Date: 12/10/2014 8:53:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Muestra](
	[Codigo] [varchar](20) NOT NULL,
	[Campo] [varchar](40) NOT NULL,
	[IdPersona] [int] NOT NULL,
	[Provincia] [int] NOT NULL,
	[Canton] [int] NOT NULL,
	[Distrito] [int] NOT NULL,
	[Direccion] [varchar](25) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Muestra_Analisis]    Script Date: 12/10/2014 8:53:53 PM ******/
CREATE TABLE [dbo].[Muestra_Analisis](
	[IdMuestraAnalisis] [int] identity(1,1) primary key,
	[Nombre] [varchar](30) NOT NULL,
	[Costo] [money] NOT NULL,
	[Codigo] [varchar](20) NOT NULL,
	[IdFactura] [int] NOT NULL,
	[IdAnalisis] [int] NOT NULL,
	[Estado] [tinyint] NOT NULL
)
GO

CREATE TABLE [dbo].[Provincia](
	[ID_Provincia] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Provincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persona]    Script Date: 12/10/2014 8:53:53 PM ******/
CREATE TABLE [dbo].[Persona](
	[ID_Persona] [int] IDENTITY(1,1) primary key,
	[Nombre] [varchar](25) NOT NULL,
	[Apellido1] [varchar](25) NOT NULL,
	[Apellido2] [varchar](25) NOT NULL,
	[Correo] [varchar](40) NOT NULL,
	[Clave] [varchar](25) NOT NULL,
	[Telefono1] [varchar](8) NULL,
	[Telefono2] [varchar](8) NULL,
	[Estado] [tinyint] NOT NULL,
	[Tipo] [tinyint] NOT NULL,
	[NombreUsuario] [varchar](25) UNIQUE NOT NULL,
	[PasswordChange] [bit] NOT NULL
)

GO
--Drop Table Reporte
/****** Object:  Table [dbo].[Reporte]    Script Date: 12/10/2014 8:53:53 PM ******/
CREATE TABLE [dbo].[Reporte](
	[IdReporte] [int] identity(1,1) primary key,
	[Fecha] [date] NULL,
	[Metodologia] [varchar](50) NOT NULL,
	[Observaciones] [varchar](50) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdCliente] [int] NOT NULL
)

GO
/****** Object:  Table [dbo].[Resultado_Analisis]    Script Date: 12/10/2014 8:53:53 PM ******/
CREATE TABLE [dbo].[Resultado_Analisis](
	[IdResultadoAnalisis] [int] identity(1,1)primary key,
	[IdMuestraAnalisis] [int] NOT NULL,
	[IdReporte] [int] NOT NULL,
	[Estado] [tinyint] NOT NULL
)

GO
/****** Object:  Table [dbo].[Resultado_Dato]    Script Date: 12/10/2014 8:53:53 PM ******/

CREATE TABLE [dbo].[Resultado_Dato](
	[IdResultadoDato] [int] identity(1,1) primary key,
	[IdDato] [int] NOT NULL,
	[Resultado] [varchar](30) NOT NULL,
	[IdResultadoAnalisis] [int] NOT NULL
)


ALTER TABLE [dbo].[Analisis]  WITH CHECK ADD FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([IdCategoria])
GO
ALTER TABLE [dbo].[Analisis_Dato]  WITH CHECK ADD  CONSTRAINT [FK_Analisis_Dato_Analisis] FOREIGN KEY([IdAnalisis])
REFERENCES [dbo].[Analisis] ([IdAnalisis])
GO
/*ALTER TABLE [dbo].[Analisis_Dato] CHECK CONSTRAINT [FK_Analisis_Dato_Analisis]
GO
ALTER TABLE [dbo].[Analisis_Dato]  WITH CHECK ADD  CONSTRAINT [FK_Analisis_Dato_Dato] FOREIGN KEY([IdDato])
REFERENCES [dbo].[Dato] ([IdDato])
GO
ALTER TABLE [dbo].[Analisis_Dato] CHECK CONSTRAINT [FK_Analisis_Dato_Dato]
GO*/
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [idClienteFactura] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[Persona] ([ID_Persona])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [idClienteFactura]
GO
ALTER TABLE [dbo].[Muestra]  WITH CHECK ADD  CONSTRAINT [idClienteMuestra] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[Persona] ([ID_Persona])
GO
ALTER TABLE [dbo].[Muestra] CHECK CONSTRAINT [idClienteMuestra]
GO
ALTER TABLE [dbo].[Muestra_Analisis]  WITH CHECK ADD  CONSTRAINT [IdAnalisi] FOREIGN KEY([IdAnalisis])
REFERENCES [dbo].[Analisis] ([IdAnalisis])
GO
ALTER TABLE [dbo].[Muestra_Analisis] CHECK CONSTRAINT [IdAnalisi]
GO
ALTER TABLE [dbo].[Muestra_Analisis]  WITH CHECK ADD  CONSTRAINT [IdFactura] FOREIGN KEY([IdFactura])
REFERENCES [dbo].[Factura] ([IdFactura])
GO
ALTER TABLE [dbo].[Muestra_Analisis] CHECK CONSTRAINT [IdFactura]
GO
ALTER TABLE [dbo].[Muestra_Analisis]  WITH CHECK ADD  CONSTRAINT [MuestraCodigo] FOREIGN KEY([Codigo])
REFERENCES [dbo].[Muestra] ([Codigo])
GO
ALTER TABLE [dbo].[Muestra_Analisis] CHECK CONSTRAINT [MuestraCodigo]
GO
ALTER TABLE [dbo].[Reporte]  WITH CHECK ADD  CONSTRAINT [IdCliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Persona] ([ID_Persona])
GO
ALTER TABLE [dbo].[Reporte] CHECK CONSTRAINT [IdCliente]
GO
ALTER TABLE [dbo].[Resultado_Analisis]  WITH CHECK ADD  CONSTRAINT [IdMuestraAnalisis] FOREIGN KEY([IdMuestraAnalisis])
REFERENCES [dbo].[Muestra_Analisis] ([IdMuestraAnalisis])
GO
ALTER TABLE [dbo].[Resultado_Analisis] CHECK CONSTRAINT [IdMuestraAnalisis]
GO
/*ALTER TABLE [dbo].[Resultado_Analisis]  WITH CHECK ADD  CONSTRAINT [IdReporte] FOREIGN KEY([IdReporte])
REFERENCES [dbo].[Reporte] ([IdReporte])
GO
ALTER TABLE [dbo].[Resultado_Analisis] CHECK CONSTRAINT [IdReporte]
GO*/
ALTER TABLE [dbo].[Resultado_Dato]  WITH CHECK ADD  CONSTRAINT [FK_Resultado_Dato_Dato] FOREIGN KEY([IdDato])
REFERENCES [dbo].[Dato] ([IdDato])
GO
ALTER TABLE [dbo].[Resultado_Dato] CHECK CONSTRAINT [FK_Resultado_Dato_Dato]
GO
ALTER TABLE [dbo].[Resultado_Dato]  WITH CHECK ADD  CONSTRAINT [idResultadoAnalisis] FOREIGN KEY([IdResultadoAnalisis])
REFERENCES [dbo].[Resultado_Analisis] ([IdResultadoAnalisis])
GO
ALTER TABLE [dbo].[Resultado_Dato] CHECK CONSTRAINT [idResultadoAnalisis]
GO
ALTER TABLE [dbo].[Canton]  WITH CHECK ADD  CONSTRAINT [FK_Provincia] FOREIGN KEY([ID_Provincia])
REFERENCES [dbo].[Provincia] ([ID_Provincia])
GO
ALTER TABLE [dbo].[Canton] CHECK CONSTRAINT [FK_Provincia]
GO
ALTER TABLE [dbo].[Distrito]  WITH CHECK ADD  CONSTRAINT [FK_Canton] FOREIGN KEY([ID_Canton])
REFERENCES [dbo].[Canton] ([ID_Canton])
GO
ALTER TABLE [dbo].[Distrito] CHECK CONSTRAINT [FK_Canton]
GO
ALTER TABLE [dbo].[Muestra]  WITH CHECK ADD  CONSTRAINT [FK_Provincias] FOREIGN KEY([Provincia])
REFERENCES [dbo].[Provincia] ([ID_Provincia])
GO
ALTER TABLE [dbo].[Muestra] CHECK CONSTRAINT [FK_Provincias]
/*
GO
ALTER TABLE [dbo].[Muestra]  WITH CHECK ADD  CONSTRAINT [idClienteMuestra] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[Persona] ([ID_Persona])
*/
GO
ALTER DATABASE [AGRONOMICOSDB] SET  READ_WRITE 
GO

Insert into Persona(Nombre,Apellido1,Apellido2,NombreUsuario,Correo,Clave,Tipo,Estado,PasswordChange) values('SUADMIN','SUADMIN','SUADMIN','SUADMIN','su@admin.com','12345',0,0,0)