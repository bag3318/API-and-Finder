create procedure insert_message()

begin

declare @rate smallint(2);
declare @usrmessage varchar(888);

insert into message (rating, usrmessage) values (@rating, @usrmessage);

end;
