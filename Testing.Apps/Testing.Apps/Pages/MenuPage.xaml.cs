using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Apps.Controllers;
using Xamarin.Forms;
using Xamarin.Forms.DependencyInjection;
using Xamarin.Forms.MVC;
using Xamarin.Forms.Xaml;

namespace Testing.Apps.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage : ContentPage
	{
		public MenuPage ()
		{
			InitializeComponent ();

            blog.Clicked += async delegate {
               // await Services.NavigateAsync<BlogsPage>();
            };

        }
	}
}