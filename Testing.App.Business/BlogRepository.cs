using System.Threading.Tasks;
using NetCore.Apis.Consumer;
using Testing.App.Connections;
using Testing.App.DataAccess;
using Testing.Core;

namespace Testing.App.Business
{
    public class BlogRepository : BlogAccess
    {
        private readonly AppDataStore store;

        public BlogRepository(MainConsumer consumer, AppDataStore store) : base(consumer)
        {
            this.store = store;
        }

        public override async Task<ApiConsumedResponse<Blog>> AddAsync(Blog Blog)
        {
            var res = await base.AddAsync(Blog);
            if (res.IsSuccessful) await store.Blogs.ReloadAsync();
            return res;
        }

        public async Task<ApiConsumedResponse<Blog>> AddAsync()
        {
            ApiConsumedResponse<Blog> res = null; 
            await store.Blog.SubmitAsync(async b => res = await AddAsync(b));
            return res;
        }

        public override async Task<ApiConsumedResponse<Blog>> EditAsync(int id, Blog Blog)
        {
            var res = await base.EditAsync(id, Blog);
            if (res.IsSuccessful) await store.Blogs.ReloadAsync();
            return res;
        }

        public async Task<ApiConsumedResponse<Blog>> EditAsync()
        {
            ApiConsumedResponse<Blog> res = null;
            await store.Blog.SubmitAsync(async b => res = await EditAsync(store.BlogId, b));
            return res;
        }
        public override async Task<ApiConsumedResponse<Blog>> DeleteAsync(int id)
        {
            var res = await base.DeleteAsync(id);
            if (res.IsSuccessful) await store.Blogs.ReloadAsync();
            return res;
        }

        public async Task<ApiConsumedResponse<Blog>> AddOrEditAsync()
        {
            ApiConsumedResponse<Blog> res;
            if (store.BlogId == 0) res = await AddAsync();
            else res = await EditAsync();
            if (res.IsSuccessful) store.Blog.Data = new Blog();
            return res;
        }

        public async Task<ApiConsumedResponse<Blog>> DeleteAsync() => await DeleteAsync(store.BlogId);


    }
}
