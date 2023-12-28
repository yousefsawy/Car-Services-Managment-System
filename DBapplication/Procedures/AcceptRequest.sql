use finalll
go

create procedure AcceptRequest
@id int
As 
Begin

update  Requests
set status = 1 where id = @id

END	