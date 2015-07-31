using System;
using System.Data;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Infrastructure.Database
{
    internal class QueryExecuter : IQueryExecuter
    {
        private readonly Lazy<ISession> session;

        public QueryExecuter(Lazy<ISession> session)
        {
            this.session = session;
        }

        public void Execute(Action<IDbConnection> action)
        {
            action(session.Value.Connection);
        }

        public TResult Execute<TResult>(Func<IDbConnection, TResult> action)
        {
            return action(session.Value.Connection);
        }
    }
}