-- create our DB
CREATE DATABASE Project0;
GO

-- create a schema
CREATE SCHEMA Project0;
GO

-- create tables
CREATE TABLE Project0.Location (
	LocationID INT NOT NULL UNIQUE,
	StoreName NVARCHAR(100) NOT NULL,
);

CREATE TABLE Project0.Customer (
	CustomerID INT NOT NULL UNIQUE,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	DefaultStoreID INT NOT NULL
);

CREATE TABLE Project0.StoreOrder (
	OrderID INT NOT NULL UNIQUE,
	StoreID INT NOT NULL,
	DatePurchased DATETIME2 NOT NULL,
	Total MONEY
);

CREATE TABLE Project0.OrderList (
	OrderID INT NOT NULL,
	ItemID INT NOT NULL
);

CREATE TABLE Project0.Inventory (
	StoreID INT NOT NULL,
	ItemID INT NOT NULL, -- should FK to ItemProducts
	ItemRemaining INT NOT NULL
);

CREATE TABLE Project0.ItemProducts (
	ItemID INT NOT NULL UNIQUE,
	ItemName NVARCHAR(100) NOT NULL,
	ItemPrice MONEY NOT NULL,
	ItemBought INT NOT NULL,
	ItemDescription NVARCHAR(200),
)

-- add primary keys
ALTER TABLE Project0.Location   
	ADD CONSTRAINT PK_Location_ID PRIMARY KEY CLUSTERED (LocationID);
ALTER TABLE Project0.Customer   
	ADD CONSTRAINT PK_Customer_ID PRIMARY KEY CLUSTERED (CustomerID);
ALTER TABLE Project0.StoreOrder   
	ADD CONSTRAINT PK_Order_ID PRIMARY KEY CLUSTERED (OrderID);
ALTER TABLE Project0.ItemProducts   
	ADD CONSTRAINT PK_Item_ID PRIMARY KEY CLUSTERED (ItemID);


-- add FK
ALTER TABLE Project0.Inventory 
	ADD CONSTRAINT FK_Store_Location_ID FOREIGN KEY (StoreID) REFERENCES Project0.Location (LocationID);
ALTER TABLE Project0.Inventory 
	ADD CONSTRAINT FK_Inventory_Item_ID FOREIGN KEY (ItemID) REFERENCES Project0.ItemProducts (ItemID);
ALTER TABLE Project0.StoreOrder 
	ADD CONSTRAINT FK_Order_Customer_ID FOREIGN KEY (OrderID) REFERENCES Project0.Customer (CustomerID);
ALTER TABLE Project0.StoreOrder 
	ADD CONSTRAINT FK_Order_Location_ID FOREIGN KEY (StoreID) REFERENCES Project0.Location (LocationID);
ALTER TABLE Project0.Customer 
	ADD CONSTRAINT FK_Customer_Location_ID FOREIGN KEY (CustomerID) REFERENCES Project0.Location (LocationID);

ALTER TABLE Project0.OrderList 
	ADD CONSTRAINT FK_Orderlist_Order_ID FOREIGN KEY (OrderID) REFERENCES Project0.StoreOrder (OrderID);
ALTER TABLE Project0.OrderList 
	ADD CONSTRAINT FK_Orderlist_Item_ID FOREIGN KEY (ItemID) REFERENCES Project0.ItemProducts (ItemID);