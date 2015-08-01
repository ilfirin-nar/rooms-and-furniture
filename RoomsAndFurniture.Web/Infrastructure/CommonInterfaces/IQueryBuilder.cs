namespace RoomsAndFurniture.Web.Infrastructure.CommonInterfaces
{
    public interface IQueryBuilder
    {
        IQueryProceeder<TCriterion> Command<TCriterion>() where TCriterion : ICriterion;

        IQueryProceeder<TCriterion, TResult> Query<TCriterion, TResult>() where TCriterion : ICriterion;
    }
}