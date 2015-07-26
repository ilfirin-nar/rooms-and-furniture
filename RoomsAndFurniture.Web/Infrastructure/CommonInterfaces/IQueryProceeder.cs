namespace RoomsAndFurniture.Web.Infrastructure.CommonInterfaces
{
    public interface IQueryProceeder {}

    public interface IQueryProceeder<in TCriterion> : IQueryProceeder where TCriterion : ICriterion
    {
        void Proceed(TCriterion criterion);
    }

    public interface IQueryProceeder<in TCriterion, out TResult> : IQueryProceeder where TCriterion : ICriterion
    {
        TResult Proceed(TCriterion criterion);
    }
}