update Furniture
    set
        Type = @Type,
        Date = @Date,
        Count = @Count,
        RoomId = @RoomId
    where Id = @Id