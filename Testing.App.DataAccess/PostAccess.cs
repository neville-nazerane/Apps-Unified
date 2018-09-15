using NetCore.Apis.Consumer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Testing.App.Connections;
using Testing.Core;

namespace Testing.App.DataAccess
{
    public class PostAccess
    {
        private readonly MainConsumer consumer;
        const string path = "api/posts";

        public PostAccess(MainConsumer consumer)
        {
            this.consumer = consumer;
        }

        public virtual async Task<ApiConsumedResponse<IEnumerable<Post>>> GetAsync()
            => await consumer.GetAsync(path);

        public virtual async Task<ApiConsumedResponse<Post>> GetAsync(int id)
            => await consumer.GetAsync($"{path}/{id}");

        public virtual async Task<ApiConsumedResponse<Post>> AddAsync(Post post)
            => await consumer.PostAsync(path, post);

        public virtual async Task<ApiConsumedResponse<Post>> EditAsync(int id, Post post)
            => await consumer.PutAsync($"{path}/{id}", post);

        public virtual async Task<ApiConsumedResponse<Post>> DeleteAsync(int id)
            => await consumer.DeleteAsync($"{path}/{id}");

    }
}
