use project
go

create procedure InsertEmployee
@fname varchar(50),
@lname varchar(50),
@phone nchar(5),
@dep_id int
As 
Begin

insert into Employee
values(@fname,@lname,@phone,0,1,@dep_id,1)

END	