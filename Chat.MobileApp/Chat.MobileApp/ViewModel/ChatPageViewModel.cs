using Chat.DataModel.Pcl.DataModels;
using Chat.MobileApp.Common.Enums;
using Chat.MobileApp.Service.ChatService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.MobileApp.ViewModel
{
    public class ChatPageViewModel
    {
        private readonly IChatService _chatService;

        public ChatPageViewModel(IChatService chatService)
        {
            _chatService = chatService;
        }

        public List<MessageDataModel> MessageList { get; set; }

        public async Task<List<MessageDataModel>> GetUserMessage(PriorityType priorityType, int receiverUserId)
        {
            var result = await _chatService.GetUserMessages(priorityType, receiverUserId);
            return result;
        }
    }
}
