using WebApiBaseLibrary.Enums;

namespace WebApiBaseLibrary.Responses
{
    public class Response<T> : IResponse<T>
    {
        public T Result { get; set; }
        public ResponseStatus Status { get; set; }
    }
}