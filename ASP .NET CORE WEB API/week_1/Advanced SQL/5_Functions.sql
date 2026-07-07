-- Drop existing objects to avoid conflicts
DROP TABLE IF EXISTS Employees;
DROP TABLE IF EXISTS Departments;

-- Create tables
CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT,
    Salary DECIMAL(10,2),
    JoinDate DATE,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

-- Insert sample data
INSERT INTO Departments (DepartmentID, DepartmentName) VALUES
(1, 'HR'),
(2, 'Finance'),
(3, 'IT');

INSERT INTO Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES
(1, 'John', 'Doe', 1, 5000.00, '2020-01-15'),
(2, 'Jane', 'Smith', 2, 6000.00, '2019-03-22'),
(3, 'Bob', 'Johnson', 3, 5500.00, '2021-07-01');

DELIMITER //

CREATE FUNCTION fn_CalculateAnnualSalary(empID INT)
RETURNS DECIMAL(10,2)
DETERMINISTIC
READS SQL DATA
BEGIN
    DECLARE monthlySalary DECIMAL(10,2);
    DECLARE annualSalary DECIMAL(10,2);

    SELECT Salary INTO monthlySalary
    FROM Employees
    WHERE EmployeeID = empID;

    SET annualSalary = monthlySalary * 12;

    RETURN annualSalary;
END //

DELIMITER ;
SELECT fn_CalculateAnnualSalary(1) AS AnnualSalary;

SELECT 
    EmployeeID,
    FirstName,
    LastName,
    Salary AS MonthlySalary,
    fn_CalculateAnnualSalary(EmployeeID) AS AnnualSalary
FROM Employees;