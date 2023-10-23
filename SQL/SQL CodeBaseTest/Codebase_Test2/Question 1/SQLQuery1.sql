
use AssignmentDB
 
--Question 1:
/*a. Create a table called Code_Employee(empno int primary key,
   empname varchar(35), (is a required field)
  empsal numeric(10,2) - (check empsal >=25000)
  emptype char(1) ) (either 'F' for fulltime or 'P' part time) (Empty Table) 

b. Create a stored procedure to add new employee records. The procedure should accept all the employee details as input parameters, except empno. Generate the new employee no in the procedure and then insert the record

  Test the procedure
c. Using Ado.net classes/methods, insert employee record in the table by invoking the procedure  
d. Display all the records (including the newely added record)*/

create table Code_Employees (
    empno int primary key,
    empname varchar(35) NOT NULL,
    empsal numeric(10,2) check (empsal >= 25000),
    emptype char(1) check (emptype IN ('F', 'P'))
);
create procedure AddEmployee
    @empname varchar(35),
    @empsal numeric(10,2),
    @emptype char(1)
as
begin
    declare @new_empno int;
    -- Generate a new employee number
    select @new_empno = COALESCE(MAX(empno), 0) + 1 from Code_Employees;
    -- Insert the new employee record
    insert into Code_Employees (empno, empname, empsal, emptype)
    values (@new_empno, @empname, @empsal, @emptype);
end;



select *from Code_Employees