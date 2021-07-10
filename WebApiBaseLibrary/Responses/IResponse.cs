using WebApiBaseLibrary.Enums;

namespace WebApiBaseLibrary.Responses
{
    public interface IResponse<out TResult>
    {
        TResult Result { get; }
        ResponseStatus Status { get; }
    }
}