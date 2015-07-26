using LightInject;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Infrastructure.Database
{
    internal class QueryBuilder : IQueryBuilder
    {
        private readonly IServiceFactory factory;

        public QueryBuilder(IServiceFactory factory)
        {
            this.factory = factory;
        }

        public IQueryProceeder<TCriterion> Command<TCriterion>() where TCriterion : ICriterion
        {
            return factory.GetInstance<IQueryProceeder<TCriterion>>();
        }

        public IQueryProceeder<TCriterion, TResult> Query<TCriterion, TResult>() where TCriterion : ICriterion
        {
            return factory.GetInstance<IQueryProceeder<TCriterion, TResult>>();
        }
    }
}