select 1
    from Room
    where
        Name = @Name and
        CreateDate <= @Date and (
            RemoveDate is null or
            RemoveDate > @Date
        )
    limit 1