using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common.Domain.Model
{
    public class ResultException : Exception
    {
        public ResultException() {}

        public ResultException(Result result)
        {
            this.Result = result;
        }

        public Result Result { get; set; }
    }
}
