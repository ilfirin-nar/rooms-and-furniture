select * from Room
    where
        Name = @Name and
        CreateDate <= @Date and (
            RemoveDate is null or
            RemoveDate > @Date
        )        