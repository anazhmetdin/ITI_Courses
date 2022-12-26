USE ITI;
-- 1.	Create a scalar function that takes date and returns Month name of that date.
DROP FUNCTION dbo.getMonth;

CREATE FUNCTION getMonth(@d DATE)
RETURNS nchar(12)
AS
BEGIN
	RETURN (SELECT DATENAME(MONTH, @d))
END

SELECT dbo.getMonth(GETDATE());

-- 2.	Create a multi-statements table-valued function that takes 2 integers and returns the values between them.
CREATE FUNCTION getRange(@start INT, @end INT)
RETURNS @range TABLE(number INT)
AS
BEGIN
	WHILE (@start <= @end)
		BEGIN
			INSERT INTO @range VALUES (@start);
			SET @start = @start + 1;
		END
	RETURN
END

SELECT * FROM getRange(1, 10);


-- 3.	 Create inline function that takes Student No and returns Department Name with Student full name.

CREATE FUNCTION getDeptSTDFullName(@stdNo INT)
RETURNS TABLE
AS
RETURN (
	SELECT d.Dept_Name, fullname=s.St_Fname+' '+s.St_Lname
	from Department d
	INNER JOIN Student s
	ON s.Dept_Id = d.Dept_Id
	WHERE s.St_Id = @stdNo
);

SELECT * FROM getDeptSTDFullName(1);

-- 4.	Create a scalar function that takes Student ID and returns a message to user 
DROP FUNCTION checkName;

CREATE FUNCTION checkName(@stdID INT)
RETURNS NCHAR(64)
AS
BEGIN
	DECLARE @message NCHAR(64);

	IF EXISTS (
		SELECT St_Id FROM Student
		WHERE St_Fname IS NULL
		AND St_Lname IS NULL
		AND St_Id = @stdID
	)
		SET @message = 'First name & last name are null';

	ELSE IF EXISTS (
		SELECT St_Id FROM Student
		WHERE St_Fname IS NULL
		AND St_Id = @stdID
	)
		SET @message = 'First name is null';

	ELSE IF EXISTS (
		SELECT St_Id FROM Student
		WHERE St_Lname IS NULL
		AND St_Id = @stdID
	)
		SET @message = 'Last name is null';
	
	ELSE
		SET @message = 'First name & last name are not null';

	RETURN @message;
END

SELECT dbo.checkName(1);

-- 5.	Create inline function that takes integer which represents manager ID and displays department name, Manager Name and hiring date
CREATE FUNCTION getDeptMngr(@mngrID INT)
RETURNS TABLE
AS
RETURN (
	SELECT d.Dept_Name, i.Ins_Name, d.Manager_hiredate
	FROM Department d
	INNER JOIN Instructor i
	ON d.Dept_Manager = i.Ins_Id
	WHERE i.Ins_Id = @mngrID
)

SELECT * FROM getDeptMngr(1);

-- 6.	Create multi-statements table-valued function that takes a string
DROP FUNCTION getNames;

CREATE FUNCTION getNames(@what NCHAR(16))
RETURNS @names TABLE (name NCHAR(32))
AS
BEGIN
	IF @what = 'first name'
		INSERT INTO @names SELECT ISNULL(St_Fname, '') FROM Student;
	ELSE IF @what = 'last name'
		INSERT INTO @names SELECT ISNULL(St_Lname, '') FROM Student;
	ELSE IF @what = 'full name'
		INSERT INTO @names SELECT ISNULL(St_Fname+' ', '')+ISNULL(St_Lname, '') FROM Student;
	
	RETURN
END

SELECT * FROM getNames('last name');

-- 7.	Write a query that returns the Student No and Student first name without the last char
SELECT s.Dept_Id, SUBSTRING(s.St_Fname, 0, LEN(s.St_Fname)) FROM Student s;

-- 8.	Wirte query to delete all grades for the students Located in SD Department 
DELETE FROM Stud_Course
WHERE St_Id IN (
	SELECT s.Dept_Id FROM Student s
	INNER JOIN Department d
	ON d.Dept_Id = s.Dept_Id
	WHERE d.Dept_Name = 'SD');
