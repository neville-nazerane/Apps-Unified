using System;
using System.Collections.Generic;
using System.Text;
using Apps.Unified;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms.DependencyInjection;

namespace Xamarin.Forms.MVC
{
    class MvcServiceConfiguration : ServiceConfiguration
    {

        readonly List<ServiceAdd> _appendedServices;
        readonly List<Action<ListenerConfiguration>> _appendedDataStore;
        internal Action<IServiceProvider> _onCreated;

        public MvcServiceConfiguration()
        {
            _appendedServices = new List<ServiceAdd>();
            _appendedDataStore = new List<Action<ListenerConfiguration>>();
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            foreach (var append in _appendedServices) append(services);
        }

        public override void ConfigureListeners(ListenerConfiguration configuration)
        {
            foreach (var append in _appendedDataStore) append(configuration);
        }

        public override void OnCreated(IServiceProvider provider) => _onCreated?.Invoke(provider);

        internal void AppendService(ServiceAdd append) => _appendedServices.Add(append);

        internal void AppendDataStore<TStore>()
            where TStore : DataStore
        {
            _appendedDataStore.Add(config => config.Add<TStore>());
        }

    }
}
