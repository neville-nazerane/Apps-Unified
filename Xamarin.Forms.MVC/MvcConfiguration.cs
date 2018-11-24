using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Apps.Unified;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms.DependencyInjection;
using Xamarin.Forms.MVC.Templates;
using Xamarin.Forms.MVC.Templates.Defaults;

namespace Xamarin.Forms.MVC
{
    public partial class MvcConfiguration
    {
        private MvcServiceConfiguration _configuration;

        public MvcConfiguration()
        {
            _configuration = new MvcServiceConfiguration();
            _menuItems = new MenuItemContents();
            InitializeTemplates();
            InitializeLayout();
        }

        MvcConfiguration AppendService(ServiceAdd append)
        {
            _configuration.AppendService(append);
            return this;
        }

        #region add services

        public MvcConfiguration AddServices(Action<IServiceCollection> config)
            => AppendService(services => config(services));

        public MvcConfiguration AddSingleton<TService>(TService service)
            where TService : class
            => AppendService(services => services.AddSingleton(service));

        public MvcConfiguration AddSingleton<TService>()
            where TService : class
            => AppendService(services => services.AddSingleton<TService>());

        public MvcConfiguration AddSingleton<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService
            => AppendService(services => services.AddSingleton<TService, TImplementation>());

        public MvcConfiguration AddScoped<TService>()
            where TService : class
            => AppendService(services => services.AddScoped<TService>());

        public MvcConfiguration AddScoped<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService
            => AppendService(services => services.AddScoped<TService, TImplementation>());

        public MvcConfiguration AddTransient<TService>()
            where TService : class
            => AppendService(services => services.AddTransient<TService>());

        public MvcConfiguration AddTransient<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService
            => AppendService(services => services.AddTransient<TService, TImplementation>());

        #endregion

        public MvcConfiguration AddDataStore<TStore>()
            where TStore : DataStore
        {
            _configuration.AppendDataStore<TStore>();
            return this;
        }

        public MvcConfiguration AddMenuItem(string text, Func<Task<IActionResponse>> linked = null)
        {
            _menuItems.Add(text, linked);
            return this;
        }

        public MvcConfiguration AddMenuItem(string text, Func<IActionResponse> linked)
        {
            _menuItems.Add(text, linked);
            return this;
        }

        public MvcConfiguration OnServicesConfigured(Action<IServiceProvider> configure)
        {
            _configuration._onCreated = configure;
            return this;
        }

        void SetConfigureServices()
        {

            AppendService(_addMenuItemAsService);
            AppendService(_addLayout);

            // add all controllers 
        }

        public Page Build()
        {
            
            Services.Configuration = _configuration;
            var page = BuildPage();
            return page as Page;
        }

        public static implicit operator Page(MvcConfiguration configuration)
            => configuration.Build();

    }
}
