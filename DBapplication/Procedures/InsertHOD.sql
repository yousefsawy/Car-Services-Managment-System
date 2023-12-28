use finalll

GO

Create Procedure InsertHOD
@username varchar(50),
@password nchar(10),
@fname varchar(50),
@lname varchar(50),
@phone nchar(50),
@dep_id int,
@active int
AS
Begin 

insert into HOD values(@username,@password,@fname,@lname,@phone,@dep_id,@active)

END