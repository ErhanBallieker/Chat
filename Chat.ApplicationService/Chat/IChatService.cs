using Chat.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.ApplicationService.Chat
{
    public interface IChatService
    {
        Task<List<Message>> GetUserMessages(int recevierUserId);
        Task<Message> PostMessage(Message message);
        Task<User> CreateUser(User user);
        Task<User> ValidateUser(string username);
    }
}
