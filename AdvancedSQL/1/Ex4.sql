CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10,2)
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
(2, '2024-05-02'),
(4, '2024-05-18'),
(1, '2024-06-07'),
(5, '2024-06-25');

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

INSERT INTO OrderDetails (OrderID, ProductID, Quantity)
VALUES
(9, 1, 3),    -- Laptop
(9, 4, 4),    -- Headphones
(10, 1, 2),   -- Laptop
(10, 11, 6),  -- Olive Oil
(11, 1, 5),   -- Laptop
(11, 4, 2),   -- Headphones
(12, 11, 10); -- Olive Oil

SELECT 
    p.ProductName,
    MONTH(o.OrderDate) AS OrderMonth,
    SUM(od.Quantity) AS TotalQuantity
FROM Orders o
JOIN OrderDetails od ON o.OrderID = od.OrderID
JOIN Products p ON od.ProductID = p.ProductID
GROUP BY p.ProductName, MONTH(o.OrderDate)
ORDER BY p.ProductName, OrderMonth;

SELECT 
    ProductName,
    [1] AS Jan, [2] AS Feb, [3] AS Mar, 
    [4] AS Apr, [5] AS May, [6] AS Jun
FROM (
    SELECT 
        p.ProductName,
        MONTH(o.OrderDate) AS OrderMonth,
        od.Quantity
    FROM Orders o
    JOIN OrderDetails od ON o.OrderID = od.OrderID
    JOIN Products p ON od.ProductID = p.ProductID
) AS SourceData
PIVOT (
    SUM(Quantity)
    FOR OrderMonth IN ([1], [2], [3], [4], [5], [6])
) AS PivotTable
ORDER BY ProductName;

SELECT ProductName, OrderMonth, TotalQuantity
FROM (
    SELECT 
        ProductName,
        [1] AS Jan, [2] AS Feb, [3] AS Mar, 
        [4] AS Apr, [5] AS May, [6] AS Jun
    FROM (
        SELECT 
            p.ProductName,
            MONTH(o.OrderDate) AS OrderMonth,
            od.Quantity
        FROM Orders o
        JOIN OrderDetails od ON o.OrderID = od.OrderID
        JOIN Products p ON od.ProductID = p.ProductID
    ) AS SourceData
    PIVOT (
        SUM(Quantity)
        FOR OrderMonth IN ([1], [2], [3], [4], [5], [6])
    ) AS PivotTable
) AS PivotedData
UNPIVOT (
    TotalQuantity FOR OrderMonth IN (Jan, Feb, Mar, Apr, May, Jun)
) AS UnpivotedData;