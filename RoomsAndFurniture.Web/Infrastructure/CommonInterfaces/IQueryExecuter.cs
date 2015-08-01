using System;
using System.Data;

namespace RoomsAndFurniture.Web.Infrastructure.CommonInterfaces
{
    public interface IQueryExecuter
    {
        void Execute(Action<IDbConnection> action);

        TResult Execute<TResult>(Func<IDbConnection, TResult> action);
    }
}