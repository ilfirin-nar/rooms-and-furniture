begin transaction;
    create temp table _difference(Value integer);

    insert into _difference(Value) select @Count - Count from Furniture where Id = @Id;

    update Furniture set Count = @Count where Id = @Id;

    update Furniture
        set Count = Count + (select Value from _difference)
        where 
            Type = @Type and
            Date > @Date and
            RoomId = @RoomId;

    drop table _difference;
end transaction;