USE [LibraryManagementSystemm]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 30/04/2023 1:21:23 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[AuthorId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](255) NOT NULL,
	[LastName] [varchar](255) NOT NULL,
	[Country] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookAuthorDetails]    Script Date: 30/04/2023 1:21:23 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookAuthorDetails](
	[BookID] [int] IDENTITY(1,1) NOT NULL,
	[AuthorId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[AuthorDetails]    Script Date: 30/04/2023 1:21:23 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[AuthorDetails] WITH SCHEMABINDING AS
SELECT a.FirstName, a.LastName, a.Country, COUNT(bad.BookID) AS BookCount
FROM dbo.[Author] a
INNER JOIN dbo.[BookAuthorDetails] bad ON a.AuthorID = bad.AuthorID
GROUP BY a.FirstName, a.LastName, a.Country;

GO
/****** Object:  Table [dbo].[Book]    Script Date: 30/04/2023 1:21:23 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[BookID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](255) NOT NULL,
	[AuthorId] [int] NOT NULL,
	[YearPublished] [int] NOT NULL,
	[TotalCopies] [int] NOT NULL,
	[AvailableCopies] [int] NOT NULL,
	[status] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookGenre]    Script Date: 30/04/2023 1:21:23 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookGenre](
	[BookID] [int] IDENTITY(1,1) NOT NULL,
	[GenreId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 30/04/2023 1:21:23 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GenreName] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[AvailableBooks]    Script Date: 30/04/2023 1:21:23 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[AvailableBooks] WITH SCHEMABINDING AS
SELECT b.Title, a.FirstName, a.LastName, g.GenreName
FROM dbo.[Book] b
INNER JOIN dbo.[BookAuthorDetails] bad ON b.BookID = bad.BookID
INNER JOIN dbo.[Author] a ON bad.AuthorID = a.AuthorID
INNER JOIN dbo.[BookGenre] bg ON b.BookID = bg.BookID
INNER JOIN dbo.[Genre] g ON bg.GenreID = g.ID
WHERE b.AvailableCopies > 0;

GO
/****** Object:  View [dbo].[BookDetails]    Script Date: 30/04/2023 1:21:23 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[BookDetails] WITH SCHEMABINDING AS
SELECT b.Title, a.FirstName, a.LastName, g.GenreName, b.TotalCopies
FROM dbo.[Book] b
INNER JOIN dbo.[BookAuthorDetails] bad ON b.BookID = bad.BookID
INNER JOIN dbo.[Author] a ON bad.AuthorID = a.AuthorID
INNER JOIN dbo.[BookGenre] bg ON b.BookID = bg.BookID
INNER JOIN dbo.[Genre] g ON bg.GenreID = g.ID;

GO
/****** Object:  View [dbo].[BookGenres]    Script Date: 30/04/2023 1:21:23 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[BookGenres] WITH SCHEMABINDING AS
SELECT b.Title, g.GenreName
FROM dbo.[Book] b
INNER JOIN dbo.[BookGenre] bg ON b.BookID = bg.BookID
INNER JOIN dbo.[Genre] g ON bg.GenreID = g.ID;

GO
/****** Object:  Table [dbo].[IssuanceDetails]    Script Date: 30/04/2023 1:21:23 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IssuanceDetails](
	[IssuanceId] [int] IDENTITY(1,1) NOT NULL,
	[BookId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[BookIssuanceCount]    Script Date: 30/04/2023 1:21:23 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[BookIssuanceCount] WITH SCHEMABINDING AS
SELECT b.Title, COUNT(i.BookID) AS IssuanceCount
FROM dbo.[Book] b
INNER JOIN dbo.[IssuanceDetails] i ON b.BookID = i.BookID
GROUP BY b.Title;

GO
/****** Object:  View [dbo].[BookStatus]    Script Date: 30/04/2023 1:21:23 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[BookStatus] WITH SCHEMABINDING AS
SELECT Title, Status
FROM dbo.[Book];

GO
/****** Object:  View [dbo].[BookYear]    Script Date: 30/04/2023 1:21:23 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[BookYear] WITH SCHEMABINDING AS
SELECT Title, YearPublished
FROM dbo.[Book];

GO
/****** Object:  Table [dbo].[Floors]    Script Date: 30/04/2023 1:21:23 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Floors](
	[FloorId] [int] IDENTITY(1,1) NOT NULL,
	[FloorNo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FloorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Librarian]    Script Date: 30/04/2023 1:21:23 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Librarian](
	[LibrarianId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[City] [varchar](255) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Address] [varchar](255) NOT NULL,
	[FloorId] [int] NOT NULL,
	[Status] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LibrarianId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 30/04/2023 1:21:23 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](255) NOT NULL,
	[Password] [varchar](255) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[Role] [varchar](255) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Phone] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[LibrarianDetails]    Script Date: 30/04/2023 1:21:23 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[LibrarianDetails] WITH SCHEMABINDING AS
SELECT u.Name, l.City, l.Address, f.FloorNo
FROM dbo.[Librarian] l
INNER JOIN dbo.[Users] u ON l.UserID = u.UserID
INNER JOIN dbo.[Floors] f ON l.FloorID = f.FloorID;

GO
/****** Object:  View [dbo].[RecentBooks]    Script Date: 30/04/2023 1:21:23 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[RecentBooks] WITH SCHEMABINDING AS
SELECT b.Title, a.FirstName, a.LastName, g.GenreName
FROM dbo.[Book] b
INNER JOIN dbo.[BookAuthorDetails] bad ON b.BookID = bad.BookID
INNER JOIN dbo.[Author] a ON bad.AuthorID = a.AuthorID
INNER JOIN dbo.[BookGenre] bg ON b.BookID = bg.BookID
INNER JOIN dbo.[Genre] g ON bg.GenreID = g.ID
WHERE b.YearPublished >= YEAR(DATEADD(year, -5, GETDATE()));

GO
/****** Object:  Table [dbo].[Student]    Script Date: 30/04/2023 1:21:23 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RollNumber] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[StudentDetails]    Script Date: 30/04/2023 1:21:23 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[StudentDetails] WITH SCHEMABINDING AS
SELECT s.StudentID, u.Name, s.RollNumber
FROM dbo.[Student] s
INNER JOIN dbo.[Users] u ON s.UserID = u.UserID;

GO
/****** Object:  Table [dbo].[Administrator]    Script Date: 30/04/2023 1:21:23 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrator](
	[AdministratorId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[String] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AdministratorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FloorsGenre]    Script Date: 30/04/2023 1:21:23 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FloorsGenre](
	[FloorId] [int] IDENTITY(1,1) NOT NULL,
	[GenreId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Issuance]    Script Date: 30/04/2023 1:21:23 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Issuance](
	[IssuanceId] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[IssuanceDate] [date] NOT NULL,
	[DueDate] [date] NOT NULL,
	[ReturnDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[IssuanceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LibrarianAttendance]    Script Date: 30/04/2023 1:21:23 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LibrarianAttendance](
	[AttendanceId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Status] [varchar](20) NOT NULL,
 CONSTRAINT [PK__Libraria__8B69261CC78CC685] PRIMARY KEY CLUSTERED 
(
	[AttendanceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReturnDetails]    Script Date: 30/04/2023 1:21:23 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReturnDetails](
	[ReturnId] [int] NOT NULL,
	[BookId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Returns]    Script Date: 30/04/2023 1:21:23 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Returns](
	[ReturnId] [int] IDENTITY(1,1) NOT NULL,
	[IssuanceId] [int] NOT NULL,
	[ReturnRate] [date] NOT NULL,
	[FineAmount] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ReturnId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 30/04/2023 1:21:23 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Category] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StaffAttendance]    Script Date: 30/04/2023 1:21:23 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StaffAttendance](
	[Id] [int] NOT NULL,
	[AttendanceDate] [datetime] NOT NULL,
 CONSTRAINT [PK_StaffAttendance] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 30/04/2023 1:21:23 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[StatusId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Category] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transaction]    Script Date: 30/04/2023 1:21:23 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaction](
	[TransactionId] [int] NOT NULL,
	[IssuanceId] [int] NOT NULL,
	[Fine] [int] NOT NULL,
 CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED 
(
	[TransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Administrator]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Author] ([AuthorId])
GO
ALTER TABLE [dbo].[Issuance]  WITH CHECK ADD FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
ALTER TABLE [dbo].[Librarian]  WITH CHECK ADD FOREIGN KEY([FloorId])
REFERENCES [dbo].[Floors] ([FloorId])
GO
ALTER TABLE [dbo].[Librarian]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[LibrarianAttendance]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Librarian] ([LibrarianId])
GO
ALTER TABLE [dbo].[Returns]  WITH CHECK ADD FOREIGN KEY([IssuanceId])
REFERENCES [dbo].[Issuance] ([IssuanceId])
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
/****** Object:  StoredProcedure [dbo].[asp_UpdateBook]    Script Date: 30/04/2023 1:21:23 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[asp_UpdateBook]
    @BookID INT,
    @Title NVARCHAR(255),
    @YearPublished INT,
    @TotalCopies INT,
    @AvaliableCopies INT,
    @status varchar(20)
AS
BEGIN
   SET NOCOUNT ON;
    UPDATE Book
    SET Title = @Title,
        YearPublished = @YearPublished,
        TotalCopies = @TotalCopies,
        AvailableCopies = @AvaliableCopies,
        status = @status
    WHERE BookID = @BookID;
END
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertBook]    Script Date: 30/04/2023 1:21:23 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertBook]
    @Title NVARCHAR(255),
    @YearPublished INT,
    @TotalCopies INT,
    @AvaliableCopies INT,
    @status varchar(20)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Book (Title, YearPublished, TotalCopies, AvailableCopies, Status)
    VALUES (@Title, @YearPublished, @TotalCopies, @AvaliableCopies, @status);
END
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertGenre]    Script Date: 30/04/2023 1:21:23 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertGenre]
    @GenreName VARCHAR(255)
AS
BEGIN
SET NOCOUNT ON;
    INSERT INTO Genre (GenreName)
    VALUES (@GenreName)
END
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertLibrarian]    Script Date: 30/04/2023 1:21:23 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertLibrarian]
    @UserId int,
    @City varchar(50),
    @Name varchar(50),
    @Address varchar(100),
    @FloorId int,
    @Status varchar(50)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Librarian (UserId, City, Name, Address, FloorId, Status)
    VALUES (@UserId, @City, @Name, @Address, @FloorId, @Status)
END
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateGenre]    Script Date: 30/04/2023 1:21:23 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UpdateGenre]
    @Id INT,
    @GenreName VARCHAR(255)
AS
BEGIN
SET NOCOUNT ON;
    UPDATE Genre
    SET GenreName = @GenreName
    WHERE	Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateLibrarian]    Script Date: 30/04/2023 1:21:23 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UpdateLibrarian]
    @LibrarianId int,
    @UserId int,
    @City varchar(255),
    @Name varchar(255),
    @Address varchar(255),
    @FloorId int,
    @Status varchar(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Librarian
    SET UserId = @UserId,
        City = @City,
		Name = @Name,
        Address = @Address,
        FloorId = @FloorId,
        Status = @Status
    WHERE LibrarianId = @LibrarianId
END
GO
