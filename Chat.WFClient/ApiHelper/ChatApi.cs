using Chat.DataModel.Pcl.DataModels;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.WFClient.ApiHelper
{
    public class ChatApi
    {
        //const string BaseUrl = "http://chatapi20170703115008.azurewebsites.net/api/chat/";

        //public ChatApi()
        //{

        //}

        //public T Execute<T>(RestRequest request) where T : new()
        //{
        //    var client = new RestClient();
        //    client.BaseUrl = new Uri(BaseUrl);
        //    var response = client.Execute<T>(request);

        //    if (response.ErrorException != null)
        //    {
        //        const string message = "Error retrieving response.  Check inner details for more info.";
        //        var chatException = new ApplicationException(message, response.ErrorException);
        //        throw chatException;
        //    }
        //    return response.Data;
        //}
    }
}
