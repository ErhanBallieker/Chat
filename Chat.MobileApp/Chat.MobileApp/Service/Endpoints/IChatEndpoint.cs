using Chat.DataModel.Pcl.DataModels;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.MobileApp.Service.Endpoints
{
    [Headers("Content-Type : application/json")]
    public interface IChatEndpoint
    {
        [Get("/chat/GetUserMessages")]
        Task<List<MessageDataModel>> GetUserMessages(int receiverUserId);

        [Get("/chat/ValidateUser")]
        Task<UserDataModel> ValidateUser(string username);

        [Post("/chat/CreateUser")]
        Task<UserDataModel> CreateUser([Body(BodySerializationMethod.Json)] UserDataModel user);

        [Post("/chat/PostMessage")]
        Task<MessageDataModel> PostMessage([Body(BodySerializationMethod.Json)] MessageDataModel message);
    }
}
