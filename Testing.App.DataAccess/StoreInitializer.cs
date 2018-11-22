using System;
using System.Collections.Generic;
using System.Text;
using Apps.DependencyInjection;
using Testing.Core;

namespace Testing.App.DataAccess
{
    public class DataInitializer
    {
        private readonly IDataInitializer<AppDataStore> initializer;
        private readonly BlogAccess blogAccess;
        private readonly PostAccess postAccess;

        public DataInitializer(
                        IDataInitializer<AppDataStore> initializer,
                        BlogAccess blogAccess,
                        PostAccess postAccess
            )
        {
            this.initializer = initializer;
            this.blogAccess = blogAccess;
            this.postAccess = postAccess;
        }

        public void Init()
        {
            initializer.Add(s => s.Blogs, async s => (await blogAccess.GetAsync()).Data);
            initializer.Add(s => s.Blog.Listener,
                                        async s =>
                                        {
                                            if (s.BlogId == 0) return null;
                                            return (await blogAccess.GetAsync(s.BlogId)).Data;
                                        });

            initializer.Add(s => s.Posts, async s => (await postAccess.GetAsync()).Data);
            initializer.Add(s => s.Post.Listener,
                                        async s =>
                                        {
                                            if (s.PostId == 0) return null;
                                            return (await postAccess.GetAsync(s.PostId)).Data;
                                        });

        }

    }
}
