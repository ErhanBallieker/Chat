using Autofac;
using Chat.MobileApp.Service;
using Chat.MobileApp.Service.ChatService;
using Chat.MobileApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Chat.MobileApp
{
    public partial class App : Application
    {
        static App instance;

        public App()
        {
            InitializeComponent();
            RegisterDependencies();

            MainPage = new NavigationPage(new LoginPage());
        }

        public static App Instance { get { return instance; } }
        public static IContainer Container { get; set; }

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            #region ViewModel Registrations
            builder.RegisterType<ChatPageViewModel>();
            builder.RegisterType<LoginPageViewModel>();
            builder.RegisterType<NewMessagePageViewModel>();
            #endregion

            #region App Service Registrations
            builder.RegisterGeneric(typeof(ApiRequest<>)).As(typeof(IApiRequest<>)).InstancePerDependency();

            builder.RegisterType<ChatService>().As<IChatService>();

            #endregion

            App.Container = builder.Build();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
