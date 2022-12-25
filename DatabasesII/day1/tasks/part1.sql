USE SD;
-- create loc datatype
SP_ADDTYPE LOC, 'nchar(2)';
-- create default and rule for loc
CREATE DEFAULT loc_default AS 'NY';
CREATE RULE loc_rule AS (@x in ('NY','DS','KW'));
-- bind rule and default to loc
SP_BINDRULE loc_rule, loc;
SP_BINDEFAULT loc_default, loc;

CREATE TABLE department (
deptNo NCHAR(8) PRIMARY KEY,
deptName NCHAR(16),
location LOC
);

INSERT INTO department
(deptNo, deptName, location)
VALUES
('d1', 'Resarch', 'NY'),
('d2', 'Accounting', 'DS'),
('d3', 'Marketing', 'KW');


CREATE TABLE employee (
empNo INT PRIMARY KEY,
fName NCHAR(16) NOT NULL,
lName NCHAR(16) NOT NULL,
deptNo NCHAR(8) REFERENCES department(deptNo),
salary INT UNIQUE
);
-- create rule for column salary in employee
CREATE RULE salary_lt6000 AS (@X < 6000);
-- bind rule
SP_BINDRULE salary_lt6000, 'employee.salary';
-- insert some employess
INSERT INTO employee
(empNo, fName, lName, deptNo, salary)
VALUES
(25348, 'Mathew', 'Smith', 'd3', 2500),
(10102, 'Ann', 'Jones', 'd3', 3000),
(18316, 'John', 'Barrimore', 'd1', 2400);


INSERT INTO project
(projectNo, projectName, budget)
VALUES
('p1', 'Apollo', 120000),
('p2', 'Gemini', 95000);

INSERT INTO works_on
(empNo, projectNo, job, enter_date)
VALUES
(10102, 'p1', 'Analyst', '2006.10.1'),
(25348, 'p2', 'Clerk',   '2007.2.15');

-- The INSERT statement conflicted with the FOREIGN KEY constraint "FK_works_on_employee". The conflict occurred in database "SD", table "dbo.employee", column 'empNo'.
INSERT INTO works_on
(empNo, projectNo, job, enter_date)
VALUES
(11111, 'p1', 'Analyst', '2006.10.1');

-- The UPDATE statement conflicted with the FOREIGN KEY constraint "FK_works_on_employee". The conflict occurred in database "SD", table "dbo.employee", column 'empNo'.
UPDATE works_on SET empNo=11111
WHERE empNo=10102;

-- The UPDATE statement conflicted with the REFERENCE constraint "FK_works_on_employee". The conflict occurred in database "SD", table "dbo.works_on", column 'empNo'.
UPDATE employee SET empNo=22222
WHERE empNo=10102;

--The DELETE statement conflicted with the REFERENCE constraint "FK_works_on_employee". The conflict occurred in database "SD", table "dbo.works_on", column 'empNo'.
DELETE FROM employee WHERE empNo=10102;

-- Add  TelephoneNumber column 
ALTER TABLE employee ADD telephoneNumber nchar(11);
-- drop this column[programmatically]
ALTER TABLE employee DROP COLUMN telephoneNumber;

-- 2
-- a
CREATE SCHEMA company;
-- i
ALTER SCHEMA company TRANSFER department;
-- b.i
ALTER SCHEMA HR TRANSFER employee;

-- 3
sp_helpconstraint 'HR.employee';

-- 4
CREATE SYNONYM Emp FOR HR.employee;

Select * from employee;
Select * from HR.employee; -- works
Select * from Emp; -- works
Select * from HR.emp;

-- 5
UPDATE company.project
SET budget = budget*1.1
WHERE projectNo = (SELECT w.projectNo 
	from company.project p
	INNER JOIN works_on w
	ON p.projectNo = w.projectNo
	WHERE w.empNo = 10102);

-- 6
UPDATE company.department
SET deptName = 'Sales'
WHERE deptNo = (SELECT deptNo
	FROM HR.employee
	WHERE fName='Mathew');

-- 7
UPDATE works_on
SET enter_date='12.12.2007'
WHERE empNo IN (SELECT e.empNo
	FROM HR.employee e
	INNER JOIN works_on w
	ON w.empNo = e.empNo
	INNER JOIN company.department d
	ON d.deptNo = e.deptNo
	WHERE d.deptName = 'Sales'
	AND w.projectNo = 'p1');

-- 8
DELETE FROM works_on
WHERE empNo IN (
	SELECT e.empNo FROM HR.employee e
	INNER JOIN company.department d
	ON e.deptNo = d.deptNo
	WHERE d.location = 'KW'
	);

-- 9