using Apps.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apps.Unified
{
    public class DataStore : ListenersManager
    {

        protected new DataStoreImplicitBuilder Build()
            => new DataStoreImplicitBuilder(base.Build());

    }

}
