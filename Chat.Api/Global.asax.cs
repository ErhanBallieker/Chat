using Autofac;
using Autofac.Integration.WebApi;
using Chat.Api.Helpers.AutoMapper;
using Chat.ApplicationService.Chat;
using Chat.Data.Context;
using Chat.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Chat.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterInstance(new ChatContext()).SingleInstance();

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));

            builder.RegisterType<ChatService>().As<IChatService>();

            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            GlobalConfiguration.Configuration.Formatters.Clear();
            GlobalConfiguration.Configuration.Formatters.Add(new System.Net.Http.Formatting.JsonMediaTypeFormatter());
            GlobalConfiguration.Configuration.Formatters.Add(new System.Net.Http.Formatting.BsonMediaTypeFormatter());
            GlobalConfiguration.Configuration.Formatters.Add(new System.Web.Http.ModelBinding.JQueryMvcFormUrlEncodedFormatter());

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            var mapper = new AutoMapperStartUp();
            mapper.Run();
        }
    }
}
