using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.DependencyInjection;

namespace Xamarin.Forms.MVC.Layouts
{

    public class LayoutComponent : LayoutComponent<int>
    {
        public int Key { set => SetComponent<LayoutComponent>(value); }
    }

    public abstract class LayoutComponent<TKey> : ContentView
        where TKey : struct
    {

        protected void SetComponent<TLayout>(TKey key)
            where TLayout : LayoutComponent<TKey>
            => Content = Services.Get<LayoutComponentMappings<TKey, TLayout>>()[key]();

    }
}
