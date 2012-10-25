USE [master]
GO
/****** Object:  Database [Bluequiz]    Script Date: 10/23/2012 21:17:24 ******/
CREATE DATABASE [Bluequiz] ON  PRIMARY 
( NAME = N'Bluequiz', FILENAME = N'F:\Microsoft SQL Server\Data\Bluequiz.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Bluequiz_log', FILENAME = N'F:\Microsoft SQL Server\Data\Bluequiz_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Bluequiz] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Bluequiz].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Bluequiz] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Bluequiz] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Bluequiz] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Bluequiz] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Bluequiz] SET ARITHABORT OFF
GO
ALTER DATABASE [Bluequiz] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [Bluequiz] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Bluequiz] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Bluequiz] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Bluequiz] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Bluequiz] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Bluequiz] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Bluequiz] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Bluequiz] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Bluequiz] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Bluequiz] SET  DISABLE_BROKER
GO
ALTER DATABASE [Bluequiz] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Bluequiz] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Bluequiz] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Bluequiz] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Bluequiz] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Bluequiz] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Bluequiz] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Bluequiz] SET  READ_WRITE
GO
ALTER DATABASE [Bluequiz] SET RECOVERY FULL
GO
ALTER DATABASE [Bluequiz] SET  MULTI_USER
GO
ALTER DATABASE [Bluequiz] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Bluequiz] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'Bluequiz', N'ON'
GO
USE [Bluequiz]
GO
/****** Object:  Table [dbo].[bq_Quiz]    Script Date: 10/23/2012 21:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[bq_Quiz](
	[QuizId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[Name] [nvarchar](100) NOT NULL,
	[DateCreated] [smalldatetime] NOT NULL,
	[FinanceCompany] [nvarchar](50) NULL,
	[CompanyIcon] [varchar](60) NULL,
 CONSTRAINT [PK_bq_Quiz] PRIMARY KEY CLUSTERED 
(
	[QuizId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[bq_Quiz] ([QuizId], [UserId], [Name], [DateCreated], [FinanceCompany], [CompanyIcon]) VALUES (N'55a0c125-226c-454d-b8d9-d70e8e75045e', NULL, N'Toeic Sample', CAST(0xA0F202BB AS SmallDateTime), NULL, NULL)
/****** Object:  Table [dbo].[bq_Part]    Script Date: 10/23/2012 21:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bq_Part](
	[PartId] [uniqueidentifier] NOT NULL,
	[QuizId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Order] [tinyint] NOT NULL,
 CONSTRAINT [PK_bq_Part] PRIMARY KEY CLUSTERED 
(
	[PartId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bq_Test]    Script Date: 10/23/2012 21:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bq_Test](
	[TestId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[QuizId] [uniqueidentifier] NOT NULL,
	[DateCreated] [smalldatetime] NOT NULL,
	[StartTime] [smalldatetime] NULL,
	[EndTime] [smalldatetime] NULL,
	[Mark] [int] NULL,
 CONSTRAINT [PK_bq_Test] PRIMARY KEY CLUSTERED 
(
	[TestId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[bq_Part_Update]    Script Date: 10/23/2012 21:17:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[bq_Part_Update]
	@partId uniqueidentifier,
	@name nvarchar(50),
	@order tinyint
AS
Begin
	update bq_Part set
		Name=@name,
		"Order"=@order
	where
		PartId=@partId
End
GO
/****** Object:  StoredProcedure [dbo].[bq_Part_Add]    Script Date: 10/23/2012 21:17:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[bq_Part_Add]
	@partId uniqueidentifier,
	@quizId uniqueidentifier,
	@name nvarchar(50),
	@order tinyint
AS
Begin
	insert bq_Part(PartId, QuizId, Name, "Order")
	values(@partId, @quizId, @name, @order)
End
GO
/****** Object:  Table [dbo].[bq_QuestionGroup]    Script Date: 10/23/2012 21:17:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[bq_QuestionGroup](
	[QuestionGroupId] [uniqueidentifier] NOT NULL,
	[QuizId] [uniqueidentifier] NOT NULL,
	[PartId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Order] [tinyint] NOT NULL,
	[Paragraph] [ntext] NULL,
	[MediaPath] [varchar](60) NULL,
 CONSTRAINT [PK_bq_QuestionGroup] PRIMARY KEY CLUSTERED 
(
	[QuestionGroupId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[bq_QuestionGroup_UpdateMediaPath]    Script Date: 10/23/2012 21:17:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[bq_QuestionGroup_UpdateMediaPath]
	@questionGroupId uniqueidentifier,
	@mediaPath varchar(60)
AS
Begin
	update bq_QuestionGroup set
		MediaPath=@mediaPath
	where
		QuestionGroupId=@questionGroupId
End
GO
/****** Object:  StoredProcedure [dbo].[bq_QuestionGroup_Update]    Script Date: 10/23/2012 21:17:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[bq_QuestionGroup_Update]
	@questionGroupId uniqueidentifier,
	@name nvarchar(50),
	@order tinyint,
	@paragraph ntext,
	@mediaPath varchar(60)
AS
Begin
	update bq_QuestionGroup set
		Name=@name,
		"Order"=@order,
		Paragraph=@paragraph,
		MediaPath=@mediaPath
	where
		QuestionGroupId=@questionGroupId
End
GO
/****** Object:  StoredProcedure [dbo].[bq_QuestionGroup_Add]    Script Date: 10/23/2012 21:17:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[bq_QuestionGroup_Add]
	@questionGroupId uniqueidentifier,
	@quizId uniqueidentifier,
	@partId uniqueidentifier,
	@name nvarchar(50),
	@order tinyint,
	@paragraph ntext,
	@mediaPath varchar(60)
AS
Begin
	insert bq_QuestionGroup(QuestionGroupId, QuizId, PartId, Name, "Order", Paragraph, MediaPath)
	values(@questionGroupId, @quizId, @partId, @name, @order, @paragraph, @mediaPath)
End
GO
/****** Object:  Table [dbo].[bq_Question]    Script Date: 10/23/2012 21:17:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[bq_Question](
	[QuestionId] [uniqueidentifier] NOT NULL,
	[QuestionGroupId] [uniqueidentifier] NOT NULL,
	[QuizId] [uniqueidentifier] NOT NULL,
	[ImagePath] [varchar](60) NULL,
	[MediaPath] [varchar](60) NULL,
	[Paragraph] [nvarchar](1000) NULL,
	[OptionA] [nvarchar](50) NULL,
	[OptionB] [nvarchar](50) NULL,
	[OptionC] [nvarchar](50) NULL,
	[OptionD] [nvarchar](50) NULL,
	[Answer] [tinyint] NOT NULL,
 CONSTRAINT [PK_bq_Question] PRIMARY KEY CLUSTERED 
(
	[QuestionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[qb_Answer]    Script Date: 10/23/2012 21:17:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[qb_Answer](
	[AnswerId] [uniqueidentifier] NOT NULL,
	[TestId] [uniqueidentifier] NOT NULL,
	[QuestionId] [uniqueidentifier] NOT NULL,
	[OrderQuestion] [tinyint] NOT NULL,
	[Answer] [tinyint] NOT NULL,
 CONSTRAINT [PK_qb_Answer] PRIMARY KEY CLUSTERED 
(
	[AnswerId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_bq_Part_bq_Quiz]    Script Date: 10/23/2012 21:17:27 ******/
ALTER TABLE [dbo].[bq_Part]  WITH CHECK ADD  CONSTRAINT [FK_bq_Part_bq_Quiz] FOREIGN KEY([PartId])
REFERENCES [dbo].[bq_Quiz] ([QuizId])
GO
ALTER TABLE [dbo].[bq_Part] CHECK CONSTRAINT [FK_bq_Part_bq_Quiz]
GO
/****** Object:  ForeignKey [FK_bq_Test_bq_Quiz]    Script Date: 10/23/2012 21:17:27 ******/
ALTER TABLE [dbo].[bq_Test]  WITH CHECK ADD  CONSTRAINT [FK_bq_Test_bq_Quiz] FOREIGN KEY([QuizId])
REFERENCES [dbo].[bq_Quiz] ([QuizId])
GO
ALTER TABLE [dbo].[bq_Test] CHECK CONSTRAINT [FK_bq_Test_bq_Quiz]
GO
/****** Object:  ForeignKey [FK_bq_QuestionGroup_bq_Part]    Script Date: 10/23/2012 21:17:43 ******/
ALTER TABLE [dbo].[bq_QuestionGroup]  WITH CHECK ADD  CONSTRAINT [FK_bq_QuestionGroup_bq_Part] FOREIGN KEY([PartId])
REFERENCES [dbo].[bq_Part] ([PartId])
GO
ALTER TABLE [dbo].[bq_QuestionGroup] CHECK CONSTRAINT [FK_bq_QuestionGroup_bq_Part]
GO
/****** Object:  ForeignKey [FK_bq_QuestionGroup_bq_Quiz]    Script Date: 10/23/2012 21:17:43 ******/
ALTER TABLE [dbo].[bq_QuestionGroup]  WITH CHECK ADD  CONSTRAINT [FK_bq_QuestionGroup_bq_Quiz] FOREIGN KEY([QuizId])
REFERENCES [dbo].[bq_Quiz] ([QuizId])
GO
ALTER TABLE [dbo].[bq_QuestionGroup] CHECK CONSTRAINT [FK_bq_QuestionGroup_bq_Quiz]
GO
/****** Object:  ForeignKey [FK_bq_Question_bq_QuestionGroup]    Script Date: 10/23/2012 21:17:43 ******/
ALTER TABLE [dbo].[bq_Question]  WITH CHECK ADD  CONSTRAINT [FK_bq_Question_bq_QuestionGroup] FOREIGN KEY([QuestionGroupId])
REFERENCES [dbo].[bq_QuestionGroup] ([QuestionGroupId])
GO
ALTER TABLE [dbo].[bq_Question] CHECK CONSTRAINT [FK_bq_Question_bq_QuestionGroup]
GO
/****** Object:  ForeignKey [FK_bq_Question_bq_Quiz]    Script Date: 10/23/2012 21:17:43 ******/
ALTER TABLE [dbo].[bq_Question]  WITH CHECK ADD  CONSTRAINT [FK_bq_Question_bq_Quiz] FOREIGN KEY([QuizId])
REFERENCES [dbo].[bq_Quiz] ([QuizId])
GO
ALTER TABLE [dbo].[bq_Question] CHECK CONSTRAINT [FK_bq_Question_bq_Quiz]
GO
/****** Object:  ForeignKey [FK_qb_Answer_bq_Question]    Script Date: 10/23/2012 21:17:43 ******/
ALTER TABLE [dbo].[qb_Answer]  WITH CHECK ADD  CONSTRAINT [FK_qb_Answer_bq_Question] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[bq_Question] ([QuestionId])
GO
ALTER TABLE [dbo].[qb_Answer] CHECK CONSTRAINT [FK_qb_Answer_bq_Question]
GO
/****** Object:  ForeignKey [FK_qb_Answer_bq_Test]    Script Date: 10/23/2012 21:17:43 ******/
ALTER TABLE [dbo].[qb_Answer]  WITH CHECK ADD  CONSTRAINT [FK_qb_Answer_bq_Test] FOREIGN KEY([TestId])
REFERENCES [dbo].[bq_Test] ([TestId])
GO
ALTER TABLE [dbo].[qb_Answer] CHECK CONSTRAINT [FK_qb_Answer_bq_Test]
GO
