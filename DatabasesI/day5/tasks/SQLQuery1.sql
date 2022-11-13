USE ITI;

-- 1.	Retrieve number of students who have a value in their age. 
SELECT COUNT(S.St_Age) FROM Student S;

-- 2.	Get all instructors Names without repetition
SELECT DISTINCT I.Ins_Name FROM Instructor I;

-- 3.	Display student with the following Format (use isNull function)
SELECT ISNULL(S.St_Id, -1)[Student ID],
	   ISNULL(S.St_Fname, 'N/A')[Student Full Name],
	   ISNULL(D.Dept_Name, 'N/A')[Department name]
FROM Student S
FULL OUTER JOIN Department D
ON D.Dept_Id = S.Dept_Id;

-- 4.	Display instructor Name and Department Name
SELECT I.Ins_Name, D.Dept_Name FROM Instructor I
LEFT OUTER JOIN Department D
ON I.Dept_Id = D.Dept_Id;

-- 5.	Display student full name and the name of the course he is taking For only courses which have a grade  
SELECT St_name=S.St_Fname+' '+S.St_Lname, C.Crs_Name
FROM Student S
INNER JOIN Stud_Course SC
ON S.St_Id = SC.St_Id
INNER JOIN Course C
ON SC.Crs_Id = C.Crs_Id
WHERE SC.Grade IS NOT NULL;

-- 6.	Display number of courses for each topic name
SELECT T.Top_Name, COUNT(C.Top_Id) [Courses Count]
FROM Topic T
INNER JOIN Course C
ON T.Top_Id = C.Top_Id
GROUP BY T.Top_Name;

-- 7.	Display max and min salary for instructors
SELECT MIN(I.Salary) MinSalary, MAX(I.Salary) MaxSalary
FROM Instructor I;

-- 8.	Display instructors who have salaries less than the average salary of all instructors.
SELECT I.* FROM Instructor I
WHERE I.Salary < (SELECT AVG(Salary) FROM Instructor);

-- 9.	Display the Department name that contains the instructor who receives the minimum salary.
SELECT D.Dept_Name 
FROM Department D,
(SELECT MIN(Salary) Salary, MAX(Dept_Id) Dept_Id FROM Instructor) I
WHERE D.Dept_Id = I.Dept_Id;

-- 10.	 Select max two salaries in instructor table. 
SELECT TOP 2 *
FROM (SELECT Salary FROM Instructor) Salary
ORDER BY Salary;

-- 11.	 Select instructor name and his salary but if there is no salary display instructor bonus keyword. “use coalesce Function”
SELECT COALESCE(CONVERT(VARCHAR, Salary), 'instructor bonus')
FROM Instructor;

-- 12.	Select Average Salary for instructors 
SELECT AVG(Salary) FROM Instructor;

-- 13.	Select Student first name and the data of his supervisor
SELECT St_Name=S.St_Fname+' '+S.St_Lname, I.*
FROM Student S
INNER JOIN Instructor I
ON I.Ins_Id = S.St_Id;

-- 14.	Write a query to select the highest two salaries in Each Department for instructors who have salaries. “using one of Ranking Functions”
SELECT * FROM
	(SELECT *, DENSE_RANK()
		OVER(PARTITION BY I.Dept_Id ORDER BY I.Salary) DR
	 FROM Instructor I) RI
WHERE RI.DR <= 2;

-- 15.	 Write a query to select a random  student from each department.  “using one of Ranking Functions”
SELECT TOP 1 * FROM
	(SELECT *, ROW_NUMBER() 
		OVER(ORDER BY NEWID()) RN
	 FROM Student) S
ORDER BY S.RN;