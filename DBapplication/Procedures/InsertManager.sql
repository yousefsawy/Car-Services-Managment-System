use finalll
go

create procedure InsertManager
@username varchar(50),
@password nchar(10),
@fname varchar(50),
@lname varchar(50),
@phone nchar(5),
@branch_id int,
@active int
As 
Begin

insert into Manager
values(@username,@password,@fname,@lname,@phone, @branch_id,@active)

END	