select Id, max(Date) as Date, Type, RoomId, Count
    from Furniture
    where
        Date <= @Date and
        RoomId = @RoomId
    group by RoomId, Type