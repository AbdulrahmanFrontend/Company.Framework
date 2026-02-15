using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class clsResult
    {
        public bool IsSuccess { get; set; } = false;
        public string Message { get; set; } = string.Empty;
        public static clsResult Success(string message = "")
        {
            return new clsResult { IsSuccess = true, Message = message };
        }
        public static clsResult Failure(string message = "")
        {
            return new clsResult { IsSuccess = false, Message = message };
        }
    }
}
