using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.Data.Domain;
using Chat.Data.Repository;

namespace Chat.ApplicationService.Chat
{
    public class ChatService : IChatService
    {
        private readonly IRepository<Message> _messageRepository;
        private readonly IRepository<User> _userRepository;
        public ChatService(IRepository<Message> messageRepository, IRepository<User> userRepository)
        {
            _messageRepository = messageRepository;
            _userRepository = userRepository;
        }

        public Task<User> CreateUser(User user)
        {
            var task = Task.Factory.StartNew(() =>
            {
                var createdUser = _userRepository.Insert(user);
                return createdUser;
            });

            return task;
        }

        public Task<List<Message>> GetUserMessages(int recevierUserId)
        {
            var task = Task.Factory.StartNew(() =>
            {
                var messageList = _messageRepository.Table.ToList();
                return messageList;
            });

            return task;
        }

        public Task<Message> PostMessage(Message message)
        {
            var task = Task.Factory.StartNew(() =>
            {
                var createdMessage = _messageRepository.Insert(message);
                return createdMessage;
            });

            return task;
        }

        public Task<User> ValidateUser(string username)
        {
            var task = Task.Factory.StartNew(() =>
            {
                var existingUser = _userRepository.Table.Where(x => x.Username == username).FirstOrDefault();
                return existingUser;
            });

            return task;
        }
    }
}
