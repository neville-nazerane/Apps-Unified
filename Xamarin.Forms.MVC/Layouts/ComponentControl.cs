using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.DependencyInjection;

namespace Xamarin.Forms.MVC.Layouts
{
    class ComponentControl<TComponent> : IComponentControl<TComponent>
        where TComponent : View
    {

        TComponent component;

        public TComponent Add(Action<TComponent> addTo)
        {
            addTo(component ?? (component = Services.Get<TComponent>()));
            return component;
        }
    }
}
