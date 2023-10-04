CREATE DATABASE [DBPruebas];


CREATE TABLE [dbo].[TablaPrueba](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ColumnaPrueba] [varchar](50) NULL,
 CONSTRAINT [PK_TablaPrueba] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TablaPrueba] ON 
GO
INSERT [dbo].[TablaPrueba] ([Id], [ColumnaPrueba]) VALUES (1, N'data test')
GO
INSERT [dbo].[TablaPrueba] ([Id], [ColumnaPrueba]) VALUES (2, N'data test 2')
GO
SET IDENTITY_INSERT [dbo].[TablaPrueba] OFF
GO
