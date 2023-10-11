use AssignmentDB

--using the same table that we created in Assignment2
--Employee table

create table EMPLOYEESS
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

-- Department table
create table DEPTT (
    DEPTNO int,
    DNAME varchar(30),
    LOC varchar(30)
);

ALTER TABLE DEPTT
ALTER COLUMN LOC VARCHAR(50);
select * from DEPTT
select * from EMPLOYEESS;

--inserting the values in both the tables.
insert into DEPTT values 
                (10, 'ACCOUNTING', 'NEW YORK'),
				(20, 'RESEARCH', 'DALLAS'),
				(30, 'SALES', 'CHICAGO'),
				(40,'OPERATIONS','BOSTON')

insert into EMPLOYEESS (EMPNO, EMPNAME, JOB, MGRID, HIREDATE, SAL, COMM, DEPTNO)
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

--Queries accordingly

--1 Retrieve a list of MANAGERS. 
SELECT EMPNAME
FROM EMPLOYEESS
WHERE JOB = 'MANAGER';

--2 Find out the names and salaries of all employees earning more than 1000 per month.
SELECT EMPNAME, SAL
FROM EMPLOYEESS
WHERE SAL > 1000;

--3 Display the names and salaries of all employees except JAMES.
SELECT EMPNAME, SAL
FROM EMPLOYEESS
WHERE EMPNAME <> 'JAMES';

--4 Find out the details of employees whose names begin with ‘S’. 
SELECT *
FROM EMPLOYEESS
WHERE EMPNAME LIKE 'S%';

--5 Find out the names of all employees that have ‘A’ anywhere in their name. 
SELECT EMPNAME
FROM EMPLOYEESS
WHERE EMPNAME LIKE '%A%';

--6 Find out the names of all employees that have ‘L’ as their third character in their name.
SELECT EMPNAME 
FROM EMPLOYEESS
WHERE SUBSTRING(EMPNAME, 3,1) ='L';

--7 Compute daily salary of JONES. 
SELECT SAL / 30 AS DAILY_SALARY
FROM EMPLOYEESS
WHERE EMPNAME = 'JONES';

--8 Calculate the total monthly salary of all employees. 
SELECT SUM(SAL) AS TOTAL_MONTHLY_SALARY
FROM EMPLOYEESS;

--9 Print the average annual salary. 
SELECT AVG(SAL) * 12 AS AVERAGE_ANNUAL_SALARY
FROM EMPLOYEESS;

--10 Select the name, job, salary, department number of all employees except SALESMAN from department number 30. 
SELECT EMPNAME AS Employee, JOB, SAL AS "Monthly Salary", DEPTNO
FROM EMPLOYEESS
WHERE JOB <> 'SALESMAN' AND DEPTNO = 30;

--11 List unique departments of the EMP table. 
SELECT DEPTNO
FROM EMPLOYEESS
GROUP BY DEPTNO;

--12 List the name and salary of employees who earn more than 1500 and are in department 10 or 30. Label the columns Employee and Monthly Salary respectively.
SELECT EMPNAME AS Employee, SAL AS "Monthly Salary"
FROM EMPLOYEESS
WHERE SAL > 1500 AND (DEPTNO = 10 OR DEPTNO = 30);

--13 Display the name, job, and salary of all the employees whose job is MANAGER or ANALYST and their salary is not equal to 1000, 3000, or 5000. 
SELECT EMPNAME AS Employee, JOB, SAL AS "Monthly Salary"
FROM EMPLOYEESS
WHERE (JOB = 'MANAGER' OR JOB = 'ANALYST') AND SAL NOT IN (1000, 3000, 5000);

--14 Display the name, salary and commission for all employees whose commission amount is greater than their salary increased by 10%. 
SELECT EMPNAME, SAL, COMM
FROM EMPLOYEESS
WHERE COMM > SAL * 1.1;

--15 Display the name of all employees who have two Ls in their name and are in department 30 or their manager is 7782. 
SELECT EMPNAME
FROM EMP
WHERE (EMPNAME LIKE '%L%L%' AND DEPTNO = 30) OR MGRID = 7782;

--16 Display the names of employees with experience of over 30 years and under 40 yrs.Count the total number of employees. 
SELECT
	(SELECT COUNT(*) FROM EMPLOYEESS 
				WHERE DATEDIFF(YEAR, HIREDATE, GETDATE()) BETWEEN 30 AND 40) 'Total', EMPNAME AS 'Total Employees', DATEDIFF(YEAR, HIREDATE, GETDATE()) 'EXPERIENCE' FROM EMPLOYEESS 
WHERE DATEDIFF(YEAR, HIREDATE, GETDATE()) BETWEEN 30 AND 40;

--17 Retrieve the names of departments in ascending order and their employees in descending order. 
SELECT D.DNAME, E.EMPNAME
FROM EMP E
JOIN DEPT D ON E.DEPTNO = D.DEPTNO
ORDER BY D.DNAME ASC, E.EMPNAME DESC;

--18 Find out experience of MILLER. 
select EMPNO, EMPNAME, HIREDATE, DATEDIFF(year, HIREDATE, Getdate()) as experience_years
from EMP E
where EMPNAME ='MILLER';



