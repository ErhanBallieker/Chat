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
    public class LoginPageViewModel
    {
        private readonly IChatService _chatService;

        public LoginPageViewModel(IChatService chatService)
        {
            _chatService = chatService;
        }

        public async Task<UserDataModel> CreateUser(PriorityType priorityType, UserDataModel user)
        {
            var result = await _chatService.CreateUser(priorityType, user);
            return result;
        }

        public async Task<UserDataModel> ValidateUser(PriorityType priorityType, string username)
        {
            var result = await _chatService.ValidateUser(priorityType, username);
            return result;
        }
    }
}
