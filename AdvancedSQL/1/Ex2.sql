CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10,2)
);

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    CustomerName NVARCHAR(100),
    Region NVARCHAR(50)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID),
    OrderDate DATE
);

CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
    ProductID INT FOREIGN KEY REFERENCES Products(ProductID),
    Quantity INT
);

INSERT INTO Products (ProductName, Category, Price)
VALUES
('Laptop', 'Electronics', 75000),
('Smartphone', 'Electronics', 60000),
('Tablet', 'Electronics', 60000),   -- tie with Smartphone
('Headphones', 'Electronics', 8000),
('Smartwatch', 'Electronics', 15000),

('Office Chair', 'Furniture', 12000),
('Sofa', 'Furniture', 45000),
('Dining Table', 'Furniture', 45000), -- tie with Sofa
('Bookshelf', 'Furniture', 9000),
('Bed Frame', 'Furniture', 30000),

('Olive Oil', 'Groceries', 1200),
('Basmati Rice', 'Groceries', 900),
('Almonds', 'Groceries', 900),        -- tie with Basmati Rice
('Coffee Beans', 'Groceries', 700),
('Honey', 'Groceries', 500);

INSERT INTO Customers (CustomerName, Region)
VALUES
('Amit Traders', 'North'),
('Blue Ocean Retail', 'South'),
('Coastal Mart', 'East'),
('Desert Wholesale', 'West'),
('Green Valley Stores', 'North'),
('Harbor Goods', 'South');

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

INSERT INTO OrderDetails (OrderID, ProductID, Quantity)
VALUES
(1, 1, 2),   -- Laptop
(1, 4, 5),   -- Headphones
(2, 6, 3),   -- Office Chair
(2, 11, 10), -- Olive Oil
(3, 2, 1),   -- Smartphone
(3, 7, 2),   -- Sofa
(4, 3, 4),   -- Tablet
(4, 12, 20), -- Basmati Rice
(5, 5, 6),   -- Smartwatch
(5, 9, 3),   -- Bookshelf
(6, 8, 1),   -- Dining Table
(6, 13, 15), -- Almonds
(7, 1, 1),   -- Laptop
(7, 14, 8),  -- Coffee Beans
(8, 10, 2),  -- Bed Frame
(8, 15, 12); -- Honey

SELECT 
    c.Region,
    p.Category,
    SUM(od.Quantity) AS TotalQuantity
FROM Orders o
JOIN Customers c ON o.CustomerID = c.CustomerID
JOIN OrderDetails od ON o.OrderID = od.OrderID
JOIN Products p ON od.ProductID = p.ProductID
GROUP BY c.Region, p.Category
ORDER BY c.Region, p.Category;

SELECT 
    c.Region,
    p.Category,
    SUM(od.Quantity) AS TotalQuantity
FROM Orders o
JOIN Customers c ON o.CustomerID = c.CustomerID
JOIN OrderDetails od ON o.OrderID = od.OrderID
JOIN Products p ON od.ProductID = p.ProductID
GROUP BY GROUPING SETS (
    (c.Region, p.Category),  -- by both
    (c.Region),              -- by Region only
    (p.Category),             -- by Category only
    ()                        -- grand total
)
ORDER BY c.Region, p.Category;

SELECT 
    c.Region,
    p.Category,
    SUM(od.Quantity) AS TotalQuantity
FROM Orders o
JOIN Customers c ON o.CustomerID = c.CustomerID
JOIN OrderDetails od ON o.OrderID = od.OrderID
JOIN Products p ON od.ProductID = p.ProductID
GROUP BY ROLLUP (c.Region, p.Category)
ORDER BY c.Region, p.Category;

SELECT 
    c.Region,
    p.Category,
    SUM(od.Quantity) AS TotalQuantity
FROM Orders o
JOIN Customers c ON o.CustomerID = c.CustomerID
JOIN OrderDetails od ON o.OrderID = od.OrderID
JOIN Products p ON od.ProductID = p.ProductID
GROUP BY CUBE (c.Region, p.Category)
ORDER BY c.Region, p.Category;