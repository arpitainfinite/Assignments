use AssignmentDB

--Question 1: Write a T-SQL Program to find the factorial of a given number.

declare @num int
declare @result int
set @num = 2
set @result = 1
while @num > 1
begin
    set @result = @result * @num
    set @num = @num - 1
end
select @result as factorial

--Question 2: Create a stored procedure to generate multiplication tables up to a given number.

create or alter procedure Multiplication_Table (@number int)
as
begin
declare @num int, @table int
set @num =1
while(@num<=10)
begin
set @table = @number *@num
print cast (@number as varchar(10)) +'*' + cast (@num as varchar) + '=' + cast(@table as varchar(20))
set @num = @num+1
end
end
exec Multiplication_Table @number = 7;

--Question 3:  Create a trigger to restrict data manipulation on EMP table during General holidays. Display the error message like “Due to Independence day you cannot manipulate data” or "Due To Diwali", you cannot manupulate" etc 

--Table creation
create Table Holiday(
holiday_date Date,
holiday_name NVARCHAR(100)
);

--Insert holiday details
Insert into Holiday(holiday_date, holiday_name)
values
('2023-12-25', 'Christmas'),
('2023-11-12', 'Diwali'),
('2023-08-15', 'Independence Day'),
('2023-09-11', 'Lohri')


select * from Holiday

--Trigger creation
create or alter trigger prevent_holiday_manipulation
on Holiday
after insert, update, delete
as
begin
    declare @holiday_message nvarchar(100);
    declare @error_message nvarchar(200); 
    
    if exists (select 1 from holiday where holiday_date in (select holiday_date from inserted)) begin
        select @holiday_message = holiday_name from holiday where holiday_date in (select holiday_date from inserted);
        select @error_message = 'Due to ' + @holiday_message + ' you cannot manipulate data';
        rollback;
        raiserror(@error_message, 16, 1);
    end;
end;
update Holiday set holiday_name = 'Christmas' where holiday_date='2023-12-25';