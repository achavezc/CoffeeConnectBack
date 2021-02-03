using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common.Domain.Model
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            this.Result = new Result();
            
        }

        public Result Result { get; set; }
        
    }
}
