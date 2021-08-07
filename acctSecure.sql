Create table AppUser 
(
  userId int primary key identity (1,1), 
  username varchar(50),
  password varchar(50), 
  surname varchar(50), 
  firstname varchar(50), 
  lastname varchar(50), 
  sex varchar(10),
  department varchar(50)
)
go
create table AcctType 
(
  acctTypeId int primary key identity(1,1),
  acctTypeDesc varchar(50)
)
go
create table TransactionType
(
   transTypeId int primary key identity(1,1),
   transDesc varchar(30)
)

go
Create table Customers 
(
    custId int primary key identity(1,1),
	custNo varchar(10),
	acctNo varchar(50), 
	acctTypeId int references AcctType (acctTypeId), 
	customername varchar(100), 
    dateofbirth date
)
go 
create table BiometricType
(
   biometricTypeId int primary key identity(1,1), 
   bioType varchar(30)
)
create table Biometrics
(
   biometricId int primary key identity(1,1),
   biometricTypeId int references BiometricType (biometricTypeId),
   custId int references Customers (custId), 
   bioImage varbinary(max)
)
go 
create table CTransaction
(
   transId int primary key identity(1,1),
   acctNo varchar(50), 
   amount decimal(18,2), 
   transTypeId int references TransactionType (transTypeId),
   transRefNo varchar(100),
   Narration varchar(200),
   transDate date,
   valueDate date,
   userId int references Appuser (userId)
)
go

Create table GLedger
( 
   ledgerId int primary key identity(1,1),
   debit decimal(18,2), 
   credit decimal(18,2), 
   postRef varchar(100),
   postDate date,
   transDate date, 
   valueDate date,
   balance decimal(18,2)
)