--1. list all customers (full names, customer ID, and country) who are not in the US
--2. list all customers from brazil
--3. list all sales agents
--4. show a list of all countries in billing addresses on invoices.
--5. how many invoices were there in 2009, and what was the sales total for that year? (extra challenge: find the invoice count sales total for every year, using one query)
--6. how many line items were there for invoice #37?
--7. how many invoices per country?
--8. show total sales per country, ordered by highest sales first.

SELECT *
FROM dbo.Customer

-- 1. list all customers (full names, customer ID, and country) who are not in the US
SELECT FirstName, LastName, Country
FROM dbo.Customer
WHERE Country != 'USA';

--2. 
SELECT CustomerId, FirstName, LastName
FROM dbo.Customer
WHERE Country = 'Brazil';

--3.
SELECT EmployeeId, FirstName, LastName
FROM dbo.Employee
WHERE Title = 'Sales Manager';

--4
SELECT BillingCountry
FROM dbo.Invoice
GROUP BY BillingCountry;

--5. how many invoices were there in 2009, and what was the sales total for that year? (extra challenge: find the invoice count sales total for every year, using one query)
SELECT COUNT(InvoiceDate) as Count, SUM(Total) as [Total Sales]
FROM dbo.Invoice
WHERE InvoiceDate >= '2009' AND InvoiceDate < '2010'

SELECT COUNT(InvoiceDate) as Count, SUM(Total) as [Total Sales]
FROM dbo.Invoice
GROUP BY YEAR(InvoiceDate);

SELECT COUNT(InvoiceDate) as Count, SUM(Total) as [Total Sales]
FROM Invoice
--WHERE DATEPART(YEAR, InvoiceDate) = 2009;
WHERE InvoiceDate BETWEEN '2009' AND '2010';

SELECT YEAR(InvoiceDate) AS YEAR, COUNT(InvoiceDate) AS Count, Sum(Total) as TotalCost
FROM Invoice
GROUP BY YEAR(InvoiceDate);


-- 6. how many line items were there for invoice #37?
--SELECT *
--FROM dbo.InvoiceLine
SELECT SUM(Quantity) as [Total Quantity]
FROM dbo.InvoiceLine
Where InvoiceId = 37

--7. how many invoices per country?
--SELECT *
--FROM dbo.Invoice;
SELECT BillingCountry as Country, COUNT(BillingCountry) as [Total Invoices]
FROM dbo.Invoice
GROUP BY BillingCountry
ORDER BY [Total Invoices]

--8. show total sales per country, ordered by highest sales first.
--SELECT *
--FROM dbo.Invoice;
SELECT BillingCountry as Country, SUM(Total) as [Total Sales]
FROM dbo.Invoice
GROUP BY BillingCOuntry
ORDER BY [Total Sales] DESC