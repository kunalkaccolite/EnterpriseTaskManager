USE [EventDB]
GO

/****** Object:  Table [dbo].[EventAction]    Script Date: 7/19/2017 8:43:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE [dbo].[Users](
	[UserId] [int] NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Roles](
	[RoleId] [int] NOT NULL,
	[RoleDescription] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[UserID_RoleID_Mappings](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_UserID_RoleID_Mappings] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[UserID_RoleID_Mappings]  WITH CHECK ADD  CONSTRAINT [FK_UserId_RoleID_Mappings_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[UserID_RoleID_Mappings] CHECK CONSTRAINT [FK_UserId_RoleID_Mappings_Roles]
GO

ALTER TABLE [dbo].[UserID_RoleID_Mappings]  WITH CHECK ADD  CONSTRAINT [FK_UserId_RoleID_Mappings_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[UserID_RoleID_Mappings] CHECK CONSTRAINT [FK_UserId_RoleID_Mappings_Users]
GO




CREATE TABLE [dbo].[EventType](
	[EventTypeID] [int] NOT NULL,
	[EventTypeDescription] [varchar](50) NULL,
	[InputTypeObject] [varchar](max) NULL,
	[OutputObjectType] [varchar](max) NULL,
 CONSTRAINT [PK_EventType] PRIMARY KEY CLUSTERED 
(
	[EventTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO






CREATE TABLE [dbo].[EventAction](
	[EventTypeID] [int] NOT NULL,
	[ActionType] [varchar](50) NOT NULL,
	[TargetURL] [varchar](max) NULL,
	[TargetInputObjectType] [varchar](max) NULL,
 CONSTRAINT [PK_EventAction] PRIMARY KEY CLUSTERED 
(
	[EventTypeID] ASC,
	[ActionType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[EventAction]  WITH CHECK ADD  CONSTRAINT [FK_EventAction_EventType] FOREIGN KEY([EventTypeID])
REFERENCES [dbo].[EventType] ([EventTypeID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[EventAction] CHECK CONSTRAINT [FK_EventAction_EventType]
GO


CREATE TABLE [dbo].[EventTransaction](
	[EventTransactionID] [int] NOT NULL,
	[EventTypeID] [int] NOT NULL,
	[ObjectData] [varchar](max) NULL,
	[ObjectKey] [varchar](50) NULL,
	[IsResolved] [varchar](10) NULL,
	[ResolvedBy] [varchar](50) NULL,
 CONSTRAINT [PK_EventTransaction] PRIMARY KEY CLUSTERED 
(
	[EventTransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[EventTransaction]  WITH CHECK ADD  CONSTRAINT [FK_EventTransaction_EventType] FOREIGN KEY([EventTypeID])
REFERENCES [dbo].[EventType] ([EventTypeID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[EventTransaction] CHECK CONSTRAINT [FK_EventTransaction_EventType]
GO


CREATE TABLE [dbo].[RoleEventTypeMappings](
	[RoleID] [int] NOT NULL,
	[EventTypeID] [int] NOT NULL,
 CONSTRAINT [PK_RoleEventTypeMappings] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC,
	[EventTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[RoleEventTypeMappings]  WITH CHECK ADD  CONSTRAINT [FK_RoleEventTypeMappings_EventType] FOREIGN KEY([EventTypeID])
REFERENCES [dbo].[EventType] ([EventTypeID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[RoleEventTypeMappings] CHECK CONSTRAINT [FK_RoleEventTypeMappings_EventType]
GO

ALTER TABLE [dbo].[RoleEventTypeMappings]  WITH CHECK ADD  CONSTRAINT [FK_RoleEventTypeMappings_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[RoleEventTypeMappings] CHECK CONSTRAINT [FK_RoleEventTypeMappings_Roles]
GO