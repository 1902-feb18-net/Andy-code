-- in SSMS, like in VS, we have CTRL+K,C for comment, CTRL+K,U uncomment

-- data types
--   numerics
--      - TINYINT	(1 byte) (aka byte/char)
--      - SMALLINT	(2 bytes) (aka short)
--		- INT		(4 bytes) (use this one when we have no special need)
--		- BIGINT	(8 bytes) (aka long)
--	 floating point
--		- FLOAT
--		- REAL
--		- DECIMAL/NUMERIC(n,p) (highest-precision + custom precision -- we use this one)
--			DECIMAL(4, 3) means, 4 digits with 3 of them after the decimal point.
--	 currency
--		- MONEY ($ in american collation)
--	 string
--		- CHAR/CHARACTER(n)
--			fixed length string with size N
--				uses one byte character encoding specific by the collation
--		- VARCHAR/CHARACTER VARYING(n)
--			variable length string up to size N
--				when we say 'abc', this is a VARCHAR
--			we can set N to MAX (VARCHAR(MAx)) and that will allow maximum size
--		- NCHAR(n)
--			unicode CHAR (the N stands for 'national')
--		- NVARCHAR(n)
--			unicode VARCHAR, this is the one we use all the time for string stuff
--			we use this to store many international alphabets without depending on collation
--				when we say N'abc', this is an NVARCHAR
--			(can also use MAX here)
--	 date/time
--		- DATE for dates
--		- TIME for times
--		- DATETIME for timestamps, for times of a certain day
--			low precision and limited range! don't use
--		- DATETIME2 for high-precision, wide-range timestamps
--			N controls precision 
--		- DATETIMEOFFSET for intervals of time
--		- we can use EXTRACT to get e.g. YEAR from out of a DATETIME2.
--			there's also implicit conversion from strings, so I can compare
--			dates with '2019'


-- SELECT statement advanced usage
-- GROUP BY clause
-- by itself, it doesn't do a lot, but it becomes useful with aggregate functions
--	aggregate f(n) are functions that take in many values and return one value
--		COUNT, AVG, SUM, MIN, MAX

-- all first name of customers, and the number of duplicates of them
SELECT FirstName, COUNT(FirstName) AS Count
FROM SalesLT.Customer
GROUP BY FirstName
ORDER BY COUNT(FirstName) DESC;

-- GROUP By accepts a list of col, and for all rows which share the same
-- values of all thos col are combined into one row in the result set
-- COUNT(*) does same thing as below
SELECT FirstName, COUNT(FirstName) AS Count, LastName
FROM SalesLT.Customer
GROUP BY FirstName, LastName
ORDER BY COUNT(FirstName) DESC;
-- if we have a GROUP BY, we can't use any col in the select list
-- unless we say how to combine it together
-- EITHER you make it the basis for combining rows (put it in the GROUP BY)
-- OR, you run some aggregate functions which says how to turn the many values
--	into one value

-- how can I show all first names having no duplicates?
SELECT FirstName
FROM SalesLT.Customer
WHERE COUNT(FirstName) = 1
GROUP BY FirstName; -- doesn't work
-- first rows from the table are filtered with WHERE
-- then we run any aggregations with GROUP BY
-- if we want to run conditions based on the aggregate rows, we need the HAVING clause
SELECT FirstName AS fn
FROM SalesLT.Customer
WHERE Lastname < 'n' -- we dont have to return every col we use
GROUP BY FirstName
HAVING COUNT(FirstName) = 1
ORDER BY fn;

-- logical order of execution of a SELECT statement
-- essentially it "runs" in the order you write it, except, the SELECT clause is last
-- 1. FROM
-- 2. WHERE
-- 3. GROUP BY
-- 4. HAVING
-- 5. SELECT
-- 6. ORDER BY