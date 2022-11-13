USE Company_SD;

-- 1
-- a.	 The name and the gender of the dependence that's gender is Female and depending on Female Employee.
SELECT Name=Fname+' '+Lname, Sex FROM Employee
WHERE Sex = 'F'
UNION ALL
SELECT D.Dependent_name, D.Sex FROM Dependent D
INNER JOIN Employee E
ON D.ESSN = E.SSN
WHERE E.Sex = 'F'
AND D.Sex = 'F';

-- b.	 And the male dependence that depends on Male Employee.
SELECT Name=Fname+' '+Lname, Sex FROM Employee
WHERE Sex = 'M'
UNION ALL
SELECT D.Dependent_name, D.Sex FROM Dependent D
INNER JOIN Employee E
ON D.ESSN = E.SSN
WHERE E.Sex = 'M'
AND D.Sex = 'M';

-- 2.	For each project, list the project name and the total hours per week (for all employees) spent on that project.
SELECT Pname, SUM(W.Hours) FROM Project P
INNER JOIN Works_for W
ON W.Pno = P.Pnumber
GROUP BY Pname;

-- 3.	Display the data of the department which has the smallest employee ID over all employees' ID.
SELECT D.*, E.SSN FROM Departments D
INNER JOIN Employee E
ON E.Dno = D.Dnum
WHERE E.SSN = (SELECT MIN(SSN) FROM Employee);

-- 4.	For each department, retrieve the department name and the maximum, minimum and average salary of its employees.
SELECT D.Dname, MaxSalary=MAX(E.Salary),
MinSalary=MIN(E.SALARY), AvgSalary=AVG(E.Salary)
FROM Departments D 
INNER JOIN Employee E
ON E.Dno = D.Dnum
GROUP BY D.Dname;

-- 5.	List the full name of all managers who have no dependents.
SELECT Name=Fname+' '+Lname
FROM Employee
WHERE SSN IN (SELECT MGRSSN FROM Departments)
AND SSN NOT IN (SELECT ESSN FROM Dependent);

-- 6.	For each department-- if its average salary is less than the average salary of all 
SELECT Dnum=MAX(D.Dnum), D.Dname, EmpCount=COUNT(E.SSN)
FROM Departments D
INNER JOIN Employee E
ON E.Dno = D.Dnum
GROUP BY D.Dname
HAVING AVG(E.Salary) < (SELECT AVG(Salary) FROM Employee)

-- 7.	Retrieve a list of employees names and the projects names they are working on ordered by department number and within each department, ordered alphabetically by last name, first name.
SELECT E.Fname, E.Lname, P.Pname, P.Dnum
FROM Employee E
INNER JOIN Works_for W
ON W.ESSn = E.SSN
INNER JOIN Project P
ON P.Pnumber = W.Pno
ORDER BY P.Dnum, E.Lname, E.Fname;

-- 8.	Try to get the max 2 salaries using subquery
SELECT TOP 2 * 
FROM (SELECT Salary FROM Employee) AS Salary
ORDER BY Salary DESC;

SELECT MaxSalary.Salary
FROM (SELECT MAX(Salary) Salary FROM Employee) MaxSalary
UNION ALL
SELECT MAX(SALARY) FROM Employee
WHERE Salary != (SELECT MAX(Salary) Salary FROM Employee)

-- 9.	Get the full name of employees that is similar to any dependent name
SELECT FullName=E.Fname+' '+E.Lname
FROM Employee E
WHERE E.Fname+' '+E.Lname IN (SELECT Dependent_name FROM Dependent);

-- 10.	Display the employee number and name if at least one of them have dependents (use exists keyword) 
SELECT SSN FROM Employee
WHERE EXISTS (SELECT ESSN FROM Dependent)

-- 11.	In the department table insert new department called "DEPT IT" , with id 100, employee with SSN = 112233 as a manager for this department. The start date for this manager is '1-11-2006'
INSERT INTO Departments (Dname, Dnum, MGRSSN, [MGRStart Date]) VALUES ('DEPT IT', 100, 112233, '1/11/2006');

-- 12.	Do what is required if you know that : Mrs.Noha Mohamed(SSN=968574)  moved to be the manager of the new department (id = 100), and they give you(your SSN =102672) her position (Dept. 20 manager) 
-- a.	First try to update her record in the department table
UPDATE Departments SET MGRSSN = 968574 WHERE Dnum = 100;

-- b.	Update your record to be department 20 manager.
UPDATE Departments SET MGRSSN = 102672 WHERE Dnum = 20;

-- c.	Update the data of employee number=102660 to be in your teamwork (he will be supervised by you) (your SSN =102672)
UPDATE Employee SET Dno = 20, Superssn = 102672 WHERE SSN = 102660;

-- 13.	Unfortunately the company ended the contract with Mr. Kamel Mohamed (SSN=223344) so try to delete his data from your database in case you know that you will be temporarily in his position.
UPDATE Employee SET Superssn = 102672 WHERE Superssn = 223344;
UPDATE Departments SET MGRSSN = 102672 WHERE MGRSSN = 223344;
UPDATE Works_for SET ESSn = 102672 WHERE ESSn = 223344;

DELETE FROM Dependent WHERE ESSN = 223344;
DELETE FROM Employee WHERE SSN = 223344;

-- 14.	Try to update all salaries of employees who work in Project ‘Al Rabwah’ by 30%
UPDATE E
SET E.Salary = E.Salary * 1.3
from Employee E
	INNER JOIN Works_for W
	ON W.ESSn = E.SSN
	INNER JOIN Project P
	ON P.Pnumber = W.Pno
WHERE P.Pname = 'Al Rabwah';