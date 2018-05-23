using System.Threading.Tasks;

namespace unAventonApi.Data.Entities
{
    public class ApiResponse
    {
        public bool Ok { get; set; }
        public string Message { get; set; }
    }

    public class ApiResponse<T> : ApiResponse
    {
        public T Data { get; set; }

        public ApiResponse()
        {
            Data = default(T);
        }
    }

    public static class BuildApiResponse
    {

// ------------------------------ Response Not OK ------------------------------
        /// <summary>
        /// Genera un Bad Response sin datos
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ApiResponse BuildNotOk(string message = null)
        {
            return new ApiResponse()
            {
                Message = message,
                Ok = false
            };
        }

        /// <summary>
        /// Genera un Bad Response con datos
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ApiResponse<T> BuildNotOk<T>(T data, string message = null)
        {
            return new ApiResponse<T>()
            {
                Message = message,
                Ok = false,
                Data = data
            };
        }

// ------------------------------ Response OK ------------------------------

        /// <summary>
        /// Genera un Response Ok sin datos
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ApiResponse BuildOk(string message = null)
        {
            return new ApiResponse()
            {
                Message = message,
                Ok = true
            };
        }

        /// <summary>
        /// Genera un Response Ok con datos
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ApiResponse<T> BuildOk<T>(T data, string message = null)
        {
            return new ApiResponse<T>()
            {
                Data = data,
                Message = message,
                Ok = true
            };
        }
    }
}