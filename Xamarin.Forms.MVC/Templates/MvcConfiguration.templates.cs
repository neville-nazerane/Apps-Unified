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
            _defaultMenuItemAdder = content => new DefaultMenuItem().SetContent(content);
            addLoadingPageAsService = services => services.AddSingleton<ILoadingPage, LoadingPage>()
                                                          .AddSingleton<LoadingPage>();
            templateUtilities = new TemplateUtilities {
                StartLoading = async () => await Services.NavigateAsync<LoadingPage>()
            };
        }

        readonly MenuItemContents _menuItems;

        ServiceAdd addLoadingPageAsService;
        TemplateUtilities templateUtilities;
        protected void LoadPage<TPage>() where TPage : Page, ILoadingPage
        {
            addLoadingPageAsService = services => services.AddSingleton<ILoadingPage, TPage>()
                                                          .AddSingleton<TPage>();
            templateUtilities.StartLoading = async () => await Services.NavigateAsync<TPage>();
        }

        Func<IMainPage> _getCustomMainPage;
        protected void SetMainPage<TPage>() where TPage : Page, IMainPage
        {
            _getCustomMainPage = () => Services.Get<TPage>();
        }

        Func<IMenuPage> _getCustomMenuPage;
        protected void SetMenuPage<TPage>() where TPage : Page, IMenuPage
        {
            _getCustomMenuPage = () => Services.Get<TPage>();
        }

        Func<MenuItemContent, View> _defaultMenuItemAdder;
        ServiceAdd _addMenuItemAsService;
        public void SetMenuItemComponet<TItem>() where TItem : View, IMenuItem
        {
            _addMenuItemAsService = services => services.AddTransient<TItem>();
            _defaultMenuItemAdder = content => Services.Get<TItem>().SetContent(content);
        }

        void AddTemplates(IServiceCollection services)
        {
            services.AddSingleton(_getCustomMenuPage());
            services.AddSingleton(_getCustomMainPage());
            addLoadingPageAsService?.Invoke(services);
            _addMenuItemAsService(services);
        }

        Page BuildPage()
        {
            var menu = _getCustomMenuPage?.Invoke() ?? new MenuPage();
            var page = _getCustomMainPage?.Invoke() ?? new MainPage(menu as Page);
            foreach (var item in _menuItems)
                menu.AddItem(_defaultMenuItemAdder(item));
            return page as Page;
        }

    }
}
