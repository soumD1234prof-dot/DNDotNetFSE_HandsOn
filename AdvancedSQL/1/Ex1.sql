CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
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

SELECT * FROM Products ORDER BY Category;

SELECT ProductName, Category, Price, ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum
FROM Products;

SELECT 
    ProductName, 
    Category, 
    Price,
    RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS RankNum,
    DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DenseRankNum
FROM Products;

SELECT * FROM (
    SELECT 
        ProductName, 
        Category, 
        Price,
        ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum
    FROM Products
) AS Top3Ranked
WHERE RowNum <= 3;