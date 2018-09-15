using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.App.Business;
using Testing.App.DataAccess;
using Testing.Core;
using Xamarin.Forms;
using Xamarin.Forms.DependencyInjection;
using Xamarin.Forms.Xaml;

namespace Testing.Apps.Components
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BlogItem : Frame
	{

        private Blog _blog;
        public Blog Blog
        {
            get => _blog;
            set {
                url.Text = value.Url;
                rating.Text = value.Rating.ToString();
                _blog = value;
            }
        }


        public BlogItem (Blog Blog)
		{
			InitializeComponent ();

            this.Blog = Blog;

            var repo = Services.Get<BlogRepository>();
            var store = Services.Get<AppDataStore>();

            edit.Clicked += async delegate {
                if (_blog != null)
                {
                    store.BlogId = _blog.Id;
                    await store.Blog.ReloadAsync();
                }
            };

            delete.Clicked += async delegate {
                if (_blog != null)
                {
                    store.BlogId = _blog.Id;
                    await repo.DeleteAsync();
                }
            };

        }
	}
}