using System;
using System.Collections.Generic;
using System.Text;
using Apps.Unified;
using Apps.DependencyInjection;
using Testing.Core;

namespace Testing.App.DataAccess
{
    public class AppDataStore : DataStore
    {

        public int PostId { get; set; }
        public DataControl<Post> Post { get; set; }
        public DataListener<IEnumerable<Post>> Posts { get; set; }

        public int BlogId { get; set; }
        public DataControl<Blog> Blog { get; set; }
        public DataListener<IEnumerable<Blog>> Blogs { get; set; }

        public AppDataStore() : base()
        {
            Post = Build();
            Blog = Build();
        }

    }
}
