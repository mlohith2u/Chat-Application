USE [master]
GO
/****** Object:  Database [ChatApp]    Script Date: 2/12/2020 8:52:41 AM ******/
CREATE DATABASE [ChatApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ChatApp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ChatApp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ChatApp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ChatApp_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ChatApp] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ChatApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ChatApp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ChatApp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ChatApp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ChatApp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ChatApp] SET ARITHABORT OFF 
GO
ALTER DATABASE [ChatApp] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ChatApp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ChatApp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ChatApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ChatApp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ChatApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ChatApp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ChatApp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ChatApp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ChatApp] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ChatApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ChatApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ChatApp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ChatApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ChatApp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ChatApp] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ChatApp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ChatApp] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ChatApp] SET  MULTI_USER 
GO
ALTER DATABASE [ChatApp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ChatApp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ChatApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ChatApp] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ChatApp] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ChatApp] SET QUERY_STORE = OFF
GO
USE [ChatApp]
GO
/****** Object:  Table [dbo].[A_U_Client]    Script Date: 2/12/2020 8:52:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[A_U_Client](
	[ID] [varchar](450) NOT NULL,
	[Secret] [varchar](max) NULL,
	[Name] [varchar](max) NULL,
	[ApplicationType] [int] NULL,
	[Active] [bit] NULL,
	[RefreshTokenLifetime] [int] NULL,
	[AllowedOrigin] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[A_U_FunctionMaster]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[A_U_FunctionMaster](
	[FunctionID] [int] NOT NULL,
	[FunctionName] [varchar](256) NULL,
	[CreatedBy] [varchar](100) NULL,
	[LastUpdated] [datetime2](7) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[A_U_Management]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[A_U_Management](
	[UserUID] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [nvarchar](50) NULL,
	[FullName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [varchar](max) NULL,
	[ConfirmPassword] [varchar](max) NULL,
	[DateofBirth] [datetime] NULL,
	[Qualification] [int] NULL,
	[Occupation] [int] NULL,
	[Address] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[UserRole] [int] NULL,
	[IsActive] [bit] NOT NULL,
	[LastUpdated] [datetime] NULL,
 CONSTRAINT [PK_A_U_Management] PRIMARY KEY CLUSTERED 
(
	[UserUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[A_U_MenuMaster]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[A_U_MenuMaster](
	[MenuIdentity] [int] IDENTITY(1,1) NOT NULL,
	[MenuID] [varchar](30) NOT NULL,
	[MenuName] [varchar](30) NOT NULL,
	[Parent_MenuID] [varchar](30) NOT NULL,
	[User_Roll] [int] NOT NULL,
	[MenuFileName] [varchar](100) NOT NULL,
	[MenuURL] [varchar](500) NOT NULL,
	[USE_YN] [char](1) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_A_U_MenuMaster] PRIMARY KEY CLUSTERED 
(
	[MenuIdentity] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[A_U_Token]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[A_U_Token](
	[ID] [varchar](450) NOT NULL,
	[Subject] [varchar](max) NULL,
	[ClientId] [varchar](max) NULL,
	[IssuedUTC] [datetime2](7) NULL,
	[ExpireUTC] [datetime2](7) NULL,
	[ProtectedTicket] [varchar](max) NULL,
 CONSTRAINT [PK_A_U_Token] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[A_WorkflowFormMaster]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[A_WorkflowFormMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FM_PKID] [int] NOT NULL,
	[FM_FormCode] [nvarchar](max) NULL,
	[FM_FormName] [nvarchar](max) NULL,
	[FM_WorkflowTime] [int] NULL,
	[FM_FormPath] [nvarchar](max) NULL,
	[FM_Notes] [nvarchar](max) NULL,
	[FM_Crby] [int] NULL,
	[FM_CrOn] [datetime2](7) NULL,
	[FM_Status] [nvarchar](max) NULL,
 CONSTRAINT [PK_A_WorkflowFormMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[A_WorkflowTransDetails]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[A_WorkflowTransDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[WTM_MasID] [int] NOT NULL,
	[WTD_TransID] [int] NULL,
	[WTD_InwardFileNo] [nvarchar](max) NULL,
	[WTD_TransDate] [datetime2](7) NULL,
	[WTD_TransFrom] [int] NULL,
	[WTD_To] [nvarchar](max) NULL,
	[WTD_Remarks] [nvarchar](max) NULL,
	[WTD_WFStatsID] [int] NULL,
	[WTD_WFActionID] [int] NULL,
	[WTD_SentBy] [int] NULL,
	[WTD_WFStatus] [nvarchar](max) NULL,
	[WTD_SentOn] [int] NULL,
 CONSTRAINT [PK_A_WorkflowTransDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[A_WorkflowTransMailBoxes]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[A_WorkflowTransMailBoxes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[WTM_MasID] [decimal](18, 2) NOT NULL,
	[WTM_TransID] [decimal](18, 2) NULL,
	[WTM_InwardFileNo] [nvarchar](max) NULL,
	[WTM_TrnFrom] [decimal](18, 2) NULL,
	[WTM_TrnTo] [decimal](18, 2) NULL,
	[WTM_UsrOrGrp] [nvarchar](max) NULL,
	[WTM_ReadFlg] [nvarchar](max) NULL,
	[WTM_TrnStatus] [nvarchar](max) NULL,
 CONSTRAINT [PK_A_WorkflowTransMailBoxes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[A_WorkflowTransMasters]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[A_WorkflowTransMasters](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[WTM_MasID] [int] NOT NULL,
	[WTM_WorkFlowID] [int] NULL,
	[WTM_DOCID] [int] NULL,
	[WTM_FormCode] [nvarchar](max) NULL,
	[WTM_Subject] [nvarchar](max) NULL,
	[WTM_AttachID] [int] NULL,
	[WTM_CrBy] [int] NULL,
	[WTM_IsDisposed] [int] NULL,
	[WTM_DisposedBy] [int] NULL,
	[WTM_WFProcessID] [int] NULL,
	[WTM_Status] [nvarchar](max) NULL,
 CONSTRAINT [PK_A_WorkflowTransMasters] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChatConversation]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatConversation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ConversationID] [nvarchar](50) NULL,
	[FromName] [nvarchar](100) NULL,
	[FromId] [nvarchar](100) NULL,
	[Message] [nvarchar](max) NULL,
	[ToName] [nvarchar](100) NULL,
	[ToId] [nchar](100) NULL,
	[Type] [varchar](20) NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK_ChatConversation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChatMaster]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CID] [nvarchar](50) NULL,
	[Date] [datetime] NULL,
	[FromName] [nvarchar](100) NULL,
	[FromId] [nvarchar](100) NULL,
	[ToName] [nvarchar](100) NULL,
	[ToId] [nvarchar](100) NULL,
	[IsOpened] [bit] NULL,
 CONSTRAINT [PK_ChatMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseImages]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseImages](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CourseID] [int] NULL,
	[CourseName] [nvarchar](50) NULL,
	[CourseIcons] [varbinary](max) NULL,
 CONSTRAINT [PK_CourseImages] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeLeaveDetails]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeLeaveDetails](
	[EmployeeLeaveDetailsID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [nvarchar](max) NULL,
	[LeaveType] [int] NULL,
	[OpeningBalance] [int] NULL,
	[LeaveUpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_EmployeeLeaveDetails] PRIMARY KEY CLUSTERED 
(
	[EmployeeLeaveDetailsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExaminationMaster]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExaminationMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Domain] [int] NULL,
	[Technology] [int] NULL,
	[Course] [int] NULL,
	[ExaminationName] [nvarchar](max) NULL,
	[Duration] [int] NULL,
	[IsEnabled] [bit] NOT NULL,
 CONSTRAINT [PK_ExaminationMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExamLevels]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamLevels](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ExaminationLevel] [nvarchar](max) NULL,
	[IsEnabled] [bit] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExternalLogin]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExternalLogin](
	[GID] [int] IDENTITY(1,1) NOT NULL,
	[Access Token] [nvarchar](max) NULL,
	[Email] [nvarchar](100) NULL,
	[Family Name] [nvarchar](50) NULL,
	[Given Name] [nvarchar](50) NULL,
	[Id] [nvarchar](50) NULL,
	[Name] [nvarchar](200) NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK_ExternalLogin] PRIMARY KEY CLUSTERED 
(
	[GID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FacultyImage]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FacultyImage](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserUID] [varchar](50) NULL,
	[DocumentName] [nvarchar](max) NULL,
	[DocumentType] [nvarchar](max) NULL,
	[Documents] [varbinary](max) NULL,
	[UpdatedOn] [datetime] NULL,
	[IsEnabled] [bit] NOT NULL,
	[FacultyID] [varchar](50) NULL,
	[FacultyName] [varbinary](max) NULL,
 CONSTRAINT [PK_FacultyImage] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FacultyMaster]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FacultyMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserUID] [int] NULL,
	[FacultyName] [varchar](max) NULL,
	[Qualification] [varchar](max) NULL,
	[DateOfBirth] [nchar](10) NULL,
	[EmailId] [nvarchar](max) NULL,
	[ContactNo] [nvarchar](50) NULL,
	[Experience] [nvarchar](max) NULL,
	[Skills] [nvarchar](max) NULL,
	[Languages] [nvarchar](max) NULL,
	[Interests] [nvarchar](max) NULL,
	[ProfilePicture] [varbinary](max) NULL,
	[IsEnabled] [bit] NOT NULL,
 CONSTRAINT [PK_FacultyMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FeedbackRating]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeedbackRating](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FacultyName] [varchar](max) NULL,
	[SkillWiseRating] [int] NULL,
	[TeachnigRating] [int] NULL,
	[ConductRating] [int] NULL,
	[IsEnabled] [bit] NULL,
 CONSTRAINT [PK_FeedbackRating] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Leave_StatusMaster]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Leave_StatusMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LeaveStatusName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Leave_StatusMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeaveHistoryMaster]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaveHistoryMaster](
	[LeaveHistoryMasterID] [int] IDENTITY(1,1) NOT NULL,
	[LeaveTypeID] [int] NULL,
	[TotalLeaveTaken] [varchar](50) NULL,
	[TotalLeaveRemaining] [varchar](50) NULL,
	[LeaveStartingDate] [datetime] NULL,
	[LeaveEndingDate] [datetime] NULL,
	[LeaveMonthlyDetails] [varchar](50) NULL,
	[LeaveCount] [varchar](50) NULL,
	[EmpID] [int] NULL,
	[LeaveCredited] [varchar](50) NULL,
	[LeaveDebited] [varchar](50) NULL,
 CONSTRAINT [PK_LeaveHistoryMaster] PRIMARY KEY CLUSTERED 
(
	[LeaveHistoryMasterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeaveList]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaveList](
	[LeaveConditionID] [int] IDENTITY(1,1) NOT NULL,
	[EmpID] [int] NULL,
	[LeaveTypeID] [int] NULL,
	[LeaveCredited] [varchar](50) NULL,
	[LeaveDebited] [varchar](50) NULL,
	[BalanceRemaining] [varchar](50) NULL,
	[BasicPayOnLeave] [varchar](50) NULL,
	[LeaveEncashed] [varchar](50) NULL,
	[LeaveStartingDate] [datetime] NULL,
	[LeaveEndingDate] [datetime] NULL,
	[AdvanceCredit] [varchar](50) NULL,
	[SalaryDeductionInPercentage] [varchar](50) NULL,
	[SalaryDeductionInRupees] [varchar](50) NULL,
	[MinLeave] [varchar](50) NULL,
	[MaxLeave] [varchar](50) NULL,
	[Reason] [varchar](50) NULL,
 CONSTRAINT [PK_LeaveConditionMaster] PRIMARY KEY CLUSTERED 
(
	[LeaveConditionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeaveMaster]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaveMaster](
	[LeaveMasterID] [int] IDENTITY(1,1) NOT NULL,
	[LeaveType] [varchar](max) NULL,
	[Days] [int] NULL,
 CONSTRAINT [PK_LeaveMaster] PRIMARY KEY CLUSTERED 
(
	[LeaveMasterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeaveUpdateCountDetails]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaveUpdateCountDetails](
	[LeaveCountID] [int] IDENTITY(1,1) NOT NULL,
	[LeaveType] [int] NULL,
	[LeaveUpdatedDate] [date] NULL,
	[NoOfDays] [varchar](50) NULL,
 CONSTRAINT [PK_LeaveUpdateCountDetails] PRIMARY KEY CLUSTERED 
(
	[LeaveCountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[message]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[message](
	[MessageID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [varchar](50) NULL,
	[Msg] [nvarchar](50) NULL,
 CONSTRAINT [PK_message] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Policytable]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Policytable](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PolicyType] [nvarchar](max) NULL,
	[Documents] [varbinary](max) NULL,
	[DocumentName] [varchar](max) NULL,
	[DocumentType] [varchar](max) NULL,
	[DocumentSize] [varchar](max) NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [varchar](max) NULL,
 CONSTRAINT [PK_Policytable] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SessionDetails]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SessionDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [varchar](50) NULL,
	[LoggedIn] [bit] NULL,
	[LoggedInTime] [datetime] NULL,
	[LoggedOutTime] [datetime] NULL,
 CONSTRAINT [PK_SessionDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentChapters]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentChapters](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StudentID] [int] NULL,
	[CourseID] [int] NULL,
	[ChapterID] [int] NULL,
	[Level1] [bit] NULL,
	[Level2] [bit] NULL,
	[Level3] [bit] NULL,
 CONSTRAINT [PK_StudentChapters] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentDocumentDetails]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentDocumentDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [nvarchar](50) NULL,
	[FileId] [int] NULL,
	[FolderId] [int] NULL,
	[DocumentName] [varchar](max) NULL,
	[Documents] [varbinary](max) NULL,
	[DocumentType] [nvarchar](max) NULL,
	[DocumentSize] [nvarchar](50) NULL,
 CONSTRAINT [PK_PatientDocumentDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentFilePlanDetails]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentFilePlanDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [varchar](50) NULL,
	[FileName] [varchar](max) NULL,
 CONSTRAINT [PK_PatientFilePlanDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentFolderDetails]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentFolderDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [nvarchar](50) NULL,
	[FileId] [int] NULL,
	[FolderName] [varchar](50) NULL,
	[Description] [varchar](max) NULL,
 CONSTRAINT [PK_PatientFolderDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentImage]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentImage](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StudentUID] [int] NULL,
	[DocumentName] [nvarchar](max) NULL,
	[DocumentType] [nvarchar](max) NULL,
	[Documents] [varbinary](max) NULL,
	[UpdatedOn] [datetime] NULL,
	[IsEnabled] [bit] NOT NULL,
 CONSTRAINT [PK_StudentImage] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentsTests]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentsTests](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NULL,
	[CourseId] [int] NULL,
	[ChapterId] [int] NULL,
	[MarksObtained] [int] NULL,
	[GradeObtained] [varchar](5) NULL,
	[IsEnable] [bit] NOT NULL,
	[Level] [varchar](50) NULL,
	[DomainId] [int] NULL,
	[TechnologyId] [int] NULL,
 CONSTRAINT [PK_StudentsTests] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentTests]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentTests](
	[ID] [nchar](10) NOT NULL,
	[StudentId] [int] NULL,
	[CourseId] [int] NULL,
	[TestName] [varchar](50) NULL,
	[MarksObtained] [int] NULL,
	[GradeObtained] [varchar](5) NULL,
	[IsEnabled] [bit] NULL,
 CONSTRAINT [PK_StudentTests] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudetTestPaperResult]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudetTestPaperResult](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[TestPaperId] [nvarchar](15) NULL,
	[TestPaperName] [varchar](50) NULL,
	[MarksObtained] [int] NULL,
	[GradeObtained] [varchar](5) NULL,
	[IsEnable] [bit] NOT NULL,
 CONSTRAINT [PK_StudetTestPaperResult_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCartDetails]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCartDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Domain] [int] NULL,
	[Technology] [int] NULL,
	[Student_Id] [int] NULL,
	[Duration] [int] NULL,
	[Price] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblCartDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblChapterMaster]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblChapterMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ChapterName] [nvarchar](500) NULL,
	[Domain] [int] NULL,
	[Technology] [int] NULL,
	[Course] [int] NULL,
	[Author] [varchar](200) NULL,
	[IsEnabled] [bit] NOT NULL,
 CONSTRAINT [PK_tblChapterMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCourseMaster]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCourseMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [nvarchar](500) NULL,
	[Domain] [int] NULL,
	[Technology] [int] NULL,
	[IsEnabled] [bit] NOT NULL,
	[Duration] [int] NULL,
	[Price] [int] NULL,
 CONSTRAINT [PK_tblCourseMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDomainMaster]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDomainMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DomainName] [varchar](100) NULL,
	[IsEnabled] [bit] NOT NULL,
 CONSTRAINT [PK_tblDomainMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDurationMaster]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDurationMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Duration] [nchar](100) NULL,
	[IsEnabled] [bit] NULL,
 CONSTRAINT [PK_tblDurationMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblEnrollDetails]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEnrollDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[USNNumber] [nvarchar](50) NULL,
	[Domain] [int] NULL,
	[Technology] [int] NULL,
	[Course] [int] NULL,
	[Duration] [int] NULL,
	[Price] [int] NULL,
	[StudentID] [int] NULL,
	[IsPaid] [bit] NOT NULL,
	[StartedOn] [datetime] NULL,
	[IsDefault] [bit] NOT NULL,
 CONSTRAINT [PK_tblEnrollDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblGenderMaster]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblGenderMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Gender] [nvarchar](50) NULL,
	[IsEnabled] [bit] NULL,
 CONSTRAINT [PK_tblGenderMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblLevelMaster]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLevelMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LevelName] [nvarchar](50) NULL,
	[IsEnabled] [bit] NOT NULL,
 CONSTRAINT [PK_tblLevelMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblOccupationMaster]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblOccupationMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Occupation] [nvarchar](50) NULL,
	[IsEnabled] [bit] NULL,
 CONSTRAINT [PK_tblOccupationMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblOptionMaster]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblOptionMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[QuestionId] [int] NULL,
	[Option] [varchar](max) NULL,
	[IsEnabled] [bit] NOT NULL,
 CONSTRAINT [PK_tblOptionMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPresentationMaster]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPresentationMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PresentationName] [varchar](200) NULL,
	[PresentationMode] [varchar](50) NULL,
	[Duration] [int] NULL,
	[IsEnabled] [bit] NULL,
	[Domain] [int] NULL,
	[Technology] [int] NULL,
	[Course] [int] NULL,
	[Chapter] [int] NULL,
	[Url] [varchar](max) NULL,
 CONSTRAINT [PK_tblPresentationMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPriceMaster]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPriceMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Price] [nvarchar](max) NULL,
	[DurationId] [int] NULL,
 CONSTRAINT [PK_tblPriceMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblQualificationMaster]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblQualificationMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Qualification] [nvarchar](50) NULL,
	[IsEnabled] [bit] NULL,
 CONSTRAINT [PK_tblQualificationMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblQuestionBankMaster]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblQuestionBankMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Domain] [int] NULL,
	[Technology] [int] NULL,
	[Course] [int] NULL,
	[QuestionBankName] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[Version] [varchar](50) NULL,
	[IsEnabled] [bit] NOT NULL,
	[Question] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblQuestionBankMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblQuestionbankQuestions]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblQuestionbankQuestions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[QuestionbankId] [int] NULL,
	[QuestionId] [int] NULL,
	[Answer] [nvarchar](max) NULL,
	[IsEnabled] [bit] NULL,
	[ChapterId] [int] NULL,
 CONSTRAINT [PK_tblQuestionbankQuestions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblQuestionMaster]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblQuestionMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Question] [varchar](max) NULL,
	[Answer] [nvarchar](max) NULL,
	[Domain] [int] NULL,
	[Technology] [int] NULL,
	[Chapter] [int] NULL,
	[Course] [int] NULL,
	[IsEnabled] [bit] NOT NULL,
	[LevelID] [int] NOT NULL,
	[ExamLevel] [int] NULL,
 CONSTRAINT [PK_tblQuestionMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblRoleMaster]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblRoleMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Role] [varchar](50) NULL,
	[IsEnabled] [bit] NOT NULL,
 CONSTRAINT [PK_tblRoleMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblStudentCourses]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblStudentCourses](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [nvarchar](50) NULL,
	[CourseId] [int] NULL,
	[CompletionStatus] [bit] NOT NULL,
	[StartedOn] [datetime] NULL,
	[CompletedOn] [datetime] NULL,
	[TechnologyId] [int] NULL,
	[DomainId] [int] NULL,
	[IsDefault] [bit] NOT NULL,
 CONSTRAINT [PK_tblStudentCourses] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblStudentDetails]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblStudentDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StudentUID] [nvarchar](50) NULL,
	[FullName] [varchar](200) NULL,
	[DateofBirth] [datetime] NULL,
	[Gender] [int] NULL,
	[Email] [nvarchar](200) NULL,
	[ContactNumber] [varchar](50) NULL,
	[Qualification] [int] NULL,
	[Occupation] [int] NULL,
	[Address] [nvarchar](400) NULL,
	[Password] [nvarchar](max) NULL,
	[Role] [int] NULL,
	[CreatedOn] [datetime] NOT NULL,
	[IsApproved] [bit] NULL,
	[IsEnabled] [bit] NOT NULL,
	[StreetAddress] [nvarchar](max) NULL,
	[CityAddress] [nchar](10) NULL,
 CONSTRAINT [PK_tblStudentDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblsubmitAnswers]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblsubmitAnswers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Question] [nvarchar](100) NULL,
	[Answer] [nvarchar](100) NULL,
	[UserId] [int] NULL,
	[Score] [int] NULL,
 CONSTRAINT [PK_tblsubmitAnswers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTechnologyMaster]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTechnologyMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TechnologyName] [nvarchar](200) NULL,
	[Domain] [int] NULL,
	[IsEnabled] [bit] NOT NULL,
	[Assignments] [int] NULL,
	[Rating] [float] NULL,
	[Duration] [int] NULL,
	[Images] [image] NULL,
 CONSTRAINT [PK_tblTechnologyMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTestMaster]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTestMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TestName] [varchar](50) NULL,
	[Domain] [int] NULL,
	[Technology] [int] NULL,
	[Course] [int] NULL,
	[Chapter] [int] NULL,
	[IsEnabled] [bit] NOT NULL,
	[Duration] [int] NULL,
	[TotalScore] [int] NULL,
 CONSTRAINT [PK_tblTestMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTestQuestionMaster]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTestQuestionMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Domain] [int] NULL,
	[Technology] [int] NULL,
	[Course] [int] NULL,
	[Chapter] [int] NULL,
	[Test] [int] NULL,
	[Question] [int] NULL,
	[Answer] [int] NULL,
	[IsEnabled] [bit] NOT NULL,
 CONSTRAINT [PK_tblTestQuestionMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestPaper]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestPaper](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TestPaperId] [nvarchar](10) NULL,
	[TestPaperName] [nvarchar](50) NULL,
	[Time] [nvarchar](50) NULL,
	[DomainId] [int] NULL,
	[TechnologyId] [int] NULL,
	[CourseId] [int] NULL,
	[ChapterId] [int] NULL,
	[QuestionId] [int] NULL,
	[Question] [nvarchar](max) NULL,
	[Answer] [nvarchar](max) NULL,
	[UserId] [int] NULL,
	[IsSaved] [bit] NULL,
	[LastUpdated] [datetime] NULL,
 CONSTRAINT [PK_TestPaper] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestPaperNames]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestPaperNames](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TestPaperId] [nvarchar](10) NULL,
	[TPName] [nvarchar](50) NULL,
	[Standard] [nvarchar](25) NULL,
	[LastUpdated] [datetime] NULL,
 CONSTRAINT [PK_TestPaperNames] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Token]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Token](
	[ID] [varchar](450) NOT NULL,
	[Subject] [varchar](max) NULL,
	[ClientId] [varchar](max) NULL,
	[IssuedUTC] [datetime2](7) NULL,
	[ExpireUTC] [datetime2](7) NULL,
	[ProtectedTicket] [varchar](max) NULL,
 CONSTRAINT [PK_Token] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionTable]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionTable](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [nvarchar](max) NULL,
	[TransactionId] [nvarchar](max) NULL,
	[TransactionStatus] [nvarchar](50) NULL,
	[StudentId] [int] NULL,
	[Date] [datetime] NULL,
	[CourseId] [int] NULL,
	[Hash] [nvarchar](max) NULL,
 CONSTRAINT [PK_TransactionTable] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UploadDocument]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UploadDocument](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] [int] NULL,
	[UploadType] [varchar](50) NULL,
	[DocumentName] [varchar](max) NULL,
	[DocumentType] [varchar](max) NULL,
	[DocumentSize] [varchar](max) NULL,
	[Documents] [varbinary](max) NULL,
	[Comments] [varchar](150) NULL,
	[UploadedBy] [varchar](50) NULL,
	[UploadedOn] [datetime2](7) NULL,
	[CourseID] [int] NULL,
	[ChapterID] [int] NULL,
	[TechnologyID] [int] NULL,
 CONSTRAINT [PK_UploadDocument] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[useractivity]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[useractivity](
	[OnlineID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [varchar](50) NULL,
	[ConnectionID] [varchar](50) NULL,
	[Status] [varchar](50) NULL,
	[Avatar] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAttendance]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAttendance](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[Time] [nvarchar](50) NULL,
	[Attendance] [bit] NULL,
 CONSTRAINT [PK_UserAttendance] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserBiometric]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserBiometric](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](50) NULL,
	[Finger] [varchar](max) NULL,
	[Authentication] [nvarchar](max) NULL,
	[IsEnabled] [bit] NOT NULL,
 CONSTRAINT [PK_UserBiometric] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VA_Workflow_Leave_Master]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VA_Workflow_Leave_Master](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MasID] [int] NOT NULL,
	[EmployeeId] [nvarchar](max) NULL,
	[EmployeeName] [nvarchar](max) NULL,
	[LeaveType] [int] NULL,
	[LeaveApplicationNo] [nvarchar](max) NULL,
	[OpeningBalance] [int] NULL,
	[FromDate] [nvarchar](max) NULL,
	[ToDate] [nvarchar](max) NULL,
	[LeaveTaken] [int] NULL,
	[ClosingBalance] [int] NULL,
	[StatusID] [int] NULL,
	[NoOfDays] [int] NULL,
	[LeaveAppliedDate] [datetime] NULL,
	[From_User] [nvarchar](max) NULL,
	[To_User] [nvarchar](max) NULL,
	[FormCode] [nvarchar](max) NULL,
	[LeaveSubject] [nvarchar](max) NULL,
	[CreatedUser] [nvarchar](max) NULL,
	[Trans_ID] [varchar](50) NULL,
	[Approvalone] [bit] NULL,
	[Approvaltwo] [bit] NULL,
	[Approvalthree] [bit] NULL,
	[ApprovaloneDate] [nvarchar](max) NULL,
	[ApprovaltwoDate] [nvarchar](max) NULL,
	[ApprovalthreeDate] [nvarchar](max) NULL,
	[LastUpdatedDate] [nvarchar](max) NULL,
	[LeavePurpose] [nvarchar](max) NULL,
	[ContactNumber] [nvarchar](50) NULL,
 CONSTRAINT [PK_WF_LeaveStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Workflow_Comment_HistoryTable]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workflow_Comment_HistoryTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserUID] [int] NULL,
	[MailId] [int] NULL,
	[WorkflowType] [int] NULL,
	[Comments] [nvarchar](max) NULL,
	[CommentedUser] [nvarchar](max) NULL,
	[ToUser] [nvarchar](max) NULL,
 CONSTRAINT [PK_Workflow_Comment_HistoryTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkflowStageMaster]    Script Date: 2/12/2020 8:52:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkflowStageMaster](
	[ID] [int] NOT NULL,
	[WorkflowType] [nvarchar](50) NULL,
	[WorkflowStage] [nvarchar](100) NULL,
 CONSTRAINT [PK_WorkflowStageMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[A_U_Management] ON 

INSERT [dbo].[A_U_Management] ([UserUID], [StudentId], [FullName], [Email], [Password], [ConfirmPassword], [DateofBirth], [Qualification], [Occupation], [Address], [PhoneNumber], [UserRole], [IsActive], [LastUpdated]) VALUES (1, N'CID0000001', N'lohith m', N'lohith@srichidtechnologies.com', N'1000:RuPtN7mJiOZuT4wYtiD9c5MSRHPTJb8Q:vZsJ1wvsQyxJ+eoaWvn6Fg0HTxpzFiPb', NULL, NULL, NULL, NULL, NULL, N'7795443373', 3, 1, CAST(N'2020-02-09T19:58:36.380' AS DateTime))
INSERT [dbo].[A_U_Management] ([UserUID], [StudentId], [FullName], [Email], [Password], [ConfirmPassword], [DateofBirth], [Qualification], [Occupation], [Address], [PhoneNumber], [UserRole], [IsActive], [LastUpdated]) VALUES (3, N'CID0000003', N'Jai', N'Jai@yahoo.com', N'1000:zpIBMZO6mCVPeG1Oh865OouoioygNGeS:DZizvVNm6dKbV2PG4g1iVO/UHRASOl58', NULL, NULL, NULL, NULL, NULL, N'4644adfaf', 3, 1, CAST(N'2020-02-10T00:34:44.250' AS DateTime))
INSERT [dbo].[A_U_Management] ([UserUID], [StudentId], [FullName], [Email], [Password], [ConfirmPassword], [DateofBirth], [Qualification], [Occupation], [Address], [PhoneNumber], [UserRole], [IsActive], [LastUpdated]) VALUES (5, N'CID0000004', N'Ashok asd', N'Ashok1@gmail.com', N'1000:APj0mjQYCrPaCwNrL+XY3ZRUqOpwYlzg:WZOHJ37/IbBlV5XGzwpJHmPhtl0hFfxk', NULL, NULL, NULL, NULL, NULL, N'662626222', 3, 1, CAST(N'2020-02-10T00:52:55.190' AS DateTime))
INSERT [dbo].[A_U_Management] ([UserUID], [StudentId], [FullName], [Email], [Password], [ConfirmPassword], [DateofBirth], [Qualification], [Occupation], [Address], [PhoneNumber], [UserRole], [IsActive], [LastUpdated]) VALUES (6, N'CID0000005', N'Emil l', N'Emil@gmail.com', N'1000:iPlGq13tKcZP5lpYnK9hEUrWf6hbrfH4:AKzZmouPZO+IQgMlIAetj87yp8ebhUBf', NULL, NULL, NULL, NULL, NULL, N'88849454564', 3, 1, CAST(N'2020-02-10T00:54:35.653' AS DateTime))
SET IDENTITY_INSERT [dbo].[A_U_Management] OFF
SET IDENTITY_INSERT [dbo].[ChatConversation] ON 

INSERT [dbo].[ChatConversation] ([ID], [ConversationID], [FromName], [FromId], [Message], [ToName], [ToId], [Type], [Date]) VALUES (1, NULL, NULL, N'CID0000004', N'hello', NULL, N'CID0000001                                                                                          ', NULL, CAST(N'2020-02-10T08:49:25.120' AS DateTime))
INSERT [dbo].[ChatConversation] ([ID], [ConversationID], [FromName], [FromId], [Message], [ToName], [ToId], [Type], [Date]) VALUES (2, NULL, NULL, N'CID0000004', N'hello', NULL, N'CID0000001                                                                                          ', NULL, CAST(N'2020-02-10T08:50:30.527' AS DateTime))
INSERT [dbo].[ChatConversation] ([ID], [ConversationID], [FromName], [FromId], [Message], [ToName], [ToId], [Type], [Date]) VALUES (3, NULL, NULL, N'CID0000004', N'dddd ', NULL, N'CID0000001                                                                                          ', NULL, CAST(N'2020-02-11T07:38:11.940' AS DateTime))
INSERT [dbo].[ChatConversation] ([ID], [ConversationID], [FromName], [FromId], [Message], [ToName], [ToId], [Type], [Date]) VALUES (4, NULL, NULL, N'CID0000004', N'lll', NULL, N'CID0000001                                                                                          ', NULL, CAST(N'2020-02-11T08:05:27.680' AS DateTime))
INSERT [dbo].[ChatConversation] ([ID], [ConversationID], [FromName], [FromId], [Message], [ToName], [ToId], [Type], [Date]) VALUES (5, NULL, NULL, N'CID0000004', N'lll', NULL, N'CID0000001                                                                                          ', NULL, CAST(N'2020-02-11T08:10:43.430' AS DateTime))
INSERT [dbo].[ChatConversation] ([ID], [ConversationID], [FromName], [FromId], [Message], [ToName], [ToId], [Type], [Date]) VALUES (6, NULL, NULL, N'CID0000004', N'lll', NULL, N'CID0000001                                                                                          ', NULL, CAST(N'2020-02-11T08:11:26.230' AS DateTime))
INSERT [dbo].[ChatConversation] ([ID], [ConversationID], [FromName], [FromId], [Message], [ToName], [ToId], [Type], [Date]) VALUES (7, NULL, NULL, N'CID0000004', N'hello', NULL, N'CID0000003                                                                                          ', NULL, CAST(N'2020-02-11T11:18:47.670' AS DateTime))
INSERT [dbo].[ChatConversation] ([ID], [ConversationID], [FromName], [FromId], [Message], [ToName], [ToId], [Type], [Date]) VALUES (8, NULL, NULL, N'CID0000001', N'lll', NULL, N'CID0000004                                                                                          ', NULL, CAST(N'2020-02-11T11:24:48.907' AS DateTime))
INSERT [dbo].[ChatConversation] ([ID], [ConversationID], [FromName], [FromId], [Message], [ToName], [ToId], [Type], [Date]) VALUES (9, NULL, NULL, N'CID0000001', N'lll', NULL, N'CID0000005                                                                                          ', NULL, CAST(N'2020-02-11T11:25:02.737' AS DateTime))
INSERT [dbo].[ChatConversation] ([ID], [ConversationID], [FromName], [FromId], [Message], [ToName], [ToId], [Type], [Date]) VALUES (10, NULL, NULL, N'CID0000001', N'lll', NULL, N'CID0000003                                                                                          ', NULL, CAST(N'2020-02-11T11:25:08.510' AS DateTime))
INSERT [dbo].[ChatConversation] ([ID], [ConversationID], [FromName], [FromId], [Message], [ToName], [ToId], [Type], [Date]) VALUES (11, NULL, NULL, N'CID0000001', N'lojkkk', NULL, N'CID0000004                                                                                          ', NULL, CAST(N'2020-02-11T11:25:57.650' AS DateTime))
INSERT [dbo].[ChatConversation] ([ID], [ConversationID], [FromName], [FromId], [Message], [ToName], [ToId], [Type], [Date]) VALUES (14, NULL, NULL, N'CID0000001', N' ', NULL, N'CID0000004                                                                                          ', NULL, CAST(N'2020-02-12T01:07:34.200' AS DateTime))
INSERT [dbo].[ChatConversation] ([ID], [ConversationID], [FromName], [FromId], [Message], [ToName], [ToId], [Type], [Date]) VALUES (15, NULL, NULL, N'CID0000001', N'sdvdsv', NULL, NULL, NULL, CAST(N'2020-02-12T01:10:49.583' AS DateTime))
INSERT [dbo].[ChatConversation] ([ID], [ConversationID], [FromName], [FromId], [Message], [ToName], [ToId], [Type], [Date]) VALUES (16, NULL, NULL, N'CID0000001', N'dd', NULL, N'CID0000004                                                                                          ', NULL, CAST(N'2020-02-12T01:11:26.723' AS DateTime))
INSERT [dbo].[ChatConversation] ([ID], [ConversationID], [FromName], [FromId], [Message], [ToName], [ToId], [Type], [Date]) VALUES (17, NULL, NULL, N'CID0000004', N'cx', NULL, N'CID0000003                                                                                          ', NULL, CAST(N'2020-02-12T01:15:46.127' AS DateTime))
INSERT [dbo].[ChatConversation] ([ID], [ConversationID], [FromName], [FromId], [Message], [ToName], [ToId], [Type], [Date]) VALUES (18, NULL, NULL, N'CID0000004', N'hello', NULL, N'CID0000001                                                                                          ', NULL, CAST(N'2020-02-12T01:16:34.827' AS DateTime))
INSERT [dbo].[ChatConversation] ([ID], [ConversationID], [FromName], [FromId], [Message], [ToName], [ToId], [Type], [Date]) VALUES (19, NULL, NULL, N'CID0000004', N'hi', NULL, N'CID0000001                                                                                          ', NULL, CAST(N'2020-02-12T05:28:09.590' AS DateTime))
INSERT [dbo].[ChatConversation] ([ID], [ConversationID], [FromName], [FromId], [Message], [ToName], [ToId], [Type], [Date]) VALUES (20, NULL, NULL, N'CID0000001', N'how r u', NULL, N'CID0000004                                                                                          ', NULL, CAST(N'2020-02-12T05:28:26.150' AS DateTime))
INSERT [dbo].[ChatConversation] ([ID], [ConversationID], [FromName], [FromId], [Message], [ToName], [ToId], [Type], [Date]) VALUES (21, NULL, NULL, N'CID0000001', N'hello', NULL, N'CID0000004                                                                                          ', NULL, CAST(N'2020-02-12T07:24:50.210' AS DateTime))
INSERT [dbo].[ChatConversation] ([ID], [ConversationID], [FromName], [FromId], [Message], [ToName], [ToId], [Type], [Date]) VALUES (22, NULL, NULL, N'CID0000004', N'hi', NULL, N'CID0000001                                                                                          ', NULL, CAST(N'2020-02-12T07:25:09.963' AS DateTime))
INSERT [dbo].[ChatConversation] ([ID], [ConversationID], [FromName], [FromId], [Message], [ToName], [ToId], [Type], [Date]) VALUES (23, NULL, NULL, N'CID0000001', N'gm', NULL, N'CID0000004                                                                                          ', NULL, CAST(N'2020-02-12T07:25:28.187' AS DateTime))
INSERT [dbo].[ChatConversation] ([ID], [ConversationID], [FromName], [FromId], [Message], [ToName], [ToId], [Type], [Date]) VALUES (24, NULL, NULL, N'CID0000004', N'hh', NULL, N'CID0000001                                                                                          ', NULL, CAST(N'2020-02-12T07:36:02.467' AS DateTime))
INSERT [dbo].[ChatConversation] ([ID], [ConversationID], [FromName], [FromId], [Message], [ToName], [ToId], [Type], [Date]) VALUES (25, NULL, NULL, N'CID0000004', N'vv', NULL, N'CID0000001                                                                                          ', NULL, CAST(N'2020-02-12T07:38:22.810' AS DateTime))
INSERT [dbo].[ChatConversation] ([ID], [ConversationID], [FromName], [FromId], [Message], [ToName], [ToId], [Type], [Date]) VALUES (26, NULL, NULL, N'CID0000004', N'ss', NULL, N'CID0000001                                                                                          ', NULL, CAST(N'2020-02-12T07:39:50.693' AS DateTime))
INSERT [dbo].[ChatConversation] ([ID], [ConversationID], [FromName], [FromId], [Message], [ToName], [ToId], [Type], [Date]) VALUES (27, NULL, NULL, N'CID0000001', N'good morning', NULL, N'CID0000004                                                                                          ', NULL, CAST(N'2020-02-12T07:41:29.550' AS DateTime))
SET IDENTITY_INSERT [dbo].[ChatConversation] OFF
SET IDENTITY_INSERT [dbo].[SessionDetails] ON 

INSERT [dbo].[SessionDetails] ([Id], [UserId], [LoggedIn], [LoggedInTime], [LoggedOutTime]) VALUES (1, N'CID0000001', 1, CAST(N'2020-02-09T22:38:28.807' AS DateTime), NULL)
INSERT [dbo].[SessionDetails] ([Id], [UserId], [LoggedIn], [LoggedInTime], [LoggedOutTime]) VALUES (2, N'CID0000001', 1, CAST(N'2020-02-09T22:38:31.190' AS DateTime), NULL)
INSERT [dbo].[SessionDetails] ([Id], [UserId], [LoggedIn], [LoggedInTime], [LoggedOutTime]) VALUES (3, N'CID0000003', 1, CAST(N'2020-02-10T00:37:25.150' AS DateTime), NULL)
INSERT [dbo].[SessionDetails] ([Id], [UserId], [LoggedIn], [LoggedInTime], [LoggedOutTime]) VALUES (4, N'CID0000001', 1, CAST(N'2020-02-10T00:38:24.670' AS DateTime), NULL)
INSERT [dbo].[SessionDetails] ([Id], [UserId], [LoggedIn], [LoggedInTime], [LoggedOutTime]) VALUES (5, N'CID0000004', 1, CAST(N'2020-02-10T00:53:08.990' AS DateTime), NULL)
INSERT [dbo].[SessionDetails] ([Id], [UserId], [LoggedIn], [LoggedInTime], [LoggedOutTime]) VALUES (6, N'CID0000005', 1, CAST(N'2020-02-10T00:54:53.257' AS DateTime), NULL)
INSERT [dbo].[SessionDetails] ([Id], [UserId], [LoggedIn], [LoggedInTime], [LoggedOutTime]) VALUES (7, N'CID0000004', 1, CAST(N'2020-02-10T07:09:13.390' AS DateTime), NULL)
INSERT [dbo].[SessionDetails] ([Id], [UserId], [LoggedIn], [LoggedInTime], [LoggedOutTime]) VALUES (8, NULL, 1, CAST(N'2020-02-10T07:10:18.040' AS DateTime), NULL)
INSERT [dbo].[SessionDetails] ([Id], [UserId], [LoggedIn], [LoggedInTime], [LoggedOutTime]) VALUES (9, NULL, 1, CAST(N'2020-02-10T07:10:28.420' AS DateTime), NULL)
INSERT [dbo].[SessionDetails] ([Id], [UserId], [LoggedIn], [LoggedInTime], [LoggedOutTime]) VALUES (10, N'CID0000004', 1, CAST(N'2020-02-10T07:10:41.887' AS DateTime), NULL)
INSERT [dbo].[SessionDetails] ([Id], [UserId], [LoggedIn], [LoggedInTime], [LoggedOutTime]) VALUES (11, N'CID0000001', 1, CAST(N'2020-02-11T11:24:09.733' AS DateTime), NULL)
INSERT [dbo].[SessionDetails] ([Id], [UserId], [LoggedIn], [LoggedInTime], [LoggedOutTime]) VALUES (12, N'CID0000004', 1, CAST(N'2020-02-11T11:30:48.473' AS DateTime), NULL)
INSERT [dbo].[SessionDetails] ([Id], [UserId], [LoggedIn], [LoggedInTime], [LoggedOutTime]) VALUES (13, N'CID0000001', 1, CAST(N'2020-02-11T11:33:59.097' AS DateTime), NULL)
INSERT [dbo].[SessionDetails] ([Id], [UserId], [LoggedIn], [LoggedInTime], [LoggedOutTime]) VALUES (14, N'CID0000004', 1, CAST(N'2020-02-12T01:13:37.400' AS DateTime), NULL)
INSERT [dbo].[SessionDetails] ([Id], [UserId], [LoggedIn], [LoggedInTime], [LoggedOutTime]) VALUES (15, N'CID0000004', 1, CAST(N'2020-02-12T01:15:06.590' AS DateTime), NULL)
INSERT [dbo].[SessionDetails] ([Id], [UserId], [LoggedIn], [LoggedInTime], [LoggedOutTime]) VALUES (16, NULL, 1, CAST(N'2020-02-12T05:26:42.570' AS DateTime), NULL)
INSERT [dbo].[SessionDetails] ([Id], [UserId], [LoggedIn], [LoggedInTime], [LoggedOutTime]) VALUES (17, N'CID0000001', 1, CAST(N'2020-02-12T05:26:47.017' AS DateTime), NULL)
INSERT [dbo].[SessionDetails] ([Id], [UserId], [LoggedIn], [LoggedInTime], [LoggedOutTime]) VALUES (18, N'CID0000004', 1, CAST(N'2020-02-12T05:27:55.020' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[SessionDetails] OFF
SET IDENTITY_INSERT [dbo].[tblStudentDetails] ON 

INSERT [dbo].[tblStudentDetails] ([ID], [StudentUID], [FullName], [DateofBirth], [Gender], [Email], [ContactNumber], [Qualification], [Occupation], [Address], [Password], [Role], [CreatedOn], [IsApproved], [IsEnabled], [StreetAddress], [CityAddress]) VALUES (1, N'CID0000001', N'lohith m', NULL, NULL, N'lohith@srichidtechnologies.com', N'7795443373', NULL, NULL, NULL, N'1000:RuPtN7mJiOZuT4wYtiD9c5MSRHPTJb8Q:vZsJ1wvsQyxJ+eoaWvn6Fg0HTxpzFiPb', NULL, CAST(N'2020-02-09T19:58:39.917' AS DateTime), NULL, 1, NULL, NULL)
INSERT [dbo].[tblStudentDetails] ([ID], [StudentUID], [FullName], [DateofBirth], [Gender], [Email], [ContactNumber], [Qualification], [Occupation], [Address], [Password], [Role], [CreatedOn], [IsApproved], [IsEnabled], [StreetAddress], [CityAddress]) VALUES (2, N'CID0000002', N'afaf af', NULL, NULL, N'adsfaf', N'4644adfaf', NULL, NULL, NULL, N'1000:Jc2ZFQIXuUWTWr806lI9P69KkRTXSEAc:e51xHGti99aQsn4fbaOtHwW4fQGZhBQH', NULL, CAST(N'2020-02-10T00:34:45.277' AS DateTime), NULL, 1, NULL, NULL)
INSERT [dbo].[tblStudentDetails] ([ID], [StudentUID], [FullName], [DateofBirth], [Gender], [Email], [ContactNumber], [Qualification], [Occupation], [Address], [Password], [Role], [CreatedOn], [IsApproved], [IsEnabled], [StreetAddress], [CityAddress]) VALUES (3, N'CID0000002', N'afaf af', NULL, NULL, N'adsfaf', N'4644adfaf', NULL, NULL, NULL, N'1000:zpIBMZO6mCVPeG1Oh865OouoioygNGeS:DZizvVNm6dKbV2PG4g1iVO/UHRASOl58', NULL, CAST(N'2020-02-10T00:34:45.277' AS DateTime), NULL, 1, NULL, NULL)
INSERT [dbo].[tblStudentDetails] ([ID], [StudentUID], [FullName], [DateofBirth], [Gender], [Email], [ContactNumber], [Qualification], [Occupation], [Address], [Password], [Role], [CreatedOn], [IsApproved], [IsEnabled], [StreetAddress], [CityAddress]) VALUES (4, N'CID0000004', N'Ashok ', NULL, NULL, N'Ashok@gmail.com', N'', NULL, NULL, NULL, N'1000:8sUrm7khCeNsDBvwtoaNZlwSleAbyh+z:Xiil4sUXZFCcq13IzK1+HyUBE60Zb+T6', NULL, CAST(N'2020-02-10T00:51:11.180' AS DateTime), NULL, 1, NULL, NULL)
INSERT [dbo].[tblStudentDetails] ([ID], [StudentUID], [FullName], [DateofBirth], [Gender], [Email], [ContactNumber], [Qualification], [Occupation], [Address], [Password], [Role], [CreatedOn], [IsApproved], [IsEnabled], [StreetAddress], [CityAddress]) VALUES (5, N'CID0000004', N'Ashok asd', NULL, NULL, N'Ashok1@gmail.com', N'662626222', NULL, NULL, NULL, N'1000:APj0mjQYCrPaCwNrL+XY3ZRUqOpwYlzg:WZOHJ37/IbBlV5XGzwpJHmPhtl0hFfxk', NULL, CAST(N'2020-02-10T00:52:55.203' AS DateTime), NULL, 1, NULL, NULL)
INSERT [dbo].[tblStudentDetails] ([ID], [StudentUID], [FullName], [DateofBirth], [Gender], [Email], [ContactNumber], [Qualification], [Occupation], [Address], [Password], [Role], [CreatedOn], [IsApproved], [IsEnabled], [StreetAddress], [CityAddress]) VALUES (6, N'CID0000005', N'Emil l', NULL, NULL, N'Emil@gmail.com', N'88849454564', NULL, NULL, NULL, N'1000:iPlGq13tKcZP5lpYnK9hEUrWf6hbrfH4:AKzZmouPZO+IQgMlIAetj87yp8ebhUBf', NULL, CAST(N'2020-02-10T00:54:35.713' AS DateTime), NULL, 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblStudentDetails] OFF
ALTER TABLE [dbo].[FacultyMaster] ADD  CONSTRAINT [DF_FacultyMaster_IsEnabled]  DEFAULT ((1)) FOR [IsEnabled]
GO
ALTER TABLE [dbo].[tblChapterMaster] ADD  CONSTRAINT [DF_tblChapterMaster_IsEnabled]  DEFAULT ((1)) FOR [IsEnabled]
GO
ALTER TABLE [dbo].[tblCourseMaster] ADD  CONSTRAINT [DF_tblCourseMaster_IsEnabled]  DEFAULT ((1)) FOR [IsEnabled]
GO
ALTER TABLE [dbo].[tblDomainMaster] ADD  CONSTRAINT [DF_tblDomainMaster_IsEnabled]  DEFAULT ((1)) FOR [IsEnabled]
GO
ALTER TABLE [dbo].[tblDurationMaster] ADD  CONSTRAINT [DF_tblDurationMaster_IsEnabled]  DEFAULT ((1)) FOR [IsEnabled]
GO
ALTER TABLE [dbo].[tblEnrollDetails] ADD  CONSTRAINT [DF_tblEnrollDetails_IsPaid]  DEFAULT ((1)) FOR [IsPaid]
GO
ALTER TABLE [dbo].[tblEnrollDetails] ADD  CONSTRAINT [DF_tblEnrollDetails_IsDefault]  DEFAULT ((0)) FOR [IsDefault]
GO
ALTER TABLE [dbo].[tblLevelMaster] ADD  CONSTRAINT [DF_tblLevelMaster_IsEnabled]  DEFAULT ((1)) FOR [IsEnabled]
GO
ALTER TABLE [dbo].[tblOptionMaster] ADD  CONSTRAINT [DF_tblOptionMaster_IsEnabled]  DEFAULT ((1)) FOR [IsEnabled]
GO
ALTER TABLE [dbo].[tblQuestionBankMaster] ADD  CONSTRAINT [DF_tblQuestionBankMaster_IsEnabled]  DEFAULT ((1)) FOR [IsEnabled]
GO
ALTER TABLE [dbo].[tblQuestionMaster] ADD  CONSTRAINT [DF_tblQuestionMaster_IsEnabled]  DEFAULT ((1)) FOR [IsEnabled]
GO
ALTER TABLE [dbo].[tblRoleMaster] ADD  CONSTRAINT [DF_tblRoleMaster_IsEnabled]  DEFAULT ((1)) FOR [IsEnabled]
GO
ALTER TABLE [dbo].[tblStudentCourses] ADD  CONSTRAINT [DF_tblStudentCourses_CompletionStatus]  DEFAULT ((0)) FOR [CompletionStatus]
GO
ALTER TABLE [dbo].[tblStudentCourses] ADD  CONSTRAINT [DF_tblStudentCourses_IsDefault]  DEFAULT ((0)) FOR [IsDefault]
GO
ALTER TABLE [dbo].[tblStudentDetails] ADD  CONSTRAINT [DF_tblStudentDetails_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[tblStudentDetails] ADD  CONSTRAINT [DF_tblStudentDetails_IsEnabled]  DEFAULT ((0)) FOR [IsEnabled]
GO
ALTER TABLE [dbo].[tblTechnologyMaster] ADD  CONSTRAINT [DF_tblTechnologyMaster_IsEnabled]  DEFAULT ((1)) FOR [IsEnabled]
GO
ALTER TABLE [dbo].[tblTestMaster] ADD  CONSTRAINT [DF_tblTestMaster_IsEnabled]  DEFAULT ((1)) FOR [IsEnabled]
GO
ALTER TABLE [dbo].[tblTestQuestionMaster] ADD  CONSTRAINT [DF_tblTestQuestionMaster_IsEnabled]  DEFAULT ((1)) FOR [IsEnabled]
GO
ALTER TABLE [dbo].[LeaveHistoryMaster]  WITH CHECK ADD  CONSTRAINT [FK_LeaveHistoryMaster_LeaveMaster] FOREIGN KEY([LeaveTypeID])
REFERENCES [dbo].[LeaveMaster] ([LeaveMasterID])
GO
ALTER TABLE [dbo].[LeaveHistoryMaster] CHECK CONSTRAINT [FK_LeaveHistoryMaster_LeaveMaster]
GO
ALTER TABLE [dbo].[LeaveList]  WITH CHECK ADD  CONSTRAINT [FK_LeaveList_LeaveMaster] FOREIGN KEY([LeaveTypeID])
REFERENCES [dbo].[LeaveMaster] ([LeaveMasterID])
GO
ALTER TABLE [dbo].[LeaveList] CHECK CONSTRAINT [FK_LeaveList_LeaveMaster]
GO
/****** Object:  StoredProcedure [dbo].[Proc_IsValidUser]    Script Date: 2/12/2020 8:52:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Reddy
-- Create date: 22-07-2017
-- Description:	Test
-- =============================================
CREATE PROCEDURE [dbo].[Proc_IsValidUser]
	@Email nvarchar(200),
	@Password nvarchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select * from tblStudentDetails where Email=@Email and Password =@Password ;
   
END











GO
/****** Object:  StoredProcedure [dbo].[Proc_MailBox_ChangeStatus]    Script Date: 2/12/2020 8:52:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Proc_MailBox_ChangeStatus]
	@WTM_MasID Numeric(5),
	@WTM_TransID Numeric(5),
	@WTM_TrnTo Numeric(5),
	@WTM_TrnStatus Char(1),
	@iRetOperation Int Output
As
Begin Transaction 
If Exists(Select * From WorkFlowTransMailBoxes where WTM_MasID = @WTM_MasID And WTM_TransID=@WTM_TransID)
Begin
	Update WorkFlowTransMailBoxes
	Set WTM_TrnStatus = upper(@WTM_TrnStatus)
	Where WTM_MasID = @WTM_MasID And WTM_TransID=@WTM_TransID
	
	Set @iRetOperation = 1           
	 IF @@ERROR <> 0            
	 BEGIN      
	   -- Rollback the transaction            
	    ROLLBACK            
	    -- Raise an error and return            
	    RAISERROR ('Error in Inserting Record', 16, 1)            
	    RETURN            
 	 End
End
Commit























GO
/****** Object:  StoredProcedure [dbo].[PROC_Menu_Delete]    Script Date: 2/12/2020 8:52:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PROC_Menu_Delete]                                                
   ( @MenuIdentity   Int=0 )                                                          
AS                                                                  
BEGIN         
        DELETE FROM A_U_MenuMaster WHERE MenuIdentity=@MenuIdentity               
              
END 







GO
/****** Object:  StoredProcedure [dbo].[PROC_Menu_Insert]    Script Date: 2/12/2020 8:52:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PROC_Menu_Insert]                                                
   (                         
     @MenuID            VARCHAR(30)     = '',  
     @MenuName          VARCHAR(30)     = '',  
     @Parent_MenuID     VARCHAR(30)     = '',  
     @User_Roll         INT     = '',  
     @MenuFileName      VARCHAR(100)     = '',  
     @MenuURL           VARCHAR(500)     = '',  
     @USE_YN            VARCHAR(1)     = ''  
      )                                                          
AS                                                                  
BEGIN         
        IF NOT EXISTS (SELECT * FROM A_U_MenuMaster WHERE MenuID=@MenuID and MenuName=@MenuName)  
            BEGIN  
  
                    INSERT INTO A_U_MenuMaster  
                    (  MenuID ,     MenuName ,     Parent_MenuID  ,    User_Roll,      MenuFileName ,     
                     MenuURL ,       USE_YN ,      CreatedDate )  
                     VALUES (  @MenuID ,     @MenuName ,       @Parent_MenuID  ,       @User_Roll,     @MenuFileName ,     
                     @MenuURL ,       @USE_YN ,        GETDATE())  
                                 
                    Select 'Inserted' as results  
                          
            END  
         ELSE  
             BEGIN  
                     Select 'Exists' as results  
              END  
  
END







GO
/****** Object:  StoredProcedure [dbo].[PROC_Menu_Select]    Script Date: 2/12/2020 8:52:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PROC_Menu_Select]                                                
   (                              
     @MenuID           VARCHAR(30)     = '',  
     @MenuName         VARCHAR(30)     = ''   
      )                                                          
AS                                                                  
BEGIN      
  
         Select MenuIdentity ,    
               MenuID ,    
               MenuName ,  
               Parent_MenuID  ,  
               User_Roll,   
               MenuFileName ,     
               MenuURL ,    
               USE_YN ,    
               CreatedDate   
            FROM   
               A_U_MenuMaster
            WHERE  
                MenuID like  @MenuID +'%'  
                AND MenuName like @MenuName +'%'  
            --  AND USE_YN ='Y'  
            ORDER BY  
                MenuName,MenuID   
      
END







GO
/****** Object:  StoredProcedure [dbo].[PROC_Menu_Update]    Script Date: 2/12/2020 8:52:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PROC_Menu_Update]                                                
   ( @MenuIdentity             Int=0,                             
     @MenuID            VARCHAR(30)     = '',  
     @MenuName          VARCHAR(30)     = '',  
     @Parent_MenuID     VARCHAR(30)     = '',  
     @User_Roll         INT     = '',  
     @MenuFileName      VARCHAR(100)     = '',  
     @MenuURL           VARCHAR(500)     = '',  
     @USE_YN            VARCHAR(1)     = ''  
      )                                                          
AS                                                                  
BEGIN         
        IF  EXISTS (SELECT * FROM A_U_MenuMaster WHERE MenuIdentity=@MenuIdentity )  
            BEGIN  
                    UPDATE A_U_MenuMaster SET  
                            MenuID=@MenuID,  
                            MenuName=@MenuName,  
                            Parent_MenuID=@Parent_MenuID,  
                            User_Roll=@User_Roll,  
                            MenuFileName=@MenuFileName,  
                            MenuURL=@MenuURL,  
                            USE_YN=@USE_YN  
                    WHERE  
                    MenuIdentity=@MenuIdentity  
                                 
                    Select 'updated' as results                       
            END  
         ELSE  
             BEGIN  
                     Select 'Not Exists' as results  
              END  
END







GO
/****** Object:  StoredProcedure [dbo].[PROC_MenubyUserRole_Select]    Script Date: 2/12/2020 8:52:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PROC_MenubyUserRole_Select]     
(    
     @Role            VARCHAR(30)     = ''   
      )         
AS                                                                  
BEGIN      
      Select MenuIdentity ,    
               MenuID ,    
               MenuName ,  
               Parent_MenuID  ,  
               User_Roll,   
               MenuFileName ,     
               MenuURL ,    
               USE_YN ,    
               CreatedDate   
            FROM   
                A_U_MenuMaster   
            WHERE             
                 User_Roll = @Role  
                AND USE_YN ='Y'  
            ORDER BY  
                MenuName,MenuID       
          
END







GO
/****** Object:  StoredProcedure [dbo].[PROC_UserRoles_Select]    Script Date: 2/12/2020 8:52:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PROC_UserRoles_Select]     
(    
     @Role             VARCHAR(30)     = ''   
      )         
AS                                                                  
BEGIN         
         Select ID,Role  
            FROM   
                tblRoleMaster   
            WHERE  
                Role like  @Role +'%'  
END







GO
/****** Object:  StoredProcedure [dbo].[Proc_WorkFLow_Get_ConditionalMailBox]    Script Date: 2/12/2020 8:52:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Proc_WorkFLow_Get_ConditionalMailBox]    
(    
 @pintUserId INT,
 @pchrStatus CHAR(1) ,
 @fromdate varchar(50),
 @todate varchar(50)
)    
    
AS    
    
BEGIN    
 Select distinct WD.WTM_MasID, WD.WTD_TransID, Convert(varchar, WD.WTD_TransDate, 100) as WTD_TransDate,WD.WTD_SentOn, WD.WTD_TransFrom, WD.WTD_To, WD.WTD_Remarks, WD.WTD_WFStatsID,  
WD.WTD_WFActionID, WD.WTD_SentBy, WD.WTD_WFStatus, UP.FullName, WTM.WTM_Subject,WTM.WTM_WorkFlowID,WTM.WTM_DOCID,MB.WTM_ReadFlg,MB.WTM_TrnStatus,WTM.WTM_FormCode from A_WorkflowTransDetails as WD  
INNER Join   
(Select  Distinct(WTM_MasID) , WTM_TransID From  A_WorkflowTransMailBoxes where WTM_TrnTo = @pintUserId and WTM_TrnStatus = @pchrStatus) as MailBox  
ON WD.WTM_MasID = MailBox.WTM_MasID and WD.WTD_TransID = MailBox.WTM_TransID ,  
A_U_Management as UP, A_WorkflowTransMailBoxes as MB , A_WorkflowTransMasters as WTM Where WD.WTD_TransFrom = UP.UserUID and WD.WTM_MasID = MB.WTM_MasID and WD.WTD_TransID = MB.WTM_TransID  
and WTM.WTM_MASID = WD.WTM_MasID  
--and WTM.WTM_CrOn between @fromdate and @todate
and MB.WTM_TrnTo = @pintUserId and  MB.WTM_TrnStatus = @pchrStatus Order by WD.WTM_MAsID desc    
END  
  
  
  
  
















GO
/****** Object:  StoredProcedure [dbo].[Proc_WorkFLow_Get_ConditionalSentMail]    Script Date: 2/12/2020 8:52:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Proc_WorkFLow_Get_ConditionalSentMail]    
(    
 @pintUserId INT,
 @pchrStatus CHAR(1), 
 @fromdate Datetime,
 @todate Datetime   
)    
    
AS    
    
BEGIN    
 Select WD.WTM_MasID, WD.WTD_TransID, WD.WTD_TransDate,WD.WTD_SentOn, WD.WTD_TransFrom, WD.WTD_To, WD.WTD_Remarks, WD.WTD_WFStatsID,  
WD.WTD_WFActionID, WD.WTD_SentBy, WD.WTD_WFStatus, UP.FullName, WTM.WTM_Subject,WTM.WTM_WorkFlowID,WTM.WTM_DOCID,MB.WTM_ReadFlg,MB.WTM_TrnStatus,WTM.WTM_FormCode from A_WorkflowTransDetails as WD  
INNER Join   
(Select  Distinct(WTM_MasID) , WTM_TransID From  A_WorkflowTransMailBoxes where WTM_TrnFrom = @pintUserId and WTM_TrnStatus = @pchrStatus) as MailBox  
ON WD.WTM_MasID = MailBox.WTM_MasID and WD.WTD_TransID = MailBox.WTM_TransID ,  
A_U_Management as UP, A_WorkflowTransMailBoxes as MB , A_WorkflowTransMasters as WTM Where WD.WTD_TransFrom = UP.UserUID and WD.WTM_MasID = MB.WTM_MasID and WD.WTD_TransID = MB.WTM_TransID  
and WTM.WTM_MASID = WD.WTM_MasID 
--and WTM. between @fromdate and @todate
and MB.WTM_TrnFrom = @pintUserId and MB.WTM_TrnStatus = @pchrStatus Order by WD.WTD_TransDate desc    
END  
  
  














GO
/****** Object:  StoredProcedure [dbo].[Proc_WorkFLow_Get_MailBox]    Script Date: 2/12/2020 8:52:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Proc_WorkFLow_Get_MailBox]    
(    
 @pintUserId INT,
 @pchrStatus CHAR(1)    
)    
    
AS    
    
BEGIN    
 Select distinct WD.WTM_MasID, WD.WTD_TransID, Convert(varchar, WD.WTD_TransDate, 100) as WTD_TransDate,WD.WTD_SentOn, WD.WTD_TransFrom, WD.WTD_To, WD.WTD_Remarks, WD.WTD_WFStatsID,  
WD.WTD_WFActionID, WD.WTD_SentBy, WD.WTD_WFStatus, UP.FullName, WTM.WTM_Subject,WTM.WTM_WorkFlowID,WTM.WTM_DOCID,MB.WTM_ReadFlg,MB.WTM_TrnStatus,WTM.WTM_FormCode from A_WorkflowTransDetails as WD  
INNER Join   
(Select  Distinct(WTM_MasID) , WTM_TransID From  A_WorkflowTransMailBoxes where WTM_TrnTo = @pintUserId and (WTM_TrnStatus = @pchrStatus )) as MailBox  
ON WD.WTM_MasID = MailBox.WTM_MasID and WD.WTD_TransID = MailBox.WTM_TransID ,  
A_U_Management as UP, A_WorkflowTransMailBoxes as MB , A_WorkflowTransMasters as WTM Where WD.WTD_TransFrom = UP.UserUID and WD.WTM_MasID = MB.WTM_MasID and WD.WTD_TransID = MB.WTM_TransID  
and WTM.WTM_MASID = WD.WTM_MasID  
and MB.WTM_TrnTo = @pintUserId and  ( MB.WTM_TrnStatus = @pchrStatus)Order by WD.WTM_MAsID desc    
END  
















GO
/****** Object:  StoredProcedure [dbo].[Proc_WorkFLow_Get_SentMail]    Script Date: 2/12/2020 8:52:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Proc_WorkFLow_Get_SentMail]    
(    
 @pintUserId INT,
 @pchrStatus CHAR(1)    
)    
    
AS    
    
BEGIN    
 Select WD.WTM_MasID, WD.WTD_TransID, WD.WTD_TransDate,WD.WTD_SentOn, WD.WTD_TransFrom, WD.WTD_To, WD.WTD_Remarks, WD.WTD_WFStatsID,  
WD.WTD_WFActionID, WD.WTD_SentBy, WD.WTD_WFStatus, UP.FullName, WTM.WTM_Subject,WTM.WTM_WorkFlowID,WTM.WTM_DOCID,MB.WTM_ReadFlg,MB.WTM_TrnStatus,WTM.WTM_FormCode from A_WorkflowTransDetails as WD  
INNER Join   
(Select  Distinct(WTM_MasID) , WTM_TransID From  A_WorkflowTransMailBoxes where WTM_TrnFrom = @pintUserId and WTM_TrnStatus = @pchrStatus) as MailBox  
ON WD.WTM_MasID = MailBox.WTM_MasID and WD.WTD_TransID = MailBox.WTM_TransID ,  
A_U_Management  as UP, A_WorkflowTransMailBoxes as MB , A_WorkflowTransMasters as WTM Where WD.WTD_TransFrom = UP.UserUID and WD.WTM_MasID = MB.WTM_MasID and WD.WTD_TransID = MB.WTM_TransID  
and WTM.WTM_MASID = WD.WTM_MasID  
and MB.WTM_TrnFrom = @pintUserId and MB.WTM_TrnStatus = @pchrStatus Order by WD.WTD_TransDate desc    
END  















GO
/****** Object:  StoredProcedure [dbo].[Proc_WorkFlow_Trans_Details_Save]    Script Date: 2/12/2020 8:52:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Proc_WorkFlow_Trans_Details_Save]
	@WTM_MasID int,
	@WTD_TransID int,
	@WTD_TransFrom int,
	@WTD_To varchar(200),
	@WTD_Remarks varchar(2000),
	@WTD_WFStatsID int,
	@WTD_WFActionID int,
	@WTD_SentBy int,
	@iRetTransID int Output,  
	@iRetOperation int Output  
As
--@WTD_WFStatus A = Inbox
--@WTD_WFStatus S = Sent Item
Begin Transaction    
If Exists(Select WTM_MasID from A_WorkflowTransDetails where WTM_MasID = @WTM_MasID and WTD_TransID = @WTD_TransID)
Begin
	Update A_WorkflowTransDetails
	Set
	  [WTD_Remarks] = @WTD_Remarks,
  	  [WTD_WFStatsID] = @WTD_WFStatsID,
	  [WTD_WFActionID] = @WTD_WFActionID,
	  [WTD_SentBy] = @WTD_SentBy,
	  [WTD_WFStatus] = 'S'
	Where
	  [WTD_TransID] = @WTD_TransID And [WTM_MasID] = @WTM_MasID


	  ---- To update Mailbox Table 
	DECLARE @WTM_MasID1 int
	DECLARE @WTD_TransID1 int
	DECLARE @WTD_SentBy1 int
	DECLARE @WTM_TrnStatus char(1)
	DECLARE @iRetOperation1 int

	Select @WTM_MasID1  = @WTM_MasID 
	Select @WTD_TransID1 = @WTD_TransID
	Select @WTD_SentBy1  = @WTD_SentBy
	SELECT @WTM_TrnStatus = 'S'
	SELECT @iRetOperation1 = 0
	
	DECLARE @RC int
  	Exec @RC = Proc_MailBox_ChangeStatus @WTM_MasID1 , @WTD_TransID1, @WTD_SentBy1 ,@WTM_TrnStatus, @iRetOperation1 OUTPUT 

  	  ---------******************
	  -- Transaction Management      
	  Set @iRetOperation = 1                
	  Set @iRetTransID = @WTD_TransID     
	
   End
Else
   Begin
	Select @WTD_TransID = (Select isnull(max(WTD_TransID),0)+1 from A_WorkflowTransDetails where WTM_MasID = @WTM_MasID)
	--Insert Into WorkFlow_Trans_Details
	--([WTM_MasID],[WTD_TransID],[WTD_TransDate],[WTD_TransFrom],[WTD_To],[WTD_Remarks],[WTD_WFStatsID],[WTD_WFActionID],[WTD_SentBy],[WTD_WFStatus])
	--Values
	--(@WTM_MasID,@WTD_TransID,getdate(),@WTD_TransFrom,@WTD_To,@WTD_Remarks,@WTD_WFStatsID,@WTD_WFActionID,@WTD_SentBy,@WTD_WFStatus)

	Insert Into A_WorkflowTransDetails
	([WTM_MasID],[WTD_TransID],WTD_InwardFileNo,[WTD_TransDate],[WTD_TransFrom],[WTD_To],[WTD_Remarks],[WTD_WFStatus])
	Values
	(@WTM_MasID,@WTD_TransID,('1'+'.'+Cast(@WTM_MasID  as varchar)),getdate(),@WTD_TransFrom,@WTD_To,@WTD_Remarks,'A')

	--Transaction Management      
	Set @iRetOperation = 0             
	Set @iRetTransID = @WTD_TransID     
	
End 
commit
















GO
/****** Object:  StoredProcedure [dbo].[Proc_WorkFlow_Trans_MailBox_Save]    Script Date: 2/12/2020 8:52:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Proc_WorkFlow_Trans_MailBox_Save]
	@WTM_MasID numeric(5,0),
	@WTM_TransID numeric(5,0),
	@WTM_TrnFrom numeric(5,0),
	@WTM_TrnTo numeric(5,0),
	@WTM_UsrOrGrp Char(1),
	@WTM_ReadFlg Char(1),
	@WTM_TrnStatus Char(1),
	@iRetOperation int Output
As
Begin Transaction 
--If Not Exists(Select * From WorkFlow_Trans_MailBox where WTM_MasID = @WTM_MasID And WTM_TransID=@WTM_TransID)
Begin
	Insert Into A_WorkflowTransMailBoxes
	([WTM_MasID],[WTM_TransID],[WTM_TrnFrom],[WTM_TrnTo],[WTM_UsrOrGrp],[WTM_ReadFlg],[WTM_TrnStatus])
	Values
	(@WTM_MasID,@WTM_TransID,@WTM_TrnFrom,@WTM_TrnTo,Upper(@WTM_UsrOrGrp),Upper(@WTM_ReadFlg),Upper(@WTM_TrnStatus))
	 Set @iRetOperation = 0       	                 
	 IF @@ERROR <> 0            
	 BEGIN      
	   -- Rollback the transaction            
	    ROLLBACK            
	    -- Raise an error and return            
	    RAISERROR ('Error in Inserting Record', 16, 1)            
	    RETURN            
 	 End   
End
Commit














GO
/****** Object:  StoredProcedure [dbo].[Proc_WorkFlow_Trans_Master_Save]    Script Date: 2/12/2020 8:52:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Proc_WorkFlow_Trans_Master_Save]
    @WTM_MasID int,   
    @WTM_WorkFlowID int,
    @WTM_FormCode varchar(20),
    @WTM_Subject varchar(200),
    @WTM_Privacy varchar(20),
    @WTM_Priority int,
    @WTM_DetailID int,
    @WTM_AttachID int,
    @WTM_CrBy int,		
    @WTM_FileNo varchar(50),
    @WTM_IsDisposed int,
    @WTM_DisposedBy int,   
    @WTM_Status varchar(10),
    @WTM_PageIds varchar(200) , 
	@iRetMasIDOut int Output ,

	@iRetOperation int Output  
As
Begin Transaction    
if Exists(Select WTM_MasID from A_WorkflowTransMasters where WTM_MasID = @WTM_MasID)     
Begin
    Update A_WorkflowTransMasters
    Set
    --[WTM_FinYearId] = @WTM_FinYearId,[WTM_WorkFlowID] = @WTM_WorkFlowID,       
    --[WTM_Subject] = @WTM_Subject,
    --[WTM_CrOn] = getdate(),    [WTM_CrBy] = @WTM_CrBy,
    --[WTM_FormCode] = @WTM_FormCode,   

    [WTM_AttachID] = @WTM_AttachID,   
    [WTM_IsDisposed] = @WTM_IsDisposed,
    [WTM_DisposedBy] = @WTM_DisposedBy,
    [WTM_Status] = @WTM_Status
    Where       
    WTM_MasID = @WTM_MasID
    -- Transaction Management     
        Set @iRetOperation = 1               
    Set @iRetMasIDOut = @WTM_MasID           
    IF @@ERROR <> 0           
       BEGIN     
       -- Rollback the transaction           
       ROLLBACK           
        -- Raise an error and return           
         RAISERROR ('Error in Update Record', 16, 1)           
         RETURN           
    End   
End
Else
Begin
    Declare @WTM_CreatorName varchar(200)
    Declare @WTM_DOCID numeric(5)
    Select @WTM_MasID =  (Select isnull(max(WTM_MasID),0)+1 from A_WorkflowTransMasters)
    Select @WTM_DOCID =  (Select isnull(max(WTM_DOCID),0)+1 from A_WorkflowTransMasters where WTM_FormCode = @WTM_FormCode)
	select @WTM_CreatorName=(select FullName from A_U_Management where UserUID = @WTM_CrBy)
    Insert Into A_WorkflowTransMasters
    ([WTM_MasID],[WTM_DOCID],[WTM_WorkFlowID],[WTM_FormCode],[WTM_Subject],[WTM_AttachID],[WTM_CrBy],[WTM_IsDisposed],[WTM_DisposedBy],[WTM_Status])
    Values
    (@WTM_MasID,@WTM_DOCID,@WTM_WorkFlowID,@WTM_FormCode,@WTM_Subject,@WTM_AttachID,@WTM_CrBy,@WTM_IsDisposed,@WTM_DisposedBy,@WTM_Status)
     -- Transaction Management     
     Set @iRetOperation = 0               
     Set @iRetMasIDOut = @WTM_MasID           
     IF @@ERROR <> 0           
    BEGIN     
    -- Rollback the transaction           
    ROLLBACK           
    -- Raise an error and return           
     RAISERROR ('Error in Inserting Record', 16, 1)           
     RETURN           
     End
End
Commit 
















GO
USE [master]
GO
ALTER DATABASE [ChatApp] SET  READ_WRITE 
GO
