using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Forms.MVC.Layouts
{
    public interface ILayoutConfig<TKey>
        where TKey : struct
    {
        ILayoutConfig<TKey> Set<TComponent>(TKey key)
                    where TComponent : View;
    }
}
