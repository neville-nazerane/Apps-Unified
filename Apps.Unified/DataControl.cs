using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Apps.DependencyInjection;
using NetCore.Apis.Client.UI;
using NetCore.Apis.Consumer;

namespace Apps.Unified
{
    public class DataControl<TData>
        where TData : class, new()
    {

        public DataListener<TData> Listener { get; }

        public TData Data { get => Listener.Data; set => Listener.Data = value; }

        private ModelHandler<TData> modelHandler;

        /// <summary>
        /// Gets or generates a model handler
        /// </summary>
        /// <returns></returns>
        public ModelHandler<TData> GetModelHandler()
        {
            if (modelHandler == null)
            {
                modelHandler = new ModelHandler<TData>();
                Listener.OnSet = data => { if (data != null) modelHandler.SetModel(data); };
                //Listener.OnGet = data => {
                //    if (modelHandler.TryGetModel(out var m)) return m;
                //    return null;
                //};
            }
            return modelHandler;
        }

        public void Set(ApiConsumedResponse<TData> responseData)
        {
            modelHandler.SubmitAsync(data => Task.FromResult(responseData)).RunSynchronously();
        }

        public async Task<TResult> SubmitAsync<TResult>(Func<TData, Task<ApiConsumedResponse<TResult>>> call)
            => await modelHandler.SubmitAsync(call);

        DataControl(DataListener<TData> listener)
        {
            Listener = listener;
        }

        public async Task ReloadAsync() => await Listener.ReloadAsync();

        public static implicit operator TData(DataControl<TData> control)
            => control.Data;

        public static implicit operator DataControl<TData>(DataStoreImplicitBuilder builder)
            => new DataControl<TData>(builder.Listener);

    }

    public class DataStoreImplicitBuilder
    {
        internal DataListenerImplicitBuilder Listener { get; }

        internal DataStoreImplicitBuilder(DataListenerImplicitBuilder listener)
        {
            Listener = listener;
        }

    }

}
