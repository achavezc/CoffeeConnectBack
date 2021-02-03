using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common.Domain.Model
{
    public class Result
    {
        public Result()
        {
            this.Meta = new MetaResponse();
        }

        public bool Success { get; set; } = false;
        public string ErrCode { get; set; } = "";
        public string Message { get; set; } = "";
        public MetaResponse Meta { get; set; }
        public dynamic Data { get; set; }
    }
}
