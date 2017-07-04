using Chat.DataModel.Pcl.DataModels;
using Chat.MobileApp.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.MobileApp.Service.ChatService
{
    public interface IChatService
    {
        Task<List<MessageDataModel>> GetUserMessages(PriorityType priorityType, int receiverUserId);

        Task<UserDataModel> ValidateUser(PriorityType priorityType, string username);

        Task<UserDataModel> CreateUser(PriorityType priorityType, UserDataModel user);

        Task<MessageDataModel> PostMessage(PriorityType priorityType, MessageDataModel message);
    }
}
