using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Infrastructure.Database
{
    internal class QueryProceeder<TCriterion> : IQueryProceeder<TCriterion>
        where TCriterion : ICriterion
    {
        private readonly ISqliteConnectionFactory connectionFactory;
        private readonly IQuery<TCriterion> query;

        public QueryProceeder(
            ISqliteConnectionFactory connectionFactory,            
            IQuery<TCriterion> query)
        {
            this.connectionFactory = connectionFactory;
            this.query = query;
        }

        public void Proceed(TCriterion criterion)
        {
            using (var connection = connectionFactory.Create())
            {
                connection.Open();
                query.Proceed(connection, criterion);
                connection.Close();
            }
        }
    }

    public class QueryProceeder<TCriterion, TResult> : IQueryProceeder<TCriterion, TResult>
        where TCriterion : ICriterion
    {
        private readonly ISqliteConnectionFactory connectionFactory;
        private readonly IQuery<TCriterion, TResult> query;

        public QueryProceeder(
            ISqliteConnectionFactory connectionFactory,
            IQuery<TCriterion, TResult> query)
        {
            this.connectionFactory = connectionFactory;
            this.query = query;
        }

        public TResult Proceed(TCriterion criterion)
        {
            using (var connection = connectionFactory.Create())
            {
                connection.Open();
                var result = query.Proceed(connection, criterion);
                connection.Close();
                return result;
            }
        }
    }
}