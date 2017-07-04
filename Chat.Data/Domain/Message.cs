using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Data.Domain
{
    public class Message : BaseEntity
    {
        public string MessageText { get; set; }
        public int SenderUserId { get; set; }
        public bool IsSenderDeleted { get; set; }
        public bool IsReceiverDeleted { get; set; }

        public virtual User SenderUser { get; set; }
    }
}
