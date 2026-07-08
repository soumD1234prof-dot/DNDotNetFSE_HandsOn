CREATE TABLE Departments ( 
DepartmentID INT PRIMARY KEY, 
DepartmentName VARCHAR(100) 
); 

CREATE TABLE Employees ( 
EmployeeID INT PRIMARY KEY, 
FirstName VARCHAR(50), 
LastName VARCHAR(50), 
DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID), 
Salary DECIMAL(10,2), 
JoinDate DATE 
);

INSERT INTO Departments (DepartmentID, DepartmentName) VALUES 
(1, 'HR'), 
(2, 'Finance'), 
(3, 'IT'), 
(4, 'Marketing'); 


INSERT INTO Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, 
JoinDate) VALUES 
(1, 'John', 'Doe', 1, 5000.00, '2020-01-15'), 
(2, 'Jane', 'Smith', 2, 6000.00, '2019-03-22'), 
(3, 'Michael', 'Johnson', 3, 7000.00, '2018-07-30'), 
(4, 'Emily', 'Davis', 4, 5500.00, '2021-11-05'); 

--Ex 1

CREATE PROCEDURE sp_RetrieveEmployee
    @DepartmentID INT
AS
BEGIN
    SELECT 
        e.EmployeeID,
        e.FirstName,
        e.LastName,
        e.DepartmentID,
        e.JoinDate
    FROM Employees e
    WHERE e.DepartmentID = @DepartmentID;
END;

--Ex 2

ALTER PROCEDURE sp_RetrieveEmployee
    @DepartmentID INT
AS
BEGIN
    SELECT 
        e.EmployeeID,
        e.FirstName,
        e.LastName,
        e.DepartmentID,
        e.Salary,          -- newly added column
        e.JoinDate
    FROM Employees e
    WHERE e.DepartmentID = @DepartmentID;
END;

--Ex 3

DROP PROCEDURE sp_RetrieveEmployee;

--Ex 4

CREATE PROCEDURE sp_RetrieveEmployee
    @DepartmentID INT
AS
BEGIN
    SELECT 
        e.EmployeeID,
        e.FirstName,
        e.LastName,
        e.DepartmentID,
        e.Salary,
        e.JoinDate
    FROM Employees e
    WHERE e.DepartmentID = @DepartmentID;
END;

EXEC sp_RetrieveEmployee @DepartmentID = 2;

EXEC sp_RetrieveEmployee @DepartmentID = 3;

--Ex 5

CREATE PROCEDURE sp_EmployeeCountByDept
    @DepartmentID INT
AS
BEGIN
    SELECT COUNT(*) AS TotalEmployees
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
END;

EXEC sp_EmployeeCountByDept @DepartmentID = 1;

EXEC sp_EmployeeCountByDept @DepartmentID = 2; 