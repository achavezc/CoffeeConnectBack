using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common.Domain.Model
{
    public class BaseRequest
    {
        public BaseRequest()
        {
            this.Meta = new MetaRequest();
        }

        public MetaRequest Meta { get; set; }
    }
}
