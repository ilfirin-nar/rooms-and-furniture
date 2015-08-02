update Room
    set
        RemoveDate = @RemoveDate
    where
        Name = @Name and
        CreateDate <= @RemoveDate