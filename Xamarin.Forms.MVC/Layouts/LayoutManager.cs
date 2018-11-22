using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.DependencyInjection;

namespace Xamarin.Forms.MVC.Layouts
{
    public class LayoutManager<TKey>
        where TKey : struct
    {
        private readonly LayoutComponentMappings<TKey> mappings;

        public LayoutManager()
        {
            mappings = Services.Get<LayoutComponentMappings<TKey>>();
        }

        public void Set<TComponent>(TKey key)
            where TComponent : View
            => mappings.Set<TComponent>(key);

    }
}
