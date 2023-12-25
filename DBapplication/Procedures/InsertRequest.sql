use project
go

create procedure InsertRequest
@qty int,
@total int, 
@status int , 
@cid int, 
@sl_id int , 
@sid int , 
@bid int
As 
Begin

insert into Requests
values(@qty,@total,@status,@cid,@sl_id,@sid,@bid)

END	