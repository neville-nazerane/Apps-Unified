using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.DependencyInjection;
using Xamarin.Forms.MVC.Layouts;

namespace Xamarin.Forms
{
    public static class MvcLayoutExtensions
    {

        public static TComponent AddComponent<TComponent>(this StackLayout layout, IComponentControl<TComponent> component)
             where TComponent : View 
                => component.Add(comp => layout.Children.Add(comp));

        public static TComponent AddComponent<TComponent>(this StackLayout layout)
             where TComponent : View
                => layout.AddComponent(Services.Get<IComponentControl<TComponent>>());


        public static TComponent SetComponent<TComponent>(this ContentView view, IComponentControl<TComponent> component)
             where TComponent : View
                => component.Add(comp => view.Content = comp);


        public static TComponent SetComponent<TComponent>(this ContentView view)
             where TComponent : View
                => view.SetComponent(Services.Get<IComponentControl<TComponent>>());

        public static TComponent SetComponent<TComponent>(this Frame view, IComponentControl<TComponent> component)
         where TComponent : View
            => component.Add(comp => view.Content = comp);


        public static TComponent SetComponent<TComponent>(this Frame view)
             where TComponent : View
                => view.SetComponent(Services.Get<IComponentControl<TComponent>>());

    }
}
