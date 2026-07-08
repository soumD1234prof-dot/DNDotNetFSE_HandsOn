CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID),
    OrderDate DATE
);

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    CustomerName NVARCHAR(100),
    Region NVARCHAR(50)
);

INSERT INTO Orders (CustomerID, OrderDate)
VALUES
(1, '2024-01-05'),
(2, '2024-01-08'),
(3, '2024-02-01'),
(4, '2024-02-10'),
(5, '2024-03-03'),
(6, '2024-03-15'),
(1, '2024-04-01'),
(3, '2024-04-20');

INSERT INTO Orders (CustomerID, OrderDate)
VALUES
(1, '2024-07-01'),
(1, '2024-07-15'),
(1, '2024-08-02'),
(3, '2024-07-10'),
(3, '2024-08-05');

INSERT INTO Customers (CustomerName, Region)
VALUES
('Amit Traders', 'North'),
('Blue Ocean Retail', 'South'),
('Coastal Mart', 'East'),
('Desert Wholesale', 'West'),
('Green Valley Stores', 'North'),
('Harbor Goods', 'South');

WITH CustomerOrderCounts AS (
    SELECT 
        o.CustomerID,
        COUNT(o.OrderID) AS OrderCount
    FROM Orders o
    GROUP BY o.CustomerID
)
SELECT 
    c.CustomerID,
    c.CustomerName,
    coc.OrderCount
FROM CustomerOrderCounts coc
JOIN Customers c ON c.CustomerID = coc.CustomerID
WHERE coc.OrderCount > 3;