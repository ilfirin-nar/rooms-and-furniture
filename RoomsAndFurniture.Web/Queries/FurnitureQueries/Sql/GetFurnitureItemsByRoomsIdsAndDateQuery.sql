select Id, max(Date) as Date, Type, RoomId, Count
    from Furniture
    where
        Date <= @Date and
        RoomId in @RoomsIds
    group by RoomId, Type