begin transaction;
    create temp table _difference(Value integer);
    create temp table _createdFurnitureId(Value integer);

    insert into _difference(Value)
        select coalesce(@Count - Count, @Count)
            from Furniture
            where
                Date <= @Date and
                Type = @Type and
                RoomId = @RoomId
            group by RoomId, Type
            having max(Date) <= @Date
            limit 1;

    insert into Furniture (Date, Type, Count, RoomId) values (@Date, @Type, @Count, @RoomId);

    insert into _createdFurnitureId(Value) select last_insert_rowid();

    update Furniture
        set Count = Count + (select Value from _difference)
        where 
            Type = @Type and
            Date > @Date and
            RoomId = @RoomId;

    drop table _createdFurnitureId;
    drop table _difference;
end transaction;