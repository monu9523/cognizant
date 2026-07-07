DROP TABLE IF EXISTS Employees;
DROP TABLE IF EXISTS Departments;
DROP PROCEDURE IF EXISTS sp_GetEmployeesByDepartment;
DROP PROCEDURE IF EXISTS sp_InsertEmployee;
          #  EXERCISE 1
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
INSERT INTO Departments (DepartmentID, DepartmentName) VALUES
(1, 'HR'),
(2, 'Finance'),
(3, 'IT'),
(4, 'Marketing');

INSERT INTO Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES
(1, 'John', 'Doe', 1, 5000.00, '2020-01-15'),
(2, 'Jane', 'Smith', 2, 6000.00, '2019-03-22'),
(3, 'Michael', 'Johnson', 3, 7000.00, '2018-07-30'),
(4, 'Emily', 'Davis', 4, 5500.00, '2021-11-05');

DELIMITER //

CREATE PROCEDURE sp_GetEmployeesByDepartment(IN deptID INT)
BEGIN
    SELECT * FROM Employees WHERE DepartmentID = deptID;
END //

DELIMITER ;
CALL sp_GetEmployeesByDepartment(1);

DELIMITER //

CREATE PROCEDURE sp_InsertEmployee(
    IN p_FirstName VARCHAR(50),
    IN p_LastName VARCHAR(50),
    IN p_DepartmentID INT,
    IN p_Salary DECIMAL(10,2),
    IN p_JoinDate DATE
)
BEGIN
    INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate)
    VALUES (p_FirstName, p_LastName, p_DepartmentID, p_Salary, p_JoinDate);
END //

DELIMITER ;
ALTER TABLE Employees MODIFY EmployeeID INT AUTO_INCREMENT;
CALL sp_InsertEmployee('Sara', 'Lee', 3, 6200.00, '2022-05-10');

# EXERCISE 4
CALL sp_GetEmployeesByDepartment(2);
CALL sp_GetEmployeesByDepartment(1);  -- Returns John Doe (HR)
CALL sp_GetEmployeesByDepartment(3);  -- Returns Michael Johnson (IT)
CALL sp_GetEmployeesByDepartment(4);  -- Returns Emily Davis (Marketing)
SHOW PROCEDURE STATUS WHERE Db = DATABASE();

#  EXERCISE 5
DELIMITER //

CREATE PROCEDURE sp_CountEmployeesByDepartment(IN deptID INT)
BEGIN
    SELECT COUNT(*) AS TotalEmployees
    FROM Employees
    WHERE DepartmentID = deptID;
END //

DELIMITER ;
SHOW PROCEDURE STATUS WHERE Db = DATABASE();
ALTER TABLE Employees MODIFY EmployeeID INT AUTO_INCREMENT;

INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate)
VALUES ('Sara', 'Lee', 1, 5200.00, '2022-06-01');
CALL sp_CountEmployeesByDepartment(1);
