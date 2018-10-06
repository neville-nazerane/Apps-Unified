using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Forms.MVC.Templates.Defaults
{
    class MenuPage : ContentPage, IMenuPage
    {
        readonly StackLayout contents;

        public MenuPage()
        {
            Title = "Hello MVC";
            Content = contents = new StackLayout();
        }

        public void AddItem<TItem>(TItem item) where TItem : View, IMenuItem => contents.Children.Add(item);

    }
}
