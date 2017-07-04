using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Data.Domain
{
    public class User : BaseEntity
    {
        public User()
        {
            Messages = new List<Message>();
        }

        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}
