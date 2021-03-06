USE [AlignDB]
GO
/****** Object:  Table [dbo].[AgentMission]    Script Date: 21/11/2021 13:10:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AgentMission](
	[AgentId] [bigint] IDENTITY(1,1) NOT NULL,
	[Agent] [nvarchar](50) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Lat] [float] NOT NULL,
	[Lon] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AgentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AgentMission] ON 

INSERT [dbo].[AgentMission] ([AgentId], [Agent], [Country], [Address], [Date], [Lat], [Lon]) VALUES (1, N'007', N'Brazil', N'Avenida Vieira Souto 168 Ipanema, Rio de Janeiro', CAST(N'2021-11-19T01:29:45.093' AS DateTime), -22.98656, -43.19905)
INSERT [dbo].[AgentMission] ([AgentId], [Agent], [Country], [Address], [Date], [Lat], [Lon]) VALUES (2, N'005', N'Poland', N'Rynek Glowny 12, Krakow', CAST(N'2021-11-19T01:30:26.720' AS DateTime), 50.06048, 19.93789)
INSERT [dbo].[AgentMission] ([AgentId], [Agent], [Country], [Address], [Date], [Lat], [Lon]) VALUES (3, N'007', N'Morocco', N'27 Derb Lferrane, Marrakech', CAST(N'2021-11-19T01:31:26.137' AS DateTime), 31.62834, -7.98339)
INSERT [dbo].[AgentMission] ([AgentId], [Agent], [Country], [Address], [Date], [Lat], [Lon]) VALUES (4, N'005', N'Brazil', N'Rua Roberto Simonsen 122, Sao Paulo', CAST(N'2021-11-19T01:31:52.667' AS DateTime), -23.54867, -46.63193)
INSERT [dbo].[AgentMission] ([AgentId], [Agent], [Country], [Address], [Date], [Lat], [Lon]) VALUES (5, N'011', N'Poland', N'swietego Tomasza 35, Krakow', CAST(N'2021-11-19T01:32:17.300' AS DateTime), 50.06196, 19.94243)
INSERT [dbo].[AgentMission] ([AgentId], [Agent], [Country], [Address], [Date], [Lat], [Lon]) VALUES (6, N'003', N'Morocco', N'Rue Al-Aidi Ali Al-Maaroufi, Casablanca', CAST(N'2021-11-19T01:33:06.640' AS DateTime), 33.60165, -7.6198)
INSERT [dbo].[AgentMission] ([AgentId], [Agent], [Country], [Address], [Date], [Lat], [Lon]) VALUES (7, N'008', N'Brazil', N'Rua tamoana 418, tefe', CAST(N'2021-11-19T01:33:29.170' AS DateTime), -3.36077, -64.72167)
INSERT [dbo].[AgentMission] ([AgentId], [Agent], [Country], [Address], [Date], [Lat], [Lon]) VALUES (8, N'013', N'Poland', N'Zlota 9, Lublin', CAST(N'2021-11-19T01:33:54.883' AS DateTime), 51.24764, 22.56981)
INSERT [dbo].[AgentMission] ([AgentId], [Agent], [Country], [Address], [Date], [Lat], [Lon]) VALUES (9, N'002', N'Morocco', N'Riad Sultan 19, Tangier', CAST(N'2021-11-19T01:34:15.927' AS DateTime), 35.78901, -5.81329)
INSERT [dbo].[AgentMission] ([AgentId], [Agent], [Country], [Address], [Date], [Lat], [Lon]) VALUES (10, N'009', N'Morocco', N'atlas marina beach, agadir', CAST(N'2021-11-19T01:34:47.530' AS DateTime), 30.42673, -9.58648)
SET IDENTITY_INSERT [dbo].[AgentMission] OFF
GO
ALTER TABLE [dbo].[AgentMission] ADD  DEFAULT (getdate()) FOR [Date]
GO
