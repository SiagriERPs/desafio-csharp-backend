using Microsoft.AspNetCore.Http;

namespace Microservice.Responses
{
    public class Response<T>
    {
        public Response()
        {

        }

        public Response(T data)
        {
            Error = null;
            StatusCode = StatusCodes.Status200OK;
            Data = data;
        }

        public int StatusCode { get; set; }
        public string Error { get; set; }
        public T Data { get; set; }
    }
}
