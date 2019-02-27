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

-- no good
ALTER TABLE Movie.Movie ADD CONSTRAINT NN_GenreID NOT NULL(GenreID);