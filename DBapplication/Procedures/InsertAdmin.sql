use project

GO

Create Procedure InsertAdmin
@Username varchar(50),
@Password nchar(10),
@fname varchar(50),
@lname varchar(50),
@phone nchar(5)
As 
Begin

insert into Admin 
values(@Username,@Password,@fname,@lname,@phone)

END