USE [Music]
GO
/****** Object:  UserDefinedFunction [dbo].[HtmlEncode]    Script Date: 9/15/2022 6:46:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[HtmlEncode]
(
    @UnEncoded as varchar(500)
)
RETURNS varchar(500)
AS
BEGIN
  DECLARE @Encoded as varchar(500)

  --order is important here. Replace the amp first, then the lt and gt. 
  --otherwise the &lt will become &amp;lt; 
  SELECT @Encoded = 
  Replace(
    Replace(
      Replace(@UnEncoded,'&','&amp;'),
    '<', '&lt;'),
  '>', '&gt;')

  RETURN @Encoded
END
GO
/****** Object:  Table [dbo].[MusicGenre]    Script Date: 9/15/2022 6:46:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MusicGenre](
	[GenreId] [int] IDENTITY(1,1) NOT NULL,
	[Genre] [varchar](100) NULL,
	[LastUpdated] [datetime] NOT NULL,
 CONSTRAINT [PK_Genre] PRIMARY KEY CLUSTERED 
(
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MusicKind]    Script Date: 9/15/2022 6:46:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MusicKind](
	[KindId] [int] IDENTITY(1,1) NOT NULL,
	[Kind] [varchar](100) NULL,
	[LastUpdated] [datetime] NOT NULL,
 CONSTRAINT [PK_Kind] PRIMARY KEY CLUSTERED 
(
	[KindId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Songs]    Script Date: 9/15/2022 6:46:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Songs](
	[SongId] [int] IDENTITY(1,1) NOT NULL,
	[SongName] [varchar](150) NULL,
	[Artist] [varchar](200) NULL,
	[Album] [varchar](100) NULL,
	[GenreId] [int] NULL,
	[KindId] [int] NULL,
	[TrackNumber] [varchar](10) NULL,
	[Rating] [int] NULL,
	[Year] [int] NULL,
	[ReleaseDate] [datetime] NULL,
	[Size] [varchar](10) NULL,
	[Plays] [int] NULL,
	[DateAdded] [datetime] NULL,
PRIMARY KEY NONCLUSTERED 
(
	[SongId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TablesLastUpdate]    Script Date: 9/15/2022 6:46:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TablesLastUpdate](
	[TableName] [varchar](150) NOT NULL,
	[LastUpdated] [datetime] NULL,
 CONSTRAINT [PK_TablesLastUpdate] PRIMARY KEY CLUSTERED 
(
	[TableName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[MusicGenre] ADD  CONSTRAINT [DF_MusicGenre_LastUpdated]  DEFAULT (getdate()) FOR [LastUpdated]
GO
ALTER TABLE [dbo].[MusicKind] ADD  CONSTRAINT [DF_MusicKind_LastUpdated]  DEFAULT (getdate()) FOR [LastUpdated]
GO
ALTER TABLE [dbo].[Songs]  WITH CHECK ADD  CONSTRAINT [FK_Songs_Genre] FOREIGN KEY([GenreId])
REFERENCES [dbo].[MusicGenre] ([GenreId])
GO
ALTER TABLE [dbo].[Songs] CHECK CONSTRAINT [FK_Songs_Genre]
GO
ALTER TABLE [dbo].[Songs]  WITH CHECK ADD  CONSTRAINT [FK_Songs_MusicKind] FOREIGN KEY([KindId])
REFERENCES [dbo].[MusicKind] ([KindId])
GO
ALTER TABLE [dbo].[Songs] CHECK CONSTRAINT [FK_Songs_MusicKind]
GO
/****** Object:  StoredProcedure [dbo].[GetSongsAsHTML]    Script Date: 9/15/2022 6:46:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetSongsAsHTML]
as
SELECT TOP 500
 '<tr>
 <td>' + [SongName] + '</td>
 <td>' + dbo.HtmlEncode([Artist])  + '</td>
 <td>' + dbo.HtmlEncode([Album]) + '</td>
 <td>' +  Cast([Year] as CHAR(4)) + '</td>
 </tr>' as Col
FROM Songs
WHERE SongName is not null and Artist is not null and Album is not null and YEAR is not null
GO