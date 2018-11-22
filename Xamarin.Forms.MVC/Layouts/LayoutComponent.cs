using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.DependencyInjection;

namespace Xamarin.Forms.MVC.Layouts
{

    public class LayoutComponent : LayoutComponent<LayoutKey>
    {
    }

    public abstract class LayoutComponent<TKey> : ContentView
        where TKey : struct
    {

        public TKey Key { set => SetComponent(value); }

        void SetComponent(TKey key)
            => Content = Services.Get<LayoutComponentMappings<TKey>>()[key]();

    }
}
