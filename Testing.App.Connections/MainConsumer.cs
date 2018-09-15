using NetCore.Apis.Consumer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Testing.App.Connections
{
    public class MainConsumer : ApiConsumer
    {

        public MainConsumer() : base(Urls.Main)
        {

        }

    }
}
