create table if not exists Room (
    Id integer not null,
    CreateDate date not null,
    RemoveDate date null,
    Name varchar(20) not null,
    IsDeleted bit not null default 0,
    constraint PF_Room primary key (Id)
);

create table if not exists Furniture (
    Id integer not null,
    Date date not null,
    Type varchar(20) not null,
    Count integer not null,
    RoomId integer not null,
    constraint PF_Furniture primary key (Id),
    constraint FK_Furniture_RoomId_Room_Id foreign key (RoomId) references Room(Id)
);

create table if not exists RoomEvent (
    Id integer not null,
    Date datetime not null,
    Type int not null,
    Description varchar(100) not null,
    constraint PF_RoomEvent primary key (Id)
);