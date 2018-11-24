using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms.MVC.Templates.Defaults
{
    class MenuItem : Button, IMenuItem
    {

        public MenuItem()
        {
            string title = Text;
            Clicked += async delegate {
                    await OnCLick();
            };
        }

        public Func<Task> OnCLick { private get; set; }
    }
}
