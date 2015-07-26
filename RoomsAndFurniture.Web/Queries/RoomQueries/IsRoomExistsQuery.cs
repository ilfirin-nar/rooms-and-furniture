using System.Data;
using System.Linq;
using Dapper;
using RoomsAndFurniture.Web.Criterions.RoomCriterions;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Queries.RoomQueries
{
    public class IsRoomExistsQuery : IQuery<IsExistsCriterion, bool>
    {
        public bool Proceed(IDbConnection connection, IsExistsCriterion criterion)
        {
            const string sql = "select exists(select 1 from Room where Name = @Name limit 1)";
            return connection.Query<bool>(sql, criterion).First();
        }
    }
}