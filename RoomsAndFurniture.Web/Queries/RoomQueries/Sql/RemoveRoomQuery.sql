update Room
    set
        RemoveDate = @RemoveDate,
        IsDeleted = 1
    where
        Name = @Name and
        CreateDate <= @RemoveDate