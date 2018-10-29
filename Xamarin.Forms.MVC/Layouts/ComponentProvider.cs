using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.DependencyInjection;

namespace Xamarin.Forms.MVC.Layouts
{
    public abstract class ComponentProvider<TKey> : ContentView
        where TKey : struct
    {
        readonly Dictionary<TKey, Func<View>> mappings;

        public int Ada { get; set; }

        public abstract TKey Data { get; set; }

        public ComponentProvider()
        {
            mappings = new Dictionary<TKey, Func<View>>();
        }

        public void Set<TComponent>(TKey key)
            where TComponent : View
        {
            mappings.Add(key, () => Services.Get<TComponent>());
        }

    }
}
