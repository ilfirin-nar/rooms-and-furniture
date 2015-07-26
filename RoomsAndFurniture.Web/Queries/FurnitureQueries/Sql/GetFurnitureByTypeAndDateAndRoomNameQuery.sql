select f.*
    from Furniture as f
    inner join Room as r on r.Id = f.RoomId
    where
        f.Type = @Type and
        f.Date <= @Date and
        r.Name = @RoomName
    order by f.Date desc
    limit 1