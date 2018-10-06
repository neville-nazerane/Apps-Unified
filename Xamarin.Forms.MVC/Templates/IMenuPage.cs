using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Forms.MVC.Templates
{
    public interface IMenuPage
    {

        void AddItem<TItem>(TItem item)
            where TItem : View, IMenuItem;


    }
}
