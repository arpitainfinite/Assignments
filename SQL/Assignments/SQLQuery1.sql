Create database AssignmentDB

use AssignmentDB

--creating clients table
create table Client1
(
	client_ID int primary key,
	cname varchar(40) not null,
	address varchar(30),
	email varchar(30) unique,
	phone varchar(10),
	business varchar(20) not null 
);

-- Insert data into Clients table
insert into Client1 values
	(1001,'ACME Utilities', 'Noida','contact@acmeutil.com',9567880032, 'Manufacturing'),
	(1002,'Trackon Consultants', 'Mumbai', 'consult@trackon.com',8734210090, 'Consultant'),
	(1003, 'MoneySaver Distributors','Kolkata','save@moneysaver.com', 7799886655, 'Reseller'),
	(1004, 'Lawful Corp', 'Chennai', 'justice@lawful.com', 9210342219, 'Professional');

select * from Client1

--creating Departments table
create table Departments
(
	deptno int primary key,
	dname varchar(20) not null,
	loc varchar(20)
);

insert into Departments values
	(10,'Design', 'Pune'),
	(20,'Development','Pune'),
	(30,'Testing','Mumbai'),
	(40,'Document','Mumbai');

select * from Departments

--creating employees table
create table Employees1
(
	empno int primary key,
	ename varchar(20) not null,
	job varchar(30),
	salary varchar(7) check(salary>0) ,
	deptno int foreign key references Departments(deptno)
); 

-- Insert data into Employees table
insert into Employees1 values
	(7001,'Sandeep','Analyst',25000,10),
	(7002,'Rajesh','Designer',30000,10),
	(7003,'Madhav','Developer',4000,20),
	(7004,'Manoj','Developer',40000,20),
	(7005,'Abhay','Designer',35000,10),
	(7006,'Uma','Tester',30000,30),
	(7007,'Gita','Tech. Writer',30000,40),
	(7008,'Priya','Tester',35000,30),
	(7009,'Nutan','Developer',45000,20),
	(7010,'Smita','Analyst',20000,10),
	(7011,'Anand','Project Mgr',65000, 10);

select * from Employees1

--creating projects table
create table projects1
(
	Project_ID int primary key,
	descr varchar(20),
	start_date date,
	planned_end_date date,
	actual_end_date date ,
	budget int check (budget>0),
	clientID int
);

-- Insert data into Projects table
insert into projects1(project_id, descr, start_date, planned_end_date, actual_end_date, budget,clientID)
values (401, 'Inventory', '2011-01-04', '2011-10-01', '2011-10-31', 150000, 1001),
	   (402, 'Accounting', '2011-08-01', '2012-01-01',' ', 500000, 1002),
	   (403, 'Payroll', '2011-10-01', '2011-12-31',' ', 75000, 1003),
	   (404, 'Contact Mgmt', '2011-11-01', '2011-12-31',' ', 50000, 1004);

select * from projects1

--creating empprojecttasks
create table empprojecttaskss1
(
	Project_ID int foreign key references projects1(project_ID),
	Empno int foreign key references Employees1(empno),
	Start_Date date,
	End_Date date,
	Task varchar(20) not null,
	Status varchar(20) not null,
	primary key(project_ID,empno)	--composite primary key
);

-- Insert data into EmpProjectTasks table
insert into empprojecttaskss1(Project_ID,empno,start_date,end_date,task,status)
values 
	   (401, 7001,'2011-04-01','2011-04-20', 'System Analysis', 'Completed'),
	   (401, 7002 ,'2011-04-21','2011-05-30' ,'System Design' ,'Completed'),
	   (401, 7003, '2011-06-01','2011-07-15', 'Coding','Completed'),
	   (401, 7004,'2011-07-18','2011-09-11','Coding', 'Completed'),
	   (401, 7006,'2011-09-03','2011-09-15','Testing', 'Completed'),
	   (401, 7009,'2011-09-18','2011-10-05','Code Change','Completed'),
	   (401,7008, '2011-10-06','2011-10-16','Testing','Completed'),
	   (401,7007, '2011-10-06','2011-10-22','Documentation','Completed'),
	   (401,7011,'2011-10-22', '2011-10-31' ,'Sign off','Completed'),
	   (402,7010,'2011-08-01','2011-08-20','System Analysis', 'Completed'),
	   (402, 7002, '2011-08-22','2011-09-30', 'System Design', 'Completed'),
	   (402, 7004, '2011-10-01',' ', 'Coding', 'In Progress');

select * from empprojecttaskss1

--result
select * from Client1
select * from Departments
select * from Employees1
select * from projects1
select * from empprojecttaskss1
