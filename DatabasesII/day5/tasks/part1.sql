-- 1
USE Company_SD;

DECLARE c1 CURSOR
FOR 
	SELECT e.Salary FROM Employee e
FOR UPDATE
DECLARE @salary int
OPEN c1

	FETCH c1 INTO @salary

	WHILE @@fetch_status = 0
	BEGIN

		IF (@salary < 3000)
			UPDATE Employee
			SET Salary = @salary * 1.1
			WHERE CURRENT OF c1
		ELSE
			UPDATE Employee
			SET Salary = @salary * 1.2
			WHERE CURRENT OF c1
        
		FETCH c1 INTO @salary
	END

CLOSE c1
DEALLOCATE c1;

SELECT Salary FROM Employee;

-- 2
DECLARE c2 CURSOR
FOR 
	SELECT d.Dname, e.Fname+' '+e.Lname
	FROM Employee e
	INNER JOIN Departments d
	ON e.SSN = d.MGRSSN
FOR READ ONLY
DECLARE @dname nchar(20), @ename nchar(40)
OPEN c2

	FETCH c2 INTO @dname, @ename

	WHILE @@fetch_status = 0
	BEGIN

		SELECT dname=@dname, ename=@ename
        
		FETCH c2 INTO @dname, @ename
	END

CLOSE c2
DEALLOCATE c2;

-- 3
USE ITI;

DECLARE c3 CURSOR
FOR 
	SELECT s.St_Fname
	FROM Student s
	WHERE s.St_Fname IS NOT NULL
FOR READ ONLY
DECLARE @fname varchar(20), @allnames varchar(1000)
OPEN c3

	FETCH c3 INTO @fname
	IF (@@fetch_status = 0)
		SET @allnames = @fname

	FETCH c3 INTO @fname

	WHILE @@fetch_status = 0
	BEGIN
		SET  @allnames = @allnames + ', ' + @fname
		FETCH c3 INTO @fname
	END

	SELECT @allnames

CLOSE c3
DEALLOCATE c3;

-- 7
CREATE SEQUENCE seq1_10 
START WITH 1
INCREMENT BY 1  
MINVALUE 1  
MAXVALUE 10  
NO CYCLE;

-- Msg 11728, Level 16, State 1, Line 97
-- The sequence object 'seq1_10' has reached its minimum or maximum value. Restart the sequence object to allow new values to be generated.
DECLARE @i int = 0;
WHILE @i < 11
BEGIN
	SELECT (NEXT VALUE FOR seq1_10)
END