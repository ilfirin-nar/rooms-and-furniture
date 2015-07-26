namespace RoomsAndFurniture.Web.Infrastructure.ClientModels
{
    public abstract class ClientData<T> where T : new()
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }
    }
}