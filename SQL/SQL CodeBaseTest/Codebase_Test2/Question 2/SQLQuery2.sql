use AssignmentDB

--Question 2: Write a Cursor program, that retrieves all the employees and updates salary for all employees of Department 10(Accounting) by 15%

select empno,sal from emp where deptno=10
declare @empno int;
declare @empsal numeric(10, 2);
declare employee_cursor cursor for
select empno, sal
from EMP
where deptno = 10;
declare @new_salary numeric(10, 2);
open employee_cursor;
fetch next from employee_cursor into @empno, @empsal;
while @@FETCH_STATUS = 0
begin  
    set @new_salary = @empsal * 1.15; 
    update EMP
    set sal = @new_salary
    where empno = @empno; 
    fetch next from employee_cursor into @empno, @empsal;
end;
close employee_cursor;
deallocate employee_cursor;

select empno,  sal
from EMP
where deptno = 10;

select * from EMP