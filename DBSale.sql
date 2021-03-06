USE [QLcustomer2]
GO
/****** Object:  Table [dbo].[add]    Script Date: 11/9/2018 5:59:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[add](
	[id] [nchar](10) NOT NULL,
	[nam] [nchar](10) NULL,
 CONSTRAINT [PK_add] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[bill_payment_in]    Script Date: 11/9/2018 5:59:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[bill_payment_in](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[company_id] [nvarchar](max) NULL,
	[company_name] [nvarchar](255) NULL,
	[price] [float] NULL,
	[del_flg] [bit] NOT NULL,
	[create_user] [varchar](8) NULL,
	[create_date] [datetime] NULL,
	[update_user] [varchar](8) NULL,
	[update_date] [datetime] NULL,
 CONSTRAINT [PK_dbo.bill_payment_in] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[bill_payment_out]    Script Date: 11/9/2018 5:59:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[bill_payment_out](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[customer_id] [nvarchar](max) NULL,
	[customer_name] [nvarchar](255) NULL,
	[price] [float] NULL,
	[del_flg] [bit] NOT NULL,
	[create_user] [varchar](8) NULL,
	[create_date] [datetime] NULL,
	[update_user] [varchar](8) NULL,
	[update_date] [datetime] NULL,
 CONSTRAINT [PK_dbo.bill_payment_out] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[catalog]    Script Date: 11/9/2018 5:59:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[catalog](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NULL,
	[del_flg] [bit] NULL,
	[create_user] [varchar](8) NULL,
	[create_date] [datetime] NULL,
	[update_user] [varchar](8) NULL,
	[update_date] [datetime] NULL,
 CONSTRAINT [PK_dbo.catalog] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[company]    Script Date: 11/9/2018 5:59:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[company](
	[company_cd] [nchar](8) NOT NULL,
	[company_name] [nvarchar](255) NULL,
	[company_short_name] [nvarchar](40) NULL,
	[tel] [nvarchar](255) NULL,
	[address] [nvarchar](255) NULL,
	[fax] [nvarchar](255) NULL,
	[phone] [nvarchar](255) NULL,
	[del_flg] [bit] NOT NULL,
	[create_date] [datetime] NULL,
	[create_user] [varchar](8) NULL,
	[update_date] [datetime] NULL,
	[update_user] [varchar](8) NULL,
 CONSTRAINT [PK_dbo.company] PRIMARY KEY CLUSTERED 
(
	[company_cd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[customer]    Script Date: 11/9/2018 5:59:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[customer](
	[user_cd] [varchar](8) NOT NULL,
	[name] [nvarchar](255) NULL,
	[user_name] [nvarchar](255) NULL,
	[pass_word] [nvarchar](255) NOT NULL,
	[mobile] [nvarchar](255) NULL,
	[email] [nvarchar](255) NULL,
	[adress] [nvarchar](255) NULL,
	[sex] [bit] NULL,
	[del_flg] [bit] NOT NULL,
	[create_user] [varchar](8) NULL,
	[create_date] [datetime] NULL,
	[update_user] [varchar](8) NULL,
	[update_date] [datetime] NULL,
 CONSTRAINT [PK_dbo.customer] PRIMARY KEY CLUSTERED 
(
	[user_cd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[details_bill_payment_in]    Script Date: 11/9/2018 5:59:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[details_bill_payment_in](
	[bill_id] [int] NOT NULL,
	[product_id] [int] NOT NULL,
	[amount] [bigint] NULL,
	[price] [nchar](10) NULL,
	[del_flg] [bit] NOT NULL,
	[create_user] [varchar](8) NULL,
	[create_date] [datetime] NULL,
	[update_user] [varchar](8) NULL,
	[update_date] [datetime] NULL,
 CONSTRAINT [PK_dbo.details_bill_payment_in] PRIMARY KEY CLUSTERED 
(
	[bill_id] ASC,
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[details_bill_payment_out]    Script Date: 11/9/2018 5:59:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[details_bill_payment_out](
	[bill_id] [int] NOT NULL,
	[product_id] [int] NOT NULL,
	[amount] [bigint] NULL,
	[price] [nchar](10) NULL,
	[del_flg] [bit] NOT NULL,
	[create_user] [varchar](8) NULL,
	[create_date] [datetime] NULL,
	[update_user] [varchar](8) NULL,
	[update_date] [datetime] NULL,
 CONSTRAINT [PK_dbo.details_bill_payment_out] PRIMARY KEY CLUSTERED 
(
	[bill_id] ASC,
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[product]    Script Date: 11/9/2018 5:59:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[catalog_id] [int] NULL,
	[name] [nvarchar](255) NULL,
	[amount] [bigint] NULL,
	[price] [float] NULL,
	[price_buy] [float] NULL,
	[del_flg] [bit] NOT NULL,
	[create_user] [varchar](8) NULL,
	[create_date] [datetime] NULL,
	[update_user] [varchar](8) NULL,
	[update_date] [datetime] NULL,
 CONSTRAINT [PK_dbo.product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[staff]    Script Date: 11/9/2018 5:59:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[staff](
	[user_cd] [varchar](8) NOT NULL,
	[name] [nvarchar](255) NULL,
	[user_name] [nvarchar](255) NULL,
	[pass_word] [nvarchar](255) NOT NULL,
	[mobile] [nvarchar](255) NULL,
	[email] [nvarchar](255) NULL,
	[adress] [nvarchar](255) NULL,
	[sex] [bit] NULL,
	[del_flg] [bit] NOT NULL,
	[create_user] [varchar](8) NULL,
	[create_date] [datetime] NULL,
	[update_user] [varchar](8) NULL,
	[update_date] [datetime] NULL,
 CONSTRAINT [PK_dbo.staff] PRIMARY KEY CLUSTERED 
(
	[user_cd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[user]    Script Date: 11/9/2018 5:59:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_cd] [varchar](8) NOT NULL,
	[pass_word] [nvarchar](255) NOT NULL,
	[user_name] [nvarchar](255) NULL,
	[mobile] [nvarchar](255) NULL,
	[email] [nvarchar](255) NULL,
	[adress] [nvarchar](255) NULL,
	[sex] [bit] NULL,
	[del_flg] [bit] NOT NULL,
	[create_date] [datetime] NULL,
	[create_user] [varchar](8) NULL,
	[update_date] [datetime] NULL,
	[update_user] [varchar](8) NULL,
 CONSTRAINT [PK_dbo.user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
