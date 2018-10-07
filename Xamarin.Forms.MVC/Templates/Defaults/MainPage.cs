using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.DependencyInjection;

namespace Xamarin.Forms.MVC.Templates.Defaults
{
    class MainPage : MasterDetailPage, IMainPage
    {

        public MainPage(Page menuPage)
        {

            var nav = new NavigationPage(new ContentPage {
                Content = new Label {
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    Text = "Welcome to Xamarin Forms MVC."
                }
            });
            Services.NavigationPage = nav;

            Master = menuPage;
            Detail = nav;

        }

    }
}
