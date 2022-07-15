using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDTO
{
    public class MessageVO
    {
        public int ErrCode { get; set; }
        public string ErrMsg { get; set; }

    }
    public class MessageVO<T>
    {
        public int ErrCode { get; set; }

        public string ErrMsg { get; set; }

        public T Data { get; set; }
    }
}
