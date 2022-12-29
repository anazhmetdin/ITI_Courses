USE SD;

-- 1
CREATE VIEW v_clerk
AS
	SELECT e.empNo, w.projectNo, w.enter_date
	FROM Emp e
	INNER JOIN works_on w
	ON w.empNo = e.empNo
	WHERE w.job = 'Clerk';

SELECT * FROM v_clerk;

-- 2
CREATE VIEW v_without_budget
AS
	SELECT * FROM company.project p
	WHERE p.budget IS NULL;

SELECT * FROM v_without_budget;

-- 3
CREATE VIEW v_count
AS
	SELECT p.projectName, COUNT(DISTINCT w.job) jobsCount
	FROM company.project p
	INNER JOIN works_on w
	ON w.projectNo = p.projectNo
	GROUP BY p.projectName;

SELECT * FROM v_count;

-- 4
CREATE VIEW v_project_p2
AS
	SELECT * FROM v_clerk
	WHERE projectNo = 'p2';

SELECT * FROM v_project_p2;

-- 5
ALTER VIEW v_without_budget
AS
	SELECT * FROM company.project p;

SELECT * FROM v_without_budget;

-- 6
DROP VIEW v_clerk, v_count;

-- 7
CREATE VIEW empD2
AS
	SELECT e.empNo, e.lName
	FROM Emp e
	WHERE e.deptNo = 'd2';

SELECT * FROM empD2;

-- 8
SELECT * FROM empD2
WHERE lName LIKE '%J%';

-- 9
CREATE VIEW v_dept
AS
	SELECT d.deptNo, d.deptName
	FROM company.department d;

SELECT * FROM v_dept;

-- 10
INSERT INTO v_dept (deptNo, deptName)
VALUES ('d4', 'Development');

-- 11
CREATE VIEW v_2006_check
AS
	SELECT e.empNo, p.projectNo
	FROM Emp e
	INNER JOIN works_on w
	ON w.empNo = e.empNo
	INNER JOIN company.project p
	ON p.projectNo = w.projectNo
	WHERE w.enter_date BETWEEN
	'2006-1-1' AND '2006-12-31';

SELECT * FROM v_2006_check;