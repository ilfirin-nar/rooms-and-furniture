insert into Furniture (Date, Type, Count, RoomId) values (@Date, @Type, @Count, @RoomId);
select last_insert_rowid();