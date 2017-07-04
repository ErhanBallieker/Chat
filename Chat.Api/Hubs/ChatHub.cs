using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.Api.Hubs
{
    public class ChatHub : Hub
    {
        public string _connectionId;
        private IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
        public ChatHub()
        {
        }

        public void SendMessage(string senderusername, string messageText)
        {
            hubContext.Clients.AllExcept(Context.ConnectionId).newMessageReceived(senderusername, messageText);
        }
    }
}