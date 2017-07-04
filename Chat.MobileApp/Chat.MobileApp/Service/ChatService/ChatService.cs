using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.DataModel.Pcl.DataModels;
using Chat.MobileApp.Service.Endpoints;
using Plugin.Connectivity;
using Chat.MobileApp.Common.Enums;
using Polly;
using Refit;

namespace Chat.MobileApp.Service.ChatService
{
    public class ChatService : IChatService
    {
        private readonly IApiRequest<IChatEndpoint> _chatRequest;
        public ChatService(IApiRequest<IChatEndpoint> chatRequest)
        {
            _chatRequest = chatRequest;
        }

        public async Task<UserDataModel> CreateUser(PriorityType priorityType, UserDataModel user)
        {
            UserDataModel userDataModel = null;
            Task<UserDataModel> userTask;

            try
            {
                if (CrossConnectivity.Current.IsConnected)
                {
                    var apiRequestelector = new ApiRequestSelector<IChatEndpoint>(_chatRequest, priorityType);
                    var chatApi = apiRequestelector.GetApiRequestByPriority();

                    userTask = chatApi?.CreateUser(user);
                    userDataModel = await Policy
                          .Handle<ApiException>()
                          .WaitAndRetryAsync(retryCount: 2, sleepDurationProvider: retryAttempt =>
                          TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
                          .ExecuteAsync(async () => await userTask);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                //TODO: log.
            }

            return userDataModel;
        }

        public async Task<List<MessageDataModel>> GetUserMessages(PriorityType priorityType, int receiverUserId)
        {
            List<MessageDataModel> messageListDataModel = null;
            Task<List<MessageDataModel>> messageListTask;

            try
            {
                if (CrossConnectivity.Current.IsConnected)
                {
                    var apiRequestelector = new ApiRequestSelector<IChatEndpoint>(_chatRequest, priorityType);
                    var chatApi = apiRequestelector.GetApiRequestByPriority();

                    messageListTask = chatApi?.GetUserMessages(receiverUserId);
                    messageListDataModel = await Policy
                          .Handle<ApiException>()
                          .WaitAndRetryAsync(retryCount: 2, sleepDurationProvider: retryAttempt =>
                          TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
                          .ExecuteAsync(async () => await messageListTask);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                //TODO: log.
            }

            return messageListDataModel;
        }

        public async Task<MessageDataModel> PostMessage(PriorityType priorityType, MessageDataModel message)
        {
            MessageDataModel messageDataModel = null;
            Task<MessageDataModel> messageTask;

            try
            {
                if (CrossConnectivity.Current.IsConnected)
                {
                    var apiRequestelector = new ApiRequestSelector<IChatEndpoint>(_chatRequest, priorityType);
                    var chatApi = apiRequestelector.GetApiRequestByPriority();

                    messageTask = chatApi?.PostMessage(message);
                    messageDataModel = await Policy
                          .Handle<ApiException>()
                          .WaitAndRetryAsync(retryCount: 2, sleepDurationProvider: retryAttempt =>
                          TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
                          .ExecuteAsync(async () => await messageTask);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                //TODO: log.
            }

            return messageDataModel;
        }

        public async Task<UserDataModel> ValidateUser(PriorityType priorityType, string username)
        {
            UserDataModel userDataModel = null;
            Task<UserDataModel> userTask;

            try
            {
                if (CrossConnectivity.Current.IsConnected)
                {
                    var apiRequestelector = new ApiRequestSelector<IChatEndpoint>(_chatRequest, priorityType);
                    var chatApi = apiRequestelector.GetApiRequestByPriority();

                    userTask = chatApi?.ValidateUser(username);
                    userDataModel = await Policy
                          .Handle<ApiException>()
                          .WaitAndRetryAsync(retryCount: 2, sleepDurationProvider: retryAttempt =>
                          TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
                          .ExecuteAsync(async () => await userTask);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                //TODO: log.
            }

            return userDataModel;
        }
    }
}
