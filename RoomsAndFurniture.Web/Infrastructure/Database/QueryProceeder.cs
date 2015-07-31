using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Infrastructure.Database
{
    internal class QueryProceeder<TCriterion> : IQueryProceeder<TCriterion>
        where TCriterion : ICriterion
    {
        private readonly IQueryExecuter queryExecuter;
        private readonly IQuery<TCriterion> query;

        public QueryProceeder(IQueryExecuter queryExecuter, IQuery<TCriterion> query)
        {
            this.queryExecuter = queryExecuter;
            this.query = query;
        }

        public void Proceed(TCriterion criterion)
        {
            queryExecuter.Execute(connection => query.Proceed(connection, criterion));
        }
    }

    public class QueryProceeder<TCriterion, TResult> : IQueryProceeder<TCriterion, TResult>
        where TCriterion : ICriterion
    {
        private readonly IQueryExecuter queryExecuter;
        private readonly IQuery<TCriterion, TResult> query;

        public QueryProceeder(IQueryExecuter queryExecuter, IQuery<TCriterion, TResult> query)
        {
            this.queryExecuter = queryExecuter;
            this.query = query;
        }

        public TResult Proceed(TCriterion criterion)
        {
            return queryExecuter.Execute(connection => query.Proceed(connection, criterion));
        }
    }
}