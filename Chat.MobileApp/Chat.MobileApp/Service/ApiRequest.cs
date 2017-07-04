using Fusillade;
using ModernHttpClient;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Chat.MobileApp.Service
{
    public class ApiRequest<T> : IApiRequest<T>
    {
        private readonly Lazy<T> _background;
        private readonly Lazy<T> _userInitiated;
        private readonly Lazy<T> _speculative;

        public string BaseApiAddress =  Device.OS == TargetPlatform.iOS ? "https://chatapi20170703115008.azurewebsites.net/api/"
                                                                        : "http://chatapi20170703115008.azurewebsites.net/api/";

        public ApiRequest(string baseApiAddress = null)
        {

            _background = new Lazy<T>(() => CreateClient(new RateLimitedHttpMessageHandler(new NativeMessageHandler(), Priority.Background), baseApiAddress));
            _userInitiated = new Lazy<T>(() => CreateClient(new RateLimitedHttpMessageHandler(new NativeMessageHandler(), Priority.UserInitiated), baseApiAddress));
            _speculative = new Lazy<T>(() => CreateClient(new RateLimitedHttpMessageHandler(new NativeMessageHandler(), Priority.Speculative), baseApiAddress));
        }

        public T Background { get { return _background.Value; } }

        public T Speculative { get { return _speculative.Value; } }

        public T UserInitiated { get { return _userInitiated.Value; } }

        private T CreateClient(HttpMessageHandler handler, string baseApiAddress = null)
        {
            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri(baseApiAddress ?? BaseApiAddress)
            };

            var res = RestService.For<T>(client);
            return res;
        }
    }
}
