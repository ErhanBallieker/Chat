using Acr.UserDialogs;
using Autofac;
using Chat.DataModel.Pcl.DataModels;
using Chat.MobileApp.Common.Enums;
using Chat.MobileApp.SignalR;
using Chat.MobileApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Chat.MobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewMessagePage : ContentPage
    {
        private string _username;
        private int _userId;

        private NewMessagePageViewModel newMessagePageViewModel;
        public NewMessagePage(string username, int userId)
        {
            InitializeComponent();
            newMessagePageViewModel = App.Container.Resolve<NewMessagePageViewModel>();
            _username = username;
            _userId = userId;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMessage.Text) && !string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                UserDialogs.Instance.ShowLoading("Sending Message");
                var result = await newMessagePageViewModel.PostMessage(PriorityType.UserInitiated, new MessageDataModel
                {
                    MessageText = txtMessage.Text,
                    SenderUserId = _userId
                });
                UserDialogs.Instance.HideLoading();

                if (result != null)
                {
                    UserDialogs.Instance.ShowSuccess("Message Sent");
                    await Navigation.PopAsync();
                    MessagingCenter.Send(this, "newMessageSent", result);
                    SignalRClient.Send(_username, txtMessage.Text);
                }
                else
                {
                    UserDialogs.Instance.ShowError("Something went wrong");
                }
            }
            else
            {
                await DisplayAlert("Warning", "Please enter your message", "OK");
            }
        }
    }
}
