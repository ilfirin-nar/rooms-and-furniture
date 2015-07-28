select * from Room
    where
        CreateDate <= @Date and (
            RemoveDate is null or
            RemoveDate > @Date
        )
    order by CreateDate desc, RemoveDate desc, Id desc