 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.DependencyInjection;

namespace Testing.Apps.Pages
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            var nav = new NavigationPage(new HomePage());
            Services.NavigationPage = nav;

            Master = new MenuPage();
            Detail = nav;

           // Services.NavigateAsync<HomePage>();

        }
    }
}
