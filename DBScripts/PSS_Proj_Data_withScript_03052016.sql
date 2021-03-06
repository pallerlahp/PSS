USE [PSS]
GO
/****** Object:  Table [dbo].[PSS_Project_Category]    Script Date: 05/03/2016 14:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PSS_Project_Category](
	[proj_category_id] [int] IDENTITY(1,1) NOT NULL,
	[category] [varchar](100) NULL,
	[active] [bit] NULL,
 CONSTRAINT [PK_PSS_Project_Category] PRIMARY KEY CLUSTERED 
(
	[proj_category_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[PSS_Project_Category] ON
INSERT [dbo].[PSS_Project_Category] ([proj_category_id], [category], [active]) VALUES (1, N'class project', 1)
INSERT [dbo].[PSS_Project_Category] ([proj_category_id], [category], [active]) VALUES (2, N'internship', 1)
INSERT [dbo].[PSS_Project_Category] ([proj_category_id], [category], [active]) VALUES (3, N'Innovation Project', 1)
SET IDENTITY_INSERT [dbo].[PSS_Project_Category] OFF
/****** Object:  Table [dbo].[PSS_User_Type]    Script Date: 05/03/2016 14:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PSS_User_Type](
	[user_type_id] [int] IDENTITY(1,1) NOT NULL,
	[type] [varchar](20) NOT NULL,
	[active] [bit] NULL,
 CONSTRAINT [PK_User_Type] PRIMARY KEY CLUSTERED 
(
	[user_type_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[PSS_User_Type] ON
INSERT [dbo].[PSS_User_Type] ([user_type_id], [type], [active]) VALUES (1, N'Admin', 1)
INSERT [dbo].[PSS_User_Type] ([user_type_id], [type], [active]) VALUES (2, N'Student', 1)
INSERT [dbo].[PSS_User_Type] ([user_type_id], [type], [active]) VALUES (3, N'Professors', NULL)
INSERT [dbo].[PSS_User_Type] ([user_type_id], [type], [active]) VALUES (6, N'Director', NULL)
INSERT [dbo].[PSS_User_Type] ([user_type_id], [type], [active]) VALUES (7, N'Coordinator', 1)
INSERT [dbo].[PSS_User_Type] ([user_type_id], [type], [active]) VALUES (8, N'%&&*#', NULL)
SET IDENTITY_INSERT [dbo].[PSS_User_Type] OFF
/****** Object:  Table [dbo].[PSS_Status]    Script Date: 05/03/2016 14:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PSS_Status](
	[status_id] [int] IDENTITY(1,1) NOT NULL,
	[status] [varchar](10) NOT NULL,
	[type] [bit] NULL,
	[active] [bit] NULL,
 CONSTRAINT [PK_Project_Status] PRIMARY KEY CLUSTERED 
(
	[status_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[PSS_Status] ON
INSERT [dbo].[PSS_Status] ([status_id], [status], [type], [active]) VALUES (2, N'Available', 1, 1)
INSERT [dbo].[PSS_Status] ([status_id], [status], [type], [active]) VALUES (3, N'InProgress', 1, 1)
INSERT [dbo].[PSS_Status] ([status_id], [status], [type], [active]) VALUES (4, N'Completed', 1, 1)
INSERT [dbo].[PSS_Status] ([status_id], [status], [type], [active]) VALUES (5, N'Requested', 0, 1)
INSERT [dbo].[PSS_Status] ([status_id], [status], [type], [active]) VALUES (6, N'Aproved', 0, 1)
INSERT [dbo].[PSS_Status] ([status_id], [status], [type], [active]) VALUES (7, N'Rejected', 0, 1)
SET IDENTITY_INSERT [dbo].[PSS_Status] OFF
/****** Object:  Table [dbo].[PSS_Sponsor]    Script Date: 05/03/2016 14:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PSS_Sponsor](
	[sponsor_id] [int] IDENTITY(1,1) NOT NULL,
	[sponsor_name] [varchar](100) NULL,
	[active] [bit] NULL,
 CONSTRAINT [PK_PSS_Sponsor] PRIMARY KEY CLUSTERED 
(
	[sponsor_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[PSS_Sponsor] ON
INSERT [dbo].[PSS_Sponsor] ([sponsor_id], [sponsor_name], [active]) VALUES (1, N'CSI', 1)
INSERT [dbo].[PSS_Sponsor] ([sponsor_id], [sponsor_name], [active]) VALUES (2, N'ECE', 1)
INSERT [dbo].[PSS_Sponsor] ([sponsor_id], [sponsor_name], [active]) VALUES (3, N'ECE', 1)
SET IDENTITY_INSERT [dbo].[PSS_Sponsor] OFF
/****** Object:  Table [dbo].[PSS_Users]    Script Date: 05/03/2016 14:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PSS_Users](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [varchar](50) NULL,
	[last_name] [varchar](50) NULL,
	[email] [varchar](100) NOT NULL,
	[contact] [varchar](20) NULL,
	[user_type_id] [int] NULL,
	[active] [bit] NULL,
 CONSTRAINT [PK_PSS_Users] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[PSS_Users] ON
INSERT [dbo].[PSS_Users] ([user_id], [first_name], [last_name], [email], [contact], [user_type_id], [active]) VALUES (1, N'Srikanth', N'Pallerla', N'pallerla.srikanth1@gmail.com', N'8106396818', 2, 1)
INSERT [dbo].[PSS_Users] ([user_id], [first_name], [last_name], [email], [contact], [user_type_id], [active]) VALUES (2, N'Sridevi', N'Pallerla', N'sreedevirudra@gmail.com', N'9900433433', 2, 1)
INSERT [dbo].[PSS_Users] ([user_id], [first_name], [last_name], [email], [contact], [user_type_id], [active]) VALUES (3, N'BasiReddy', N'Vinuthna', N'vbasireddy@murraystate.edu', N'22533', 1, NULL)
INSERT [dbo].[PSS_Users] ([user_id], [first_name], [last_name], [email], [contact], [user_type_id], [active]) VALUES (4, N'Srikanth', N'Pallerla', N'pallerla.srikanth@gmail.com', N'8106396818', 3, 1)
INSERT [dbo].[PSS_Users] ([user_id], [first_name], [last_name], [email], [contact], [user_type_id], [active]) VALUES (6, N'Vinuthna', N'BasiReddy', N'vbasireddy@murraystate.edu', N'9959368189', 3, 1)
SET IDENTITY_INSERT [dbo].[PSS_Users] OFF
/****** Object:  Table [dbo].[PSS_Projects]    Script Date: 05/03/2016 14:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PSS_Projects](
	[project_id] [int] IDENTITY(1,1) NOT NULL,
	[project_title] [varchar](1000) NOT NULL,
	[description] [text] NULL,
	[proj_category_id] [int] NULL,
	[project_status_id] [int] NULL,
	[extra_details] [text] NULL,
	[sponsor_id] [int] NULL,
	[material_budget] [varchar](100) NULL,
	[preferred_major] [varchar](100) NULL,
	[user_id] [int] NULL,
	[project_created_date] [datetime] NULL,
	[project_selection_closing_date] [datetime] NULL,
	[active] [bit] NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[project_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[PSS_Projects] ON
INSERT [dbo].[PSS_Projects] ([project_id], [project_title], [description], [proj_category_id], [project_status_id], [extra_details], [sponsor_id], [material_budget], [preferred_major], [user_id], [project_created_date], [project_selection_closing_date], [active]) VALUES (1, N'Test', N'test', 1, 2, N'adsad', NULL, N'asdas', N'asdsad', 1, NULL, NULL, NULL)
INSERT [dbo].[PSS_Projects] ([project_id], [project_title], [description], [proj_category_id], [project_status_id], [extra_details], [sponsor_id], [material_budget], [preferred_major], [user_id], [project_created_date], [project_selection_closing_date], [active]) VALUES (2, N'Proj2', N'adada', 3, 2, N'adasd', 1, N'asdsad', N'sadad', 1, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[PSS_Projects] OFF
/****** Object:  Table [dbo].[PSS_Student_Project]    Script Date: 05/03/2016 14:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PSS_Student_Project](
	[project_request_id] [int] IDENTITY(1,1) NOT NULL,
	[student_id] [int] NULL,
	[project_id] [int] NOT NULL,
	[requested_date] [date] NULL,
	[project_request_status_id] [int] NOT NULL,
	[document] [varbinary](max) NULL,
	[file_name] [varchar](50) NULL,
 CONSTRAINT [PK_PSS_Student_Project] PRIMARY KEY CLUSTERED 
(
	[project_request_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[PSS_Student_Project] ON

SET IDENTITY_INSERT [dbo].[PSS_Student_Project] OFF
/****** Object:  ForeignKey [FK_PSS_Users_PSS_User_Type]    Script Date: 05/03/2016 14:34:05 ******/
ALTER TABLE [dbo].[PSS_Users]  WITH CHECK ADD  CONSTRAINT [FK_PSS_Users_PSS_User_Type] FOREIGN KEY([user_type_id])
REFERENCES [dbo].[PSS_User_Type] ([user_type_id])
GO
ALTER TABLE [dbo].[PSS_Users] CHECK CONSTRAINT [FK_PSS_Users_PSS_User_Type]
GO
/****** Object:  ForeignKey [FK_PSS_Projects_PSS_Project_Category]    Script Date: 05/03/2016 14:34:05 ******/
ALTER TABLE [dbo].[PSS_Projects]  WITH CHECK ADD  CONSTRAINT [FK_PSS_Projects_PSS_Project_Category] FOREIGN KEY([proj_category_id])
REFERENCES [dbo].[PSS_Project_Category] ([proj_category_id])
GO
ALTER TABLE [dbo].[PSS_Projects] CHECK CONSTRAINT [FK_PSS_Projects_PSS_Project_Category]
GO
/****** Object:  ForeignKey [FK_PSS_Projects_PSS_Sponsor]    Script Date: 05/03/2016 14:34:05 ******/
ALTER TABLE [dbo].[PSS_Projects]  WITH CHECK ADD  CONSTRAINT [FK_PSS_Projects_PSS_Sponsor] FOREIGN KEY([sponsor_id])
REFERENCES [dbo].[PSS_Sponsor] ([sponsor_id])
GO
ALTER TABLE [dbo].[PSS_Projects] CHECK CONSTRAINT [FK_PSS_Projects_PSS_Sponsor]
GO
/****** Object:  ForeignKey [FK_PSS_Projects_PSS_Status]    Script Date: 05/03/2016 14:34:05 ******/
ALTER TABLE [dbo].[PSS_Projects]  WITH CHECK ADD  CONSTRAINT [FK_PSS_Projects_PSS_Status] FOREIGN KEY([project_status_id])
REFERENCES [dbo].[PSS_Status] ([status_id])
GO
ALTER TABLE [dbo].[PSS_Projects] CHECK CONSTRAINT [FK_PSS_Projects_PSS_Status]
GO
/****** Object:  ForeignKey [FK_PSS_Projects_PSS_Users]    Script Date: 05/03/2016 14:34:05 ******/
ALTER TABLE [dbo].[PSS_Projects]  WITH CHECK ADD  CONSTRAINT [FK_PSS_Projects_PSS_Users] FOREIGN KEY([user_id])
REFERENCES [dbo].[PSS_Users] ([user_id])
GO
ALTER TABLE [dbo].[PSS_Projects] CHECK CONSTRAINT [FK_PSS_Projects_PSS_Users]
GO
/****** Object:  ForeignKey [FK_PSS_Student_Project_PSS_Projects]    Script Date: 05/03/2016 14:34:05 ******/
ALTER TABLE [dbo].[PSS_Student_Project]  WITH CHECK ADD  CONSTRAINT [FK_PSS_Student_Project_PSS_Projects] FOREIGN KEY([project_id])
REFERENCES [dbo].[PSS_Projects] ([project_id])
GO
ALTER TABLE [dbo].[PSS_Student_Project] CHECK CONSTRAINT [FK_PSS_Student_Project_PSS_Projects]
GO
/****** Object:  ForeignKey [FK_PSS_Student_Project_PSS_Status]    Script Date: 05/03/2016 14:34:05 ******/
ALTER TABLE [dbo].[PSS_Student_Project]  WITH CHECK ADD  CONSTRAINT [FK_PSS_Student_Project_PSS_Status] FOREIGN KEY([project_request_status_id])
REFERENCES [dbo].[PSS_Status] ([status_id])
GO
ALTER TABLE [dbo].[PSS_Student_Project] CHECK CONSTRAINT [FK_PSS_Student_Project_PSS_Status]
GO
/****** Object:  ForeignKey [FK_PSS_Student_Project_PSS_Users]    Script Date: 05/03/2016 14:34:05 ******/
ALTER TABLE [dbo].[PSS_Student_Project]  WITH CHECK ADD  CONSTRAINT [FK_PSS_Student_Project_PSS_Users] FOREIGN KEY([student_id])
REFERENCES [dbo].[PSS_Users] ([user_id])
GO
ALTER TABLE [dbo].[PSS_Student_Project] CHECK CONSTRAINT [FK_PSS_Student_Project_PSS_Users]
GO
