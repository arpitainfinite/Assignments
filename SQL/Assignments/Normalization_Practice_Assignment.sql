create database normalization_practice

use normalization_practice

--Table for 1NF

create table ClientRental_1NF(
client_No varchar(45),
c_Name varchar(50),
property_No varchar(30),
p_Address varchar(50),
rent_Start Date,
rent_Finish Date,
rent int,
owner_No varchar(10),
owner_Name varchar(15)
);

insert into ClientRental_1NF values
('CR76','John Kay','PG4','6 lawerence st.glasgow','1-JUL-00','31-AUG-01',350,'CO40','Tina Murphy'),
('CR76','John Kay','PG16','5 novar dr glasgow','1-SEP-02','1-SEP-03',450,'CO93','Tony Shaw'),
('CR56','Aline Stewart','PG4','6 lawerence st.glasgow','1-SEP-99','10-JUN-00',350,'CO40','Tina Murphy'),
('CR56','Aline Stewart','PG36','2 manor rd.glasgow','10-OCT-00','1-DEC-01',370,'CO93','Tony Shaw'),
('CR56','Aline Stewart','PG16','5 novar dr glasgow','1-NOV-02','1-AUG-03',450,'CO93','Tony Shaw');

select * from ClientRental_1NF

--Table for 2NF and 3NF

create table Client(
Client_No varchar(10) primary key,
C_Name varchar(20)
);

insert into Client values
('CR76','John Kay'),
('CR56','Aline Stewart');

select * from Client

create table Owners(
Owner_No varchar(35) primary key,
O_Name varchar(25)
);

insert into Owners values
('C040','Tina Muphy'),
('C093','Tony Shaw');

select * from Owners

create table Property_Owner(
Property_No varchar(10) primary key,
P_Address varchar(30),
Rent int,
Owner_No varchar(35) foreign key references Owners(Owner_No)
);

insert into Property_Owner values
('PG4','6 lawerence st.glasgow',350,'C040'),
('PG16','5 novar dr glasgow',450,'C093'),
('PG36','2 manor rd.glasgow',370,'C093');

select * from Property_Owner

create table Rent(
Client_No varchar(10) foreign key references Client (Client_No),
Property_No varchar(10) foreign key references Property_Owner (Property_No),
rent_Start Date,
rent_Finish Date
);

insert into Rent values
('CR76','PG4','1-JUL-00','31-AUG-01'),
('CR76','PG16','1-SEP-02','1-SEP-03'),
('CR56','PG4','1-SEP-99','10-JUN-00'),
('CR56','PG36','10-OCT-00','1-DEC-01'),
('CR56','PG16','1-NOV-02','1-AUG-03');

select * from Rent