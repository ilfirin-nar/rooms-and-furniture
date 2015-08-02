create table if not exists Room (
    Id integer not null,
    CreateDate date not null,
    RemoveDate date null,
    Name varchar(20) not null,    
    constraint PF_Room primary key (Id)
);

create table if not exists Furniture (
    Id integer not null,
    CreateDate date not null,
    RemoveDate date null,
    Type varchar(20) not null,
    constraint PF_Furniture primary key (Id)
);

create table if not exists FurnitureLocation (
    Id integer not null,
    BeginDate date not null,
    EndDate date null,
    FurnitureId integer not null,
    RoomId integer not null,
    constraint PF_FurnitureLocation primary key (Id),
    constraint FK_FurnitureLocation_FurnitureId_Furniture_Id foreign key (FurnitureId) references Furniture(Id),
    constraint FK_FurnitureLocation_RoomId_Room_Id foreign key (RoomId) references Room(Id)
);