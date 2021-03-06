USE [band_tracker]
GO
/****** Object:  Table [dbo].[bands]    Script Date: 3/3/2017 4:34:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bands](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[bands_venues]    Script Date: 3/3/2017 4:34:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bands_venues](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[band_id] [int] NULL,
	[venue_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[venues]    Script Date: 3/3/2017 4:34:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[venues](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[bands] ON 

INSERT [dbo].[bands] ([id], [name]) VALUES (1, N'Pajama Funnel')
INSERT [dbo].[bands] ([id], [name]) VALUES (2, N'Allergy to Warm')
INSERT [dbo].[bands] ([id], [name]) VALUES (3, N'Upcoming Friendship and the Liar')
INSERT [dbo].[bands] ([id], [name]) VALUES (4, N'Nylon Unison')
INSERT [dbo].[bands] ([id], [name]) VALUES (5, N'Dangerous Sincerity')
INSERT [dbo].[bands] ([id], [name]) VALUES (6, N'Velvet of Mirage')
INSERT [dbo].[bands] ([id], [name]) VALUES (7, N'Best Stillness')
INSERT [dbo].[bands] ([id], [name]) VALUES (8, N'Chihuahua of the Juke')
INSERT [dbo].[bands] ([id], [name]) VALUES (9, N'Offbeat Turmoil')
INSERT [dbo].[bands] ([id], [name]) VALUES (10, N'Correctional Interest')
INSERT [dbo].[bands] ([id], [name]) VALUES (11, N'Cool Emu and the Figurine')
INSERT [dbo].[bands] ([id], [name]) VALUES (12, N'Illustration of Intuitive')
INSERT [dbo].[bands] ([id], [name]) VALUES (13, N'Experimental Gangster')
INSERT [dbo].[bands] ([id], [name]) VALUES (14, N'Organic Monk')
INSERT [dbo].[bands] ([id], [name]) VALUES (15, N'Asylum Pad')
SET IDENTITY_INSERT [dbo].[bands] OFF
SET IDENTITY_INSERT [dbo].[bands_venues] ON 

INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (1, 5, 4)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (2, 5, 4)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (3, 2, 4)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (4, 7, 4)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (5, 2, 14)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (6, 2, 5)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (7, 10, 14)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (8, 2, 6)
SET IDENTITY_INSERT [dbo].[bands_venues] OFF
SET IDENTITY_INSERT [dbo].[venues] ON 

INSERT [dbo].[venues] ([id], [name]) VALUES (1, N'The Station')
INSERT [dbo].[venues] ([id], [name]) VALUES (2, N'H20')
INSERT [dbo].[venues] ([id], [name]) VALUES (3, N'Club Fiber')
INSERT [dbo].[venues] ([id], [name]) VALUES (4, N'Aquafire Lounge')
INSERT [dbo].[venues] ([id], [name]) VALUES (5, N'Cabooze Tavern')
INSERT [dbo].[venues] ([id], [name]) VALUES (6, N'Bindywald''s')
INSERT [dbo].[venues] ([id], [name]) VALUES (7, N'Foam')
INSERT [dbo].[venues] ([id], [name]) VALUES (8, N'Claret')
INSERT [dbo].[venues] ([id], [name]) VALUES (9, N'Fuzzy Logic')
INSERT [dbo].[venues] ([id], [name]) VALUES (10, N'Lillypot')
INSERT [dbo].[venues] ([id], [name]) VALUES (11, N'Cafe Flow')
INSERT [dbo].[venues] ([id], [name]) VALUES (12, N'Nana Banana Lounge')
INSERT [dbo].[venues] ([id], [name]) VALUES (13, N'Nos')
INSERT [dbo].[venues] ([id], [name]) VALUES (14, N'The Bandwidth Bar')
INSERT [dbo].[venues] ([id], [name]) VALUES (15, N'Club Naivete')
SET IDENTITY_INSERT [dbo].[venues] OFF
