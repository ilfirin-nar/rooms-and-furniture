select Id, Type, max(Date), RoomId, Count
    from Furniture
    where
        Date <= @Date and
        RoomId = @RoomId and
        Type in (select from @FurnitureTypes)
    group by RoomId, Type, Count, Id