﻿namespace RoomsAndFurniture.Web.Infrastructure.CommonInterfaces
{
    public interface IEntity {}

    public interface IEntity<T> : IEntity
    {
        T Id { get; set; }
    }
}