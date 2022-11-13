USE Company_SD;

-- 1.	Display the Department id, name and id and the name of its manager.
SELECT D.Dnum, D.Dname, E.SSN, EName=E.Fname+' '+E.Lname
FROM Departments D
INNER JOIN Employee E
ON E.Dno = D.Dnum;

-- 2.	Display the name of the departments and the name of the projects under its control.
SELECT D.Dname, P.Pname FROM Departments D
INNER JOIN Project P
ON P.Dnum = D.Dnum;

-- 3.	Display the full data about all the dependence associated with the name of the employee they depend on him/her.
SELECT D.*, EName=E.Fname+' '+E.Lname
FROM Dependent D
INNER JOIN Employee E
ON E.SSN = D.ESSN;

-- 4.	Display the Id, name and location of the projects in Cairo or Alex city.
SELECT Pnumber, Pname, Plocation FROM Project
WHERE City = 'Cairo'
or City = 'Alex';

-- 5.	Display the Projects full data of the projects with a name starts with "a" letter.
SELECT * FROM Project
WHERE Pname LIKE 'a%';

-- 6.	display all the employees in department 30 whose salary from 1000 to 2000 LE monthly
SELECT * FROM Employee
WHERE Dno = 30
AND Salary BETWEEN 1000 AND 2000;

-- 7.	Retrieve the names of all employees in department 10 who works more than or equal10 hours per week on "AL Rabwah" project.
SELECT EName=E.Fname+' '+E.Lname, W.Hours FROM  Employee E
INNER JOIN Works_for W
ON W.ESSn = E.SSN
INNER JOIN Project P
ON P.Pnumber = W.Pno
WHERE E.Dno = 10
AND P.Pname = 'AL Rabwah'
AND W.Hours >= 10;

-- 8.	Find the names of the employees who directly supervised with Kamel Mohamed.
SELECT EName=E.Fname+' '+E.Lname
FROM Employee E, Employee S
WHERE S.Fname+' '+S.Lname = 'Kamel Mohamed'
AND S.SSN = E.Superssn;

-- 9.	Retrieve the names of all employees and the names of the projects they are working on, sorted by the project name.
SELECT EName=E.Fname+' '+E.Lname, P.Pname
FROM Employee E
INNER JOIN Works_for W
ON W.ESSn = E.SSN
INNER JOIN Project P
ON W.Pno = P.Pnumber
ORDER BY P.Pname;

-- 10.	For each project located in Cairo City , find the project number, the controlling department name ,the department manager last name ,address and birthdate.
SELECT P.Pnumber, D.Dname, E.Lname, E.Address, E.Bdate
FROM Project P
INNER JOIN Departments D
ON P.Dnum = D.Dnum
INNER JOIN Employee E
ON D.MGRSSN = E.SSN
WHERE P.City = 'Cairo';

-- 11.	Display All Data of the managers
SELECT E.* FROM Employee E
INNER JOIN Departments D
ON E.SSN = D.MGRSSN;

-- 12.	Display All Employees data and the data of their dependents even if they have no dependents
SELECT E.*, D.* FROM Employee E
LEFT OUTER JOIN Dependent D
ON D.ESSN = E.SSN;

-- 13.	Insert your personal data to the employee table as a new employee in department number 30, SSN = 102672, Superssn = 112233, salary=3000.
INSERT INTO Employee (Dno, SSN, Superssn, Salary, Fname, Lname)
VALUES (30, 102672, 112233, 3000, 'Ahmed', 'Negmeldin');

-- 14.	Insert another employee with personal data your friend as new employee in department number 30, SSN = 102660, but don’t enter any value for salary or supervisor number to him.
INSERT INTO Employee (Dno, SSN, Fname, Lname)
VALUES (30, 102660, 'Hagar', 'Mustafa');

-- 15.	Upgrade your salary by 20 % of its last value.
UPDATE Employee SET Salary = 1.2 * Salary
WHERE SSN = 102672;
