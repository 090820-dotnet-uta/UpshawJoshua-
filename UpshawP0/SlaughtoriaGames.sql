/*
CREATE TABLE CustomerAddress
(
	CustAddID INT IDENTITY (1,1) NOT NULL,		
	City CHAR(100) NOT NULL,
	"State" VARCHAR(2) NOT NULL,		
	Street CHAR(100) NOT NULL,
	Zip NUMERIC(5,0) NOT NULL,			
	AptNum CHAR(10),					--Optional entry
	PRIMARY KEY (CustAddID),
	
	CONSTRAINT CHK_StateAbbreviated CHECK (LEN("State") = 2),
	CONSTRAINT CHK_ZipCodeLength CHECK (LEN(Zip)> 0  AND  LEN(Zip) <= 5)
);
*/
CREATE TABLE Stores
(
	StoreID INT NOT NULL IDENTITY(1,1),			--StoreID is unique (One store has one address) and increments by 1 for every new store
	PhoneNumber NVARCHAR(22) NOT NULL,			--Long enough to hold max phone number (15 digits) plus any hyphens or world codes
	City CHAR(100) NOT NULL, 
	"State" VARCHAR(2) NOT NULL,	
	Street CHAR(100) NOT NULL,
	Zip NUMERIC(5,0) NOT NULL,
	PRIMARY KEY (StoreID),

	CONSTRAINT CHK_State CHECK (LEN("State") > 0 AND LEN("State") <= 2),
	CONSTRAINT CHK_ZipCode CHECK (LEN(Zip)> 0  AND  LEN(Zip) <= 5)
);
/*
CREATE TABLE Bundles
(
	PK INT NOT NULL IDENTITY(1,1),
	BundleID INT NOT NULL,		--Can't be identity, BundleID groups bundles and bundled items
	IsInBundle BIT NOT NULL,	--If it isn't IN a bundle (BIT=1) then it IS a bundle(BIT=0)
	IsBundle BIT NOT NULL,
	BundleProduct INT NOT NULL,	--References the SKUNum

	PRIMARY KEY(PK),
	FOREIGN KEY (BundleProduct) REFERENCES Products(SKUNum) ON DELETE CASCADE ON UPDATE CASCADE,
	
	--AFTER INSERT trigger on products that checks to see if an item IsBundle or IsInBundle
	--Might have to add an arbitrary PK INT just to be the primary key 
	--Code in BundleID, IsInBundle, IsBundle
)
GO
CREATE TRIGGER CheckForBundle
ON Products
AFTER INSERT
AS
	INSERT INTO Bundles (
END
*/
CREATE TABLE Products 
(
	SKUNum INT IDENTITY(100,10),				--Unique identifier for a product
	ProductName VARCHAR(255) NOT NULL,
	ProductDescrip VARCHAR(255) NOT NULL, 
	UnitPrice DECIMAL(10, 2) NOT NULL DEFAULT 1.00,
	ProductDiscount DECIMAL(2,2) NOT NULL DEFAULT .00,	--Theres not a discount by default, discount must be set 
	
										--Need table for bundles BUT HOW TO MAKE IT WORK
	IsInBundle BIT NOT NULL DEFAULT 0,	--property that checks if an item is included in a bundle, if so decrement it when IsBundle = true and items share bundle ID
	IsBundle BIT NOT NULL DEFAULT 0,	--(Maybe not needed?)checks if that item is a bundle, if true and item is purchased, items with IsInBundle set to true will decrement
	BundleId INT NOT NULL DEFAULT 0,	--If an item is in a bundle, give that bundle (and the item included in the bundle) that ID so they decrement together

	PRIMARY KEY (SKUNum),

	CONSTRAINT CHK_Discount CHECK (0.00 <= ProductDiscount AND ProductDiscount < 1.00), --Discount can't be more than 100%
);
CREATE TABLE Inventory 
(
	InventoryId INT NOT NULL IDENTITY (1,1),
	StoreInventory INT NOT NULL,
	ItemInInventory INT NOT NULL,
	ProductCurrentQuantity INT DEFAULT 0,
	PRIMARY KEY(InventoryId),
	FOREIGN KEY(StoreInventory) REFERENCES Stores(StoreId) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY(ItemInInventory) REFERENCES Products(SKUNum) ON DELETE CASCADE ON UPDATE CASCADE,
	
	CONSTRAINT CHK_Quantity CHECK (ProductCurrentQuantity > 0), --Can't have a negative number of items 
);
CREATE TABLE Customers
(
	CustomerID INT NOT NULL IDENTITY (1,1), --Unique identifier for each customer
	
	FirstName VARCHAR(255) NOT NULL,
	LastName VARCHAR(255) NOT NULL,
	UserName VARCHAR(255) NOT NULL,
	Pword VARCHAR(255) NOT NULL,

	City CHAR(100) NOT NULL,
	"State" VARCHAR(2) NOT NULL,		
	Street CHAR(100) NOT NULL,
	Zip NUMERIC(5,0) NOT NULL,			
	AptNum CHAR(10),					--Optional entry

	DefaultStore INT DEFAULT 1 NOT NULL,
	PRIMARY KEY (CustomerID),

	CONSTRAINT CHK_StateLen CHECK (LEN("State") > 0 AND LEN("State") <= 2),
	CONSTRAINT CHK_ZipCodeLength CHECK (LEN(Zip)> 0  AND  LEN(Zip) <= 5)
);
CREATE TABLE Orders
(
	PK INT IDENTITY (1,1),		--Arbitrary column made specifically for primary key
	OrderID INT NOT NULL,		--Unique identifier for each order
	OrderedProduct INT NOT NULL,
	StoreOrderedFrom INT,
	WhoOrdered INT NOT NULL,
	OrderedProductAmount INT NOT NULL DEFAULT 1,
	OrderDate DATETIME NOT NULL DEFAULT GETDATE(),
	OrderTotal DECIMAL(10,2) NOT NULL, 

	PRIMARY KEY (PK),
	FOREIGN KEY (OrderedProduct) REFERENCES Products(SKUNum) ON UPDATE CASCADE,	--One product can be in MANY orders
	FOREIGN KEY (StoreOrderedFrom) REFERENCES Stores(StoreID) ON DELETE SET NULL ON UPDATE CASCADE,	--One Store has MANY orders
	FOREIGN KEY (WhoOrdered) REFERENCES Customers(CustomerID) ON DELETE CASCADE ON UPDATE CASCADE,	--One Customer has MANY orders

	CONSTRAINT CHK_OrderedAmount CHECK (OrderedProductAmount < 5000 AND OrderedProductAmount > 0)
	
); 
/*
CREATE TABLE ChosenStore
(
	ChosenID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	StoreID INT NOT NULL FOREIGN KEY REFERENCES Stores(StoreId),
	CustomerID INT NOT NULL FOREIGN KEY REFERENCES Customers(CustomerID),
);
*/
/*
CREATE TABLE Cart 
(
	CartId INT IDENTITY(1,1) NOT NULL PRIMARY KEY, --Here just for the computed column TotalPrice also allows users to remove items from their cart by CartId
	CartOwner INT NOT NULL FOREIGN KEY REFERENCES Customers(CustomerID),
	ProductInCart INT NOT NULL FOREIGN KEY REFERENCES Products(SKUNum),
	StoreProductIsFrom INT NOT NULL FOREIGN KEY REFERENCES Stores(StoreId),
	ProductInCartQuantity INT NOT NULL DEFAULT 1, 

	--1.User adds item to their cart table as they shop.
		--Everytime an item(s) is added, a new cart row is created, linked together by the CartOwner(CustomerID)
	--2.In C#, this continues as long as the customer doesn't choose to 'Checkout' and thus leave.
	--3.Upon clicking 'Checkout' (and invoking the 'Checkout' function) all the rows in the Cart table with the same CustomerID are deleted
	--4.This activates a BEFORE DELETION TRIGGER in SQL
		--That trigger will (1st) create a new Order row
		--(2nd) Then take the row that was just placed on the DELETED table and assign them to the corresponding columns 
);
GO
CREATE TRIGGER Checkout
ON Cart
AFTER DELETE
AS
BEGIN;
	INSERT INTO Orders(OrderID, OrderedProduct, StoreOrderedFrom, OrderedProductAmount, OrderTotal)
	SELECT d.CartId, d.ProductInCart, d.StoreProductIsFrom, d.ProductInCartQuantity
	FROM deleted d
END
*/
-------END OF CREATING TABLES--------------
SELECT * FROM Customers
INSERT INTO Customers(FirstName, LastName, UserName, Pword, City, "State", Street, Zip, AptNum, DefaultStore)
VALUES ('Joshua', 'Upshaw', 'Jupshaw97', 'Revature97', 'Wellington', 'FL', '1197 Reading Terrace',33404, '54A',1)
INSERT INTO Customers(FirstName, LastName, UserName, Pword, City, "State", Street, Zip, DefaultStore)
VALUES ('Tyrion', 'Lanister', 'TLan44', 'KLSD2020', 'Townsville', 'MD', '7743 Evil Fightin Ln',44675,2)
INSERT INTO Customers(FirstName, LastName, UserName, Pword, City, "State", Street, Zip, DefaultStore)
VALUES ('Halle', 'Berry', 'HB1981', 'CatWumnSukd', 'North Pole', 'NP', '6755 Candy Cane Ln',12354,3)
INSERT INTO Customers(FirstName, LastName, UserName, Pword, City, "State", Street, Zip, DefaultStore)
VALUES ('Kholek', 'Suneater', 'D00mstak', 'DLCplz', 'Norsca', 'NC', '2234 Old World Way', 82546,4)
INSERT INTO Customers(FirstName, LastName, UserName, Pword, City, "State", Street, Zip, DefaultStore)
VALUES ('Dean', 'Domino', 'DedMunee10', '37goldbars', 'Sierra Madre', 'NV', '2077 Vault Tec Ln', 90123,5)

INSERT INTO Stores(PhoneNumber, City, "State", Street, Zip)
VALUES ('(850)877-3813', 'Tallahassee', 'FL', '1500 Appalachee Pkwy',32304)
INSERT INTO Stores(PhoneNumber, City, "State", Street, Zip)
VALUES ('(212)967-9070', 'New York City', 'NY', '1282 Broadway',10001)
INSERT INTO Stores(PhoneNumber, City, "State", Street, Zip)
VALUES ('(446)991-1922','Gotham City', 'GC', '1940 Wayne Blvd',44675)
INSERT INTO Stores(PhoneNumber, City, "State", Street, Zip)
VALUES ('(779)572-3326', 'Arlington', 'TX', '2005 Revature Way',44675)
INSERT INTO Stores( PhoneNumber, City, "State", Street, Zip)
VALUES ('(198)331-9861', 'New Vegas', 'NV', '2077 Bethesda Blvd',11496)

---XB1 ITEMS----
INSERT INTO Products(ProductName, ProductDescrip, UnitPrice) --Bundle and discount attribute defaulted, only change them when needed
VALUES ('Xb1: Deep Rock Galactic', 
		'1-4 player co-op FPS featuring space Dwarves, 100% destructible environments, procedurally-generated caves, and hoardes of alien bugs!', 
		60.00)
INSERT INTO Products(ProductName, ProductDescrip, UnitPrice) --Bundle and discount attribute defaulted, only change them when needed
VALUES ('Xb1: Halo Master Chief Collection', 
		'The Master Chief"s Collection catalogues the Chief"s iconic journey with all six games collected in a single integrated experience!', 
		60.00)
INSERT INTO Products(ProductName, ProductDescrip, UnitPrice) --Bundle and discount attribute defaulted, only change them when needed
VALUES ('Xb1: Doom Eternal', 
		'Hell"s armies have invaded Earth! Become the Slayer in an epic single-player campaign to conquer demons across dimensions!', 
		60.00)
INSERT INTO Products(ProductName, ProductDescrip, UnitPrice, ProductDiscount) 
VALUES ('Xb1: TESV Skyrim', 
		'Take to the icy tundras of Tamriel"s Skyrim in this action packed RPG as you battle your way through a civil war and the return of the dragons!', 
		60.00, .50)
------PS4 ITEMS-----
INSERT INTO Products(ProductName, ProductDescrip, UnitPrice, IsBundle, BundleId) 
VALUES ('PS4: The Bloodborne Bundle', 
		'This bundle includes both a unique Hunter-style PS4 with an exclusive copy of Bloodborne signed by the From Software team!', 
		300.00, 1, 1)
INSERT INTO Products(ProductName, ProductDescrip, UnitPrice, IsInBundle, BundleId) 
VALUES ('PS4: Bloodborne Exclusive Edition (signed)', 
		'Featuring an open world, it follows a samurai on a quest to protect Tsushima Island during the first Mongol invasion of Japan.', 
		1.00,1,1)
INSERT INTO Products(ProductName, ProductDescrip, UnitPrice) 
VALUES ('PS4: Ghost of Tsushima', 
		'Featuring an open world, it follows a samurai on a quest to protect Tsushima Island during the first Mongol invasion of Japan.', 
		60.00)
INSERT INTO Products(ProductName, ProductDescrip, UnitPrice) 
VALUES ('PS4: God of War', 
		'Kratos is a father again. As mentor and protector to Atreus, a son determined to earn his respect, he is forced to confront the rage that has long defined him while out in a very dangerous world with his son.', 
		60.00)
INSERT INTO Products(ProductName, ProductDescrip, UnitPrice, ProductDiscount) 
VALUES ('PS4: TESV Skyrim', 
		'Take to the icy tundras of Tamriel"s Skyrim in this action packed RPG as you battle your way through a civil war and the return of the dragons!', 
		60.00, .50)
--------Nintendo Switch Items------
INSERT INTO Products(ProductName, ProductDescrip, UnitPrice) 
VALUES ('NS: Animal Crossing New Horizons', 
		'Escape to a deserted island and create your own paradise as you explore, create, and customize in this life simulation game!', 
		60.00)
INSERT INTO Products(ProductName, ProductDescrip, UnitPrice) 
VALUES ('NS: Super Mario Odyssey', 
		'Mario"s latest journey takes him far beyond the Mushroom Kingdom as he works alongside his trusty cap to save the day!', 
		60.00)
INSERT INTO Products(ProductName, ProductDescrip, UnitPrice, IsBundle, BundleId) 
VALUES ('NS: Mario Kart Bundle', 
		'This bundle includes a limited edition Mario themed Nintendo Switch with an exclusive copy of Mario Kart 8 signed by Mario himself!', 
		460.00, 1, 2)
INSERT INTO Products(ProductName, ProductDescrip, UnitPrice, IsInBundle, BundleId) 
VALUES ('NS: Mario Kart 8 Exclusive Edition', 
		'Mario"s latest journey takes him far beyond the Mushroom Kingdom as he works alongside his trusty cap to save the day!', 
		1.00, 1, 2)
INSERT INTO Products(ProductName, ProductDescrip, UnitPrice, ProductDiscount) 
VALUES ('NS: Fire Emblem 3 Houses', 
		'Shape the fate of the world in this tactical RPG where your character takes the fight to corrupt politics and the forces of evil!', 
		60.00, .30)
INSERT INTO Products(ProductName, ProductDescrip, UnitPrice, ProductDiscount) 
VALUES ('NS: TESV Skyrim', 
		'Take to the icy tundras of Tamriel"s Skyrim in this action packed RPG as you battle your way through a civil war and the return of the dragons!', 
		60.00, .50)
------STORE 1 ITEMS------
INSERT INTO Inventory(StoreInventory, ItemInInventory, ProductCurrentQuantity) 
VALUES (1,120,200)
INSERT INTO Inventory(StoreInventory, ItemInInventory, ProductCurrentQuantity) 
VALUES (1,210,250) --Mario Kart 8 bundle 
INSERT INTO Inventory(StoreInventory, ItemInInventory, ProductCurrentQuantity) 
VALUES (1,220,250) --Mario Kart 8 bundle item
INSERT INTO Inventory(StoreInventory, ItemInInventory, ProductCurrentQuantity) 
VALUES (1,130,300)
INSERT INTO Inventory(StoreInventory, ItemInInventory, ProductCurrentQuantity) 
VALUES (1,160,200)

------STORE 2 ITEMS------
INSERT INTO Inventory(StoreInventory, ItemInInventory, ProductCurrentQuantity) 
VALUES (2,170,200)
INSERT INTO Inventory(StoreInventory, ItemInInventory, ProductCurrentQuantity) 
VALUES (2,180,250)
INSERT INTO Inventory(StoreInventory, ItemInInventory, ProductCurrentQuantity) 
VALUES (2,190,250)
INSERT INTO Inventory(StoreInventory, ItemInInventory, ProductCurrentQuantity) 
VALUES (2,200,300)
INSERT INTO Inventory(StoreInventory, ItemInInventory, ProductCurrentQuantity) 
VALUES (2,210,200)

------STORE 3 ITEMS------
INSERT INTO Inventory(StoreInventory, ItemInInventory, ProductCurrentQuantity) 
VALUES (3,240,200)
INSERT INTO Inventory(StoreInventory, ItemInInventory, ProductCurrentQuantity) 
VALUES (3,140,250) --Bloodborne Bundle
INSERT INTO Inventory(StoreInventory, ItemInInventory, ProductCurrentQuantity) 
VALUES (3,150,250) --Bloodborne Bundle item (InBundle)
INSERT INTO Inventory(StoreInventory, ItemInInventory, ProductCurrentQuantity) 
VALUES (3,120,300)
INSERT INTO Inventory(StoreInventory, ItemInInventory, ProductCurrentQuantity) 
VALUES (3,100,200)

------STORE 4 ITEMS------
INSERT INTO Inventory(StoreInventory, ItemInInventory, ProductCurrentQuantity) 
VALUES (4,110,200)
INSERT INTO Inventory(StoreInventory, ItemInInventory, ProductCurrentQuantity) 
VALUES (4,130,250)
INSERT INTO Inventory(StoreInventory, ItemInInventory, ProductCurrentQuantity) 
VALUES (4,160,250)
INSERT INTO Inventory(StoreInventory, ItemInInventory, ProductCurrentQuantity) 
VALUES (4,170,300)
INSERT INTO Inventory(StoreInventory, ItemInInventory, ProductCurrentQuantity) 
VALUES (4,180,200)

------STORE 5 ITEMS------
INSERT INTO Inventory(StoreInventory, ItemInInventory, ProductCurrentQuantity) 
VALUES (5,190,200)
INSERT INTO Inventory(StoreInventory, ItemInInventory, ProductCurrentQuantity) 
VALUES (5,200,250)
INSERT INTO Inventory(StoreInventory, ItemInInventory, ProductCurrentQuantity) 
VALUES (5,230,250)
INSERT INTO Inventory(StoreInventory, ItemInInventory, ProductCurrentQuantity) 
VALUES (5,240,300)
INSERT INTO Inventory(StoreInventory, ItemInInventory, ProductCurrentQuantity) 
VALUES (5,100,200)

--Procedure for reducing quantity of an item based on how many are ordered (AFTER Trigger on orders table but then the action affects the inventory table, take last order put into the inserted, take out ordred quantity)
/*
GO
CREATE PROCEDURE SetNewQuantity
	@SKUNum INT,
	@OrderedQuantity INT
	AS
BEGIN
	--Insert Ordered amount and SKU of item into order
	INSERT INTO Orders(OrderedProduct,OrderAmount)
	VALUES(@SKUNum,@OrderedQuantity)
	--Update total number of that product available here
	UPDATE Products
	SET ProductCurrentQuantity = ProductCurrentQuantity - @OrderedQuantity
	WHERE SKUNum = @SKUNum
END

--Function to GetTotal price of a SINGLE ITEM 
GO
CREATE FUNCTION GetItemTotal
	(@OrderedQuantity int,
	@UnitPrice DECIMAL(10,2),
	@Discount DECIMAL(2,2))
	RETURNS DECIMAL(10,2)
	AS
	BEGIN 
	RETURN @OrderedQuantity * (@UnitPrice*(1-@Discount))	--Account for the possible discount 
END
*/
