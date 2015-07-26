using System.Data;

namespace RoomsAndFurniture.Web.Infrastructure.CommonInterfaces
{
    public interface IQuery {}

    public interface IQuery<in TCriterion> : IQuery
        where TCriterion : ICriterion
    {
        void Proceed(IDbConnection connection, TCriterion criterion);
    }

    public interface IQuery<in TCriterion, out TResult> : IQuery
        where TCriterion : ICriterion
    {
        TResult Proceed(IDbConnection connection, TCriterion criterion);
    }
}