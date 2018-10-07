using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Forms.MVC.Templates
{
    internal static class InternalExtensions
    {

        public static View SetContent<TItem>(this TItem item, MenuItemContent content)
            where TItem : View, IMenuItem
        {
            content.SetTo(item);
            return item;
        }

    }
}
