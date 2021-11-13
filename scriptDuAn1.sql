create database DuAn1;
GO

use DuAn1;
GO

create table Roles
(
	Id_role int identity primary key,
	Name nvarchar(20) NOT NULL
);
Go

create table Employees
(
	Id_role int NOT NULL,
	Gender nvarchar(10) NOT NULL, -- nam || nữ
	Email nvarchar(50) NOT NULL,
	Address nvarchar(100) NOT NULL,
	Password varchar(100) DEFAULT('1292201552198220877194054219216496220885'),
	DayOfBirth date NOT NULL,
	Id_employee int identity(1,1) primary key NOT NULL,
	Name nvarchar(50) NOT NULL,
	Salary float NOT NULL,
	constraint fk_idRole foreign key (Id_role) references Roles (Id_role)
);
Go

Create table TypesVoucher
(
	ID_Type int identity primary key not null,
	Sale float not null -- loại giảm giá (vd:20%,30%,...)
)
GO

create table Vouchers
(
	Id_voucher varchar(6) primary key,
	DateBegin date not null default(getdate()),
	DateEnd date,
	Id_employee int not null,
	ID_Type int not null,
	Status int not null DEFAULT(0), -- chưa dùng || đã dùng
	constraint FK_Id_employe_voucher foreign key (Id_employee) references Employees(Id_employee),
	constraint FK_Id_TypeVoucher_voucher foreign key (ID_Type) references TypesVoucher(ID_Type)
);
Go


create table Shifts
(
	TimeBegin VARCHAR(10) not null,
	TimeEnd VARCHAR(10) not null,
	Id_shift int primary key,
);
Go

create table Schedules
(
	Id_schedule int identity primary key,
	Id_employee int not null,
	Id_shift int not null,
	Days int, -- các ngày nhân viên làm trong tuần (vd: 234 thì làm t2,t3,t4)
	constraint FK_Id_employee_schedule foreign key (Id_employee) references Employees(Id_employee),
	constraint FK_Id_Shift foreign key (Id_shift) references Shifts(Id_shift)
);
Go

create table TypesOfIngredient
(
	Id_type int identity primary key not null,
	Name nvarchar(50)
);
Go

create table Suppliers
(
	Name nvarchar(50) not null,
	Id_supplier int identity primary key not null,
	Email nvarchar(50) not null,
	Address nvarchar(100) not null
);
Go

create table Ingredients
(
	Id_ingredient int identity primary key,
	Name nvarchar(100) not null,
	Id_supplier int not null,
	Id_type int not null,
	Price float not null,
	Constraint FK_ID_Type foreign key(Id_type) references TypesOfIngredient(Id_type),
	Constraint FK_ID_supplier foreign key (Id_supplier) references Suppliers(Id_supplier)
);
Go

create table InputBills
(
	ID_Bill int identity primary key,
	DateCheckIn datetime not null default(getdate()),
	ID_employee int not null,
	Constraint FK_ID_employee foreign key (ID_employee) references employees(ID_employee)
)

Create table units -- đơn vị (vd:kg,lít,..)
(
	ID_unit int identity primary key,
	Name nvarchar(20)
)

Create table InputBillsDetaill
(
	Id_BillDetaill int identity primary key,
	quantity float not null,
	Id_unit int not null,
	Id_Ingredient int not null,
	ID_Bill int not null,
	Constraint FK_ID_unit foreign key(Id_unit) references units(Id_unit),
	Constraint FK_ID_ingredient foreign key(Id_Ingredient) references Ingredients(Id_Ingredient),
	Constraint FK_ID_InputBills foreign key(ID_Bill) references InputBills(ID_Bill),
)

create table TypesOfBeverage
(
	Id_type int identity primary key,
	Name nvarchar(50) not null
);
Go

create table Beverages
(
	Name nvarchar(55) not null,
	Price float not null,
	Id_type int not null,
	Id_beverage int primary key identity,
	Image nvarchar(500) not null,
	constraint FK_Id_type_Beverages foreign key (Id_type) references TypesOfBeverage (Id_type)
);
Go

create table Bills_detail
(
	Id_bill int primary key identity,
	Quantity int not null,
	Id_beverage int not null,
	constraint FK_Id_beverage_Bill_detail foreign key(Id_beverage) references Beverages(Id_beverage)
);
Go

create table Customers
(
	Email nvarchar(50) not null,
	Gender nvarchar(10) not null, -- nam || nữ
	Id_customer int primary key identity,
	Reward int not null default(0) -- điểm khách hàng thân thiết
);
Go

Create table tables
(
	ID_Table int primary key identity,
	name nvarchar(50) not null,
	Status nvarchar(20) not null default(N'trống') -- có người || trống
)

create table Bills(
	Id_employee int not null,
	Id_bill int primary key identity,
	Id_customer int not null,
	Id_table int  not null,
	DateCheckIn date  not null,
	Constraint FK_Id_employee_Employee foreign key (Id_employee) references Employees(Id_employee),
	Constraint FK_Id_bill_BillDetail foreign key(Id_bill) references Bills_detail (Id_bill),
	constraint FK_Id_customer foreign key(Id_customer) references Customers(Id_customer),
	constraint FK_Id_table foreign key(Id_table) references tables(Id_table)
);
go

-- drop proc dbo.LOGIN
CREATE PROCEDURE [dbo].[LOGIN] @EMAIL VARCHAR(50), @PASSWORD NVARCHAR(100)
AS 
BEGIN
	DECLARE @STATUS INT
	IF EXISTS(SELECT * FROM Employee 
	WHERE Email = @EMAIL AND Password = @PASSWORD)
		SET @STATUS = 1
	ELSE 
		SET @STATUS = 0
	SELECT @STATUS
END
GO


/****** Object:  StoredProcedure [dbo].[FORGOT_PASSWORD]    Script Date: 11/5/2021 1:37:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FORGOT_PASSWORD] @EMAIL varchar(50)
AS
BEGIN
	Declare @STATUS int

if exists(select Id_employee from Employee where Email = @EMAIL)
	set @STATUS = 1
else
	set @STATUS = 0
select @STATUS
END
GO
/****** Object:  StoredProcedure [dbo].[CREATE_NEW_PASS]    Script Date: 11/5/2021 1:39:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CREATE_NEW_PASS] 
@Email nvarchar(50),
@Password nvarchar(50)
AS
BEGIN
Update Empolyee SET Password = @Password
where Email = @Email
END

/****** Object:  StoredProcedure [dbo].[CHANGE_PASSWORD]    Script Date: 11/5/2021 1:39:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CHANGE_PASSWORD] 
@EMAIL varchar(50),
@OLDPASS nvarchar(50),
@NEWPASS nvarchar(50)
AS
BEGIN
		DECLARE @OP varchar(50)
		SELECT @OP = Password from Employee where Email = @EMAIL
		IF @OP = @OLDPASS
		BEGIN 
		UPDATE Employee SET Password = @NEWPASS where Email = @EMAIL
		return 1
		END
		ELSE
		return -1
END
GO

/****** Object:  StoredProcedure [dbo].[INSERT_DATA_TO_EMPLOYEE]    Script Date: 11/5/2021 1:39:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[INSERT_DATA_TO_EMPLOYEE] 
@Id_role int,
@Name nvarchar(50),
@Gender int,
@Email varchar(50),
@Address nvarchar(50),
@DayOfBirth date,
@Salary float,
@Password varchar(50)
AS
BEGIN
		INSERT INTO Employee(Id_role,Gender,Email,Address,Password,DayOfBirth,Name,Salary)
		VALUES(@Id_role,@Gender,@Email,@Address,@Password,@DayOfBirth,@Name,@Salary)
END
GO

/****** Object:  StoredProcedure [dbo].[UPDATE_DATA_TO_EMPLOYEE]    Script Date: 11/5/2021 1:39:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UPDATE_DATA_TO_EMPLOYEE] 
@Name nvarchar(50),
@Gender int,
@Email varchar(50),
@Address nvarchar(50),
@DayOfBirth date
AS
BEGIN
		UPDATE Employee SET Address =  @Address, Gender = @Gender,
												Email = @Email, DayOfBirth = @DayOfBirth
												where Email = @Email
		
END
GO

/****** Object:  StoredProcedure [dbo].[UPDATE_DATA_TO_EMPLOYEE]    Script Date: 11/5/2021 1:39:53 PM ******/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DELETE_DATA_FROM_EMPLOYEE] @Email varchar(50)
AS
BEGIN
		DELETE from Employee 
		where Email = @Email
END
GO

/****** Object:  StoredProcedure [dbo].[SEARCH_EMPLOYEE]    Script Date: 11/5/2021 1:39:53 PM ******/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SEARCH_EMPLOYEE]
@Name nvarchar(50)
AS
BEGIN
		SET NOCOUNT ON;
		SELECT  Name,Gender,Id_role,Email,Address,DayOfBirth,Salary from Employee 
		where Name like '%' + @Name + '%'
END
GO

--@tenNv nvarchar(50)
--AS
--BEGIN
--			Set nocount on;
--			select Email,TenNV,DiaChi,VaiTro,TinhTrang from NhanVien 
--			where TenNV like '%' + @tenNv + '%'
--END


-- Beverage
-- get beverage
if OBJECT_ID ('sp_GetBeverage') is not null 
drop proc sp_GetBeverage
go 
create proc sp_GetBeverage
as
begin
            SELECT name,price,id_type,id_beverage,image
            FROM   beverages

end
go
-- beverage insert
if OBJECT_ID ('sp_BeverageInsert') is not null 
drop proc sp_BeverageInsert
go 
create PROCEDURE sp_BeverageInsert(
                                          @Name   NVARCHAR(55),
                                          @Price       int,
                                          @id_type        int,
                                          @image nvarchar(500))
AS
  BEGIN

        BEGIN
			insert into Beverages(Name,Price,Id_type,Image)
			values(@Name,@Price,@id_type,@image)
        END
	END

-- exec sp_BeverageInsert 'Tra Sua',50000,1,'sdfsdf'
-- beverage update
if OBJECT_ID ('sp_BeverageUpdate') is not null 
drop proc sp_BeverageUpdate
go 
create PROCEDURE sp_BeverageUpdate(
                                          @Name   NVARCHAR(55),
                                          @Price       int,
                                          @id_type        int,
                                          @image nvarchar(500),
										  @id_beverage int)
AS
  BEGIN

        BEGIN
			update Beverages
			set Name = @Name,
				Price = @Price,
				Id_type = @id_type,
				Image = @image
			where Id_beverage = @id_beverage

        END
	END

--	exec sp_BeverageUpdate 'trasua1',60000,1,'eeeee',1
--  beverage delete
if OBJECT_ID ('sp_BeverageDelete') is not null 
drop proc sp_BeverageDelete
go 
create PROCEDURE sp_BeverageDelete(@Name   NVARCHAR(55))
AS
  BEGIN

        BEGIN
			delete Beverages
			where Name like '%'+@Name+'%'
        END
	END

--	exec sp_BeverageDelete 3
-- beverage search
if OBJECT_ID ('sp_BeverageSearch') is not null 
drop proc sp_BeverageSearch
go 
create PROCEDURE sp_BeverageSearch(@Name   NVARCHAR(55))
AS
  BEGIN

        BEGIN
			set nocount on;
			select Name,Price,Id_type,Id_beverage,Image
			from	Beverages where Name like '%'+@Name+'%'

        END
	END

-- exec sp_BeverageSearch 'trasua1'

-- TypeOfBeverage
-- TypeOfBeverage insert
create PROCEDURE sp_TypeOfBeverageDelete(@ID int)
AS
  BEGIN
	
        BEGIN
			delete TypesOfBeverage
			where Id_type = @ID
        END
	END
go
create PROCEDURE sp_TypeOfBeverageGet 
										
AS
  BEGIN
		select id_type, name from typesofbeverage
	END
go
create PROCEDURE sp_TypeOfBeverageInsertSearch(   @Name   NVARCHAR(55),
										@StatementType nvarchar(20) = '')
AS
  BEGIN
	IF @StatementType = 'Insert'
        BEGIN
			insert into TypesOfBeverage(Name)
			values(@Name)
        END
	IF @StatementType = 'Search'
        BEGIN
			select Id_type, Name 
			from TypesOfBeverage where Name like '%'+@Name+'%'
        END
	END
go
create PROCEDURE sp_TypeOfBeverageUpdate (  @Name   NVARCHAR(55),
											@id_type int)
										
AS
  BEGIN
		update TypesOfBeverage
		set Name = @Name
		where Id_type = @id_type
	END
-- exec sp_TypeOfBeverageUpdate 'nuocngot1',2

-- ****** SimpleForMe ******

-- INGREDIENT
-- Get Ingredient
if OBJECT_ID ('sp_GetIngredient') is not null 
drop proc sp_GetIngredient
go 
create proc sp_GetIngredient
as
begin
    SELECT Id_ingredient, Name, Id_supplier, Id_type, Price
    FROM Ingredients
end
go

-- Insert Ingredient
if OBJECT_ID ('sp_IngredientInsert') is not null 
drop proc sp_IngredientInsert
go 
create PROCEDURE sp_IngredientInsert (@Name nvarchar(100),
									  @Id_supplier int,
									  @Id_type int,
								 	  @Price float)
										
AS
  BEGIN
		insert into Ingredients(Name,Id_supplier,Id_type,Price)
		values(@Name,@Id_supplier,@Id_type,@Price)
	END
-- exec sp_IngredientInsert 'Duong', 1, 1, 20000

--Update Ingredient
if OBJECT_ID ('sp_IngredientUpdate') is not null 
drop proc sp_IngredientUpdate
go 
create PROCEDURE sp_IngredientUpdate(@Name nvarchar(100),
									  @Id_supplier int,
									  @Id_type int,
								 	  @Price float,
									  @Id_ingredient int)
AS
  BEGIN
		update Ingredients
		set Name = @Name,
			Id_supplier = @Id_supplier,
			Id_type = @Id_type,
			Price = @Price
		where Id_ingredient = @Id_ingredient
	END
-- exec sp_IngredientUpdate 'Bot ngot', 1, 1, 50000, 1

-- Delete Ingredient
if OBJECT_ID ('sp_IngredientDelete') is not null 
drop proc sp_IngredientDelete
go 
create PROCEDURE sp_IngredientDelete(@Id_ingredient int)
AS
  BEGIN
		delete Ingredients
		where Id_ingredient = @Id_ingredient
	END
-- exec sp_IngredientDelete 1

-- Search Ingredient
if OBJECT_ID ('sp_IngredientSearch') is not null 
drop proc sp_IngredientSearch
go 
create PROCEDURE sp_IngredientSearch(@Name NVARCHAR(100))
AS
  BEGIN

        BEGIN
			set nocount on;
			select Name, Id_type, Price, Id_supplier
			from Ingredients where Name like '%' + @Name + '%'
        END
	END
-- exec sp_IngredientSearch 'Bot ngot'

-- TYPE OF INGREDIENT
-- Get Type of Ingredient
if OBJECT_ID ('sp_GetTypeOfIngredient') is not null 
drop proc sp_GetTypeOfIngredient
go 
create proc sp_GetTypeOfIngredient
as
begin
    SELECT Id_type, Name
    FROM TypesOfIngredient
end
go

-- Insert Type of Ingredient
if OBJECT_ID ('sp_TypeOfIngredientInsert') is not null 
drop proc sp_TypeOfIngredientInsert
go 
create PROCEDURE sp_TypeOfIngredientInsert (@Name nvarchar(50))
										
AS
  BEGIN
		insert into TypesOfIngredient(Name)
		values(@Name)
	END
-- exec sp_TypeOfIngredientInsert 'Bot'

-- Update Type of Ingredient
if OBJECT_ID ('sp_TypeOfIngredientUpdate') is not null 
drop proc sp_TypeOfIngredientUpdate
go 
create PROCEDURE sp_TypeOfIngredientUpdate(@Name nvarchar(50),
										   @Id_type int)
AS
  BEGIN
		update TypesOfIngredient
		set Name = @Name
		where Id_type = @Id_type
	END
-- exec sp_TypeOfIngredientUpdate 'Dau', 1

-- Delete Type of Ingredient
if OBJECT_ID ('sp_TypeOfIngredientDelete') is not null 
drop proc sp_TypeOfIngredientDelete
go 
create PROCEDURE sp_TypeOfIngredientDelete(@Id_type int)
AS
  BEGIN
		delete TypesOfIngredient
		where Id_type = @Id_type
	END
-- exec sp_TypeOfIngredientDelete 1

-- Search Type of Ingredient
if OBJECT_ID ('sp_TypeOfIngredientSearch') is not null 
drop proc sp_TypeOfIngredientSearch
go 
create PROCEDURE sp_TypeOfIngredientSearch(@Name NVARCHAR(50))
AS
  BEGIN

        BEGIN
			set nocount on;
			select Name, Id_type
			from TypesOfIngredient where Name like '%' + @Name + '%'
        END
	END
-- exec sp_TypeOfIngredientSearch 'Dau'

-- SUPPLIER
-- Get Supplier
if OBJECT_ID ('sp_GetSupplier') is not null 
drop proc sp_GetSupplier
go 
create proc sp_GetSupplier
as
begin
    SELECT Name, Id_supplier, Email, Address
    FROM Suppliers
end
go



-- Insert Supplier
if OBJECT_ID ('sp_SupplierInsert') is not null 
drop proc sp_SupplierInsert
go 
create PROCEDURE sp_SupplierInsert (@Name nvarchar(50),
									@Email nvarchar(50),
									@Address nvarchar(100))
									
AS
  BEGIN
		insert into Suppliers(Name, Email, Address)
		values(@Name, @Email, @Address)
	END
-- exec sp_SuppliersInsert 'Dong A', 'donga@gmail.com', 'Binh Thanh'

-- Update Supplier
if OBJECT_ID ('sp_SupplierUpdate') is not null 
drop proc sp_SupplierUpdate
go 
create PROCEDURE sp_SupplierUpdate(@Name nvarchar(50),
								   @Email nvarchar(50),
								   @Address nvarchar(100),
								   @Id_supplier int)
AS
  BEGIN
		update Suppliers
		set Name = @Name,
			Email = @Email,
			Address = @Address
		where Id_supplier = @Id_supplier
	END
-- exec sp_SupplierUpdate 'Dong Au', 'dongau@gmail.com', 'Binh Chanh', 1

-- Delete Supplier
if OBJECT_ID ('sp_SupplierDelete') is not null 
drop proc sp_SupplierDelete
go 
create PROCEDURE sp_SupplierDelete(@Id_supplier int)
AS
  BEGIN
		delete Suppliers
		where Id_supplier = @Id_supplier
	END
-- exec sp_SupplierDelete 1

-- Search Supplier
if OBJECT_ID ('sp_SupplierSearch') is not null 
drop proc sp_SupplierSearch
go 
create PROCEDURE sp_SupplierSearch(@Name NVARCHAR(50))
AS
  BEGIN

        BEGIN
			set nocount on;
			select Name, Id_supplier
			from Suppliers where Name like '%' + @Name + '%'
        END
	END
-- exec sp_SupplierSearch 'Dong A'


-- update voucher
-- add quantity
alter table vouchers
Add Quantity int not null
-- proc for tale shifts
-- proc add shifts
Go
create proc InsertDataShifts
@Id_shift int, @TimeBegin varchar(50), @TimeEnd varchar(50)
as
	begin
		if(not exists(select * from Shifts where Id_shift = @Id_shift))
		begin
			insert into Shifts(TimeBegin,TimeEnd, Id_shift) 
			values(@TimeBegin, @TimeEnd, @Id_shift)
		end
	end
Go
-- proc delete data table shifts
create proc DeleteDataShifts
@Id_shift int
as
	begin
		delete from Shifts where Id_shift = @Id_shift
	end
go
-- proc update data table shifts
create proc UpdateDataShifts
@Id_shift int, @TimeBegin varchar(50), @TimeEnd varchar(50)
as
	begin
		Update Shifts set TimeBegin = @TimeBegin, TimeEnd = @TimeEnd where Id_shift = @Id_shift
	end
go
-- proc search data table shifts
create proc SearchDataShifts
@Id_shift int
as
	begin
		set nocount on;
		select Id_shift, TimeBegin, TimeEnd from Shifts where Id_shift = @Id_shift
	end
go
-- proc get data table shifts
create proc GetDataShifts
as
	begin
		select * from Shifts
	end
go
-- get data schedule
CREATE proc getDataSchedule
as
	begin
		select b.Id_schedule, a.Name, b.Days, c.Id_shift from Employees a
		inner join Schedules b on a.Id_employee = b.Id_employee
		inner join Shifts c on b.Id_shift = c.Id_shift
	end
go
-- load Name
create proc loadName
as
	begin
		select Name, Id_employee from Employees
	end
go
-- load shift
create proc loadIdShift
as
	begin
		select Id_shift from Shifts
	end
go
-- proc Insert data Schedules
create proc InsertDataSchedule
@day int, @Id_employee int, @Id_shift int
as
	begin
		if(not exists(select * from Schedules where Id_employee = @Id_employee and Id_shift = @Id_shift and Days = @day))
			begin
					insert into Schedules(Id_employee, Id_shift, Days)
					values(@Id_employee, @Id_shift, @day)
			end
	end
go
-- proc delete data schedules
create proc DeleteDataSchedule
@Id_shift int, @Id_employee int, @day int
as
	begin
		delete from Schedules where Id_shift = @Id_shift and Id_employee = @Id_employee and Days = @day
	end
go
-- proc update data schedules
create proc UpdateDataSchedule
@Id_shift int, @Id_employee int, @day int, @Id_schedule int
as
	begin
		update Schedules set Id_employee = @Id_employee, Id_shift = @Id_shift, Days = @day where Id_schedule = @Id_schedule
	end
go
-- proc search schedules
create proc searchSchedules
@Id_employee int
as
	begin
		set nocount on;
		select b.Id_schedule, a.Name, b.Days, c.Id_shift from Employees a
		inner join Schedules b on a.Id_employee = b.Id_employee and a.Id_employee = @Id_employee
		inner join Shifts c on b.Id_shift = c.Id_shift
	end
<<<<<<< HEAD
go
-- proc for table TypeOfVoucher
-- proc get data
create proc getDataTypeVouchers
as
	begin 
		select ID_Type,CONCAT(CAST(Sale AS varchar(10)),'%') from TypesVoucher
	end
go
-- proc insert data TypeVoucher
create proc InsertDataTypeVoucher
@Sale float
as
	begin
			if(not exists(select * from TypesVoucher where Sale = @Sale))
			begin
				insert into TypesVoucher(Sale) values (@Sale)
			end
	end
go
-- proc delete data TypeVoucher
create proc DeleteDataTypeVoucher
@Id int
as
	begin 
		delete from TypesVoucher where ID_Type = @Id
	end
go
-- proc Update data TypeVoucher
create proc UpdateDatatypeVoucher
@Id int, @Sale float
as
	begin
		if(not exists(select * from TypesVoucher where Sale = @Sale))
			begin
				Update TypesVoucher set Sale = @Sale where ID_Type = @Id
			end
	end
go
-- proc search data TypeVoucher
create proc SearchDataTypeVoucher
@Sale float
as
	begin
		set nocount on;
		select * from TypesVoucher where Sale = @Sale
	end
go

-- proc for table Voucher
-- proc insert data table
go
create proc loadTypeVoucher
as
	begin
		select ID_Type, Sale from TypesVoucher
	end
go
-- proc insert data Voucher
create proc insertDataVoucher
@Id_voucher varchar(6), @DayBegin date, @DayEnd date,  @mail varchar(50), @Id_type int, @Status int
as
	begin
		declare @Id_employee int
		if(not exists (select Id_voucher from Vouchers where Id_voucher = @Id_voucher))
		begin
			select @Id_employee = Id_employee from Employees where Email = @mail
			insert into Vouchers(Id_voucher, DateBegin, DateEnd,Id_employee ,ID_Type, Status) values (@Id_voucher, @DayBegin, @DayEnd,@Id_employee ,@Id_type, @Status)
		end
	end
go
-- get Sale for Voucher
create proc getSaleForVoucher
as
	begin
		select ID_Type, Sale from TypesVoucher
	end
go
-- get data of voucher
create proc getDataVoucher
as
	begin
		select a.Id_voucher, a.DateBegin, a.DateEnd, b.Sale, a.Status from Vouchers a 
		inner join TypesVoucher b on a.ID_Type = b.ID_Type
	end
go
-- get count Sale in vouchers
create proc getCountSaleVoucher
@Id_type int
as
	begin
		select count(ID_Type) from Vouchers where ID_Type = @Id_type
	end
go
-- search Sale in Voucher
create proc SearchDataVoucher
@Id_type int
as
	begin
		set nocount on;
		select Id_voucher, DateBegin, DateEnd, ID_Type, Status from Vouchers where ID_Type = @Id_type
	end
go
-- delete voucher in number sale
create proc DeleteDataVoucher
@Id_type int, @DayBegin varchar(50), @DayEnd varchar(50)
as
	begin
		delete Vouchers where ID_Type = @Id_type and DateBegin = @DayBegin and DateEnd = @DayEnd
	end



=======

--- CUSTOMERS --
alter table Customers
Add Name nvarchar(50),
-- CUSTOMERS UPDATE
if OBJECT_ID ('sp_CustomerUpdate') is not null 
drop proc sp_CustomerUpdate
go 
create PROCEDURE sp_CustomerUpdate(
                                          @Email   NVARCHAR(55),
                                          @Gender       NVARCHAR(10),
                                          @idCustomers       int,
                                          @reward int,
										  @name nvarchar(50))
AS
  BEGIN
				update Customers
				set
				Email = @Email,
				Gender = @Gender,
				Reward = @reward,
				Name = @name
				where Id_customer = @idCustomers
			
END
go
-- exec sp_CustomerUpdate 'a@b','nu',1,231232

-- Search Supplier
if OBJECT_ID ('sp_CustomerSearch') is not null 
drop proc sp_CustomerSearch
go 
create PROCEDURE sp_CustomerSearch(@Email NVARCHAR(50))
AS
  BEGIN

        BEGIN
			set nocount on;
			select Name, Email, Gender,Id_customer,Reward
			from Customers where Email like '%' + @Email + '%'
        END
END
-- exec sp_CustomerSearch 'a@b'
<<<<<<< HEAD
-- get
if OBJECT_ID ('sp_GetCustomers') is not null 
drop proc sp_GetCustomers
go 
create proc sp_GetCustomers
as
begin
      select  Name, Email, Gender,Id_customer,Reward  from Customers
end
-- exec sp_getcustomers
-- proc table
-- get data table

CREATE proc getDataTable
as
	begin
		select * from tables
	end
go
-- insert data table
create proc InsertDataTable
@name nvarchar(50), @Status nvarchar(20)
as
	begin
		insert into tables (name, Status) values(@name, @Status)
	end
go
-- Delete data table
create proc DeleteTable
@id int
as
	begin
		delete tables where ID_Table = @id
	end
go
-- search data table
create proc SearchTable
@name nvarchar(50)
as
	begin
		select * from tables where name like + '%' + @name + '%'
	end
go
-- update data table
create proc UpdateTable
@name nvarchar(50), @Status nvarchar(20), @id int
as
	begin
		if(not exists(select * from tables where name = @name))
		begin
			update tables set name = @name, Status = @Status where ID_Table = @id
		end
	end
go
=======
-- create proc for table
-- proc get table
go
create proc getDataTable
as
	begin
		select * from tables
	end
go
--proc insert table
create proc InsertDataTable
@name nvarchar(50), @Status nvarchar(20)
as
	begin
		insert into tables (name, Status) values(@name, @Status)
	end
go
-- proc update table
create proc UpdateTable
@name nvarchar(50), @Status nvarchar(20), @id int
as
	begin
		if(not exists(select * from tables where name = @name))
		begin
			update tables set name = @name, Status = @Status where ID_Table = @id
		end
	end
go
-- proc delete table
create proc DeleteTable
@id int
as
	begin
		delete tables where ID_Table = @id
	end
go
-- search name table
create proc SearchTable
@name nvarchar(50)
as
	begin
		select * from tables where name like + '%' + @name + '%'
	end
go
-- proc get email for send voucher
create proc getEmailSendVoucher
@reward int
as
	begin
		select Email from Customers where Reward = @reward
	end
go
-- proc get voucher for send mail to customer
create proc getVoucherSendMail
@id_type int
as
	begin
		declare @status int = 0
		if(exists(select Id_voucher from Vouchers where Status = @status))
		begin
			select a.Id_voucher from Vouchers a,TypesVoucher b where a.Status = 0 and b.ID_Type = @id_type
		end
	end
go
-- proc update voucher after send mail to customer
create proc UpdateVoucherForSend
@Id_voucher nvarchar(6)
as
	begin
		Update Vouchers set Status = 1 where Id_voucher = @Id_voucher
	end
go
-- update reward after send voucher mail to customer
create proc UpdateCustomerAfterSendVoucher
@email nvarchar(50)
as
	begin
		Update Customers set Reward = 0 where Email = @email
	end
go
-- proc get sale for configuration
create proc getConfigurationSale
@id int
as
	begin
		if(@id = 0)
			begin
				select ID_Type, Sale from TypesVoucher 
			end
		else
			begin
				select ID_Type, Sale from TypesVoucher where ID_Type = @id
			end
	end
go