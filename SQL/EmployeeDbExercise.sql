-- wasn't able to make foreign keys successfully in the end

-- create db
CREATE DATABASE EmployeeExercise 
GO 

-- create tables

CREATE TABLE dbo.Employee  
   (
   ID INT PRIMARY KEY NOT NULL,  
   FirstName NVARCHAR(50) NOT NULL,  
   LastName NVARCHAR(50) NOT NULL,  
   SSN INT NOT NULL UNIQUE,  
   DeptID INT NOT NULL,
   CONSTRAINT FK_Dept_ID FOREIGN KEY (DeptID) REFERENCES dbo.Department (ID)
   )  

GO  

CREATE TABLE dbo.Department  
   (
   ID INT PRIMARY KEY NOT NULL,  
   Name NVARCHAR(50) NOT NULL,  
   Location NVARCHAR(200) NOT NULL,  
   )
GO
--DROP TABLE dbo.EmpDetails

CREATE TABLE dbo.EmpDetails  
   (
   ID INT PRIMARY KEY NOT NULL,
   EmployeeID INT NOT NULL,  
   Salary INT,  
   Address1 NVARCHAR(100) NOT NULL,  
   Address2 NVARCHAR(100), 
   City NVARCHAR(100) NOT NULL,
   State NVARCHAR(20) NOT NULL,
   Country NVARCHAR(100) NOT NULL
   CONSTRAINT FK_Employee_ID FOREIGN KEY (EmployeeID) REFERENCES dbo.Employee (ID)
   )  
GO  

ALTER TABLE dbo.Employee 
	ADD CONSTRAINT FK_Dept_ID FOREIGN KEY (DeptID) REFERENCES dbo.Department (ID);

-- insert into tables
-- employee
INSERT dbo.Employee(ID, FirstName, LastName, SSN, DeptId)  
    VALUES (1, 'Tina', 'Smith', 1111, 1) 
INSERT dbo.Employee(ID, FirstName, LastName, SSN, DeptId)  
    VALUES (2, 'Tinaaaa', 'Smithy', 2222, 2) 
INSERT dbo.Employee(ID, FirstName, LastName, SSN, DeptId)  
    VALUES (3, 'Tinast', 'Smitharoo', 3333, 3)  

-- Department
INSERT dbo.Department (ID, Name, Location)
	VALUES (1, 'Marketing', 'Jersey');
INSERT dbo.Department (ID, Name, Location)
	VALUES (2, 'Marketing', 'Kansas');
INSERT dbo.Department (ID, Name, Location)
	VALUES (3, 'Engineering', 'Minysoda');

--empDetails insert
INSERT dbo.EmpDetails(ID, EmployeeID, Salary, Address1, Address2, City, State, Country)
	VALUES(100, 1, 70000, 'backyard', 'work', 'Bees', 'KK', 'pineapples');
INSERT dbo.EmpDetails(ID, EmployeeID, Salary, Address1, Address2, City, State, Country)
	VALUES(200, 2, 50000, 'basement', 'restroom', 'Trees', 'SS', 'apples');
INSERT dbo.EmpDetails(ID, EmployeeID, Salary, Address1, Address2, City, State, Country)
	VALUES(300, 3, 100000, 'attic', 'bedroom', 'Mee', 'DD', 'pears');


-- list all employees from marketing
SELECT * 
FROM Employee


-- report total salary of marketing

-- report total employees by department

-- Update tina's salary to 90000

SELECT *
FROM EmpDetails
