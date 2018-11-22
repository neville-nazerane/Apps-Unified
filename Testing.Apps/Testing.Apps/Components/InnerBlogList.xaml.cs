using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.App.DataAccess;
using Xamarin.Forms;
using Xamarin.Forms.DependencyInjection;
using Xamarin.Forms.MVC.Components;
using Xamarin.Forms.MVC.Extensions;
using Xamarin.Forms.Xaml;

namespace Testing.Apps.Components
{

    public class BlogList : InjectableComponent<InnerBlogList> { }

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InnerBlogList : ContentView
	{
		public InnerBlogList (AppDataStore store)
		{
			InitializeComponent ();

            contents.BindTo(store.Blogs, b => new BlogItem(b));

		}
	}
}