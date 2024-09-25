
namespace CoffeeShopAPI.CoreModel
{
    public class APIResponse<T>
    {
        public int StatusCode {  get; set; }
        public string Message { get; set; } = string.Empty;
        public bool Success { get; set; } = true;
        public T Data { get; set; }

        public void ToFailedResponse(string message, int statuscode)
        {
            Success = false;
            Message = message;
            StatusCode = statuscode;
        }
        public void ToSuccessResponse(String message, int statuscode)
        {
            Success = true;
            Message = Message;
            StatusCode = StatusCode;
        }
        public void ToSuccessResponse(T data, string message, int statuscode)
        {
            Success = true;
            Message = message;
            Data = data;
            StatusCode = statuscode;
        }
    }
    public class ApiResponse
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;

        public void ToFailedResponse(string message)
        {
            Success = false;
            Message = message;
        }

        public void ToSuccessResponse(string message)
        {
            Success = true;
            Message = message;
        }
    }
}
