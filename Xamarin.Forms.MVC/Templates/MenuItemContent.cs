using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms.MVC.Templates
{
    public class MenuItemContent
    {

        public string Text { get; set; }

        public Func<Task<IActionResponse>> Linked { get; set; }

        internal MenuItemContent() { }

        internal void SetTo(IMenuItem item)
        {
            item.Text = Text;
            if (Linked == null)
                item.OnCLick = () => Task.CompletedTask;
            else item.OnCLick = Linked;
        }

    }
}
