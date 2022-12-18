USE [fatma_arican]
GO
/****** Object:  Table [dbo].[apartments]    Script Date: 19.12.2022 01:16:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[apartments](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[empty] [bit] NULL,
	[floor] [int] NULL,
	[door_number] [int] NULL,
	[owner_user_id] [int] NULL,
	[apartment_type_id] [int] NULL,
	[deleted] [bit] NULL,
 CONSTRAINT [apartment_pk] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[apartments_type]    Script Date: 19.12.2022 01:16:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[apartments_type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[number_of_rooms] [nvarchar](50) NULL,
	[dues_paid] [decimal](18, 0) NULL,
	[area] [int] NULL,
	[type] [nvarchar](50) NULL,
 CONSTRAINT [apartment_type_pk] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[messages]    Script Date: 19.12.2022 01:16:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[messages](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[from_apartment_id] [int] NULL,
	[to_apartment_id] [int] NULL,
	[summary] [nvarchar](500) NULL,
	[read] [bit] NULL,
	[create_date] [datetime] NULL,
 CONSTRAINT [messages_pk] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[payments]    Script Date: 19.12.2022 01:16:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[payments](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[apartments_id] [int] NULL,
	[payment_date] [datetime] NULL,
	[amount] [int] NULL,
	[payment_type_id] [int] NULL,
	[reason] [nvarchar](50) NULL,
	[state] [nvarchar](50) NULL,
	[due_date] [datetime] NULL,
 CONSTRAINT [payments_pk] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[payments_type]    Script Date: 19.12.2022 01:16:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[payments_type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [payment_type_pk] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 19.12.2022 01:16:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[full_name] [nvarchar](50) NULL,
	[identity_number] [nvarchar](50) NULL,
	[email] [nvarchar](100) NULL,
	[phone] [nvarchar](50) NULL,
	[plate] [nvarchar](50) NULL,
	[deleted] [bit] NULL,
	[user_type_id] [int] NULL,
 CONSTRAINT [users_pk] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users_type]    Script Date: 19.12.2022 01:16:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users_type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](200) NULL,
 CONSTRAINT [user_type_pk] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
