USE [master]
GO
/****** Object:  Database [DoAn]    Script Date: 15/04/2017 8:16:03 SA ******/
CREATE DATABASE [DoAn]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DoAn', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\DoAn.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DoAn_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\DoAn_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DoAn] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DoAn].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DoAn] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DoAn] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DoAn] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DoAn] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DoAn] SET ARITHABORT OFF 
GO
ALTER DATABASE [DoAn] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DoAn] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [DoAn] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DoAn] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DoAn] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DoAn] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DoAn] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DoAn] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DoAn] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DoAn] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DoAn] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DoAn] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DoAn] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DoAn] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DoAn] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DoAn] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DoAn] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [DoAn] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DoAn] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DoAn] SET  MULTI_USER 
GO
ALTER DATABASE [DoAn] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DoAn] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DoAn] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DoAn] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [DoAn]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 15/04/2017 8:16:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ApplicationUsers]    Script Date: 15/04/2017 8:16:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationUsers](
	[Id] [nvarchar](128) NOT NULL,
	[FullName] [nvarchar](256) NULL,
	[Address] [nvarchar](256) NULL,
	[BirthDay] [datetime] NULL,
	[Email] [nvarchar](max) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ApplicationUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ControPanels]    Script Date: 15/04/2017 8:16:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ControPanels](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.ControPanels] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CustomImages]    Script Date: 15/04/2017 8:16:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomImages](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Images] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.CustomImages] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Donations]    Script Date: 15/04/2017 8:16:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Donations](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Class] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NULL,
	[Address] [nvarchar](max) NULL,
	[Note] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdateBy] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Donations] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IdentityRoles]    Script Date: 15/04/2017 8:16:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.IdentityRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IdentityUserClaims]    Script Date: 15/04/2017 8:16:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](max) NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[ApplicationUser_Id] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.IdentityUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IdentityUserLogins]    Script Date: 15/04/2017 8:16:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityUserLogins](
	[UserId] [nvarchar](128) NOT NULL,
	[LoginProvider] [nvarchar](max) NULL,
	[ProviderKey] [nvarchar](max) NULL,
	[ApplicationUser_Id] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.IdentityUserLogins] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IdentityUserRoles]    Script Date: 15/04/2017 8:16:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
	[IdentityRole_Id] [nvarchar](128) NULL,
	[ApplicationUser_Id] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.IdentityUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Laudatories]    Script Date: 15/04/2017 8:16:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Laudatories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Class] [nvarchar](max) NULL,
	[Appellation] [nvarchar](max) NULL,
	[CountBook] [int] NOT NULL,
	[Note] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdateBy] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Laudatories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201704121553208_adddatabase', N'DoAn.Data.Migrations.Configuration', 0x1F8B0800000000000400ED5ADB6EE336107D2FD07F10F4D402592B1714480379175E3B298CC689B14AF69D96C68EB014A98A54607F5B1FFA49FD850E75A564D9969C389B4D8300814D71CE5C7848CE8CFCEFDFFFD89F9601351E21123E677DF3A4776C1AC05CEEF96CD1376339FF706E7EFAF8F34FF6A5172C8DAFF9BC33350F2599E89B0F5286179625DC070888E805BE1B71C1E7B2E7F2C0221EB74E8F8F7FB74E4E2C400813B10CC3FE1233E907907CC1AF43CE5C08654CE8847B4045368E4F9C04D5B821018890B8D037477CC07A232289690CA84FD00007E8DC3408635C1289E65DDC0B7064C4D9C2097180D0BB5508386F4EA880CCEC8B727A5B0F8E4F950756299843B9B1903CE80878729685C4AA8BEF1558B3081906ED12832B57CAEB24707D13E38BF1A053C2809A465DE1C590466A7216DB64097ABAC891513E382A48805C517F47C630A6328EA0CF209611C119D378467DF74F58DDF16FC0FA2CA654B70F2DC46795011C9A463C8448AEBEC03CB37A3C320DAB2A67D5050B314D26F565CCE4D9A969DCA07232A3502CBFE6B72379047F00838848F0A6444A8870F5C61E24015CD35ED3A5FEE7DA906FB8634C634296D7C016F2A16FFE865BE4CA5F82970F6406DC331FF717CAC828860603B72B75D0F658E46A3F734E81B01D28B65532623B4F12668C03B280B6342925DE59D2A84BE9797196240B22B6A8C58FADF47E47328E38CBCEC3564CCCA7BFD3B051D77739AC869488C3B3701AF96EE1DB085C3F2078CB4D23FC946535E7A6E1B844997DBA0B6CE07911BC80D1375C6E5B8F7D94B4DE59D724F608D269D5726B15F3DFF7D6FF6D6F0DC210D0ACF41C3EB0AE21C7AA002F916F6F6FF3A96C9AF8C8AFE26E1BB0D14C8DC25236EC42AC60B28D283265557F5254076435C10F55B68EA4284D49ABA35EB500B0768095395D23969E24EE80CA2FE5269CF27EDF01521C3F4D28DA59D6B41C45E0CB92D24A6BCABCF6B436149FF684842132432B46B311C3492BD1E107A77BAD16A418962B1A4AB6C2DA42137A8671AE3D55EBEDC1951F09A90AE11951DC1C7AC1DAB42ACD364439D7D5C4A4FAD95C863F97529F4B4E278579956D3588328C57E85980076CE22414E6D4AAD535F1A4294028891A0EFC21A771C0365D1ADBA4D3235C974F47DA23E4B9B08E918FADA3D8562D0AF5485B6BA1AE5D80F5F56BB7BAFAD6DE7371B5EDBFC7DA6E933ECCD2A605982E9F8EB447C88FC28A0DD9D81B23487960EFC78EE250EF4E8DCDA2AF75CB6729980E910DB5C7C88A171D231B6A8F51D42C3A4A31D82122495A54894832F26AD8A96502FBD1B3CC16BAF3738BEC5B2668A502A8104C7FD0C1A632CBAFD8550EFF70845D4B36EB530AED45D2594B2EED2CD1DBFDFA632DF34BA7A87E077FF43D95F5392B21214809EFFC4587D4477FCB0913C2FC390899D6E42626A6E7B55729AFE7B5862584473BBCDB78F1E682AF22BBB37DD0B1B4D7FB09EC9144EE0389D63A0A4F7A6F30F3E521DE19BC8DF0EB1DFBE70A7FB5219FA3FE1290E5AF3A56F7A6FB33AE647302F6C32EE3217651A5E9F6A455AC34ADBD9D4DEB6EE0B526F6930CD57B651D80F66846BFD3EEF0B46BE8E73E096FAD67FBFAB856EFBDAEF7CE5AF556B3DEE98ED66A9A8DE18E9E71742435389D31CD7AB3ED9BAFBB7AAF8DBA2ABDDB96DDD9ADCDD9262D5A5BB76DEF767BEBB64949FED8AF7BD2A1B7BB9E56DB96FEDB237B04C25F9410EA97480C5CE55B099ACF19B339CF098B1EEA16E5536A7C9E8024E8031944D29F1357E26317CFE5E47DC35742639C7219CCC01BB3DB5886B11C0801C18C567AD9B6B55D7FD2C0AEDA6CDF86C9EA3C870B68A68F2EC02DFB1CFBD42BECBE6A48343640A80D971DB0689523D541BB581548379CB504CAC2378210983A9EEF2008F12C0371CB1CF208FBD8762FE01A16C45DE5D5D16690DD0B510DBB3DF2C9222281C8304A79FC8A1CF682E5C7FF00A521369982270000, N'6.1.3-40302')
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201704130125538_addIndentityApplicationUser', N'DoAn.Data.Migrations.Configuration', 0x1F8B0800000000000400ED5DD96EE4B8157D0F907F10F494041E979774A363B866E0B6DB89116FE8720FF2D6A025BA2CB4968A44796C04F9B279984FCA2F84942889AB286AA92A7B1A01066D2EE75E5E1E8A97E4AD9BFFFDFADBF14FCF51E83CC1340B9278EEEEEFEEB90E8CBDC40FE2E5DCCDD1C30F1FDC9F7EFCE31F8E3FF9D1B3F373D5EE90B4C33DE36CEE3E22B43A9ACD32EF114620DB8D022F4DB2E401ED7A4934037E323BD8DBFBDB6C7F7F0631848BB11CE7F8731EA32082C51FF8CFD324F6E00AE520BC4A7C1866B41CD72C0A54E71A44305B010FCEDDB3E424DE3D0308B8CE491800ACC002860FAE03E238410061F58EBE647081D2245E2E56B80084772F2B88DB3D80308354EDA3A679D711EC1D9011CC9A8E1594976728892C01F70FA9496662F75E86756B9361A37DC2C6452F64D485E1E62EB62FB647780B6218BA8E28F0E8344C49636ADB620ACAFF66BB6CCF1DA7A9DFA9B9802943FEB7E39CE621CA53388F618E52805BDCE6F761E0FD13BEDC25DF603C8FF33064D5C48AE23AAE0017DDA6C90AA6E8E5337CA0CA5F9CB9CE8CEF37133BD6DD983EE5902E627478E03AD75838B80F61CD0266F80B94A4F0EF30862940D0BF0508C1144FE2850F0B3B4AD20559E4BF95344C3BBC705CE70A3C5FC278891EE7EE3BBC52CE8367E8570554812F71809719EE83D21C2A146C17BAC0BAE75925F663928410C40694E359438C76BA1404B988C0125AB2A5E9F89D2C4A5944CEDAC9524C48D62216FFB393DC0D72F22C89E9D7D1869055AFEF6C54CADAC8A7EB3404D9F464BC4D03AF1EDB19F48208E0ADEF36C5FFA2AECE07D7597880A87D60023BF1FD14AE41E9EB04B5CD471F219D17D825C87D80E9F462B7C2EA6EDF97D8EF6D899DAC5610AB557E952796759AE01303DE52BEBDE9355891EA33DE3ADB96E1557D1438C956D710ED561D774BC8F314C3FD92A4DF7659C41DA773BF66011F745DC087FBF70F871FDEBD07FEE1FBBFC2C377BD16B3DF6331FB2DB3B57FF0618AF56558D43D89780D9E826531D382387C9E4DF172FE0CCBC5963D06ABF2D4CB4DEF57DAEC3C4D22F2374FA7B2F6EB22C9D3625F4CB44DEE40BA8468208309D4F82CAE50B79FC9445399CDCAA664407D885F895837F92B7DA795DB99717817C29357508B58C4CE7B113A6FCA8779259FBD73DCDCF0E93B78F77E0CCFC2E86F8F23E76390A2C733F0529F13B08B771744C67E9F221084937B228594D3247E08D208FA76E76AC58108BB84F883E8FF03648FD35F05402F4FF13A5D2010ADA63FEB3D2631BCCEA37BB2FCD7276BB4A9B9FB2539071E3E677C8A49AFC1789789F72DC9D1A7D82784FE823C5B7ED700A3A873E27978319F633243BFF0E34DA7AF7638F2A15EB30386CF5341A4F6C0841DE46BD5B4F1C2D42D244F4CD34CE58DB5A97A992C83B89BAA5553BDAA650BA3AAB499ADAA04AC9BA6B4A55ED1A28151CFB2D568FE6D3143E33BB805ECF67BB8C39C96E92F5E8CEEF148171364B60CB7FA234AFA1984F9C6AF2788698B353F3EF90BD8ED27BFFA78B7BD67B6C2ACB8EC29F0D7E1235141D81A6BA2EA4996255E5030507195466F46789DB177E498AF494AE5C5AB163C0E4CB280EC2EB864EEEEEDEEEE4B466915506D420A01CDD5092FE42FA2299841B7DB42E3A3E8D435392C8DCAD2D9DBCA2C068F47631ABAEB4E651BEA1475D559F490A6B28DE062696C433FCA53D9A674C3BAAA2CF86453598677EA26584FE5178704C280003B23F57BF4497C764F4AE13352EC83582ADD0A33FA21130744501710F1213A2B1268835DDDE6334747C387F048D611C09A380C25161BDF6180AA5ED05538CD9BBC01A47E2454A1300F8F06187A0C9010F84FB30144A4451B60431D0328BD7A978024AA5B28579D245BB5A35F430BD8EAD4D70A4B3F24022CB340646CF6098269A87FA810BDAC4E1B723DB29A0DD20D7BA77D97C151104274EBF88177308AEE5640364C97BDD9667766064627A3C540861D5863A46A30A35BA9A2A6D94AAA5DDA669F1E6425612FD658A91ACCE856A21C351B49B15D5B6CD8834CC46FCA232DB6CAF9AFB7E2BAEE7856C609D382E39926A0F8F80AAC56F81CC20418D312675146179FFEB0B08FBF8D4A8C999729C2706B6D6B4978AFC33BAF504B3C001F9E0769864870F33D2027A1533F929AF18E87E6BB5FC952F916F22C561B41D58BFCBBF1728A606BDEFF10201A33E273F932C2335C0C1232F3DEDEDD2181DE2004A92250E73409F328D605FBB4F52E2F89D9FE654977842AA291C5A8CA6494E3996005D1D233C9D402F5C5F9EB36BBACB3D773721987B0C7DCB6F59E666ACB0B37B67F59D21DA1728E391D68D91B2348E3C2F76347EDE6DB5343DF755B973C0D9D63216851770C1A7BCA62D0A2EE18F513388B52175A58A40867E32C52946C0D3B99B3613F7A36E7477B7EB6F47DCB04E522373982B115163A35D1999C5E4DF11B22ACCEADEEC255EEA6C29EAEEDDDB58CF505C62AE2D25AE6A3336337341FF29162D8DCD4973EFDE7470FA1B372F530C4DA591743A847A942F358147578E106E74B77FBD3658EC4FB34FB2932224CB38A9AD03916A3295DBF63D0C4BEB1404D6977241A0DC7C2D0224B0C26A04A0263EA2C1C312EE68DF3C7B81A0B879F0F6CE3FC7EBECA424B367C8D5392ADE885A7B1A8BA85C5F14B0A58E38E62526D776445E81A0BADA8EE81ADD059ACB3588F72741BB732E5EAEED84DA89BB82F6CF11EACBDC1B6DD84CBB78D61BBB006639A8FFC389B3813512438F955B125168D1992C068F95692487BC16F4BA2F2256B18893418D3D24008D9E13F565C95CDC5041398C35F4F3015EB27047FE5AF6605FBBE683A5A55ED6CFD73F2A2217D11746F91B2953A7E521840E54F84668C16BD14A4EF2E1D15B4A3EBF08347EBF8B03BE2074508CA454662DCEAA0300B138A4F48D694D3BDDE763891D46DAD3725C5D4B63FF5F6E49F083A0205DB9F917BAF9329A8631EFDE8ECA91E82BBB0A76A6BBD1B759815FE097C7BD9C33FAF4FF0117B952CA28FE55D48449B8EB0F9B546086C2F83B8E88337BB0B8E414229A4426C527B7EB4A4FEBB0EA9A0E10CE6C46D527C43D9842465299DCFB9BB78C9108C4A562FFE1D9E86012407E6AAC11588830798A1328EDF3DD8DB3F1092C06D4F42B65996F95CA483212B1B3F716B487D1210CB1A7F6333203142FC0452EF11A452BE9341A9CEEE0334459AB3B7617EF6774863999F4F1E56A1FE2902CF7F66B1EC13848D3893EA3083573B8D53AC222E25D0A059E4326BF9C6CC5A76E0C22FFF0729CA66F2B100EA9131EB3BEDA6A79D22DBD4203C29A3D456734DFFF2BF8E5FEB2AD950FC5471048A4D6126F519674B53F78C665D3E33CF68B0D2759B882FFDF8E922F6E1F3DCFD4F0170E45CFCEBAB80B1E3DCA4D8A13F72F69CFFB6E9D7F1C3209D837A6828C3F457B277F2A2D7BBB2C5DC404AE0226BCF280EC1505831F30FDEC8212A32A3D8E170998006ED20EA6C3F662759E1A02932FD0CF3DB55D97C86F99072C69EB1F04631A12E234F1F2C6D369EBE9C5367E7E9A39A36334FE15F0ECCCB33F5FEAE784559C7177312D75BED10F4F36BC58424C3D1B8A423439DF857BB571BDE60D6993864B45D5B991764E0ED8094FBE3F7C298D192908C9D77A4F9197BFFF4081818B318A6A413207E4A865210C89120B769107BC10A84AA71C9EF285DBECEC4E235AC587306573026327463EE26D3189351CB1116AEC9286B4BD332628A0D45828101C958FA32C71CEB3D297974D187B2D06E2F9A1B20905D2E9B89084453490CC858F34A09A48B3C7C4504B24AF833117F36B5716D983D9DF7AE0D9147881BA82FD5C51C06E214D37014D513B829E951192F80CFCDF7092644E99D952D6E69D6248950823436EF912C8CAD55CAE2B22A196435B99124414D954A0A9370C92082499C24C960EA5442AAEAA0C34878075492C457AB84B12DBA8B6B96B75664D3A44DAC3ED588285AFA684992A5162AC14223BB21538FAA75CCB48D69D09A3C3D6DD2E976DC2A9DB63149D7E4BFD9440E2965061A555E2FC326D4164C6708BDEA60045D24F1F839A3B89148751D4DC2115513E23CBE51A64B11358A51B8F5A389DC1DDF285365841AC524632E1D8B0C50725822767698FFD759EC7C65C1B28120319731F43837A76E73113F2495E72568543511AEADAE200278870527290A1E80877035B96A2F72E016D7A9E4C1E71EFA17F14D8E5639C24386D17DC8FDFA86786D6DF28B3457BCCEC737ABC27718630858CD803C51DCC41FF320F46BBDCF15815A1A08E20ED25B72329788DC962F5F6AA4EB24EE0844CD577BB177305A85182CBB8917E009F6D10DD3EF122E81F7D25C7FEA40CC13C19BFDF82C00CB144419C568FAE33F3187FDE8F9C7FF03792C03AE7C790000, N'6.1.3-40302')
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201704141617052_updatedatabase', N'DoAn.Data.Migrations.Configuration', 0x1F8B0800000000000400ED5C5B6FDDB8117E2FD0FF20E8A92DB23EBE348BD4B077E1D8716B34768C1C67D1B78096E86321BA9C4A54D646D15FD687FEA4FE85921225F12A92BA1C1F7B8D00810F2FDF0C87C3E1901CCDFFFEF3DFA39F1F92D8FB0EF322CAD2637F6F67D7F7601A646194AE8EFD12DDFDF0CEFFF9A7DFFFEEE843983C78BF34ED0E483BDC332D8EFD7B84D6878B4511DCC304143B4914E45991DDA19D204B1620CC16FBBBBB7F59ECED2D2086F03196E71D7D2E531425B0FA817F9E666900D7A804F16516C2B8A0E5B86659A17A572081C51A04F0D83FCB4ED29D338080EF9DC411C00C2C617CE77B204D33041066EFF04B019728CFD2D5728D0B407CF3B886B8DD1D880B48D93EEC9ADB8E60779F8C60D1756CA082B24059E208B8774045B210BB0F12ACDF8A0C0BED03162E7A24A3AE0477EC63F96279C4D72085B1EF89040F4FE39C34A6B2ADA6A0FEBFD8617BBEF1BAFA37AD2E609521FFDE78A7658CCA1C1EA7B04439C02DAECBDB380AFE0E1F6FB26F303D4ECB3866D9C48CE23AAE00175DE7D91AE6E8F133BCA3CC5F9CF9DE82EFB7103BB6DD983EF5902E5274B0EF7B579838B88D61AB05CCF09728CBE15F610A738060780D1082399EC48B10567294A80BB4C8FF0D35AC7678E1F8DE2578F808D315BA3FF6DFE295721E3DC0B029A00C7C4923BCCC701F949750C1603FD125E6BD2C1AB2EFB32C862035A01C2D3AC5E857974A412E12B0828EDAD2757C5516252D4267E3CA524D48D14316FF6945F70975F22C4BA9757451C8A6D7AB362A693D89E93A8D4131BF325EE751D08EED0C065102F0D6779DE3BFA8ABF3CEF79601206CEF9BC04EC230871B60FA2A437DF3310D91D31C1265C12E54271FFCF74D9418BB7E5987B8E5909E94E8FBC7D98757F3B80142B39ABB8FA0C4C3C8F247377BD7767B3578BF358377B25E43CC56BD47CE6D42327C7EC31AFFCD3473AFE6EED5DCD998BB66FD7EC6A87D16EFB23D039F14EB2B88769A8E3B35E4798EE17ECDF26F3B2CE21BCFBA5F672BF76D6DE5C1DEEDDDC1BBB73F82F0E0C73FC383B783EC6638C06E863D73BEB7FF6E0E5366B09F0335ED0A7C8F56D54C8BCA5DE0C9F0BDCFB0B66BC57DB4AEAF7BB8E9FD4A9B9DE759427EF3EA54D77E5D66655E398499B6C90DC857108DD4600235BD1637A8DBAFC98453599B954DC98086287E4362D3CADFF03B2F5D6B8DC31B3E9EBC4AB58844DC1C45A1F353B98BCFC4EC9DE3E606D3B7FFF6C7299C38E341731A3AEFA31CDD9F814757BFE64302A2787657A3A2729AA577519EC0D0CDE550DC0460EF1B1BC4F06FA0B89FDF4B824199E3758ABDA5643DFF25C77D96C2AB32B925CB7F73B4269B9A9B5FB37310E023DD8794F41A8DF7310BBE6525FA9056EEFE1714B8EA770B30093B27418017F3395666185647A671C72562A837EC80E1A36B94A83D306107F9DA34EDBC30750BC913D3345379637DAC7ECC56516AC76AD354CF6ADDC2C82A6DE6CA2A01B3E394B6D4335A3530F259B79ACCBFAD66687A07B782DD7E0F779CD332FF1D97D13D9EE85E85CC96E1396B424ABF80B89C9AD420E5AFD6FCF4CA5FC16EBFF2AB8F77DB7B66ABC48ACBBE47E1267C244A084B6343AA7A52145910551AA8B84AA337233CCFD83BF2CCD72435F3E2550B1E0756B288EC2EB8E4D8DFDDD9D99384D24BA0D9841404BAAB139EC89F44513083EE9785C647D1B16B72583A96A5B3B793580C1E8F463474D79D4B36D429B2E559F490E6928DE0626964438DF25CB2A9DD305B96059F6C2EC9F04EDD0CEBA9B63824020C44D8196903314ED2B35B520A1F90621FC454E956585043260E88A02E21E263D3D624C20CBBBA9D99A3A3E163D724E908605D0092128B0D6C324035A1232A9C2E18C500D2BEC7AA5098375E030C3D064808BC693680886AD107D8A98E01945EBD4B4092AA3B30D79C247BB9A3D6D001B639F5F5C2524322C0320B44C6669F209886FA870AD1CBB2DA90DB91B5DA20DDB05BEDBB0C8E422144B78E1FB8855074B702B2606CF66697DD9919189D8C1E011976608D909AC14C2EA54635CD5252EDD22EFBF42829097BB1464ACD60269712D551B39014DBB5C3863D4A44FCA63CD1626B9CFF762B6EEB8E1675803C2D385A6822E98F2EC17A8DCF214C643D2DF1967558FDE90F4BF7C0F3A4C658048522FEBCE5B6A584F73ABCF30AB5C40308E17994178844F5DF0272123A0D13A919EF7868EC7E434BE55BC8B3D86C044D2FF277E7E5545F19F0FE8700D189119FCB57099EE16A909099F7FEEE1EF9C201C42057C4449D667199A4BAB8AABEDEF52531DBBF2EB14768823D588CA64C46395A08521025BD90442DA8BE387F76B3CB3A7B032797710807CC6D5FEF79A6B6BE7063FBD725F6088D73CCF140CB5E9882742EFC30ED68DD7C77D5D077DDD6254FA31459085A648F4183AE590C5A648FD13E81B3286DA18344AAE0424E2255898344D8C8414E2E6C853D1E1B4EC8C2B1E5CEDC91C83F056FEFA543A5993311AA2B7D61768139950F330CDDC9DDDD32F4F47DC9A6810B4FE696365BE1C0531782CCF1D515BF9A8A575321D73B9A0ADD51D2C64A70B773EE86A2BFBBD6568482AD50C462EA7BDBDB8A279A0FF9183D6E6EDA8BCEE1F3A387D0AE21FA18CAAD204DDCAC1EA509476551D421B54F385FBA1B4F9B3912EF90DDA7C88830CF2AEAC245598CAE74F3CE7017EFC90275A5F64834029485A1458E184C10A104C6D4391C3EB8384FEE0CC2D538EC507C3027B751F1550E5CB2219B1C936CC5203C8D44D52D1CAE1CA4204DEEFA41AAB54756846BB2D08AEA01D80A9EC53A87F5284774722B53AE76F0ACDAF04E715FD8E23D58FB6AE3BA09D7EF79E376610DC63C467E9A4D9C89A2138E574DB123168D9393C068F9562A91F651CB5589EAD7DB714AA4C198570D843035DE5871552E97714C301A7F25C7546C5E21F8672EB556B06FEAA6A355D3CED53F27AF789245D0BDBFCB52B234290CA0F2B3B805C3C52006E95BA325836EEA3AFEE0D13B3EEC8E84511576755190B8CE3610D24184E2B3A9B3CAE922162C4E246D5BE74D4931B5FDE10D03F54F049D4005FB432706AF933954C73CFAC9B5A7097EB0D19EA6ADF36E64312B7CD8C7F66A0F1F523283117B965A4403446C9488369D60F3EB8D8AD95E0DE2226E5EEC2E3885124A61446293D6F3A325EDEF368C8886F098B3744A313D75139281AB763E8FFDE5638160526BF5F29FF1691C4172606E1A5C8234BA8305AABF5DF1F777F7F6858C9FDB937D7351142117DD6348C1C94FDC06322B4544B2C6EFCA46240349BF833CB807B9944E69545ECBDB08CD91D3F265889FFDF66E2AF1F399221BD43F24E0E18F2C967BBEA00967521D5AF36CA7718E55C4651C1B358B5C1AC5D09846D10D5CC876318A513697D8282045BE30F2B68DAAEC016E5072FEB0A148523EB151431473866DE73AD704CABC2EF45916BA227DE0B86524A608AC643A2241E0EBA27E098B5A1FD4B289E40BCA65577D793EC15AB610F4F06C720344B5F14C6C9349974FB43619AC74932CE24BDFB25EA4217C38F6FF55011C7A17FFF82A60BCF13EE5F8AC7AE8ED7AFFEEE3CFD2024B47FC011CCA30C3991C9C8BEEF9AE6C31D59B12B84AC23689AF3B16564CE436742FE212BB8DDA3AD4C9DBCC5B88E2ECA148DC366E575325671B773C9213B04D853789087509D686606993AB0DD53975B2B521AC6913AD0D713AC5346B73EFEF8A07C24D58CC59CE386A876098CB2EE6971A8FC6E5901A7B5A7AB67BB5E179719379A026DBB595699E465E7C49A99C7E2B1A33594EA9A9D3487559498667BBC1C0588B614E3A01E2A7142807911CE4749D476910AD41AC1A97FC4468639D89C45B58B1E60CAE614A68E8C66C47D3186ED4D21116AE49281BCBBA3561C62445BE98FE6C32B3688EF9338659954717582B13B57BAC7F0205724B4D369302D1CC40FD79835EA202E9826A9F910239E56F9B497F9E6AE37A62EDB1DEBB9E4879849098F6F5424C49234E318DB45245779872D8D5A130F8DC7C9B6185A8BDB3BAC5354D82272994408D4D632713636B95B4B82479065A5DAA3B895057A5A2C2E4CF339060F2E04934983A1591A63AB21809EF804A94F86A1531B6853DB96E796B49764DFAC8EA334789A425A32551965AA8080B8DDC864C3DAADE31D336A6416BD2AEF551A7DB712F75DAC6445D93CEEC2952022A138AA9D2341A36A1BE38514354A185107441F2D3A700E44622D5598A8453544DF4FEF442992FE3DF2442E1D68F26287D7AA1CC95E06F12914CB9741C12FAC911B7D8D9295372DF5EFF3A8345B4EA204838710A03CECD69DB5CA47759E379091C354D846BAB4B8800DE61C1498EA23B10205C4DAEDAAB94E6D5752A79F0B985E145FAA944EB12E121C3E436E63E2C235E5B1FFD2A6B21CFF3D1A775E53B4C3104CC66449E283EA5EFCB280E5BBECF15610C1A08E20ED25B72329788DC96AF1E5BA4AB2CB504A2E26BBDD81B98AC630C567C4A97E03B1CC21B56BF8F700582C7EEFA5307629E085EEC47671158E520292846D71FFFC43A1C260F3FFD1F77FD190B44820000, N'6.1.3-40302')
INSERT [dbo].[ApplicationUsers] ([Id], [FullName], [Address], [BirthDay], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'007cd382-7623-451f-b327-c358ae061db6', N'admin', NULL, CAST(0x0000A754008D4FDC AS DateTime), N'admin@gmail.com', 1, N'AGSp+9nh+hlCpBB3c9Iv0UGL63XcEpCbXKQgdj6mnUd5n0LrarWVlxxjrlui00Qx+g==', N'6f8b0d8f-92a1-4fb9-9ef1-58750345d68c', NULL, 0, 0, NULL, 0, 0, N'admin')
SET IDENTITY_INSERT [dbo].[ControPanels] ON 

INSERT [dbo].[ControPanels] ([ID], [Name], [Status]) VALUES (1, N'Tổ chức', 0)
INSERT [dbo].[ControPanels] ([ID], [Name], [Status]) VALUES (2, N'Quyên góp', 1)
SET IDENTITY_INSERT [dbo].[ControPanels] OFF
INSERT [dbo].[IdentityRoles] ([Id], [Name]) VALUES (N'e6317cff-a15c-4040-90da-949390ca07ed', N'Admin')
INSERT [dbo].[IdentityRoles] ([Id], [Name]) VALUES (N'fb6bf258-60fc-4537-8cd3-7c561840362b', N'User')
INSERT [dbo].[IdentityUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'007cd382-7623-451f-b327-c358ae061db6', N'e6317cff-a15c-4040-90da-949390ca07ed', NULL, NULL)
INSERT [dbo].[IdentityUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'007cd382-7623-451f-b327-c358ae061db6', N'fb6bf258-60fc-4537-8cd3-7c561840362b', NULL, NULL)
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ApplicationUser_Id]    Script Date: 15/04/2017 8:16:04 SA ******/
CREATE NONCLUSTERED INDEX [IX_ApplicationUser_Id] ON [dbo].[IdentityUserClaims]
(
	[ApplicationUser_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ApplicationUser_Id]    Script Date: 15/04/2017 8:16:04 SA ******/
CREATE NONCLUSTERED INDEX [IX_ApplicationUser_Id] ON [dbo].[IdentityUserLogins]
(
	[ApplicationUser_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ApplicationUser_Id]    Script Date: 15/04/2017 8:16:04 SA ******/
CREATE NONCLUSTERED INDEX [IX_ApplicationUser_Id] ON [dbo].[IdentityUserRoles]
(
	[ApplicationUser_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_IdentityRole_Id]    Script Date: 15/04/2017 8:16:04 SA ******/
CREATE NONCLUSTERED INDEX [IX_IdentityRole_Id] ON [dbo].[IdentityUserRoles]
(
	[IdentityRole_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Donations] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Laudatories] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[IdentityUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.IdentityUserClaims_dbo.ApplicationUsers_ApplicationUser_Id] FOREIGN KEY([ApplicationUser_Id])
REFERENCES [dbo].[ApplicationUsers] ([Id])
GO
ALTER TABLE [dbo].[IdentityUserClaims] CHECK CONSTRAINT [FK_dbo.IdentityUserClaims_dbo.ApplicationUsers_ApplicationUser_Id]
GO
ALTER TABLE [dbo].[IdentityUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.IdentityUserLogins_dbo.ApplicationUsers_ApplicationUser_Id] FOREIGN KEY([ApplicationUser_Id])
REFERENCES [dbo].[ApplicationUsers] ([Id])
GO
ALTER TABLE [dbo].[IdentityUserLogins] CHECK CONSTRAINT [FK_dbo.IdentityUserLogins_dbo.ApplicationUsers_ApplicationUser_Id]
GO
ALTER TABLE [dbo].[IdentityUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.IdentityUserRoles_dbo.ApplicationUsers_ApplicationUser_Id] FOREIGN KEY([ApplicationUser_Id])
REFERENCES [dbo].[ApplicationUsers] ([Id])
GO
ALTER TABLE [dbo].[IdentityUserRoles] CHECK CONSTRAINT [FK_dbo.IdentityUserRoles_dbo.ApplicationUsers_ApplicationUser_Id]
GO
ALTER TABLE [dbo].[IdentityUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.IdentityUserRoles_dbo.IdentityRoles_IdentityRole_Id] FOREIGN KEY([IdentityRole_Id])
REFERENCES [dbo].[IdentityRoles] ([Id])
GO
ALTER TABLE [dbo].[IdentityUserRoles] CHECK CONSTRAINT [FK_dbo.IdentityUserRoles_dbo.IdentityRoles_IdentityRole_Id]
GO
USE [master]
GO
ALTER DATABASE [DoAn] SET  READ_WRITE 
GO
