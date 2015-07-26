namespace RoomsAndFurniture.Web.Infrastructure.ClientModels
{
    public class SuccessResult<T> : ClientData<T> where T : new()
    {
        public SuccessResult()
        {
            IsSuccess = true;
        }

        public SuccessResult(string message)
        {
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