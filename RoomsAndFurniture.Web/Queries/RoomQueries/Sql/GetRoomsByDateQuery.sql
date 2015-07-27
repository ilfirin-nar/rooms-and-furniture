select * from Room
    where
        @Date between CreateDate and coalesce(RemoveDate, '9999-12-31')