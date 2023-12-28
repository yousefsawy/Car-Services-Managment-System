use finalll
go

create procedure GetDepRequests
@hid int

As 
Begin

select * from Requests where status = 0 and branch_id in 
	(select branch_id from departments where id in 
		(select dep_id from hod where id = @hid)) and service_id in 
			(select service_id from specialities where dep_id in 
				(select dep_id from hod where id = @hid ))

END	