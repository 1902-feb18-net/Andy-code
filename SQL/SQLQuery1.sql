SELECT 'Hello world!';

SELECT * From SalesLT.Customer;

-- is a comment! yay

-- in a SQL server... you have many DBs
-- within each DB we have many "schemas"
-- a schema is a namespace/scope for DB objs

-- in AdventureWorksLT DB, we have schema SalesLT
-- inside schemas, we have many DB objects including tables

--this would switch db from master
-- but azure sql db doesn't support yet
USE AdventureWorksLT;
-- have to use dropdown instead

-- semicolons are not necessary
-- whitespace doesn't matter
-- case also doesn't matter, case inssensitve
SelecT         *
FROM

SalesLt.Customer

-- SQL's string comparison by default is also case-insensitive
-- depnds on the "collation" i.e. the 
-- settings for datetime format, number format


-- The SELECT statement/command ...
-- doesn't even need to access the DB
SELECT 1;
SELECT CURRENT_TIMESTAMP;

-- we get all col and all rows from a table with SELECT *
-- SELECT *, and FROM
SELECT *
FROM SalesLT.Customer

-- we can select which cols we want by replacing the *
SELECT Title, FirstName, MiddleName, LastName
FROM SalesLT.Customer;

-- we can do "aliases"
SELECT FirstName AS [First Name], LastName AS "Last Name"
FROM SalesLT.Customer;

-- we can computer new values from the col values
SELECT FirstName + ' ' + LastName AS [Full Name]
FROM SalesLT.Customer;

-- we can process the returned rows with DISTINCT
-- any rows of the result set that have all the same col values
-- will be de-duplicated

-- get all first names that customers have
SELECT DISTINCT FirstName
FROM SalesLT.Customer;

-- we can filter rows on conditions as well
-- with WHERE clause
SELECT *
FROM SalesLT.Customer
WHERE FirstName = 'Alice'

SELECT *
FROM SalesLT.Customer
WHERE FirstName = 'Alice' AND LastName != 'Steiner';
-- so we have boolean operators AND and OR and NOT
-- not queals != (traditional SQL is <>)

-- We have ordered comparison of numbers, dates, time, and strings
-- strings are ordered by "dictionary order" "lexicographic order"
-- but this is affected by collation
-- with operators < <= > >=

-- all customers whose first name starts with C
SELECT * 
FROM SalesLT.Customer
WHERE FirstName >= 'c' AND FirstName < 'd';
-- everything that starts with c and has more letters too 
-- sorts after 'c'

-- we can sort the results (they are in undefined order by default)
-- ORDER BY clause accomplishes this
SELECT *
FROM SalesLT.Customer
WHERE FirstName >= 'c' AND FirstName < 'd'
ORDER BY FirstName, LastName DESC; 
-- ordering is "ascending" (ASC) by default, but can be descending(DESC)

-- we can do regex-lite pattern matching on strings with LIKE operator;
-- all customers with first name starting with c, then a vowel
SELECT *
FROM SalesLT.Customer
WHERE FirstName LIKE 'C[aeoiu]%'
-- [abc] for one character , either a, b, or c
-- % for any num of any characters
-- _ for one of any character