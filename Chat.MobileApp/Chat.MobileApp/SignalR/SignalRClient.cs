using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.MobileApp.SignalR
{
    public class SignalRClient
    {
        private readonly string _identityNumber;
        private readonly HubConnection _connection;
        private static IHubProxy _posProxy;

        public event EventHandler<OnMessageReceivedEventArg> OnMessageReceived;

        public SignalRClient()
        {
            _connection = new HubConnection("http://chatapi20170703115008.azurewebsites.net/");
            _posProxy = _connection.CreateHubProxy("ChatHub");
            _posProxy.On("newMessageReceived", (string senderUsername, string messageText) =>
            {
                var onMessageReceivedEventArg = new OnMessageReceivedEventArg
                {
                    SenderUsername = senderUsername,
                    MessageText = messageText,
                };

                OnMessageReceived?.Invoke(this, onMessageReceivedEventArg);
            });
        }

        public async Task Connect(string username)
        {
            try
            {
                await _connection.Start();
            }
            catch (Exception ex)
            {
            }

            Send(username, "connected");
        }

        public static async void Send(string senderUsername, string message)
        {
            try
            {
                await _posProxy.Invoke("SendMessage", senderUsername, message);
            }
            catch (Exception ex)
            {

            }
        }

        public class OnMessageReceivedEventArg
        {
            public string SenderUsername { get; set; }
            public string MessageText { get; set; }
        }
    }
}
