using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marta_M.Utils
{
    public class ApiResponse
    {
        public static ApiResponse<T> Error<T>(T obj, string message) => new ApiResponse<T>(obj, true, message);
        public static ApiResponse<T> Ok<T>(T obj) => new ApiResponse<T>(obj);
    }

    public class ApiResponse<T>
    {
        public T Object { get; }
        public bool Error { get; }
        public string Message { get; }

        public ApiResponse(T obj)
        {
            Object = obj;
            Error = false;
        }

        public ApiResponse(T obj, bool error, string message)
        {
            Object = obj;
            Error = error;
            Message = message;
        }
    }
}
