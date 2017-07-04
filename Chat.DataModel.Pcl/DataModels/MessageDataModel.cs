using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.DataModel.Pcl.DataModels
{
    public class MessageDataModel : BaseEntityDataModel
    {
        public new int Id { get; set; }
        public string MessageText { get; set; }
        public int SenderUserId { get; set; }
        public bool IsSenderDeleted { get; set; }
        public bool IsReceiverDeleted { get; set; }
        public  UserDataModel SenderUser { get; set; }
    }
}
