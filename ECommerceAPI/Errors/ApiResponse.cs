using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace ECommerceAPI.Errors
{
    public class ApiResponse
    {
        public int StatusCode;
        public string ErrorMessage;
        public ApiResponse(int StatusCode,string? ErrorMessage = null) 
        { 
            this.StatusCode = StatusCode;
            this.ErrorMessage = ErrorMessage ?? GetDefultMessageForStatusCode(StatusCode);
        }

        private string GetDefultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "You have made Bad Request",
                404 => "Not Found",
                401 => "You are Not Authorized",
                _ => "Error",
            };

        }
    }
}
