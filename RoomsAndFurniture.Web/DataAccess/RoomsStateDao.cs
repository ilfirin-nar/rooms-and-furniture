using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure;

namespace RoomsAndFurniture.Web.DataAccess
{
    internal class RoomsStateDao : IRoomsStateDao
    {
        public IList<RoomState> Get(DateTime date)
        {
            using (var connection = new SqlConnection(ConnectionStringKeeper.RoomsAndFurniture))
            {
                const string sql = @"
                    select *
                    from dbo.Room as r
                    inner join dbo.Furniture as f on f.RoomId = r.Id
                    where r.CreateTime >= @date and f.Date = @date";
                return connection.Query<Room, IList<Furniture>, RoomState>(sql, (room, furnitureList) => new RoomState
                {
                    RoomId = room.Id,
                    Date = date,
                    FurnitureState = furnitureList
                }).ToList();
            }
        }
    }
}