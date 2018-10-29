using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Forms.MVC.Templates.Defaults
{
    class LoadingPage : ContentPage, ILoadingPage
    {
        readonly Label displayLabel;

        public LoadingPage()
        {
            var layout = new StackLayout();
            Content = layout;
            layout.Children.Add(displayLabel = new Label());
            layout.Children.Add(new ProgressBar
            {
                Progress = 0.3
            });
        }

        public string DisplayMessage { set => displayLabel.Text = value; }
    }
}
