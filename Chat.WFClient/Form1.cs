using Chat.DataModel.Pcl.DataModels;
using Chat.WFClient.ApiHelper;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat.WFClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            //var chatApi = new ChatApi();
            //var request = new RestRequest(Method.GET);
            //request.Resource = "GetUserMessages";
            //request.AddQueryParameter("receiverUserId", "1");
            //var result = chatApi.Execute<List<MessageDataModel>>(request);


            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("http://chatapi20170703115008.azurewebsites.net/api/chat/");

            //    var result = await client.GetStringAsync("GetUserMessages");
            //}
        }
    }
}
