using System;
using Testing.App.Business;
using Testing.App.Connections;
using Testing.App.DataAccess;
using Testing.Apps.Components;
using Testing.Apps.Config;
using Testing.Apps.Controllers;
using Testing.Apps.Pages;
using Xamarin.Forms;
using Xamarin.Forms.DependencyInjection;
using Xamarin.Forms.MVC;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Testing.Apps
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MvcConfiguration()

                        // menu items
                        .AddMenuItem("Home", () => Services.Get<SimpleController>().Index())
                        .AddMenuItem("Empty")
                        .AddMenuItem("Show Blogs", () => Services.Get<SimpleController>().BlogPage())

                        .AddDataStore<AppDataStore>()
                        .OnServicesConfigured(provider => provider.GetService<DataInitializer>().Init())

                        // services
                        .AddScoped<SimpleController>()

                        .AddSingleton<MainConsumer>()

                        .AddTransient<InnerBlogList>()
                        .AddTransient<InnerBlogEditor>()

                        .AddSingleton<BlogAccess>()
                        .AddSingleton<PostAccess>()
                        .AddSingleton<DataInitializer>()

                        .AddTransient<InnerBlogList>()
                        .AddTransient<InnerBlogEditor>()

                        .AddScoped<BlogRepository>()
                        .AddScoped<PostRepository>()
                        
                        // pages temp
                        .AddScoped<HomePage>()
                        .AddScoped<BlogsPage>();
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
