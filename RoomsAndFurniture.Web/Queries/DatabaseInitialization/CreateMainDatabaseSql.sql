create table if not exists Room (
    Id integer not null,
    CreateDate datetime not null,
    RemoveDate datetime null,
    Name varchar(20) not null,
    IsDeleted bit not null default 0,
    constraint PF_Room primary key (Id)
);

create table if not exists Furniture (
    Id integer not null,
    Date datetime not null,
    Type varchar(20) not null,
    Count integer not null,
    RoomId integer not null,
    constraint PF_Furniture primary key (Id),
    constraint FK_Furniture_RoomId_Room_Id foreign key (RoomId) references Room(Id)
);

create table if not exists RoomEvent (
    Id integer not null,
    Date datetime not null,
    RoomEventType tinyint not null,
    RoomId integer not null,
    FurnitureId integer not null,
    constraint PF_RoomEvent primary key (Id),
    constraint FK_RoomEvent_RoomId_Room_Id foreign key (RoomId) references Room(Id),
    constraint FK_RoomEvent_FurnitureId_Furniture_Id foreign key (FurnitureId) references Furniture(Id)
);