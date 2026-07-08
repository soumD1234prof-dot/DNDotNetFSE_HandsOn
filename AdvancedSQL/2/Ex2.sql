CREATE TABLE Customers1 (
    CustomerID INT PRIMARY KEY,
    Name VARCHAR(100),
    Region VARCHAR(50)
);

CREATE TABLE Products1 (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders1 (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    OrderDate DATE,
    FOREIGN KEY (CustomerID) REFERENCES Customers1(CustomerID)
);

CREATE TABLE OrderDetails1 (
    OrderDetailID INT PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    FOREIGN KEY (OrderID) REFERENCES Orders1(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products1(ProductID)
);

INSERT INTO Customers1(CustomerID, Name, Region) VALUES
(1, 'Alice', 'North'),
(2, 'Bob', 'South'),
(3, 'Charlie', 'East'),
(4, 'David', 'West');

INSERT INTO Products1 (ProductID, ProductName, Category, Price) VALUES
(1, 'Laptop', 'Electronics', 1200.00),
(2, 'Smartphone', 'Electronics', 800.00),
(3, 'Tablet', 'Electronics', 600.00),
(4, 'Headphones', 'Accessories', 150.00);

INSERT INTO Orders1 (OrderID, CustomerID, OrderDate) VALUES
(1, 1, '2023-01-15'),
(2, 2, '2023-02-20'),
(3, 3, '2023-03-25'),
(4, 4, '2023-04-30');

INSERT INTO OrderDetails1 (OrderDetailID, OrderID, ProductID, Quantity) VALUES
(1, 1, 1, 1),
(2, 2, 2, 2),
(3, 3, 3, 1),
(4, 4, 4, 3);

SELECT * FROM Orders1 WHERE OrderDate = '2023-01-15';

SET STATISTICS IO ON;
SET STATISTICS TIME ON;

SELECT name 
FROM sys.key_constraints 
WHERE type = 'PK' AND parent_object_id = OBJECT_ID('Orders1');

ALTER TABLE OrderDetails1 DROP CONSTRAINT FK__OrderDeta__Order__3F6663D5;

ALTER TABLE Orders1 DROP CONSTRAINT PK__Orders1__C3905BAFE814658F;

CREATE CLUSTERED INDEX IX_Orders1_OrderDate
ON Orders1 (OrderDate);

SELECT * FROM Orders1 WHERE OrderDate = '2023-01-15';

ALTER TABLE Orders1 ADD CONSTRAINT PK_Orders1_OrderID 
PRIMARY KEY NONCLUSTERED (OrderID);

ALTER TABLE OrderDetails1 ADD CONSTRAINT FK_OrderDetails1_Orders1
FOREIGN KEY (OrderID) REFERENCES Orders1(OrderID);