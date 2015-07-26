namespace RoomsAndFurniture.Web.Infrastructure.ClientModels
{
    public class FailResult : ResultBase
    {
        public FailResult()
        {
            IsSuccess = false;
        }

        public FailResult(string message)
        {
            Message = message;
            IsSuccess = false;
        }
    }

    public class FailResult<T> : ResultBase<T> where T : new()
    {
        public FailResult()
        {
            IsSuccess = false;
        }

        public FailResult(string message)
        {
            Message = message;
            IsSuccess = false;
        }
        public FailResult(string message, T data)
        {
            Message = message;
            Data = data;
            IsSuccess = false;
        }
    }
}