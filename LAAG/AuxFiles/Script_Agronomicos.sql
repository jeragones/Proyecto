USE [master]
GO
/****** Object:  Database [AGRONOMICOSDB]    Script Date: 28/09/2014 11:25:17 a.m. ******/
CREATE DATABASE [AGRONOMICOSDB]
GO
USE [AGRONOMICOSDB]
GO
CREATE TABLE [dbo].[Analisis](
	[IdAnalisis] [int] NOT NULL,
	[Nombre] [varchar](30) NOT NULL,
	[id_Categoria] [int] NOT NULL,
	[Descripcion] [varchar](50) NULL,
	[UsuarioCreacion] [varchar](20) NOT NULL,
	[FechaCreacion] [date] NOT NULL,
	[UsuarioActualizacion] [varchar](20) NULL,
	[FechaActualizacion] [date] NULL,
 CONSTRAINT [PK__Analisis__EFD67EA6AB5CA0F7] PRIMARY KEY CLUSTERED 
(
	[IdAnalisis] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 28/09/2014 11:25:17 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Factura](
	[IdFactura] [int] NOT NULL,
	[Fecha] [date] NOT NULL,
	[Costo] [int] NOT NULL,
	[IdCliente] [int] NOT NULL,
	[UsuarioCreacion] [varchar](20) NOT NULL,
	[FechaCreacion] [date] NOT NULL,
	[UsuarioActualizacion] [varchar](20) NULL,
	[FechaActualizacion] [date] NULL,
 CONSTRAINT [PK__Factura__50E7BAF19CB964D0] PRIMARY KEY CLUSTERED 
(
	[IdFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Muestra]    Script Date: 28/09/2014 11:25:17 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Muestra](
	[Codigo] [varchar](20) NOT NULL,
	[Campo] [varchar](40) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[Provincia] [varchar](10) NOT NULL,
	[Canton] [varchar](20) NOT NULL,
	[Distrito] [varchar](25) NOT NULL,
	[Direccion] [varchar](25) NOT NULL,
	[UsuarioCracion] [varchar](20) NOT NULL,
	[FechaCreacion] [date] NOT NULL,
	[UsuarioActualizacion] [varchar](20) NULL,
	[FechaActualizacion] [date] NULL,
 CONSTRAINT [PK__Muestra__06370DAD588A101A] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Muestra_analisis]    Script Date: 28/09/2014 11:25:17 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Muestra_analisis](
	[IdMuestraAnalisis] [int] NOT NULL,
	[Nombre] [varchar](30) NOT NULL,
	[Costo] [int] NOT NULL,
	[Codigo] [varchar](20) NOT NULL,
	[IdFactura] [int] NOT NULL,
	[IdAnalisis] [int] NOT NULL,
	[Estado] [tinyint] NOT NULL,
	[UsuarioCreacion] [varchar](20) NOT NULL,
	[FechaCreacion] [date] NOT NULL,
	[UsuarioActualizacion] [varchar](20) NULL,
	[FechaActualizacion] [date] NULL,
 CONSTRAINT [PK__Muestra___87760CC557EB1FBB] PRIMARY KEY CLUSTERED 
(
	[IdMuestraAnalisis] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 28/09/2014 11:25:17 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Persona](
	[ID_Persona] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](25) NOT NULL,
	[Apellido1] [varchar](25) NOT NULL,
	[Apellido2] [varchar](25) NOT NULL,
	[Correo] [varchar](40) NOT NULL,
	[Clave] [varchar](25) NOT NULL,
	[FechaCreacion] [date] NULL,
	[Telefono1] [varchar](8) NULL,
	[Telefono2] [varchar](8) NULL,
	[UsuarioCreacion] [varchar](25) NULL,
	[FechaActualizacion] [date] NULL,
	[UsuarioActualizacion] [varchar](25) NULL,
	[Estado] [tinyint] NOT NULL,
	[Tipo] [tinyint] NOT NULL,
	[NombreUsuario] [varchar](25) NOT NULL,
	[PasswordChange] [bit] NOT NULL,
 CONSTRAINT [PK__Persona__E9916EC112BC7DDC] PRIMARY KEY CLUSTERED 
(
	[ID_Persona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[NombreUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Reporte]    Script Date: 28/09/2014 11:25:17 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Reporte](
	[IdReporte] [int] NOT NULL,
	[Fecha] [date] NULL,
	[Metodologia] [varchar](1) NOT NULL,
	[Observaciones] [varchar](1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdCliente] [int] NOT NULL,
 CONSTRAINT [PK__Reporte__F95611366D7F251C] PRIMARY KEY CLUSTERED 
(
	[IdReporte] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Resultado_analisis]    Script Date: 28/09/2014 11:25:17 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[idCategoria][int] IDENTITY(1,1) PRIMARY KEY,
	[Nombre][varchar](30) NOT NULL
)
GO
ALTER TABLE [dbo].[Analisis] ADD FOREIGN KEY (id_Categoria) REFERENCES Categorias(idCategoria)
GO
CREATE TABLE [dbo].[Resultado_analisis](
	[IdResultadoAnalisis] [int] NOT NULL,
	[IdMuestraAnalisis] [int] NOT NULL,
	[IdReporte] [int] NOT NULL,
	[Estado] [tinyint] NOT NULL,
	[UsuarioCreacion] [int] NOT NULL,
	[FechaCreacion] [date] NOT NULL,
	[UsuarioActualizacion] [int] NULL,
	[FechaActualizacion] [date] NULL,
 CONSTRAINT [PK__Resultad__B07F1E58888EAD77] PRIMARY KEY CLUSTERED 
(
	[IdResultadoAnalisis] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Resultado_elemento]    Script Date: 28/09/2014 11:25:17 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Resultado_elemento](
	[IdResultadoElemento] [int] NOT NULL,
	[Nombre] [varchar](25) NOT NULL,
	[Resultado] [varchar](30) NOT NULL,
	[IdResultadoAnalisis] [int] NOT NULL,
	[UsuarioCreacion] [varchar](20) NOT NULL,
	[FechaCracion] [date] NOT NULL,
	[UsuarioModificacion] [varchar](20) NULL,
	[FechaModificacion] [date] NULL,
 CONSTRAINT [PK__Resultad__5934520D9D4C47C0] PRIMARY KEY CLUSTERED 
(
	[IdResultadoElemento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [idClienteFactura] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Persona] ([ID_Persona])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [idClienteFactura]
GO
ALTER TABLE [dbo].[Muestra]  WITH CHECK ADD  CONSTRAINT [idClienteMuestra] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Persona] ([ID_Persona])
GO
ALTER TABLE [dbo].[Muestra] CHECK CONSTRAINT [idClienteMuestra]
GO
ALTER TABLE [dbo].[Muestra_analisis]  WITH CHECK ADD  CONSTRAINT [IdAnalisi] FOREIGN KEY([IdAnalisis])
REFERENCES [dbo].[Analisis] ([IdAnalisis])
GO
ALTER TABLE [dbo].[Muestra_analisis] CHECK CONSTRAINT [IdAnalisi]
GO
ALTER TABLE [dbo].[Muestra_analisis]  WITH CHECK ADD  CONSTRAINT [IdFactura] FOREIGN KEY([IdFactura])
REFERENCES [dbo].[Factura] ([IdFactura])
GO
ALTER TABLE [dbo].[Muestra_analisis] CHECK CONSTRAINT [IdFactura]
GO
ALTER TABLE [dbo].[Muestra_analisis]  WITH CHECK ADD  CONSTRAINT [MuestraCodigo] FOREIGN KEY([Codigo])
REFERENCES [dbo].[Muestra] ([Codigo])
GO
ALTER TABLE [dbo].[Muestra_analisis] CHECK CONSTRAINT [MuestraCodigo]
GO
ALTER TABLE [dbo].[Reporte]  WITH CHECK ADD  CONSTRAINT [IdCliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Persona] ([ID_Persona])
GO
ALTER TABLE [dbo].[Reporte] CHECK CONSTRAINT [IdCliente]
GO
ALTER TABLE [dbo].[Resultado_analisis]  WITH CHECK ADD  CONSTRAINT [IdMuestraAnalisis] FOREIGN KEY([IdMuestraAnalisis])
REFERENCES [dbo].[Muestra_analisis] ([IdMuestraAnalisis])
GO
ALTER TABLE [dbo].[Resultado_analisis] CHECK CONSTRAINT [IdMuestraAnalisis]
GO
ALTER TABLE [dbo].[Resultado_analisis]  WITH CHECK ADD  CONSTRAINT [IdReporte] FOREIGN KEY([IdReporte])
REFERENCES [dbo].[Reporte] ([IdReporte])
GO
ALTER TABLE [dbo].[Resultado_analisis] CHECK CONSTRAINT [IdReporte]
GO
ALTER TABLE [dbo].[Resultado_elemento]  WITH CHECK ADD  CONSTRAINT [idResultadoAnalisis] FOREIGN KEY([IdResultadoAnalisis])
REFERENCES [dbo].[Resultado_analisis] ([IdResultadoAnalisis])
GO
ALTER TABLE [dbo].[Resultado_elemento] CHECK CONSTRAINT [idResultadoAnalisis]
GO
USE [master]
GO
ALTER DATABASE [AGRONOMICOSDB] SET  READ_WRITE 
GO
