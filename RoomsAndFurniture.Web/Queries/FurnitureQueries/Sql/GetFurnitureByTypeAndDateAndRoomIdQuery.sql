select f.*
    from Furniture as f
    inner join FurnitureLocation as fl on f.Id = fl.FurnitureId
    where
        f.CreateDate <= @Date and (
            f.RemoveDate is null or
            f.RemoveDate > @Date
        ) and
        fl.RoomId = @RoomId and
        f.Type = @Type and 
        fl.BeginDate <= @Date and (
            fl.EndDate is null or
            fl.EndDate > @Date
        )      
    order by fl.Date desc
    limit 1