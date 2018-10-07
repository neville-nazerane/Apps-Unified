using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms.DependencyInjection;
using Xamarin.Forms.MVC.Templates;
using Xamarin.Forms.MVC.Templates.Defaults;
using DefaultMenuItem = Xamarin.Forms.MVC.Templates.Defaults.MenuItem;

namespace Xamarin.Forms.MVC
{
    public partial class MvcConfiguration 
    {

        void InitializeTemplates()
        {
            defaultMenuItemAdder = content => new DefaultMenuItem().SetContent(content);
        }

        protected MenuItemContents MenuItems { get; set; }

        Func<IMainPage> getCustomMainPage;
        protected void SetMainPage<TPage>()
            where TPage : Page, IMainPage
        {
            getCustomMainPage = () => Services.Get<TPage>();
        }

        Func<IMenuPage> getCustomMenuPage;
        protected void SetMenuPage<TPage>()
            where TPage : Page, IMenuPage
        {
            getCustomMenuPage = () => Services.Get<TPage>();
        }

        Func<MenuItemContent, View> defaultMenuItemAdder;
        serviceAdd addMenuItemAsService;
        protected void SetMenuItem<TItem>() where TItem : View, IMenuItem, new()
        {
            addMenuItemAsService = services => services.AddTransient<TItem>();
            defaultMenuItemAdder = content => Services.Get<TItem>().SetContent(content);
        }

        IServiceCollection AddTemplates(IServiceCollection services)
            => addMenuItemAsService(services);

        Page BuildPage()
        {
            var menu = getCustomMenuPage?.Invoke() ?? new MenuPage();
            var page = getCustomMainPage?.Invoke() ?? new MainPage(menu as Page);
            if (MenuItems != null)
                foreach (var item in MenuItems)
                    menu.AddItem(defaultMenuItemAdder(item));
            return page as Page;
        }

    }
}
