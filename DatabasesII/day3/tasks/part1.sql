USE ITI;

-- 1
CREATE VIEW passingStudents 
AS
	SELECT s.St_Fname, c.Crs_Name
	FROM Stud_Course sc
	INNER JOIN Student s
	ON s.St_Id = sc.St_Id
	INNER JOIN Course c
	ON sc.Crs_Id = c.Crs_Id
	WHERE sc.Grade > 50;

SELECT * FROM passingStudents;

-- 2
CREATE VIEW managersTopics
WITH ENCRYPTION AS
	SELECT DISTINCT i.Ins_Name, t.Top_Name
	FROM Instructor i
	INNER JOIN Ins_Course ic
	ON i.Ins_Id = ic.Ins_Id
	INNER JOIN Course c
	ON c.Crs_Id = ic.Crs_Id
	INNER JOIN Topic t
	ON t.Top_Id = c.Top_Id
	WHERE i.Ins_Id IN 
	(
		SELECT d.Dept_Manager FROM Department d
	);

SELECT * FROM managersTopics;

-- 3
CREATE VIEW SD_Java_instructors
AS
	SELECT i.Ins_Name, d.Dept_Name
	FROM Instructor i
	INNER JOIN Department d
	ON d.Dept_Id = i.Dept_Id
	WHERE d.Dept_Name IN (
		'SD', 'Java'
	);

SELECT * FROM SD_Java_instructors;

-- 4
CREATE VIEW V1
AS
	SELECT * FROM Student s
	WHERE s.St_Address IN ('Alex', 'Cairo')
WITH CHECK OPTION;

-- Msg 550, Level 16, State 1, Line 54
-- The attempted insert or update failed because the target view either specifies WITH CHECK OPTION or spans a view that specifies WITH CHECK OPTION and one or more rows resulting from the operation did not qualify under the CHECK OPTION constraint.
Update V1 set st_address='tanta'
Where st_address='alex';

-- 5
USE SD;

CREATE VIEW projectEmpCount
AS
	SELECT p.projectName, employees=COUNT(w.empNo)
	FROM works_on w
	INNER JOIN company.project p
	ON p.projectNo = w.projectNo
	GROUP BY p.projectName;

SELECT * FROM projectEmpCount;

-- 6
USE ITI;

-- Msg 1902, Level 16, State 3, Line 77
-- Cannot create more than one clustered index on table 'Department'. Drop the existing clustered index 'PK_Department' before creating another.
CREATE CLUSTERED INDEX hiredateIndex
ON Department(Manager_hiredate);

-- 7
-- Msg 1505, Level 16, State 1, Line 81
-- The CREATE UNIQUE INDEX statement terminated because a duplicate key was found for the object name 'dbo.Student' and the index name 'uniqueAge'. The duplicate key value is (21).
CREATE UNIQUE INDEX uniqueAge
ON Student(St_Age);

-- 8
MERGE INTO DailyTransaction T
USING LastTransaction S
ON S.User_ID = T.User_ID
WHEN MATCHED THEN
UPDATE SET T.TransactionAmount = S.TransactionAmount
WHEN NOT MATCHED THEN
INSERT VALUES (S.User_ID, S.TransactionAmount);