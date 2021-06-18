using System;
using System.Collections.Generic;
using System.Text;

namespace Sistran.BusinessObjects
{
    public partial class Response<T>
    {
        public string ErrorCode { get; set; }
        public string HumanMsg { get; set; }
        public string SystemMsg { get; set; }
        public List<T> Content { get; set; }
    }

}
