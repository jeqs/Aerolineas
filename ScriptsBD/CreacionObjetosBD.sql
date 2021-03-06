USE [Aerolineas]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerItinerario]    Script Date: 11/02/2021 7:51:13 p. m. ******/
DROP PROCEDURE [dbo].[ObtenerItinerario]
GO
ALTER TABLE [dbo].[Itinerario] DROP CONSTRAINT [FK_Itinerario_Ciudad]
GO
ALTER TABLE [dbo].[Itinerario] DROP CONSTRAINT [FK_Itinerario_Avion]
GO
/****** Object:  Table [dbo].[Itinerario]    Script Date: 11/02/2021 7:51:13 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Itinerario]') AND type in (N'U'))
DROP TABLE [dbo].[Itinerario]
GO
/****** Object:  Table [dbo].[Ciudad]    Script Date: 11/02/2021 7:51:13 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Ciudad]') AND type in (N'U'))
DROP TABLE [dbo].[Ciudad]
GO
/****** Object:  Table [dbo].[Avion]    Script Date: 11/02/2021 7:51:13 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Avion]') AND type in (N'U'))
DROP TABLE [dbo].[Avion]
GO
/****** Object:  Table [dbo].[Avion]    Script Date: 11/02/2021 7:51:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Avion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nomre] [varchar](256) NULL,
 CONSTRAINT [PK_Avion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ciudad]    Script Date: 11/02/2021 7:51:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciudad](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](256) NULL,
 CONSTRAINT [PK_Ciudad] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Itinerario]    Script Date: 11/02/2021 7:51:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Itinerario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdAvion] [int] NULL,
	[IdCiudad] [int] NULL,
	[HorasVuelo] [decimal](6, 2) NULL,
 CONSTRAINT [PK_Itinerario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Itinerario]  WITH CHECK ADD  CONSTRAINT [FK_Itinerario_Avion] FOREIGN KEY([IdAvion])
REFERENCES [dbo].[Avion] ([Id])
GO
ALTER TABLE [dbo].[Itinerario] CHECK CONSTRAINT [FK_Itinerario_Avion]
GO
ALTER TABLE [dbo].[Itinerario]  WITH CHECK ADD  CONSTRAINT [FK_Itinerario_Ciudad] FOREIGN KEY([IdCiudad])
REFERENCES [dbo].[Ciudad] ([Id])
GO
ALTER TABLE [dbo].[Itinerario] CHECK CONSTRAINT [FK_Itinerario_Ciudad]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerItinerario]    Script Date: 11/02/2021 7:51:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerItinerario]
AS
BEGIN
	Select 
	Itinerario.Id,
	Itinerario.IdAvion,
	Avion.Nomre,
	Itinerario.IdCiudad,
	Ciudad.Nombre,
	Itinerario.HorasVuelo
	From Itinerario 
	Left Join Avion on Avion.Id = Itinerario.IdAvion
	Left Join Ciudad on Ciudad.Id = Itinerario.IdCiudad
END
GO
