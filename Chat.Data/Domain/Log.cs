using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Data.Domain
{
    public class Log : BaseEntity
    {
        public Guid Key { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
    }
}
