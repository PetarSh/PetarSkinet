using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetarSkinet.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int status, string message=null)
        {
            StatusCode = status;
            Message = message ?? GetDefaultMessage(status);
        }

        

        public int StatusCode { get; set; }
        public string Message { get; set; }
        private string GetDefaultMessage(int status)
        {
            return status switch
            {
                400 => "los request",
                401 => "ne si avtoriziran",
                404 => "resorsot ne e najden",
                500 => "sokapa se serverot",
                _ => null
            };
        }
    }
}
