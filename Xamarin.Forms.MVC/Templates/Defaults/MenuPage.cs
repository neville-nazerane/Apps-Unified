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

        public void AddItem(View item)
        {
            contents.Children.Add(item);
        }
    }
}
