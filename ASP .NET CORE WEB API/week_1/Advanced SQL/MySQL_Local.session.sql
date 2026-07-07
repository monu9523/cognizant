-- Select Database
USE cognizant_advance_sql;

-- Drop tables in correct order (child tables first)
DROP TABLE IF EXISTS OrderDetails;
DROP TABLE IF EXISTS Orders;
DROP TABLE IF EXISTS Products;
DROP TABLE IF EXISTS Customers;