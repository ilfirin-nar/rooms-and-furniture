select 1
    from Room as r    
    where
        r.Name = @Name and
        r.CreateDate <= @Date and (
            r.RemoveDate is null or
            r.RemoveDate > @Date
        ) and
        r.Id not in (
            select f.RoomId from Furniture as f
                where f.Date <= @Date
                group by f.RoomId, f.Type
                having max(f.Date) <= @Date and f.Count != 0
        )
    limit 1