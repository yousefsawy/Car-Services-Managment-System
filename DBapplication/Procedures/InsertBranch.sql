use project_standard_1
go

create procedure InsertBranch
@city varchar(50),
@area varchar(50)
As 
Begin

insert into branches
values(@city,@area,0,0,1)

END	