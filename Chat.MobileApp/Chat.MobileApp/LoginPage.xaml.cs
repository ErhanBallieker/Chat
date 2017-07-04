using Acr.UserDialogs;
using Autofac;
using Chat.DataModel.Pcl.DataModels;
using Chat.MobileApp.Common.Enums;
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
    public partial class LoginPage : ContentPage
    {
        private LoginPageViewModel loginPageViewModel;
        public LoginPage()
        {
            InitializeComponent();

            loginPageViewModel = App.Container.Resolve<LoginPageViewModel>();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsername.Text) && !string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                UserDialogs.Instance.ShowLoading("Searching for user..");
                var existingUser = await loginPageViewModel.ValidateUser(PriorityType.UserInitiated, txtUsername.Text);
                UserDialogs.Instance.HideLoading();
                if (existingUser != null)
                {
                    await Navigation.PushAsync(new MainPage(existingUser.Username, existingUser.Id));
                    UserDialogs.Instance.ShowSuccess("Login Succeeded",1000);
                }
                else
                {
                    UserDialogs.Instance.ShowError("User not found.", 500);

                    UserDialogs.Instance.ShowLoading("Creating new user for you..");
                    existingUser = await loginPageViewModel.CreateUser(PriorityType.UserInitiated, new UserDataModel
                    {
                        Name = txtFirstName.Text ?? "NotGiven",
                        Lastname = txtLastName.Text ?? "NotGiven",
                        Username = txtUsername.Text
                    });

                    UserDialogs.Instance.HideLoading();
                    if (existingUser != null)
                    {
                        UserDialogs.Instance.ShowSuccess("User Created", 1000);
                        await Navigation.PushAsync(new MainPage(existingUser.Username, existingUser.Id));
                    }
                    else
                    {
                        UserDialogs.Instance.ShowError("Something went wrong. Please try again", 2000);
                    }
                }
            }
            else
            {
                await DisplayAlert("Warning!", "Please enter your username", "OK");
            }

        }
    }
}
