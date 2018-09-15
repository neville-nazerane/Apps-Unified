using NetCore.Apis.Consumer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Testing.App.Connections;
using Testing.Core;

namespace Testing.App.DataAccess
{
    public class BlogAccess
    {
        private readonly MainConsumer consumer;
        const string path = "api/Blogs";

        public BlogAccess(MainConsumer consumer)
        {
            this.consumer = consumer;
        }

        public virtual async Task<ApiConsumedResponse<IEnumerable<Blog>>> GetAsync()
            => await consumer.GetAsync(path);

        public virtual async Task<ApiConsumedResponse<Blog>> GetAsync(int id)
            => await consumer.GetAsync($"{path}/{id}");

        public virtual async Task<ApiConsumedResponse<Blog>> AddAsync(Blog blog)
            => await consumer.PostAsync(path, blog);

        public virtual async Task<ApiConsumedResponse<Blog>> EditAsync(int id, Blog blog)
            => await consumer.PutAsync($"{path}/{id}", blog);

        public virtual async Task<ApiConsumedResponse<Blog>> DeleteAsync(int id)
            => await consumer.DeleteAsync($"{path}/{id}");

    }
}
