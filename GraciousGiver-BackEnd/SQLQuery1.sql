create database GraciousGiverProject

use GraciousGiverProject




create table Product
(
	ProductId int identity(1,1),
	ProductName varchar(100),
	ProductCategory varchar(70),
	ProductState varchar(70),
	ProductPhoto varchar(200),
	ProductDescription varchar(200),
	ProductLocation varchar(70) ,
	ProductComment varchar(200) NULL,
	DonatorId int NULL
)


create table City(
	CityId int identity(1,1),
	CityName varchar(100)	
)

create table State(
	StateId int identity(1,1),
	StateName varchar (100)
)

create table ProductCategory
(
	ProductCategoryId int identity(1,1),
	ProductCategoryName varchar(500)
)


insert into ProductCategory values ('Clothes')
insert into ProductCategory values('Food')

insert into Product values('Boots','Clothes','good','sad','nice','Ferizaj','none','1234')

insert into City values ('Gjilan')

