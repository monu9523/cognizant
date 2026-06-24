USE cognizant_advance_sql;
CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10,2)
);
INSERT INTO Products VALUES
(1, 'iPhone 15', 'Electronics', 79999),
(2, 'Samsung Galaxy S24', 'Electronics', 74999),
(3, 'OnePlus 12', 'Electronics', 74999),
(4, 'iPad Air', 'Electronics', 59999),

(5, 'Nike Running Shoes', 'Footwear', 4999),
(6, 'Adidas Sneakers', 'Footwear', 5999),
(7, 'Puma Sports Shoes', 'Footwear', 5999),
(8, 'Campus Casual Shoes', 'Footwear', 2999),

(9, 'Wooden Study Table', 'Furniture', 12000),
(10, 'Office Chair', 'Furniture', 8500),
(11, 'Bookshelf', 'Furniture', 8500),
(12, 'Coffee Table', 'Furniture', 6000);
SELECT * FROM Products;
Select 
ProductID,ProductName,Category,Price,
ROW_NUMBER() OVER (
PARTITION BY Category ORDER BY Price DESC )
AS Row_Num, RANK() OVER (
PARTITION BY Category 
ORDER BY Price DESC )
AS Rank_Num, dense_rank() OVER (
PARTITION BY Category ORDER BY Price DESC)
AS Dense_Rank_Num FROM Products; 