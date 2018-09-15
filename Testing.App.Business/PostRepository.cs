using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NetCore.Apis.Consumer;
using Testing.App.Connections;
using Testing.App.DataAccess;
using Testing.Core;

namespace Testing.App.Business
{
    public class PostRepository : PostAccess
    {
        private readonly AppDataStore store;

        public PostRepository(MainConsumer consumer, AppDataStore store) : base(consumer)
        {
            this.store = store;
        }

        public override async Task<ApiConsumedResponse<Post>> AddAsync(Post post)
        {
            var res = await base.AddAsync(post);
            if (res.IsSuccessful) await store.Posts.ReloadAsync();
            return res;
        }

        public async Task<ApiConsumedResponse<Post>> AddAsync() => await AddAsync(store.Post);

        public override async Task<ApiConsumedResponse<Post>> EditAsync(int id, Post post)
        {
            var res = await base.EditAsync(id, post);
            if (res.IsSuccessful) await store.Posts.ReloadAsync();
            return res;
        }

        public async Task<ApiConsumedResponse<Post>> EditAsync() => await EditAsync(store.PostId, store.Post);

        public override async Task<ApiConsumedResponse<Post>> DeleteAsync(int id)
        {
            var res = await base.DeleteAsync(id);
            if (res.IsSuccessful) await store.Posts.ReloadAsync();
            return res;
        }

        public async Task<ApiConsumedResponse<Post>> AddOrEditAsync()
        {
            if (store.PostId == 0) return await AddAsync();
            else return await EditAsync();
        }

        public async Task<ApiConsumedResponse<Post>> DeleteAsync() => await DeleteAsync(store.PostId);


    }
}
