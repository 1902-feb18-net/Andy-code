-- DDL

-- DATA Definition Language
-- Operates on whole tables at a time, can't see individual rows
-- also works with lots of other DB obj, like views, functions, procedures
-- tirggers, constraints, etc...

-- to create, change, and delete these DB objs, we have
-- CREATE, ALTER, DROP

-- GO is a special keyword to separate batches of commands
-- some commands demand to be in their own batch
CREATE SCHEMA Movie;
GO

-- CREATE TABLE
-- create table gets comma-separated list of col
-- each col has name and data type
CREATE TABLE Movie.Movie(
	MovieId INT
);

SELECT * FROM Movie.Movie;

-- We have ALTER TABLE to add or delete col
--		(And do some other things too)
ALTER TABLE Movie.Movie ADD
	Title NVARCHAR(200);

-- delete an entire table
DROP TABLE Movie.Movie;

-- we can specify constraints on each col

-- constraints:
--	- NOT NULL (null not allowed)
--	- NULL (not really a constraint, just being explicit)
--		(the default behavior: null is allowed)
--	- PRIMARY KEY 
--		(sets PK, enforces uniqueness, sets clustered index)
--		(implies NOT NULL, but we like to be explicit anyways)
--	- UNIQUE (can be set on multiple col, take together)
--	- CHECK (arbitrary condition that must be true for each row)
--	- DEFAULT (give a default value for that col when inserted w/o an explicit value)
--		NULL is the default DEFAULT
--	- FOREIGN KEY
--	- IDENTITY(start, increment) (not exactly a constraint but similar)
--		IDENTITY(10, 10) would count 10, 20, 30, 40 etc
--		Default values are 1, 1. (Counting: 1, 2, 3, 4, 5)
-- by default we aren't allowed to give explicit values for IDENTITY col
--		you'd need to turn on IDENTITY_INSERT option
CREATE TABLE Movie.Movie (
	MovieId INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Title NVARCHAR(200) NOT NULL,
	ReleaseDate DATETIME2 NOT NULL,
	DateModified DATETIME2 NOT NULL DEFAULT(GETDATE()),
	CONSTRAINT U_Movie_Title_Date UNIQUE (Title, ReleaseDate),
	-- constraint PK_blah PRIMARY KEY (col1, col2) -- (composite PK)
	CONSTRAINT CHK_DateNotTooEarly CHECK (ReleaseDate > '1900')
);

INSERT INTO Movie.Movie (Title, ReleaseDate) VALUES (
	'LOTR: THE FELLOWSHIP OF THE RING', '2001'
);

SELECT * FROM Movie.Movie;

DROP TABLE Movie.Genre;
CREATE TABLE Movie.Genre (
	GenreId INT NOT NULL PRIMARY KEY IDENTITY,
	Name NVARCHAR(100) NOT NULL,
	DateModified DATETIME2 DEFAULT(GETDATE()),
	CHECK (Name != ''),
);

ALTER TABLE Movie.Movie ADD
	GenreID INT NULL,
	CONSTRAINT FK_Movie_Genre FOREIGN KEY (GenreID) REFERENCES Movie.Genre(GenreId)

-- adding col without some default (or allowing null as default) is not allowed
-- workaround: allow NULL at first, fiz up existing rows, then add NOT NULL constraint

INSERT INTO Movie.Genre (NAME) VALUES ('Action/Adventure');

UPDATE Movie.Movie SET GenreID = 1;

SELECT * FROM Movie.Movie;

DELETE FROM Movie.Genre;

ALTER TABLE Movie.Movie 
	ALTER COLUMN  GenreID INT NOT NULL;


-- Computed columns

-- dropping FullName after making a mistake
--ALTER TABLE Movie.Movie DROP COLUMN FullName;

ALTER TABLE Movie.Movie ADD
	FullName AS (Title + ' (' + CONVERT(NVARCHAR, YEAR(ReleaseDate)) + ')');

SELECT * FROM Movie.Movie
-- Comuted col have different options like PERSISTED

-- view
GO

--ALTER VIEW Movie.NewReleases AS
--	SELECT * FROM Movie.Movie
--	WHERE RleaseDate 

CREATE VIEW Movie.NewReleases AS 
	SELECT * FROM Movie.Movie
	WHERE ReleaseDate > '2019-01-01';
GO

SELECT * FROM Movie.NewReleases;

INSERT INTO Movie.NewReleases (Title, ReleaseDate, GenreID) VALUES
	('LOTR: The Two Towers', '2019-02-01', 
		(SELECT GenreId FROM Movie.Genre WHERE Name = 'Action/Adventure'));

-- views provides an abstraction over the actual table structure
-- by running a query behind the scenes to generated what pretends to be a table

-- we can do inserts/updates/deletes through it too, but
-- only on col that directly map to real table col

--var in SQL server using @ symbols
DECLARE @action AS INT;
SET @action = 1;

-- table-valued var
DECLARE @my_table AS TABLE (
	col1 INT, col2 INT
);

-- can use above as a temporary table
-- use things like INSERT INTO @my_table
-- .. etc

-- user-defined functions
GO
CREATE FUNCTION Movie.MoviesReleasedInYear(@year INT)
RETURNS INT
AS
BEGIN
	DECLARE @result INT;

	SELECT @result = COUNT(*)
	FROM Movie.Movie
	WHERE YEAR(ReleaseDate) = @year;

	RETURN @result;
END
GO

SELECT Movie.MoviesReleasedInYear(2002);

-- functions do not allow writing any data = only reading

-- EXERCISE
-- 1. write a function to get the initials of a customer based on his ID (look up string functions)
GO
--CREATE FUNCTION CustomerInitials(@initials VARCHAR)
--RETURNS VARCHAR
--AS
--BEGIN
--	DECLARE @result VARCHAR;
--	SELECT @result = LEFT(c.FirstName, 1) + LEFT(c.LastName, 1)
--	FROM Customer AS c
--	RETURN @result;
--END

CREATE FUNCTION GetCustomerInitials(@Id INT)
RETURNS NVARCHAR(3)
AS
BEGIN
	DECLARE @initials NVARCHAR(3);

	-- in SQL, string indexing is 1-based
	SELECT @initials = SUBSTRING(FirstName, 1, 1) + SUBSTRING(LastName, 1, 1)
	FROM Customer
	WHERE CustomerId = @id;

	RETURN @initials;
END
GO

CREATE TRIGGER Movie.MovieDateModified ON Movie.Movie
AFTER UPDATE
AS
BEGIN
	-- inside a trigger you have access to two special table vars
	-- inserted and deleted
	UPDATE Movie.Movie
	SET DateModified = GETDATE()
	WHERE MovieId IN (SELECT MovieId FROM inserted)
	-- in this case , inserted has the new verson of updated rows
END

SELECT * FROM Movie.Movie;
UPDATE Movie.Movie
SET Title = 'LOTR: FEllowship of the ring'
WHERE MovieId = 1;

-- we can do triggers on INSERT, UPDATE, or DELETE
-- they can be BEFORE, AFTER, or INSTEAD OF


-- PROCEDURES
-- procedure are like functions
-- but they allow any sql command inside them, including DB write
-- they don't have to return anything
-- you can only call them with EXECUTE, never inside a SELECT or anything else
GO
CREATE PROCEDURE Movie.RenameMovies(@newname NVARCHAR(50), @rowsChanged INT OUTPUT)
AS
BEGIN
	-- we can use WHILE loops, IF ELSE, TRY CATCH
	BEGIN TRY
		If (EXISTS (SELECT * FROM Movie.Movie))
		BEGIN 
			SET @rowsChanged = (SELECT COUNT(*) FROM Movie.Movie)
			UPDATE Movie.Movie
			SET Title = @newname
		END
		ELSE
		BEGIN
			SET @rowsChanged = 0;
			RAISERROR('No movies found!', 16, 1);
		END
		END TRY
	BEGIN CATCH
		PRINT ERROR_MESSAGE()
	END CATCH
END
GO

-- how to use a procedure, ALMOST correct
DECLARE @rowschanged INT;
EXECUTE Movie.RenameMovies 'Movie', @rowschanged;
SELECT @rowschanged;