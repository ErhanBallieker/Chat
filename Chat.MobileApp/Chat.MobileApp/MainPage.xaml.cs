using Autofac;
using Chat.DataModel.Pcl.DataModels;
using Chat.MobileApp.Common.Enums;
using Chat.MobileApp.SignalR;
using Chat.MobileApp.ViewModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Chat.MobileApp
{
    public partial class MainPage : ContentPage
    {
        private readonly ChatPageViewModel chatPageViewModel;
        private static SignalRClient _client;
        private string _username;
        private int _userId;
        public MainPage(string username, int userId)
        {
            InitializeComponent();
            _username = username;
            _userId = userId;
            chatPageViewModel = App.Container.Resolve<ChatPageViewModel>();


            Task.Run(async () =>
            {
                var result = await chatPageViewModel.GetUserMessage(PriorityType.UserInitiated, userId);
                if (result != null && result.Count > 0)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        messagesListView.ItemsSource = result;
                    });
                }
            });

            MessagingCenter.Subscribe<NewMessagePage, MessageDataModel>(this, "newMessageSent", async (p, message) =>
             {

                 var result = await chatPageViewModel.GetUserMessage(PriorityType.UserInitiated, userId);
                 if (result != null && result.Count > 0)
                 {
                     Device.BeginInvokeOnMainThread(() =>
                     {
                         messagesListView.ItemsSource = null;
                         messagesListView.ItemsSource = result;
                     });

                 }
             });

            _client = new SignalRClient();
            Task.Run(async () =>
            {
                await _client.Connect(username);
            });

            _client.OnMessageReceived += _client_OnMessageReceived;
        }

        private void _client_OnMessageReceived(object sender, SignalRClient.OnMessageReceivedEventArg e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await chatPageViewModel.GetUserMessage(PriorityType.UserInitiated, _userId);
                if (result != null && result.Count > 0)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        messagesListView.ItemsSource = null;
                        messagesListView.ItemsSource = result;
                    });

                }
            });
        }

        private void messagesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedMessage = messagesListView.SelectedItem as MessageDataModel;
            if (selectedMessage == null)
            {
                return;
            }

            messagesListView.SelectedItem = null;
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new NewMessagePage(_username, _userId));
        }
    }
}
