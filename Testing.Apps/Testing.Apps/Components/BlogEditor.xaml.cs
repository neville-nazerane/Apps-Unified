using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.DependencyInjection;
using Xamarin.Forms.Xaml;

using Testing.App.DataAccess;
using NetCore.Apis.Client.UI;
using Testing.Core;

namespace Testing.Apps.Components
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BlogEditor : ContentView
	{
        public ModelHandler<Blog> Handler { get; }

		public BlogEditor (AppDataStore store)
		{
			InitializeComponent ();

            store.Blog
                .GetModelHandler()
                .BindErrors(errors)
                .Bind(b => b.Url, url, urlErrors)
                .Bind(b => b.Rating, rating, ratingErrors);
        }

    }
}