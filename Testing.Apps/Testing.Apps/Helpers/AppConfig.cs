using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms.DependencyInjection;

using Testing.App.Business;
using Testing.App.DataAccess;
using Testing.App.Connections;
using Xamarin.Forms.MVC;
using Testing.Apps.Controllers;

namespace Testing.Apps.Helpers
{
    class AppConfig : MvcConfiguration
    {

        public static SimpleController Simple => Fetch<SimpleController>();

        public AppConfig()
        {
            MenuItems = new MenuItemContents {
                { "Home", () => Simple.Index() },
                { "Empty" }
            };
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services

                .AddScoped<SimpleController>()

                .AddSingleton<MainConsumer>()

                .AddSingleton<BlogAccess>()
                .AddSingleton<PostAccess>()
                .AddSingleton<DataInitializer>()

                .AddScoped<BlogRepository>()
                .AddScoped<PostRepository>();
        }

        public override void OnCreated(IServiceProvider provider) => provider.GetService<DataInitializer>().Init();

        public override void ConfigureListeners(ListenerConfiguration configuration) => configuration.Add<AppDataStore>();



    }
}
