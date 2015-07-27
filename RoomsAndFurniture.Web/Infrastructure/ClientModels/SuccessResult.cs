namespace RoomsAndFurniture.Web.Infrastructure.ClientModels
{
    public class SuccessResult : ResultBase
    {
        public SuccessResult()
        {
            IsSuccess = true;
        }

        public SuccessResult(string message)
        {
            Message = message;
            IsSuccess = true;
        }

    }

    public class SuccessResult<T> : ResultBase<T>
    {
        public SuccessResult()
        {
            IsSuccess = true;
        }

        public SuccessResult(string message)
        {
            Message = message;
            IsSuccess = true;
        }

        public SuccessResult(string message, T data)
        {
            Message = message;
            Data = data;
            IsSuccess = true;
        }

        public SuccessResult(T data)
        {
            Data = data;
            IsSuccess = true;
        }
    }
}