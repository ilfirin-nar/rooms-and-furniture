select f.CreateDate as Date, f.Type, count(f.Id) as Count, fl.RoomId
    from Furniture as f
    inner join FurnitureLocation as fl on f.Id = fl.FurnitureId
    where
        f.CreateDate <= @Date and (
            f.RemoveDate is null or
            f.RemoveDate > @Date
        ) and
        fl.RoomId in @RoomsIds
    group by fl.RoomId, f.Type;