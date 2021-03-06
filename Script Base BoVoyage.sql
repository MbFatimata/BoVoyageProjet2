USE [BoVoyage]
GO
/****** Object:  Table [dbo].[AgencesVoyage]    Script Date: 15/06/2018 17:13:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AgencesVoyage](
	[NumeroUniqueAgence] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AgencesVoyage_1] PRIMARY KEY CLUSTERED 
(
	[NumeroUniqueAgence] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 15/06/2018 17:13:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[NumeroUniqueClient] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Civilite] [varchar](10) NOT NULL,
	[Nom] [varchar](50) NOT NULL,
	[Prenom] [varchar](50) NOT NULL,
	[Adresse] [varchar](150) NOT NULL,
	[Telephone] [varchar](20) NOT NULL,
	[DateNaissance] [date] NOT NULL,
	[Age] [int] NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[NumeroUniqueClient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Destinations]    Script Date: 15/06/2018 17:13:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Destinations](
	[NumeroUniqueDestination] [int] IDENTITY(1,1) NOT NULL,
	[Continent] [varchar](50) NOT NULL,
	[Pays] [varchar](50) NOT NULL,
	[Region] [varchar](50) NOT NULL,
	[Description] [varchar](300) NOT NULL,
 CONSTRAINT [PK_Destinations] PRIMARY KEY CLUSTERED 
(
	[NumeroUniqueDestination] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DossiersReservation]    Script Date: 15/06/2018 17:13:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DossiersReservation](
	[NumeroUniqueDossier] [int] IDENTITY(1,1) NOT NULL,
	[NumeroUniqueClient] [int] NOT NULL,
	[NumeroCarteBancaire] [varchar](50) NOT NULL,
	[PrixTotal] [decimal](18, 0) NOT NULL,
	[NumeroUniqueVoyage] [int] NOT NULL,
	[NombreParticipant] [int] NOT NULL,
	[Assurance] [bit] NOT NULL,
 CONSTRAINT [PK_DossiersReservation] PRIMARY KEY CLUSTERED 
(
	[NumeroUniqueDossier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Participants]    Script Date: 15/06/2018 17:13:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Participants](
	[NumeroUniqueParticipant] [int] IDENTITY(1,1) NOT NULL,
	[NumeroUniqueDossier] [int] NOT NULL,
	[Reduction] [decimal](18, 0) NOT NULL,
	[Civilite] [varchar](10) NOT NULL,
	[Nom] [varchar](50) NOT NULL,
	[Prenom] [varchar](50) NOT NULL,
	[Adresse] [varchar](150) NOT NULL,
	[Telephone] [varchar](20) NOT NULL,
	[DateNaissance] [date] NOT NULL,
	[Age] [int] NOT NULL,
 CONSTRAINT [PK_Participants] PRIMARY KEY CLUSTERED 
(
	[NumeroUniqueParticipant] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Voyages]    Script Date: 15/06/2018 17:13:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Voyages](
	[NumeroUniqueVoyage] [int] IDENTITY(1,1) NOT NULL,
	[NumeroUniqueDestination] [int] NOT NULL,
	[NumeroUniqueAgence] [int] NOT NULL,
	[DateAller] [date] NOT NULL,
	[DateRetour] [date] NOT NULL,
	[PlacesDisponibles] [int] NOT NULL,
	[TarifToutCompris] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Voyages] PRIMARY KEY CLUSTERED 
(
	[NumeroUniqueVoyage] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DossiersReservation]  WITH CHECK ADD  CONSTRAINT [FK_DossiersReservation_Clients] FOREIGN KEY([NumeroUniqueClient])
REFERENCES [dbo].[Clients] ([NumeroUniqueClient])
GO
ALTER TABLE [dbo].[DossiersReservation] CHECK CONSTRAINT [FK_DossiersReservation_Clients]
GO
ALTER TABLE [dbo].[DossiersReservation]  WITH CHECK ADD  CONSTRAINT [FK_DossiersReservation_Voyages] FOREIGN KEY([NumeroUniqueVoyage])
REFERENCES [dbo].[Voyages] ([NumeroUniqueVoyage])
GO
ALTER TABLE [dbo].[DossiersReservation] CHECK CONSTRAINT [FK_DossiersReservation_Voyages]
GO
ALTER TABLE [dbo].[Participants]  WITH CHECK ADD  CONSTRAINT [FK_Participants_DossiersReservation] FOREIGN KEY([NumeroUniqueDossier])
REFERENCES [dbo].[DossiersReservation] ([NumeroUniqueDossier])
GO
ALTER TABLE [dbo].[Participants] CHECK CONSTRAINT [FK_Participants_DossiersReservation]
GO
ALTER TABLE [dbo].[Voyages]  WITH CHECK ADD  CONSTRAINT [FK_Voyages_AgencesVoyage] FOREIGN KEY([NumeroUniqueAgence])
REFERENCES [dbo].[AgencesVoyage] ([NumeroUniqueAgence])
GO
ALTER TABLE [dbo].[Voyages] CHECK CONSTRAINT [FK_Voyages_AgencesVoyage]
GO
ALTER TABLE [dbo].[Voyages]  WITH CHECK ADD  CONSTRAINT [FK_Voyages_Destinations] FOREIGN KEY([NumeroUniqueDestination])
REFERENCES [dbo].[Destinations] ([NumeroUniqueDestination])
GO
ALTER TABLE [dbo].[Voyages] CHECK CONSTRAINT [FK_Voyages_Destinations]
GO
