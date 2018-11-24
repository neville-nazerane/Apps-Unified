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

        ServiceAdd _addLayout;

        void InitializeLayout()
        {
            SetLayoutKey<LayoutKey>();
        }

        public MvcConfiguration SetLayoutKey<TKey>()
            where TKey : struct => SetLayoutKey<TKey, LayoutManager<TKey>>();

        public MvcConfiguration SetLayoutKey<TKey, TManager>()
            where TKey : struct
            where TManager : LayoutManager<TKey>
        {
            _addLayout = services => services.AddScoped<LayoutComponentMappings<TKey>>()
                                            .AddScoped<TManager>();
            return this;
        }

    }
}
