-- joins

-- cross join
-- example: Subways: bread x meat x add ons x sauce = a ton of possibilities

SELECT e1.*, e2.*
FROM Employee AS e1 CROSS JOIN Employee AS e2


-- most common join, inner
-- most common condition for inner join: foreign key = primary key
SELECT *
FROM Track INNER JOIN Genre ON Track.GenreId = Genre.GenreId;

-- joining on 'true' is the same as a cross join
SELECT * 
FROM Track INNER JOIN Genre ON 1 = 1;

-- 3 kinds of outer join: left outer, right outer, full outer
SELECT  Track.Name, Genre.Name
FROM Track RIGHT JOIN Genre ON Track.GenreId = Genre.GenreId

SELECT  t.Name, g.Name
FROM Track t RIGHT JOIN Genre g ON t.GenreId = g.GenreId;

-- all rock songs in db, showing full artist name and song name
SELECT ar.Name + ' - ' + t.name
FROM Track as t
	INNER JOIN Album as a1 on t.AlbumId = a1.AlbumId
	INNER JOIN Artist AS ar ON a1.ArtistId = ar.artistId
	INNER JOIN Genre AS g ON t.GenreId = g.GenreId
WHERE g.Name = 'Rock'

-- Every employeetogether with who he reports to (his manager) if any
SELECT *
FROM Employee AS emp
	LEFT OUTER JOIN Employee AS mgr ON emp.ReportsTo = mgr.EmployeeId;

-- JOIN EXERCISES!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
--1. show all invoices of customers from brazil (mailing address not billing)
SELECT c.FirstName, c.LastName, I.*
FROM Invoice as I
	JOIN Customer AS c ON i.CustomerId = c.CustomerId
WHERE c.Country = 'Brazil'

--2. show all invoices together with the name of the sales agent of each one
SELECT i1.InvoiceId, e1.FirstName, e1.LastName
FROM Invoice AS i1
	INNER JOIN Customer AS c ON c.CustomerId = i1.CustomerId
	INNER JOIN Employee AS e1 ON e1.EmployeeId = c.SupportRepId;

--3. show all playlists ordered by the total number of tracks they have
SELECT pl.Name, COUNT(pl.PlaylistId)
FROM Playlist AS pl
	INNER JOIN PlaylistTrack AS plt ON plt.PlaylistId = pl.PlaylistId
GROUP BY pl.PlaylistId, pl.Name;

--4. which sales agent made the most in sales in 2009?
--5. how many customers are assigned to each sales agent?
--6. which track was purchased the most since 2010?
--7. show the top three best-selling artists.
--8. which customers have the same initials as at least one other customer?



-- subqueries

-- another way besides joins to combine info from multiple tables
SELECT *
FROM Track AS t
WHERE t.TrackId NOT IN (
	SELECT TrackId
	FROM Invoice
);

--// here we have a subquery in the WHERE clause of another query
-- we have operators IN, NOT IN

SELECT t.Name
FROM Track as t
WHERE t.TrackId = (
	SELECT TOP(1) TrackId
	FROM InvoiceLine
	GROUP BY TrackId
	ORDER BY COUNT(*) DESC
);

-- We have TOP(n) to take just the first n results of a query
-- the inner query is: get the top trackid when we group all the invoicelines
-- by trackid and count up how many in each group

-- we can also have subqueries in HAVING (no difference)
-- but also in FROM clause

SELECT * 
FROM Track INNER JOIN(
		SELECT Artist.Name AS Artist, Album.Title AS Album, Album.AlbumId As AlbumId
		FROM Artist JOIN Album ON Album.ArtistId = Artist.ArtistId
	) AS subq ON Track.AlbumId = subq.Album
WHERE Track.Name < 'b';

-- similar to subquery in FROM is 'common table expression' (CTE)
-- which uses a "WITH" clause
WITH purchased_tracks AS (
	SELECT DISTINCT TrackId
	FROM InvoiceLine
)
SELECT *
FROM Track AS t
WHERE t.TrackId NOT IN (
	SELECT TrackId
	FROM purchased_tracks
);

-- some other subquery operators
-- EXISTS, NOT EXISTS
-- SOME/ANY, ALL

-- get the artists who made the album with longest title
SELECT * 
FROM Artist
WHERE ArtistId = (
	SELECT ArtistId
	FROM Album
	WHERE LEN(Title) >= ALL (SELECT LEN(Title) FROM Album)
)

SELECT *
FROM Artist
WHERE ArtistId = (
	SELECT TOP(1) ArtistId
	FROM Album
	ORDER BY LEN(Title) DESC
);

-- SET operations 
-- have from mathematical sets the concepts of 
-- UNION, INTERSECT, and (set differences) EXCEPT

-- all first names of customers and emloyees
SELECT FirstName FROM Customer
UNION
SELECT FirstName FROM Employee --67 with dupes, 63 without

-- all rows of the first query and also all rows of the 2nd query
-- (the number and types of the col need to be compatible)

-- For each set op, we have a distinct version and an ALL version
-- the DISTINCT version is the default
--	so by default all these ops makes a pass to remove dupes row from result


-- UNITON gives you values that are in EITHER result
-- INTERSECT gives you values that are in BOTH results
-- EXCEPT gives you values that are in the FIRST but NOT the SECOND result


-- ------------------------------------------------------------------------------------
-- SET JOIN EXERCISES!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

--1. which artists did not make any albums at all?
SELECT Artist.Name
FROM Artist
WHERE ArtistId = (
	SELECT ArtistId
	FROM Album AS a1
	WHERE 
	--WHERE LEN(Title) >= ALL (SELECT LEN(Title) FROM Album)
)

--2. which artists did not record any tracks of the Latin genre?

--3. which video track has the longest length? (use media type table)
--4. find the names of the customers who live in the same city as the boss employee (the one who reports to nobody)
--5. how many audio tracks were bought by German customers, and what was the total price paid for them?
--6. list the names and countries of the customers supported by an employee who was hired younger than 35.