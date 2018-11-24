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
using Xamarin.Forms.MVC.Templates;
using Testing.Apps.Components;
using Xamarin.Forms.MVC.Layouts;

namespace Testing.Apps.Config
{
    //class AppConfig : MvcConfiguration
    //{

    //    public static SimpleController Simple => Fetch<SimpleController>(); 

    //    public AppConfig()
    //    {
    //        MenuItems = new MenuItemContents {
    //            { "Home", () => Simple.Index() },
    //            { "Empty" },
    //            { "Show Blogs", () => Simple.BlogPage() }
    //        };

    //        //AddLayoutComponent<ComponentKey, Comp>()
    //        //                                    .Set<InnerBlogList>(ComponentKey.BlogList)
    //        //                                    .Set<InnerBlogEditor>(ComponentKey.BlogEditor);
    //    }

    //    public override void ConfigureServices(IServiceCollection services)
    //    {
    //        base.ConfigureServices(services);

    //        services

    //            .AddScoped<SimpleController>()

    //            .AddSingleton<MainConsumer>()

    //            .AddTransient<InnerBlogList>()
    //            .AddTransient<InnerBlogEditor>()

    //            .AddSingleton<BlogAccess>()
    //            .AddSingleton<PostAccess>()
    //            .AddSingleton<DataInitializer>()

    //            .AddTransient<InnerBlogList>()
    //            .AddTransient<InnerBlogEditor>()

    //            .AddScoped<BlogRepository>()
    //            .AddScoped<PostRepository>();
    //    }

    //    public override void OnCreated(IServiceProvider provider) => provider.GetService<DataInitializer>().Init();

    //    public override void ConfigureListeners(ListenerConfiguration configuration) => configuration.Add<AppDataStore>();

    //}
}
