-- SQL has many statements/commands
-- categorized as a num of sub languages

-- data manipulation language (DML) operaates on individ rows
-- 5 DML commands in SQL server

-- SELECT, INSERT, UPDATE, DELETE, TRUNCATE TABLE

-- SELECT is for read access to the rows

SELECT * FROM Genre;
-- INSERT (simple)
INSERT INTO Genre VALUES (26, 'MISC');

-- really we should name the col
-- this is more readable/ less err prone
-- and lets us skip col that have default values we are ok with
INSERT INTO Genre (GenreId, Name) VALUES 
(
(SELECT MAX(GenreId) FROM Genre) + 1,
'MISC 3'
);

-- can insert multiple rows at once
INSERT INTO Genre (GenreId, Name) VALUES
	(29, 'MISC 4'),
	(30, 'MISC 5');

-- can insert the result of a query 
-- (this one duplicates every genre)
INSERT INTO Genre (GenreId, Name)
	(SELECT GenreId + 100, Name
	FROM Genre);

-- UPDATE statement
UPDATE Genre
SET Name = 'Misc 1' -- could change more than one column, comma separated
WHERE Name = 'Misc';

-- if we left out the WHERE, we would change every row

-- take the high ID copies of my MISC genres,
-- lower the IDs, and rename them to say Miscellaneous
UPDATE Genre
SET GenreId = GenreId - 50, Name = 'Miscellaneous ' + SUBSTRING(Name, 6, 1)
WHERE GenreId > 100 AND Name LIKE 'Misck'

SELECT 'Miscellaneous ' + SUBSTRING(Name, 6, 1)
FROM Genre

-- DELETE statement
DELETE FROM Genre
WHERE GenreId > 100; -- without where, would delete every row

-- TRUNCATE TABLE
-- TRUNCATE TABLE Genre; 
-- -- deletes every row, no conditions

-- DELETE FROM Genre deletes every row, one at a time
-- TRUNCATE TABLE Genre deletes every row all at once, faster


-- EXERCISES
--1. insert two new records into the employee table.
SELECT *
FROM Employee
INSERT INTO Employee (EmployeeId, LastName, FirstName, Title, ReportsTo, BirthDate, HireDate, Address, City, State, Country, PostalCode, Phone, Fax, Email)
VALUES
(9, 'Star', 'Joe', 'Stand User', NULL, NULL, NULL, 'jojojo Adventures', 'somewhere', 'KK', 'someCountry', 'T11111', '+1 (222)222-2222', '+1(333)333-3333', 'js@gmail.com'),
(10, 'Starrrr', 'Joeeee', 'Stand User', NULL, NULL, NULL, 'jojojo Adventures', 'somewhere', 'KK', 'someCountry', 'T11111', '+1 (222)222-2222', '+1(333)333-3333', 'js@gmail.com')
--2. insert two new records into the tracks table.
SELECT * 
FROM Track
INSERT INTO Track (TrackId, Name, AlbumId, MediaTypeId, GenreId, Composer, Milliseconds, Bytes, UnitPrice) VALUES
(3504, 'blah', 1, 1, 1, NULL, 7777, 9393993, 5.99),
(3505, 'blah2', 1, 1, 1, NULL, 7777, 9393993, 5.99)

--3. update customer Aaron Mitchell's name to Robert Walter
SELECT *
FROM Customer
WHERE FirstName = 'Aaron'

UPDATE Customer
SET FirstName = 'Robert', LastName = 'Walter'
WHERE FirstName = 'Aaron' AND LastName = 'Mitchell'

SELECT *
FROM Customer
WHERE FirstName = 'Robert'

--4. delete one of the employees you inserted.
DELETE FROM Track
WHERE TrackId = 3505;
SELECT * 
FROM Track

--5. delete customer Robert Walter. (more complex than it seems!)
DELETE FROM Customer
WHERE FirstName = 'Robert' AND LastName = 'Walter'
-- to preserve referential integrity, the DB throws an error
-- could set those FK values to NULL, or, we could delete all of them

-- so we need to remove all invoices that ref Robert 
-- and all invoice lines that ref those invoices
-- but in reverse order, deleting robert is last step