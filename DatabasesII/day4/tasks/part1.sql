USE ITI;

-- 1
CREATE PROC deptStudents
AS
	SELECT d.Dept_Name, COUNT(s.St_Id)
	FROM Department d
	INNER JOIN Student s
	ON s.Dept_Id = d.Dept_Id
	GROUP BY d.Dept_Name;

deptStudents;

-- 2
USE SD;

CREATE VIEW p1Emps
AS
	SELECT fullName=e.Fname+' '+e.Lname
	FROM Emp e
	INNER JOIN works_on w
	ON w.empNo = e.empNo
	INNER JOIN company.project p
	ON p.projectNo = p.projectNo
	WHERE p.projectNo = 'p1';

CREATE PROC P1empCount
AS
	IF ((SELECT COUNT(*) FROM p1Emps) > 3)
		SELECT 'The number of employees in the project p1 is 3 or more'
	ELSE
		SELECT fullName AS [The following employees work for the project p1]
		FROM p1Emps;

P1empCount;

-- 3
CREATE PROC replaceEmp @old int, @new int, @pnum nchar(10)
AS
	UPDATE works_on SET empNo = @new
	WHERE empNo = @old
	AND projectNo = @pnum;

-- 4
ALTER TABLE company.project ADD budget INT; 

CREATE TABLE auditProjectBudget (
	ProjectNo nchar(10) REFERENCES company.project(projectNo),
	UserName nchar(100),
	ModifiedDate date default getdate(),
	budget_old int,
	budget_new int
);

CREATE TRIGGER auditProjectBudgetTrigger
ON company.project
AFTER UPDATE
AS
	if (UPDATE(budget))
		INSERT INTO auditProjectBudget
		VALUES
		((SELECT ProjectNo FROM INSERTED),
		CURRENT_USER,
		getDate(),
		(SELECT budget FROM DELETED),
		(SELECT budget FROM INSERTED));

UPDATE company.project SET budget = 200000
WHERE projectNo = 'p2';

UPDATE company.project SET budget = 90000
WHERE projectNo = 'p2';

SELECT * FROM auditProjectBudget;

-- 5
CREATE TRIGGER departmentReadOnly
ON company.department
INSTEAD OF INSERT
AS
	SELECT 'Not allowed';

INSERT INTO company.department(deptNo, deptName)
VALUES ('d5', 'new');

-- 6
CREATE TRIGGER employeeReadOnlyMarch
ON HR.employee
INSTEAD OF INSERT
AS
	IF (FORMAT(getDate(), 'MM') = 3)
		SELECT 'Not allowed'
	ELSE
		INSERT INTO HR.employee
		SELECT * FROM inserted;

-- 7
USE ITI;

CREATE TABLE auditStudent(
	[Server User Name] nchar(100),
	Date Date,
	Note nchar(256)
);

CREATE TRIGGER auditStudentTrigger
ON Student
AFTER INSERT
AS
	INSERT INTO auditStudent
	VALUES
	(CURRENT_USER, GETDATE(),
	CURRENT_USER+' Insert New Row with Key='+(SELECT st_id FROM INSERTED)+' in table student');

-- 8
CREATE TRIGGER auditStudentTrigger
ON Student
INSTEAD OF DELETE
AS
	INSERT INTO auditStudent
		VALUES
		(CURRENT_USER, GETDATE(),
		CURRENT_USER+' try to delete Row with Key='+(SELECT st_id FROM DELETED));

-- 9
USE AdventureWorks2012;

-- A
select * from HumanResources.Employee
for xml raw('Employee'),ELEMENTS,ROOT('Employess');

-- B
select * from HumanResources.Employee
for xml raw('Employee'),ROOT('Employess');

-- 10
USE ITI;

-- A
SELECT d.Dept_Name, i.Ins_Name
FROM Department d
INNER JOIN Instructor i
ON d.Dept_Id = i.Dept_Id
for xml Auto,ROOT('Instructors');

-- B
SELECT d.Dept_Name "@dept_Name",
i.Ins_Name "@Ins_Name"
FROM Department d
INNER JOIN Instructor i
ON d.Dept_Id = i.Dept_Id
for xml path,ROOT('Instructors');

-- 11
USE Company_SD;

declare @docs xml ='<customers>
              <customer FirstName="Bob" Zipcode="91126">
                     <order ID="12221">Laptop</order>
              </customer>
              <customer FirstName="Judy" Zipcode="23235">
                     <order ID="12221">Workstation</order>
              </customer>
              <customer FirstName="Howard" Zipcode="20009">
                     <order ID="3331122">Laptop</order>
              </customer>
              <customer FirstName="Mary" Zipcode="12345">
                     <order ID="555555">Server</order>
              </customer>
       </customers>'

declare @hdocs int

--3)create memory tree
Exec sp_xml_preparedocument @hdocs output, @docs

--4)process document 'read tree from memory'
--OPENXML Creates Result set from XML Document

SELECT * 
INTO customers
FROM OPENXML (@hdocs, '//customer')  --levels  XPATH Code
WITH (FirstName nchar(10) '@FirstName',
	  Zipcode nchar(10) '@Zipcode')
--5)remove memory tree
Exec sp_xml_removedocument @hdocs

SELECT * FROM customers;