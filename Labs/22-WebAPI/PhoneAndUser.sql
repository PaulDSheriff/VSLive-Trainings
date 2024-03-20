USE [AdventureWorksLT2019]
GO
/****** Object:  Table [dbo].[PhoneType]    Script Date: 3/20/2024 3:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhoneType](
	[PhoneTypeId] [int] NOT NULL,
	[TypeDescription] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_PhoneType] PRIMARY KEY CLUSTERED 
(
	[PhoneTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 3/20/2024 3:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(2,1) NOT NULL,
	[LoginId] [nvarchar](50) NOT NULL,
	[FirstName] [dbo].[Name] NOT NULL,
	[LastName] [dbo].[Name] NOT NULL,
	[Email] [nvarchar](256) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Phone] [dbo].[Phone] NOT NULL,
	[PhoneType] [nvarchar](10) NULL,
	[IsFullTime] [bit] NULL,
	[IsEnrolledIn401k] [bit] NULL,
	[IsEnrolledInHealthCare] [bit] NULL,
	[IsEnrolledInHSA] [bit] NULL,
	[IsEnrolledInFlexTime] [bit] NULL,
	[IsActive] [bit] NULL,
	[BirthDate] [date] NULL,
	[StartTime] [time](7) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[PhoneType] ([PhoneTypeId], [TypeDescription]) VALUES (1, N'Home')
GO
INSERT [dbo].[PhoneType] ([PhoneTypeId], [TypeDescription]) VALUES (2, N'Mobile')
GO
INSERT [dbo].[PhoneType] ([PhoneTypeId], [TypeDescription]) VALUES (3, N'Work')
GO
INSERT [dbo].[PhoneType] ([PhoneTypeId], [TypeDescription]) VALUES (4, N'Other')
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([UserId], [LoginId], [FirstName], [LastName], [Email], [Password], [Phone], [PhoneType], [IsFullTime], [IsEnrolledIn401k], [IsEnrolledInHealthCare], [IsEnrolledInHSA], [IsEnrolledInFlexTime], [IsActive], [BirthDate], [StartTime]) VALUES (1, N'MichaelThomason', N'Michael', N'Thomason', N'MichaelThomason@advworks.com', N'MThomason@Word123', N'615.555.3333', N'Mobile', 1, 1, 1, 0, 0, 1, CAST(N'1985-03-15' AS Date), NULL)
GO
INSERT [dbo].[User] ([UserId], [LoginId], [FirstName], [LastName], [Email], [Password], [Phone], [PhoneType], [IsFullTime], [IsEnrolledIn401k], [IsEnrolledInHealthCare], [IsEnrolledInHSA], [IsEnrolledInFlexTime], [IsActive], [BirthDate], [StartTime]) VALUES (2, N'SheilaCleverly', N'Sheila', N'Cleverly', N'SheilaCleverly@advworks.com', N'Re!asdf#992', N'615.123.3456', N'Work', 1, 0, 1, 0, 0, 1, CAST(N'1981-06-09' AS Date), NULL)
GO
INSERT [dbo].[User] ([UserId], [LoginId], [FirstName], [LastName], [Email], [Password], [Phone], [PhoneType], [IsFullTime], [IsEnrolledIn401k], [IsEnrolledInHealthCare], [IsEnrolledInHSA], [IsEnrolledInFlexTime], [IsActive], [BirthDate], [StartTime]) VALUES (3, N'CatherineAbel', N'Catherine', N'Abel', N'CatherineAbel@advworks.com', N'Tx*99_pass', N'615.998.3332', N'Mobile', 1, 1, 1, 1, 1, 1, CAST(N'1979-04-05' AS Date), NULL)
GO
INSERT [dbo].[User] ([UserId], [LoginId], [FirstName], [LastName], [Email], [Password], [Phone], [PhoneType], [IsFullTime], [IsEnrolledIn401k], [IsEnrolledInHealthCare], [IsEnrolledInHSA], [IsEnrolledInFlexTime], [IsActive], [BirthDate], [StartTime]) VALUES (4, N'KimAbercrombie', N'Kim', N'Abercrombie', N'KimAbercrombie@advworks.com', N'PwdKim#Abercrombie123', N'615.555.3333', N'Work', 1, 0, 0, 1, 0, 1, CAST(N'1995-03-08' AS Date), NULL)
GO
INSERT [dbo].[User] ([UserId], [LoginId], [FirstName], [LastName], [Email], [Password], [Phone], [PhoneType], [IsFullTime], [IsEnrolledIn401k], [IsEnrolledInHealthCare], [IsEnrolledInHSA], [IsEnrolledInFlexTime], [IsActive], [BirthDate], [StartTime]) VALUES (7, N'JimWalker', N'Jim', N'Walker', N'JimWalker@advworks.com', N'azembolrous!123', N'615.369.9372', N'Mobile', 1, 1, 1, 0, 1, 1, CAST(N'1999-07-29' AS Date), NULL)
GO
INSERT [dbo].[User] ([UserId], [LoginId], [FirstName], [LastName], [Email], [Password], [Phone], [PhoneType], [IsFullTime], [IsEnrolledIn401k], [IsEnrolledInHealthCare], [IsEnrolledInHSA], [IsEnrolledInFlexTime], [IsActive], [BirthDate], [StartTime]) VALUES (8, N'SamAbolrous', N'Sam', N'Abolrous', N'SamAbolrous@advworks.com', N'Abolrous#PwdSam*987', N'615.555.3333', N'Work', 0, 0, 0, 0, 1, 1, CAST(N'2000-12-03' AS Date), CAST(N'07:00:00' AS Time))
GO
INSERT [dbo].[User] ([UserId], [LoginId], [FirstName], [LastName], [Email], [Password], [Phone], [PhoneType], [IsFullTime], [IsEnrolledIn401k], [IsEnrolledInHealthCare], [IsEnrolledInHSA], [IsEnrolledInFlexTime], [IsActive], [BirthDate], [StartTime]) VALUES (9, N'RichardDudely', N'Richard', N'Dudely', N'RichardDudely@advworks.com', N'Avacodo#567', N'615.987.3782', N'Mobile', 1, 1, 0, 0, 1, 1, CAST(N'1997-08-23' AS Date), NULL)
GO
INSERT [dbo].[User] ([UserId], [LoginId], [FirstName], [LastName], [Email], [Password], [Phone], [PhoneType], [IsFullTime], [IsEnrolledIn401k], [IsEnrolledInHealthCare], [IsEnrolledInHSA], [IsEnrolledInFlexTime], [IsActive], [BirthDate], [StartTime]) VALUES (10, N'ScottBerton', N'Scott', N'Berton', N'ScottBerton@advworks.com', N'gustavo#chong%87', N'615.555.3333', N'Work', 0, 0, 0, 1, 0, 1, CAST(N'2001-02-12' AS Date), CAST(N'08:00:00' AS Time))
GO
INSERT [dbo].[User] ([UserId], [LoginId], [FirstName], [LastName], [Email], [Password], [Phone], [PhoneType], [IsFullTime], [IsEnrolledIn401k], [IsEnrolledInHealthCare], [IsEnrolledInHSA], [IsEnrolledInFlexTime], [IsActive], [BirthDate], [StartTime]) VALUES (11, N'PaulShaefer', N'Paul                ', N'Shaefer', N'Pauls@netinc.com', N'P@ssw0Rd', N'(714) 399-9212', N'Work', 1, 1, 1, 0, 0, 1, CAST(N'1963-02-05' AS Date), NULL)
GO
INSERT [dbo].[User] ([UserId], [LoginId], [FirstName], [LastName], [Email], [Password], [Phone], [PhoneType], [IsFullTime], [IsEnrolledIn401k], [IsEnrolledInHealthCare], [IsEnrolledInHSA], [IsEnrolledInFlexTime], [IsActive], [BirthDate], [StartTime]) VALUES (12, N'MichaelKawoski', N'Michael             ', N'Kawoski', N'Michaelk@netinc.com', N'P@ssw0Rd', N'(714) 939-0002', N'Mobile', 1, 1, 1, 1, 0, 1, CAST(N'1953-07-05' AS Date), NULL)
GO
INSERT [dbo].[User] ([UserId], [LoginId], [FirstName], [LastName], [Email], [Password], [Phone], [PhoneType], [IsFullTime], [IsEnrolledIn401k], [IsEnrolledInHealthCare], [IsEnrolledInHSA], [IsEnrolledInFlexTime], [IsActive], [BirthDate], [StartTime]) VALUES (13, N'SaraWinchell', N'Sara                ', N'Winchell', N'Saraw@netinc.com', N'P@ssw0Rd', N'(714) 738-9382', N'Work', 1, 1, 1, 0, 0, 0, CAST(N'1978-08-02' AS Date), NULL)
GO
INSERT [dbo].[User] ([UserId], [LoginId], [FirstName], [LastName], [Email], [Password], [Phone], [PhoneType], [IsFullTime], [IsEnrolledIn401k], [IsEnrolledInHealthCare], [IsEnrolledInHSA], [IsEnrolledInFlexTime], [IsActive], [BirthDate], [StartTime]) VALUES (14, N'JohnKroon', N'John                ', N'Kroon', N'Johnk@netinc.com', N'P@ssw0Rd', N'(949) 667-7347', N'Work', 1, 1, 1, 0, 1, 1, CAST(N'1970-03-23' AS Date), NULL)
GO
INSERT [dbo].[User] ([UserId], [LoginId], [FirstName], [LastName], [Email], [Password], [Phone], [PhoneType], [IsFullTime], [IsEnrolledIn401k], [IsEnrolledInHealthCare], [IsEnrolledInHSA], [IsEnrolledInFlexTime], [IsActive], [BirthDate], [StartTime]) VALUES (15, N'TimNicker', N'Tim                 ', N'Nicker', N'Timn@netinc.com', N'P@ssw0Rd', N'(714) 767-3747', N'Work', 1, 1, 1, 0, 1, 1, CAST(N'1975-04-05' AS Date), NULL)
GO
INSERT [dbo].[User] ([UserId], [LoginId], [FirstName], [LastName], [Email], [Password], [Phone], [PhoneType], [IsFullTime], [IsEnrolledIn401k], [IsEnrolledInHealthCare], [IsEnrolledInHSA], [IsEnrolledInFlexTime], [IsActive], [BirthDate], [StartTime]) VALUES (16, N'RussMartlog', N'Russ                ', N'Martlog', N'Russm@netinc.com', N'P@ssw0Rd', N'(714) 334-5643', N'Work', 1, 1, 1, 1, 0, 1, CAST(N'1969-05-05' AS Date), NULL)
GO
INSERT [dbo].[User] ([UserId], [LoginId], [FirstName], [LastName], [Email], [Password], [Phone], [PhoneType], [IsFullTime], [IsEnrolledIn401k], [IsEnrolledInHealthCare], [IsEnrolledInHSA], [IsEnrolledInFlexTime], [IsActive], [BirthDate], [StartTime]) VALUES (17, N'JohnBoron', N'John                ', N'Boron', N'Johnb@netinc.com', N'P@ssw0Rd', N'(714) 939-9993', N'Mobile', 1, 0, 0, 0, 0, 0, CAST(N'1965-03-02' AS Date), NULL)
GO
INSERT [dbo].[User] ([UserId], [LoginId], [FirstName], [LastName], [Email], [Password], [Phone], [PhoneType], [IsFullTime], [IsEnrolledIn401k], [IsEnrolledInHealthCare], [IsEnrolledInHSA], [IsEnrolledInFlexTime], [IsActive], [BirthDate], [StartTime]) VALUES (18, N'JamesBirdy', N'James               ', N'Birdy', N'Jamesb@netinc.com', N'P@ssw0Rd', N'(310) 939-9932', N'Work', 1, 0, 0, 0, 0, 1, CAST(N'1966-06-23' AS Date), NULL)
GO
INSERT [dbo].[User] ([UserId], [LoginId], [FirstName], [LastName], [Email], [Password], [Phone], [PhoneType], [IsFullTime], [IsEnrolledIn401k], [IsEnrolledInHealthCare], [IsEnrolledInHSA], [IsEnrolledInFlexTime], [IsActive], [BirthDate], [StartTime]) VALUES (19, N'TreyChen', N'Trey                ', N'Chen', N'Treyc@netinc.com', N'P@ssw0Rd', N'(562) 991-0009', N'Work', 1, 1, 0, 0, 0, 1, CAST(N'1961-07-11' AS Date), NULL)
GO
INSERT [dbo].[User] ([UserId], [LoginId], [FirstName], [LastName], [Email], [Password], [Phone], [PhoneType], [IsFullTime], [IsEnrolledIn401k], [IsEnrolledInHealthCare], [IsEnrolledInHSA], [IsEnrolledInFlexTime], [IsActive], [BirthDate], [StartTime]) VALUES (20, N'JimJones', N'Jim                 ', N'Jones', N'Jimj@netinc.com', N'P@ssw0Rd', N'(714) 223-0029', N'Mobile', 1, 0, 1, 0, 0, 1, CAST(N'1970-01-20' AS Date), NULL)
GO
INSERT [dbo].[User] ([UserId], [LoginId], [FirstName], [LastName], [Email], [Password], [Phone], [PhoneType], [IsFullTime], [IsEnrolledIn401k], [IsEnrolledInHealthCare], [IsEnrolledInHSA], [IsEnrolledInFlexTime], [IsActive], [BirthDate], [StartTime]) VALUES (21, N'JohnPittsburgh', N'John                ', N'Pittsburgh', N'Johnp@netinc.com', N'P@ssw0Rd', N'(714) 554-0493', N'Work', 1, 0, 1, 0, 0, 1, CAST(N'1978-08-06' AS Date), NULL)
GO
INSERT [dbo].[User] ([UserId], [LoginId], [FirstName], [LastName], [Email], [Password], [Phone], [PhoneType], [IsFullTime], [IsEnrolledIn401k], [IsEnrolledInHealthCare], [IsEnrolledInHSA], [IsEnrolledInFlexTime], [IsActive], [BirthDate], [StartTime]) VALUES (22, N'JeanneRussell', N'Jeanne              ', N'Russell', N'Jeanner@netinc.com', N'P@ssw0Rd', N'(949) 339-0000', N'Mobile', 1, 1, 0, 1, 0, 1, CAST(N'1966-08-15' AS Date), NULL)
GO
INSERT [dbo].[User] ([UserId], [LoginId], [FirstName], [LastName], [Email], [Password], [Phone], [PhoneType], [IsFullTime], [IsEnrolledIn401k], [IsEnrolledInHealthCare], [IsEnrolledInHSA], [IsEnrolledInFlexTime], [IsActive], [BirthDate], [StartTime]) VALUES (23, N'DavidLafeet', N'David               ', N'Lafeet', N'Davidl@netinc.com', N'P@ssw0Rd', N'(949) 399-9232', N'Work', 1, 1, 0, 1, 0, 1, CAST(N'1973-10-14' AS Date), NULL)
GO
INSERT [dbo].[User] ([UserId], [LoginId], [FirstName], [LastName], [Email], [Password], [Phone], [PhoneType], [IsFullTime], [IsEnrolledIn401k], [IsEnrolledInHealthCare], [IsEnrolledInHSA], [IsEnrolledInFlexTime], [IsActive], [BirthDate], [StartTime]) VALUES (24, N'KhanhVoon', N'Khanh               ', N'Voon', N'Khanhv@netinc.com', N'P@ssw0Rd', N'(714) 342-3232', N'Work', 1, 1, 0, 1, 1, 1, CAST(N'1962-11-20' AS Date), NULL)
GO
INSERT [dbo].[User] ([UserId], [LoginId], [FirstName], [LastName], [Email], [Password], [Phone], [PhoneType], [IsFullTime], [IsEnrolledIn401k], [IsEnrolledInHealthCare], [IsEnrolledInHSA], [IsEnrolledInFlexTime], [IsActive], [BirthDate], [StartTime]) VALUES (25, N'JimRussell', N'Jim                 ', N'Russell', N'Jimr@netinc.com', N'P@ssw0Rd', N'(714) 123-2343', N'Work', 1, 1, 0, 0, 1, 1, CAST(N'1960-12-10' AS Date), NULL)
GO
INSERT [dbo].[User] ([UserId], [LoginId], [FirstName], [LastName], [Email], [Password], [Phone], [PhoneType], [IsFullTime], [IsEnrolledIn401k], [IsEnrolledInHealthCare], [IsEnrolledInHSA], [IsEnrolledInFlexTime], [IsActive], [BirthDate], [StartTime]) VALUES (26, N'DavidTarkas', N'David               ', N'Tarkas', N'Davidt@netinc.com', N'P@ssw0Rd', N'(714) 893-7361', N'Mobile', 1, 1, 0, 0, 1, 1, CAST(N'1967-03-15' AS Date), NULL)
GO
INSERT [dbo].[User] ([UserId], [LoginId], [FirstName], [LastName], [Email], [Password], [Phone], [PhoneType], [IsFullTime], [IsEnrolledIn401k], [IsEnrolledInHealthCare], [IsEnrolledInHSA], [IsEnrolledInFlexTime], [IsActive], [BirthDate], [StartTime]) VALUES (27, N'CraigShowman', N'Craig               ', N'Showman', N'Craigs@netinc.com', N'P@ssw0Rd', N'(949) 938-1234', N'Mobile', 1, 1, 0, 1, 0, 1, CAST(N'1974-04-06' AS Date), NULL)
GO
INSERT [dbo].[User] ([UserId], [LoginId], [FirstName], [LastName], [Email], [Password], [Phone], [PhoneType], [IsFullTime], [IsEnrolledIn401k], [IsEnrolledInHealthCare], [IsEnrolledInHSA], [IsEnrolledInFlexTime], [IsActive], [BirthDate], [StartTime]) VALUES (28, N'BrooksAnderson', N'Brooks              ', N'Anderson', N'Brooksa@netinc.com', N'P@ssw0Rd', N'(949) 777-3929', N'Mobile', 1, 1, 1, 0, 0, 1, CAST(N'1959-08-30' AS Date), NULL)
GO
INSERT [dbo].[User] ([UserId], [LoginId], [FirstName], [LastName], [Email], [Password], [Phone], [PhoneType], [IsFullTime], [IsEnrolledIn401k], [IsEnrolledInHealthCare], [IsEnrolledInHSA], [IsEnrolledInFlexTime], [IsActive], [BirthDate], [StartTime]) VALUES (29, N'MarkParks', N'Mark                ', N'Parks', N'Markp@netinc.com', N'P@ssw0Rd', N'(425) 377-7333', N'Mobile', 0, 1, 0, 0, 1, 1, CAST(N'1968-10-19' AS Date), CAST(N'06:00:00' AS Time))
GO
INSERT [dbo].[User] ([UserId], [LoginId], [FirstName], [LastName], [Email], [Password], [Phone], [PhoneType], [IsFullTime], [IsEnrolledIn401k], [IsEnrolledInHealthCare], [IsEnrolledInHSA], [IsEnrolledInFlexTime], [IsActive], [BirthDate], [StartTime]) VALUES (30, N'KeithNashville', N'Keith               ', N'Nashville', N'Keithn@netinc.com', N'P@ssw0Rd', N'(702) 773-0093', N'Mobile', 1, 0, 0, 1, 1, 0, CAST(N'1972-01-31' AS Date), NULL)
GO
INSERT [dbo].[User] ([UserId], [LoginId], [FirstName], [LastName], [Email], [Password], [Phone], [PhoneType], [IsFullTime], [IsEnrolledIn401k], [IsEnrolledInHealthCare], [IsEnrolledInHSA], [IsEnrolledInFlexTime], [IsActive], [BirthDate], [StartTime]) VALUES (31, N'JaneJoan', N'Jane                ', N'Joan', N'Janej@netinc.com', N'P@ssw0Rd', N'(408) 939-9993', N'Work', 1, 0, 0, 0, 0, 1, CAST(N'1962-12-07' AS Date), NULL)
GO
INSERT [dbo].[User] ([UserId], [LoginId], [FirstName], [LastName], [Email], [Password], [Phone], [PhoneType], [IsFullTime], [IsEnrolledIn401k], [IsEnrolledInHealthCare], [IsEnrolledInHSA], [IsEnrolledInFlexTime], [IsActive], [BirthDate], [StartTime]) VALUES (33, N'BrianGossling', N'Brian', N'Gossling', N'BrianGossling@advworks.com', N'P@ssw0Rd', N'916.234.8372', N'Work', 1, 0, 1, 1, 0, 1, CAST(N'1993-05-16' AS Date), NULL)
GO
INSERT [dbo].[User] ([UserId], [LoginId], [FirstName], [LastName], [Email], [Password], [Phone], [PhoneType], [IsFullTime], [IsEnrolledIn401k], [IsEnrolledInHealthCare], [IsEnrolledInHSA], [IsEnrolledInFlexTime], [IsActive], [BirthDate], [StartTime]) VALUES (34, N'BenQueen', N'Ben', N'Queen', N'BenQueen@advworks.com', N'P@ssw0Rd', N'615.339.9032', N'Mobile', 1, 1, 1, 1, 1, 1, CAST(N'1996-11-01' AS Date), NULL)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_IsFullTime]  DEFAULT ((0)) FOR [IsFullTime]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_IsEnrolledIn401k]  DEFAULT ((0)) FOR [IsEnrolledIn401k]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_IsEnrolledInHealthCare]  DEFAULT ((0)) FOR [IsEnrolledInHealthCare]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_IsEnrolledInHSA]  DEFAULT ((0)) FOR [IsEnrolledInHSA]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_IsEnrolledInFlexTime]  DEFAULT ((0)) FOR [IsEnrolledInFlexTime]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
