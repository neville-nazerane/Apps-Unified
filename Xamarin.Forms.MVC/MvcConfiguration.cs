using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms.DependencyInjection;
using Xamarin.Forms.MVC.Templates;
using Xamarin.Forms.MVC.Templates.Defaults;

namespace Xamarin.Forms.MVC
{
    public partial class MvcConfiguration : ServiceConfiguration
    {

        delegate IServiceCollection serviceAdd(IServiceCollection services);

        public MvcConfiguration()
        {
            InitializeTemplates();
            InitializeLayout();
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            addMenuItemAsService?.Invoke(services);
            addLayout(services);
            // add all controllers 
        }

        public Page Build()
        {
            Services.Configuration = this;
            var page = BuildPage();
            return page as Page;
        }

        public static implicit operator Page(MvcConfiguration configuration)
            => configuration.Build();

    }
}
