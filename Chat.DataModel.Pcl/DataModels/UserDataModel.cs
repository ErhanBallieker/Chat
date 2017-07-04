using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.DataModel.Pcl.DataModels
{
    public class UserDataModel : BaseEntityDataModel
    {
        public new int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public virtual ICollection<MessageDataModel> Messages { get; set; }
    }
}
