namespace RoomsAndFurniture.Web.Infrastructure.ClientModels
{
    public abstract class ResultBase
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }
    }

    public abstract class ResultBase<T> : ResultBase
    {
        public T Data { get; set; }
    }
}