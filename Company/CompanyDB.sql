-- ==========================================
-- Company Database
-- Sprint 3 - SQL Implementation
-- ==========================================

CREATE DATABASE CompanyDB;
GO

USE CompanyDB;
GO

CREATE TABLE Department
(
    Dnumber INT PRIMARY KEY,
    Dname VARCHAR(50) NOT NULL UNIQUE,
    Mgr_ssn CHAR(9),
    Mgr_start_date DATE,
    NumberOfEmployees INT DEFAULT 0
);
GO

CREATE TABLE Employee
(
    Ssn CHAR(9) PRIMARY KEY,
    Fname VARCHAR(50) NOT NULL,
    Minit CHAR(1),
    Lname VARCHAR(50) NOT NULL,
    Bdate DATE NOT NULL,
    Address VARCHAR(200),
    Sex CHAR(1) NOT NULL
        CHECK (Sex IN ('M', 'F')),
    Salary DECIMAL(10, 2) NOT NULL
        CHECK (Salary > 0),
    Super_ssn CHAR(9),
    Dno INT NOT NULL
);
GO
CREATE TABLE Dept_Locations
(
    Dnumber INT NOT NULL,
    Dlocation VARCHAR(100) NOT NULL,

    CONSTRAINT PK_Dept_Locations
        PRIMARY KEY (Dnumber, Dlocation)
);
GO
CREATE TABLE Project
(
    Pnumber INT PRIMARY KEY,
    Pname VARCHAR(100) NOT NULL UNIQUE,
    Plocation VARCHAR(100),
    Dnum INT NOT NULL
);
GO
CREATE TABLE Works_On
(
    Essn CHAR(9) NOT NULL,
    Pno INT NOT NULL,
    Hours DECIMAL(5, 2) NOT NULL
        CHECK (Hours >= 0),

    CONSTRAINT PK_Works_On
        PRIMARY KEY (Essn, Pno)
);
GO

CREATE TABLE Dependent
(
    Essn CHAR(9) NOT NULL,
    Dependent_name VARCHAR(100) NOT NULL,
    Sex CHAR(1) NOT NULL
        CHECK (Sex IN ('M', 'F')),
    Bdate DATE NOT NULL,
    Relationship VARCHAR(50) NOT NULL,

    CONSTRAINT PK_Dependent
        PRIMARY KEY (Essn, Dependent_name)
);
GO
USE CompanyDB;
GO

-- ==========================================
-- FOREIGN KEY CONSTRAINTS
-- ==========================================

ALTER TABLE Employee
    ADD CONSTRAINT FK_Employee_Department
        FOREIGN KEY (Dno)
            REFERENCES Department(Dnumber);
GO

ALTER TABLE Employee
    ADD CONSTRAINT FK_Employee_Supervisor
        FOREIGN KEY (Super_ssn)
            REFERENCES Employee(Ssn);
GO

ALTER TABLE Department
    ADD CONSTRAINT FK_Department_Manager
        FOREIGN KEY (Mgr_ssn)
            REFERENCES Employee(Ssn);
GO

ALTER TABLE Dept_Locations
    ADD CONSTRAINT FK_DeptLocations_Department
        FOREIGN KEY (Dnumber)
            REFERENCES Department(Dnumber);
GO

ALTER TABLE Project
    ADD CONSTRAINT FK_Project_Department
        FOREIGN KEY (Dnum)
            REFERENCES Department(Dnumber);
GO

ALTER TABLE Works_On
    ADD CONSTRAINT FK_WorksOn_Employee
        FOREIGN KEY (Essn)
            REFERENCES Employee(Ssn);
GO

ALTER TABLE Works_On
    ADD CONSTRAINT FK_WorksOn_Project
        FOREIGN KEY (Pno)
            REFERENCES Project(Pnumber);
GO

ALTER TABLE Dependent
    ADD CONSTRAINT FK_Dependent_Employee
        FOREIGN KEY (Essn)
            REFERENCES Employee(Ssn);
GO
-- ==========================================
-- CRUD OPERATIONS
-- PART 1: INSERT STATEMENTS
-- ==========================================

-- 1. Insert departments
INSERT INTO Department
(Dnumber, Dname, Mgr_ssn, Mgr_start_date, NumberOfEmployees)
VALUES
    (1, 'Administration', NULL, NULL, 2),
    (2, 'Information Technology', NULL, NULL, 2);
GO

-- 2. Insert employees
INSERT INTO Employee
(Ssn, Fname, Minit, Lname, Bdate, Address, Sex, Salary, Super_ssn, Dno)
VALUES
    ('100000001', 'Ahmed', 'A', 'Ali', '1985-03-12',
     'Muscat, Oman', 'M', 1800.00, NULL, 1),

    ('100000002', 'Sara', 'M', 'Hassan', '1992-08-20',
     'Seeb, Oman', 'F', 1300.00, '100000001', 1),

    ('100000003', 'Khalid', 'S', 'Nasser', '1988-11-05',
     'Bawshar, Oman', 'M', 1700.00, NULL, 2),

    ('100000004', 'Maha', 'R', 'Salim', '1995-02-14',
     'Al Khoudh, Oman', 'F', 1200.00, '100000003', 2);
GO

-- Assign managers after employees exist
UPDATE Department
SET Mgr_ssn = '100000001',
    Mgr_start_date = '2024-01-01'
WHERE Dnumber = 1;

UPDATE Department
SET Mgr_ssn = '100000003',
    Mgr_start_date = '2024-02-01'
WHERE Dnumber = 2;
GO

-- 3. Insert department locations
INSERT INTO Dept_Locations
(Dnumber, Dlocation)
VALUES
    (1, 'Muscat'),
    (2, 'Seeb');
GO

-- 4. Insert projects
INSERT INTO Project
(Pnumber, Pname, Plocation, Dnum)
VALUES
    (101, 'HR System', 'Muscat', 1),
    (102, 'Network Upgrade', 'Seeb', 2);
GO

-- 5. Insert works-on and dependent records
INSERT INTO Works_On
(Essn, Pno, Hours)
VALUES
    ('100000002', 101, 20.00),
    ('100000004', 102, 25.00);

INSERT INTO Dependent
(Essn, Dependent_name, Sex, Bdate, Relationship)
VALUES
    ('100000001', 'Omar', 'M', '2015-06-10', 'Son');
GO

-- ==========================================
-- UPDATE STATEMENTS
-- ==========================================

-- 1. Give an employee a salary raise
UPDATE Employee
SET Salary = Salary + 150
WHERE Ssn = '100000002';
GO

-- 2. Reassign an employee to another department
UPDATE Employee
SET Dno = 2
WHERE Ssn = '100000002';
GO

-- 3. Change a project's location
UPDATE Project
SET Plocation = 'Bawshar'
WHERE Pnumber = 101;
GO

-- 4. Update hours worked on a project
UPDATE Works_On
SET Hours = 30.00
WHERE Essn = '100000004'
  AND Pno = 102;
GO

-- 5. Correct a dependent's relationship
UPDATE Dependent
SET Relationship = 'Child'
WHERE Essn = '100000001'
  AND Dependent_name = 'Omar';
GO

-- ==========================================
-- DELETE STATEMENTS
-- ==========================================

-- Delete dependent first
DELETE FROM Dependent
WHERE Essn = '100000001'
  AND Dependent_name = 'Omar';
GO

-- Delete works-on record
DELETE FROM Works_On
WHERE Essn = '100000004'
  AND Pno = 102;
GO