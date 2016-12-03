delimiter $$

create procedure insert_message()

begin

declare ID smallint;

declare rate smallint;
declare usrmsg varchar(888);

insert into message (rating, usrmessage) values (ID, rate, usrmsg);
set ID = select LAST_INSERT_ID();
return ID;
end;
