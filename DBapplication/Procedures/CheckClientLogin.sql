use project
go

create procedure CheckClientLogin
@un varchar(50),
@pass varchar(50)

As 
Begin

select * from client 
where username = @un  and  password = @pass and active = 1

END	