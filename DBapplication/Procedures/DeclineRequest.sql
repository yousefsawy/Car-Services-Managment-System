use project
go

create procedure DeclineRequest
@id int
As 
Begin

update  Requests
set status = -1 where id = @id

END	