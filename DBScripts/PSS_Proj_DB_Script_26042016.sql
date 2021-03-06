USE [PSS]
GO
/****** Object:  Table [dbo].[PSS_Project_Category]    Script Date: 04/26/2016 21:09:19 ******/
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
/****** Object:  Table [dbo].[PSS_User_Type]    Script Date: 04/26/2016 21:09:19 ******/
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
/****** Object:  Table [dbo].[PSS_Status]    Script Date: 04/26/2016 21:09:19 ******/
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
/****** Object:  Table [dbo].[PSS_Sponsor]    Script Date: 04/26/2016 21:09:19 ******/
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
/****** Object:  Table [dbo].[PSS_Users]    Script Date: 04/26/2016 21:09:19 ******/
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
/****** Object:  Table [dbo].[PSS_Projects]    Script Date: 04/26/2016 21:09:19 ******/
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
/****** Object:  Table [dbo].[PSS_Student_Project]    Script Date: 04/26/2016 21:09:19 ******/
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
/****** Object:  ForeignKey [FK_PSS_Projects_PSS_Project_Category]    Script Date: 04/26/2016 21:09:19 ******/
ALTER TABLE [dbo].[PSS_Projects]  WITH CHECK ADD  CONSTRAINT [FK_PSS_Projects_PSS_Project_Category] FOREIGN KEY([proj_category_id])
REFERENCES [dbo].[PSS_Project_Category] ([proj_category_id])
GO
ALTER TABLE [dbo].[PSS_Projects] CHECK CONSTRAINT [FK_PSS_Projects_PSS_Project_Category]
GO
/****** Object:  ForeignKey [FK_PSS_Projects_PSS_Sponsor]    Script Date: 04/26/2016 21:09:19 ******/
ALTER TABLE [dbo].[PSS_Projects]  WITH CHECK ADD  CONSTRAINT [FK_PSS_Projects_PSS_Sponsor] FOREIGN KEY([sponsor_id])
REFERENCES [dbo].[PSS_Sponsor] ([sponsor_id])
GO
ALTER TABLE [dbo].[PSS_Projects] CHECK CONSTRAINT [FK_PSS_Projects_PSS_Sponsor]
GO
/****** Object:  ForeignKey [FK_PSS_Projects_PSS_Status]    Script Date: 04/26/2016 21:09:19 ******/
ALTER TABLE [dbo].[PSS_Projects]  WITH CHECK ADD  CONSTRAINT [FK_PSS_Projects_PSS_Status] FOREIGN KEY([project_status_id])
REFERENCES [dbo].[PSS_Status] ([status_id])
GO
ALTER TABLE [dbo].[PSS_Projects] CHECK CONSTRAINT [FK_PSS_Projects_PSS_Status]
GO
/****** Object:  ForeignKey [FK_PSS_Projects_PSS_Users]    Script Date: 04/26/2016 21:09:19 ******/
ALTER TABLE [dbo].[PSS_Projects]  WITH CHECK ADD  CONSTRAINT [FK_PSS_Projects_PSS_Users] FOREIGN KEY([user_id])
REFERENCES [dbo].[PSS_Users] ([user_id])
GO
ALTER TABLE [dbo].[PSS_Projects] CHECK CONSTRAINT [FK_PSS_Projects_PSS_Users]
GO
/****** Object:  ForeignKey [FK_PSS_Student_Project_PSS_Projects]    Script Date: 04/26/2016 21:09:19 ******/
ALTER TABLE [dbo].[PSS_Student_Project]  WITH CHECK ADD  CONSTRAINT [FK_PSS_Student_Project_PSS_Projects] FOREIGN KEY([project_id])
REFERENCES [dbo].[PSS_Projects] ([project_id])
GO
ALTER TABLE [dbo].[PSS_Student_Project] CHECK CONSTRAINT [FK_PSS_Student_Project_PSS_Projects]
GO
/****** Object:  ForeignKey [FK_PSS_Student_Project_PSS_Status]    Script Date: 04/26/2016 21:09:19 ******/
ALTER TABLE [dbo].[PSS_Student_Project]  WITH CHECK ADD  CONSTRAINT [FK_PSS_Student_Project_PSS_Status] FOREIGN KEY([project_request_status_id])
REFERENCES [dbo].[PSS_Status] ([status_id])
GO
ALTER TABLE [dbo].[PSS_Student_Project] CHECK CONSTRAINT [FK_PSS_Student_Project_PSS_Status]
GO
/****** Object:  ForeignKey [FK_PSS_Student_Project_PSS_Users]    Script Date: 04/26/2016 21:09:19 ******/
ALTER TABLE [dbo].[PSS_Student_Project]  WITH CHECK ADD  CONSTRAINT [FK_PSS_Student_Project_PSS_Users] FOREIGN KEY([student_id])
REFERENCES [dbo].[PSS_Users] ([user_id])
GO
ALTER TABLE [dbo].[PSS_Student_Project] CHECK CONSTRAINT [FK_PSS_Student_Project_PSS_Users]
GO
/****** Object:  ForeignKey [FK_PSS_Users_PSS_User_Type]    Script Date: 04/26/2016 21:09:19 ******/
ALTER TABLE [dbo].[PSS_Users]  WITH CHECK ADD  CONSTRAINT [FK_PSS_Users_PSS_User_Type] FOREIGN KEY([user_type_id])
REFERENCES [dbo].[PSS_User_Type] ([user_type_id])
GO
ALTER TABLE [dbo].[PSS_Users] CHECK CONSTRAINT [FK_PSS_Users_PSS_User_Type]
GO
