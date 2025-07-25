USE [master]
GO
/****** Object:  Database [moviesDb]    Script Date: 4.07.2025 11:43:08 ******/
CREATE DATABASE [moviesDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'moviesDb', FILENAME = N'C:\Users\Vahap\moviesDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'moviesDb_log', FILENAME = N'C:\Users\Vahap\moviesDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [moviesDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [moviesDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [moviesDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [moviesDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [moviesDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [moviesDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [moviesDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [moviesDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [moviesDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [moviesDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [moviesDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [moviesDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [moviesDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [moviesDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [moviesDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [moviesDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [moviesDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [moviesDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [moviesDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [moviesDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [moviesDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [moviesDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [moviesDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [moviesDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [moviesDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [moviesDb] SET  MULTI_USER 
GO
ALTER DATABASE [moviesDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [moviesDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [moviesDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [moviesDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [moviesDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [moviesDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [moviesDb] SET QUERY_STORE = OFF
GO
USE [moviesDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4.07.2025 11:43:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Casts]    Script Date: 4.07.2025 11:43:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Casts](
	[CastId] [int] IDENTITY(1,1) NOT NULL,
	[MovieId] [int] NOT NULL,
	[PersonId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Role] [nvarchar](max) NULL,
 CONSTRAINT [PK_Casts] PRIMARY KEY CLUSTERED 
(
	[CastId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Crews]    Script Date: 4.07.2025 11:43:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Crews](
	[CrewId] [int] IDENTITY(1,1) NOT NULL,
	[MovieId] [int] NOT NULL,
	[PersonId] [int] NOT NULL,
	[Job] [nvarchar](max) NULL,
 CONSTRAINT [PK_Crews] PRIMARY KEY CLUSTERED 
(
	[CrewId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GenreMovie]    Script Date: 4.07.2025 11:43:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GenreMovie](
	[GenresGenreId] [int] NOT NULL,
	[MoviesMovieId] [int] NOT NULL,
 CONSTRAINT [PK_GenreMovie] PRIMARY KEY CLUSTERED 
(
	[GenresGenreId] ASC,
	[MoviesMovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 4.07.2025 11:43:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[GenreId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
(
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 4.07.2025 11:43:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[MovieId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[GenreId] [int] NOT NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[People]    Script Date: 4.07.2025 11:43:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Biography] [nvarchar](max) NULL,
	[Imdb] [nvarchar](max) NULL,
	[HomePage] [nvarchar](max) NULL,
	[PlaceOfBirth] [nvarchar](max) NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 4.07.2025 11:43:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250511133630_InitialCreate', N'8.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250511185951_UpdateOneToMany', N'8.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250512190547_OneToOneRelation', N'8.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250513205729_ManyToMany', N'8.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250513225236_ManyToManyRelation2', N'8.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250519145926_UpdateFluentApi', N'8.0.11')
GO
SET IDENTITY_INSERT [dbo].[Casts] ON 

INSERT [dbo].[Casts] ([CastId], [MovieId], [PersonId], [Name], [Role]) VALUES (3, 14, 3, N'Oyuncu 1', N'Rol 1')
INSERT [dbo].[Casts] ([CastId], [MovieId], [PersonId], [Name], [Role]) VALUES (4, 14, 4, N'Oyuncu 2', N'Rol 2')
SET IDENTITY_INSERT [dbo].[Casts] OFF
GO
SET IDENTITY_INSERT [dbo].[Crews] ON 

INSERT [dbo].[Crews] ([CrewId], [MovieId], [PersonId], [Job]) VALUES (3, 14, 3, N'Yönetmen')
INSERT [dbo].[Crews] ([CrewId], [MovieId], [PersonId], [Job]) VALUES (4, 14, 4, N'Yönetmen Yard.')
SET IDENTITY_INSERT [dbo].[Crews] OFF
GO
INSERT [dbo].[GenreMovie] ([GenresGenreId], [MoviesMovieId]) VALUES (3, 4)
INSERT [dbo].[GenreMovie] ([GenresGenreId], [MoviesMovieId]) VALUES (5, 4)
INSERT [dbo].[GenreMovie] ([GenresGenreId], [MoviesMovieId]) VALUES (2, 5)
INSERT [dbo].[GenreMovie] ([GenresGenreId], [MoviesMovieId]) VALUES (3, 6)
INSERT [dbo].[GenreMovie] ([GenresGenreId], [MoviesMovieId]) VALUES (7, 6)
INSERT [dbo].[GenreMovie] ([GenresGenreId], [MoviesMovieId]) VALUES (3, 7)
INSERT [dbo].[GenreMovie] ([GenresGenreId], [MoviesMovieId]) VALUES (5, 7)
INSERT [dbo].[GenreMovie] ([GenresGenreId], [MoviesMovieId]) VALUES (3, 8)
INSERT [dbo].[GenreMovie] ([GenresGenreId], [MoviesMovieId]) VALUES (4, 8)
INSERT [dbo].[GenreMovie] ([GenresGenreId], [MoviesMovieId]) VALUES (17, 13)
INSERT [dbo].[GenreMovie] ([GenresGenreId], [MoviesMovieId]) VALUES (17, 14)
INSERT [dbo].[GenreMovie] ([GenresGenreId], [MoviesMovieId]) VALUES (19, 14)
INSERT [dbo].[GenreMovie] ([GenresGenreId], [MoviesMovieId]) VALUES (17, 15)
INSERT [dbo].[GenreMovie] ([GenresGenreId], [MoviesMovieId]) VALUES (17, 16)
INSERT [dbo].[GenreMovie] ([GenresGenreId], [MoviesMovieId]) VALUES (17, 17)
GO
SET IDENTITY_INSERT [dbo].[Genres] ON 

INSERT [dbo].[Genres] ([GenreId], [Name]) VALUES (2, N'Bilim-Kurgu')
INSERT [dbo].[Genres] ([GenreId], [Name]) VALUES (3, N'Dram')
INSERT [dbo].[Genres] ([GenreId], [Name]) VALUES (4, N'Romantik')
INSERT [dbo].[Genres] ([GenreId], [Name]) VALUES (5, N'Savaş')
INSERT [dbo].[Genres] ([GenreId], [Name]) VALUES (7, N'Komedi')
INSERT [dbo].[Genres] ([GenreId], [Name]) VALUES (17, N'Korku')
INSERT [dbo].[Genres] ([GenreId], [Name]) VALUES (19, N'Bilim-Kurgu')
SET IDENTITY_INSERT [dbo].[Genres] OFF
GO
SET IDENTITY_INSERT [dbo].[Movies] ON 

INSERT [dbo].[Movies] ([MovieId], [Title], [Description], [ImageUrl], [GenreId]) VALUES (4, N'The Godfather', N'Corleone ailesinin başındaki Vito Corleone''nin hikayesi, suç dünyasındaki güç mücadelelerini ve ailenin iç dinamiklerini derinlemesine işler. Mafya sinemasının en güçlü örneklerinden biridir.', N'2.jpg', 0)
INSERT [dbo].[Movies] ([MovieId], [Title], [Description], [ImageUrl], [GenreId]) VALUES (5, N'Interstellar', N'Küresel bir kıtlık ve çevresel çöküş sonrası, bir grup astronot yeni bir yaşanabilir gezegen bulmak için solucan deliğinden geçerek bilinmezliğe doğru epik bir yolculuğa çıkar.', N'3.jpg', 0)
INSERT [dbo].[Movies] ([MovieId], [Title], [Description], [ImageUrl], [GenreId]) VALUES (6, N'Recep İvedik', N'Sıradışı ve kaba tavırlarıyla tanınan Recep''in, gündelik hayatın içinde yaşadığı absürt ve komik olaylarla izleyiciyi kahkahaya boğan hikayesi.', N'4.jpg', 0)
INSERT [dbo].[Movies] ([MovieId], [Title], [Description], [ImageUrl], [GenreId]) VALUES (7, N'Ayla', N'Kore Savaşı''na katılan Türk astsubay Süleyman Dilbirliği''nin savaş alanında bulduğu küçük Koreli bir kıza sahip çıkması ve aralarındaki duygusal bağ, izleyenleri derinden etkiler.', N'5.jpg', 0)
INSERT [dbo].[Movies] ([MovieId], [Title], [Description], [ImageUrl], [GenreId]) VALUES (8, N'The Shawshank Redemption', N'Haksız yere ömür boyu hapse mahkum edilen Andy Dufresne''nin, Shawshank hapishanesindeki zekice planıyla yıllar süren bir özgürlük mücadelesini anlatır.', N'6.jpg', 0)
INSERT [dbo].[Movies] ([MovieId], [Title], [Description], [ImageUrl], [GenreId]) VALUES (13, N'Hüddam 2', N'<p>&Ccedil;ok korkutucu bir k&ouml;yde ge&ccedil;en film.</p>', N'no-image.jpg', 0)
INSERT [dbo].[Movies] ([MovieId], [Title], [Description], [ImageUrl], [GenreId]) VALUES (14, N'Inception', N'Zihinlerin derinliklerinde geçen çok katmanlı bir rüya yolculuğunda, bir grup uzman bilinçaltına fikir yerleştirmeye çalışır. Gerçeklik ile rüya arasındaki çizgi giderek bulanıklaşır.', N'1.jpg', 0)
INSERT [dbo].[Movies] ([MovieId], [Title], [Description], [ImageUrl], [GenreId]) VALUES (15, N'Yeni Korku filmi 1', N'Zihinlerin derinliklerinde geçen çok katmanlı bir rüya yolculuğunda, bir grup uzman bilinçaltına fikir yerleştirmeye çalışır. Gerçeklik ile rüya arasındaki çizgi giderek bulanıklaşır.', N'1.jpg', 0)
INSERT [dbo].[Movies] ([MovieId], [Title], [Description], [ImageUrl], [GenreId]) VALUES (16, N'Yeni Korku filmi 2', N'Corleone ailesinin başındaki Vito Corleone''nin hikayesi, suç dünyasındaki güç mücadelelerini ve ailenin iç dinamiklerini derinlemesine işler. Mafya sinemasının en güçlü örneklerinden biridir.', N'2.jpg', 0)
INSERT [dbo].[Movies] ([MovieId], [Title], [Description], [ImageUrl], [GenreId]) VALUES (17, N'Siccin 5', N'<p><strong>Siccin 5</strong> filmi a&ccedil;ıklaması</p>', N'b39154e4-6967-4c25-a29c-c8eb656dd74b.jpg', 0)
SET IDENTITY_INSERT [dbo].[Movies] OFF
GO
SET IDENTITY_INSERT [dbo].[People] ON 

INSERT [dbo].[People] ([PersonId], [Name], [Biography], [Imdb], [HomePage], [PlaceOfBirth], [UserId]) VALUES (1, N'Personel 1', N'Tanıtım 1', NULL, NULL, NULL, 1)
INSERT [dbo].[People] ([PersonId], [Name], [Biography], [Imdb], [HomePage], [PlaceOfBirth], [UserId]) VALUES (2, N'Personel 2', N'Tanıtım 2', NULL, NULL, NULL, 2)
INSERT [dbo].[People] ([PersonId], [Name], [Biography], [Imdb], [HomePage], [PlaceOfBirth], [UserId]) VALUES (3, N'Personel 1', N'Tanıtım 1', NULL, NULL, NULL, 5)
INSERT [dbo].[People] ([PersonId], [Name], [Biography], [Imdb], [HomePage], [PlaceOfBirth], [UserId]) VALUES (4, N'Personel 2', N'Tanıtım 2', NULL, NULL, NULL, 6)
SET IDENTITY_INSERT [dbo].[People] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [UserName], [Email], [Password], [ImageUrl]) VALUES (1, N'User a', N'a_user@gmail.com', N'a123', N'person1.png')
INSERT [dbo].[Users] ([UserId], [UserName], [Email], [Password], [ImageUrl]) VALUES (2, N'User b', N'b_user@gmail.com', N'b123', N'person2.png')
INSERT [dbo].[Users] ([UserId], [UserName], [Email], [Password], [ImageUrl]) VALUES (3, N'User c', N'c_user@gmail.com', N'c123', N'person3.png')
INSERT [dbo].[Users] ([UserId], [UserName], [Email], [Password], [ImageUrl]) VALUES (4, N'User d', N'd_user@gmail.com', N'd123', N'person4.png')
INSERT [dbo].[Users] ([UserId], [UserName], [Email], [Password], [ImageUrl]) VALUES (5, N'User a', N'a_user@gmail.com', N'a123', N'person1.png')
INSERT [dbo].[Users] ([UserId], [UserName], [Email], [Password], [ImageUrl]) VALUES (6, N'User b', N'b_user@gmail.com', N'b123', N'person2.png')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [IX_Casts_MovieId]    Script Date: 4.07.2025 11:43:08 ******/
CREATE NONCLUSTERED INDEX [IX_Casts_MovieId] ON [dbo].[Casts]
(
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Casts_PersonId]    Script Date: 4.07.2025 11:43:08 ******/
CREATE NONCLUSTERED INDEX [IX_Casts_PersonId] ON [dbo].[Casts]
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Crews_MovieId]    Script Date: 4.07.2025 11:43:08 ******/
CREATE NONCLUSTERED INDEX [IX_Crews_MovieId] ON [dbo].[Crews]
(
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Crews_PersonId]    Script Date: 4.07.2025 11:43:08 ******/
CREATE NONCLUSTERED INDEX [IX_Crews_PersonId] ON [dbo].[Crews]
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_GenreMovie_MoviesMovieId]    Script Date: 4.07.2025 11:43:08 ******/
CREATE NONCLUSTERED INDEX [IX_GenreMovie_MoviesMovieId] ON [dbo].[GenreMovie]
(
	[MoviesMovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_People_UserId]    Script Date: 4.07.2025 11:43:08 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_People_UserId] ON [dbo].[People]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Casts]  WITH CHECK ADD  CONSTRAINT [FK_Casts_Movies_MovieId] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movies] ([MovieId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Casts] CHECK CONSTRAINT [FK_Casts_Movies_MovieId]
GO
ALTER TABLE [dbo].[Casts]  WITH CHECK ADD  CONSTRAINT [FK_Casts_People_PersonId] FOREIGN KEY([PersonId])
REFERENCES [dbo].[People] ([PersonId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Casts] CHECK CONSTRAINT [FK_Casts_People_PersonId]
GO
ALTER TABLE [dbo].[Crews]  WITH CHECK ADD  CONSTRAINT [FK_Crews_Movies_MovieId] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movies] ([MovieId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Crews] CHECK CONSTRAINT [FK_Crews_Movies_MovieId]
GO
ALTER TABLE [dbo].[Crews]  WITH CHECK ADD  CONSTRAINT [FK_Crews_People_PersonId] FOREIGN KEY([PersonId])
REFERENCES [dbo].[People] ([PersonId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Crews] CHECK CONSTRAINT [FK_Crews_People_PersonId]
GO
ALTER TABLE [dbo].[GenreMovie]  WITH CHECK ADD  CONSTRAINT [FK_GenreMovie_Genres_GenresGenreId] FOREIGN KEY([GenresGenreId])
REFERENCES [dbo].[Genres] ([GenreId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GenreMovie] CHECK CONSTRAINT [FK_GenreMovie_Genres_GenresGenreId]
GO
ALTER TABLE [dbo].[GenreMovie]  WITH CHECK ADD  CONSTRAINT [FK_GenreMovie_Movies_MoviesMovieId] FOREIGN KEY([MoviesMovieId])
REFERENCES [dbo].[Movies] ([MovieId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GenreMovie] CHECK CONSTRAINT [FK_GenreMovie_Movies_MoviesMovieId]
GO
ALTER TABLE [dbo].[People]  WITH CHECK ADD  CONSTRAINT [FK_People_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[People] CHECK CONSTRAINT [FK_People_Users_UserId]
GO
USE [master]
GO
ALTER DATABASE [moviesDb] SET  READ_WRITE 
GO
