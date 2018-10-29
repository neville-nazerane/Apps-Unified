using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.DependencyInjection;
using Xamarin.Forms.MVC.Layouts;

namespace Xamarin.Forms.MVC
{
    public partial class MvcConfiguration
    {

        LayoutComponentMappings<int, LayoutComponent> defaultLayoutMapping;
        serviceAdd layoutComponentAdd;

        void InitializeLayout()
        {
            defaultLayoutMapping = new LayoutComponentMappings<int, LayoutComponent>();
            layoutComponentAdd = services => services.AddScoped<LayoutComponent>()
                                                             .AddSingleton(defaultLayoutMapping);
        }

        public ILayoutConfig<TKey> AddLayoutComponent<TKey, TLayout>()   
            where TKey : struct
            where TLayout : LayoutComponent<TKey>
        {
            var old = layoutComponentAdd;
            var mapping = new LayoutComponentMappings<TKey, TLayout>();

            layoutComponentAdd = services => old(services)
                                        .AddScoped<TLayout>()
                                        .AddSingleton(mapping);
            return mapping;
        }

        public ILayoutConfig<int> SetComponents() => defaultLayoutMapping;
         
        IServiceCollection AddLayout(IServiceCollection services)
            => layoutComponentAdd(services);

    }
}
