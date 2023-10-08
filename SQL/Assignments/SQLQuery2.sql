use AssignmentDB

--we will first create a table EMP 
create table EMP
(
EMPNO int ,
EMPNAME varchar(50),
JOB varchar(50),
MGRID int,
HIREDATE date,
SAL int,
COMM int,
DEPTNO int
)

--now we create second table DEPT
create table DEPT (
    DEPTNO int,
    DNAME varchar(30),
    LOC varchar(30)
);

ALTER TABLE DEPT
ALTER COLUMN LOC VARCHAR(50);
select * from DEPT
select * from EMP;

--inserting the values in both the tables.
insert into DEPT values 
                (10, 'ACCOUNTING', 'NEW YORK'),
				(20, 'RESEARCH', 'DALLAS'),
				(30, 'SALES', 'CHICAGO'),
				(40,'OPERATIONS','BOSTON')

insert into EMP (EMPNO, EMPNAME, JOB, MGRID, HIREDATE, SAL, COMM, DEPTNO)
values
    (7369, 'SMITH', 'CLERK', 7902, CONVERT(DATE, '17-DEC-80', 5), 800, NULL, 20),
    (7499, 'ALLEN', 'SALESMAN', 7698, CONVERT(DATE, '20-FEB-81', 5), 1600, 300, 30),
    (7521, 'WARD', 'SALESMAN', 7698, CONVERT(DATE, '22-FEB-81', 5), 1250, 500, 30),
    (7566, 'JONES', 'MANAGER', 7839, CONVERT(DATE, '02-APR-81', 5), 2975, NULL, 20),
    (7654, 'MARTIN', 'SALESMAN', 7698, CONVERT(DATE, '28-SEP-81', 5), 1250, 1400, 30),
    (7698, 'BLAKE', 'MANAGER', 7839, CONVERT(DATE, '01-MAY-81', 5), 2850, NULL, 30),
    (7782, 'CLARK', 'MANAGER', 7839, CONVERT(DATE, '09-JUN-81', 5), 2450, NULL, 10),
    (7788, 'SCOTT', 'ANALYST', 7566, CONVERT(DATE, '19-APR-87', 5), 3000, NULL, 20),
    (7839, 'KING', 'PRESIDENT', NULL, CONVERT(DATE, '17-NOV-81', 5), 5000, NULL, 10),
    (7844, 'TURNER', 'SALESMAN', 7698, CONVERT(DATE, '08-SEP-81', 5), 1500, 0, 30),
    (7876, 'ADAMS', 'CLERK', 7788, CONVERT(DATE, '23-MAY-87', 5), 1100, NULL, 20),
    (7900, 'JAMES', 'CLERK', 7698, CONVERT(DATE, '03-DEC-81', 5), 950, NULL, 30),
    (7902, 'FORD', 'ANALYST', 7566, CONVERT(DATE, '03-DEC-81', 5), 3000, NULL, 20),
    (7934, 'MILLER', 'CLERK', 7782, CONVERT(DATE, '23-JAN-82', 5), 1300, NULL, 10);

--queries accordingly...

--1 List all employees whose name begins with 'A'.
select * from EMP where EMPNAME LIKE 'A%';

--2 Select all those employees who don't have a manager. 
select * from EMP where MGRID IS NULL;

--3 List employee name, number and salary for those employees who earn in the range 1200 to 1400. 
SELECT EMPNAME, EMPNO, SAL
FROM EMP
WHERE SAL BETWEEN 1200 AND 1400;

--4  Give all the employees in the RESEARCH department a 10% pay rise. Verify that this has been done by listing all their details before and after the rise
SELECT * FROM EMP WHERE DEPTNO = 20;
UPDATE EMP SET SAL = SAL * 1.10 WHERE DEPTNO = 20;
SELECT * FROM EMP WHERE DEPTNO = 20;

--5 Find the number of CLERKS employed. Give it a descriptive heading. 
SELECT COUNT(*) AS "Number of Clerks" FROM EMP WHERE JOB = 'CLERK';

--6 Find the average salary for each job type and the number of people employed in each job.
SELECT JOB, AVG(SAL) AS "Average Salary", COUNT(*) AS "Number of Employees"
FROM EMP
GROUP BY JOB;

--7 List the employees with the lowest and highest salary. 
SELECT * FROM EMP WHERE SAL = (SELECT MIN(SAL) FROM EMP)
UNION
SELECT * FROM EMP WHERE SAL = (SELECT MAX(SAL) FROM EMP);

--8 List full details of departments that don't have any employees. 
SELECT * FROM DEPT WHERE DEPTNO NOT IN (SELECT DISTINCT DEPTNO FROM EMP);

--9 Get the names and salaries of all the analysts earning more than 1200 who are based in department 20. Sort the answer by ascending order of name.
SELECT EMPNAME, SAL
FROM EMP
WHERE JOB = 'ANALYST' AND SAL > 1200 AND DEPTNO = 20
ORDER BY EMPNAME ASC;

--10  For each department, list its name and number together with the total salary paid to employees in that department. 
SELECT D.DNAME, D.DEPTNO, SUM(E.SAL) AS "Total Salary"
FROM DEPT D
LEFT JOIN EMP E ON D.DEPTNO = E.DEPTNO
GROUP BY D.DEPTNO, D.DNAME;

--11 Find out salary of both MILLER and SMITH.
SELECT EMPNAME, SAL
FROM EMP
WHERE EMPNAME IN ('MILLER', 'SMITH');

--12 Find out the names of the employees whose name begin with ‘A’ or ‘M’.
SELECT EMPNAME
FROM EMP
WHERE EMPNAME LIKE 'A%' OR EMPNAME LIKE 'M%';

--13 Compute yearly salary of SMITH.
SELECT EMPNAME, SAL * 12 AS "Yearly Salary"
FROM EMP
WHERE EMPNAME = 'SMITH';

--14 List the name and salary for all employees whose salary is not in the range of 1500 and 2850.
SELECT EMPNAME, SAL
FROM EMP
WHERE SAL NOT BETWEEN 1500 AND 2850;

--15 Find all managers who have more than 2 employees reporting to them
SELECT MGRID, COUNT(*) AS "Number of Employees"
FROM EMP
GROUP BY MGRID
HAVING COUNT(*) > 2;