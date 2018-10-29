using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Forms.MVC.Layouts
{
    public interface IComponentControl<TComponent>
        where TComponent : View
    {

        TComponent Add(Action<TComponent> addTo);

    }
}
