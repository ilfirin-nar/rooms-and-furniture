select exists(
    select 1 from Room
    where
        Name = @Name and
        @Date between CreateDate and coalesce(RemoveDate, '9999-12-31')
    limit 1
)