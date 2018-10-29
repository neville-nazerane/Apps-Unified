using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.DependencyInjection;

namespace Xamarin.Forms.MVC.Layouts
{
    class LayoutComponentMappings<TKey, TLayout> : Dictionary<TKey, Func<View>>, ILayoutConfig<TKey>
        where TKey : struct
        where TLayout : LayoutComponent<TKey>
    {

        public ILayoutConfig<TKey> Set<TComponent>(TKey key)
            where TComponent : View
        {
            this[key] = () => Services.Get<TComponent>();
            return this;
        }
    }
}
