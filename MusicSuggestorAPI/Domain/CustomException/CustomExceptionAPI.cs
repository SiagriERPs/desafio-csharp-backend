using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicSuggestorAPI.Domain.CustomException
{
    public class CustomExceptionAPI : Exception
    {
        public CustomExceptionAPI(string message, int statusCode)
            :base(message)
        {
            this.StatusCode = statusCode;
        }

        public int StatusCode { get; set; }
    }
}
