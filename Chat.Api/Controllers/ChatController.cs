using Chat.Api.Helpers.AutoMapper;
using Chat.Api.Helpers.Filters;
using Chat.ApplicationService.Chat;
using Chat.Data.Domain;
using Chat.DataModel.Pcl.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Chat.Api.Controllers
{
    [LogFilter]
    public class ChatController : ApiController
    {
        private readonly IChatService _chatService;
        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet]
        public async Task<List<MessageDataModel>> GetUserMessages(int receiverUserId)
        {
            var result = await _chatService.GetUserMessages(receiverUserId);
            return result?.ToModel<Message, MessageDataModel>();
        }

        [HttpGet]
        public async Task<UserDataModel> ValidateUser(string username)
        {
            var result = await _chatService.ValidateUser(username);
            return result?.ToModel<User, UserDataModel>();
        }

        [HttpPost]
        public async Task<User> CreateUser(UserDataModel user)
        {
            var userDomain = user.ToModel<UserDataModel, User>();
            var result = await _chatService.CreateUser(userDomain);
            return result;
        }

        [HttpPost]
        public async Task<Message> PostMessage(MessageDataModel message)
        {
            var messageDomain = message.ToModel<MessageDataModel, Message>();
            var result = await _chatService.PostMessage(messageDomain);
            return result;
        }
    }
}
