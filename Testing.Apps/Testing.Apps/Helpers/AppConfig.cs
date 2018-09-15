using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms.DependencyInjection;

using Testing.App.Business;
using Testing.App.DataAccess;
using Testing.App.Connections;

namespace Testing.Apps.Helpers
{
    class AppConfig : ServiceConfiguration
    {

        public override void ConfigureServices(IServiceCollection services)
        {
            services
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
