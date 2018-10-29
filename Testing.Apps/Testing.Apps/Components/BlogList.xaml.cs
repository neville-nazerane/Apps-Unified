using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.App.DataAccess;
using Xamarin.Forms;
using Xamarin.Forms.DependencyInjection;
using Xamarin.Forms.Xaml;

namespace Testing.Apps.Components
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BlogList : ContentView
	{
		public BlogList (AppDataStore store)
		{
			InitializeComponent ();

            store.Blogs.OnSet = blogs => {
                if (blogs == null) return;
                contents.Children.Clear();
                foreach (var b in blogs)
                    contents.Children.Add(new BlogItem(b));
            };

		}
	}
}