using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms.DependencyInjection;
using Xamarin.Forms.MVC.Templates;
using Xamarin.Forms.MVC.Templates.Defaults;

namespace Xamarin.Forms.MVC
{
    public partial class MvcConfiguration 
    {

        IMainPage mainPage;
        IMenuPage menuPage;

        protected void SetMainPage<TPage>(TPage page = null)
            where TPage : Page, IMainPage
        {
            mainPage = page;
        }

        protected void SetMenuPage<TPage>(TPage page = null)
            where TPage : Page, IMenuPage
        {
            menuPage = page;
        }

        Page BuildPage()
        {
            var menu = menuPage ?? new MenuPage();
            var page = mainPage ?? new MainPage(menu as Page);
            return page as Page;
        }

    }
}
