using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool IsSuccess, string message): this(IsSuccess)
        { 
            this.Message = message;
        }
        public Result(bool IsSuccess)
        {
            this.IsSuccess = IsSuccess;
        }
        public bool IsSuccess { get; }

        public string Message { get; }
    }
}
