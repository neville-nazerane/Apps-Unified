using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.MVC.Layouts;

namespace Testing.Apps.Config
{
    class Comp : LayoutComponent<ComponentKey>
    {

        public ComponentKey Key { set => SetComponent<Comp>(value); }

    }
}
