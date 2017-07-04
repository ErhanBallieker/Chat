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
    public class NewMessagePageViewModel
    {
        private readonly IChatService _chatService;

        public NewMessagePageViewModel(IChatService chatService)
        {
            _chatService = chatService;
        }

        public async Task<MessageDataModel> PostMessage(PriorityType priorityType, MessageDataModel message)
        {
            var result = await _chatService.PostMessage(priorityType, message);
            return result;
        }
    }
}
