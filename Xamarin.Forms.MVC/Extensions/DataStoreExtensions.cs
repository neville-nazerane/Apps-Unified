using Apps.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Forms.MVC.Extensions
{
    public static class DataStoreExtensions
    {

        public static StackLayout BindTo<TModel, TView>(
                            this StackLayout stackLayout,
                            DataListener<IEnumerable<TModel>> listener,
                            Func<TModel, TView> createView,
                            bool requiresAppend = false
            )
            where TView : View
        {
            listener.OnSet = list => {
                if (list == null) return;
                if (!requiresAppend) stackLayout.Children.Clear();
                foreach (var m in list)
                    stackLayout.Children.Add(createView(m));
            };
            return stackLayout;
        }

    }
}
