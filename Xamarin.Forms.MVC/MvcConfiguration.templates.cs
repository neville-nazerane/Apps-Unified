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

        //IMainPage mainPage;
        //IMenuPage menuPage;

        void InitializeTemplates()
        {
            defaultMenuItemAdder = content => SetupMenuItem(new DefaultMenuItem(), content);
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
            defaultMenuItemAdder = content => SetupMenuItem(Services.Get<TItem>(), content);
        }

        View SetupMenuItem<TItem>(TItem menuItem, MenuItemContent content)
             where TItem : View, IMenuItem
        {
            content.Set(menuItem);
            return menuItem;
        }

        protected class MenuItemContents : List<MenuItemContent>
        {

            public void Add(string title, Func<IActionResponse> linked)
            {
                Add(new MenuItemContent {
                    Text = title,
                    Linked = () => {
                        var res = linked();
                        return Task.FromResult(res);
                    }
                });
            }

            public void Add(string title, Func<Task<IActionResponse>> linked = null)
            {
                Add(new MenuItemContent {
                    Text = title,
                    Linked = linked
                });
            }

        }

        protected class MenuItemContent
        {
            public string Text { get; set; }

            public Func<Task<IActionResponse>> Linked { get; set; }

            internal MenuItemContent() { }

            internal void Set(IMenuItem item)
            {
                item.Text = Text;
                if (Linked == null)
                    item.OnCLick = () => Task.CompletedTask ;
                else item.OnCLick = Linked;
            }

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
