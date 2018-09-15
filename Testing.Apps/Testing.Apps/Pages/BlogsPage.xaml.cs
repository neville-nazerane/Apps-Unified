using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.App.Business;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Testing.Apps.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BlogsPage : ContentPage
	{
		public BlogsPage (BlogRepository repository)
		{
			InitializeComponent ();

            submit.Clicked += async delegate {
                await repository.AddOrEditAsync();
            };

		}
	}
}