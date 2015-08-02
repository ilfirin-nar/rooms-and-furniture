select fl.*
    from FurnitureLocation as fl
    inner join Furniture as f on f.Id = fl.FurnitureId
    where 
        f.Type = @Type and
        f.CreateDate <= @Date and (
            f.RemoveDate is null or
            f.RemoveDate > @Date
        ) and
        fl.BeginDate <= @Date and (
            fl.EndDate is null or
            fl.EndDate > @Date
        )  and
        fl.RoomId = @RoomId