WITH DateCTE AS (
    -- Anchor: starting date
    SELECT CAST('2025-01-01' AS DATE) AS CalendarDate

    UNION ALL

    -- Recursive: add 1 day each time
    SELECT DATEADD(DAY, 1, CalendarDate)
    FROM DateCTE
    WHERE CalendarDate < '2025-01-31'
)
SELECT CalendarDate
FROM DateCTE
OPTION (MAXRECURSION 100);



CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10,2)
);

CREATE TABLE StagingProducts (
    ProductID INT,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10,2)
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

INSERT INTO StagingProducts (ProductID, ProductName, Category, Price)
VALUES
(1, 'Laptop', 'Electronics', 78000),      -- price update (was 75000)
(4, 'Headphones', 'Electronics', 7500),   -- price update (was 8000)
(11, 'Olive Oil', 'Groceries', 1350),     -- price update (was 1200)
(16, 'Gaming Mouse', 'Electronics', 3500),-- new product, doesn't exist yet
(17, 'Yoga Mat', 'Fitness', 2200);        -- new product, doesn't exist yet

SET IDENTITY_INSERT Products ON;

MERGE Products AS target
USING StagingProducts AS source
ON target.ProductID = source.ProductID

WHEN MATCHED THEN
    UPDATE SET 
        target.Price = source.Price,
        target.ProductName = source.ProductName,
        target.Category = source.Category

WHEN NOT MATCHED BY TARGET THEN
    INSERT (ProductID, ProductName, Category, Price)
    VALUES (source.ProductID, source.ProductName, source.Category, source.Price);

SELECT * FROM Products ORDER BY ProductID;