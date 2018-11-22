using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.DependencyInjection;

namespace Xamarin.Forms.MVC.Components
{
    public abstract class InjectableComponent<TComponent> : ContentView
        where TComponent : View
    {

        public InjectableComponent()
        {
            Content = Services.Get<TComponent>();
        }

    }
}
