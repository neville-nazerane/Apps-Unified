using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms.MVC.Templates
{
    public interface IMenuItem
    {

        string Text { get; set; }

        Func<Task> OnCLick { set; }

    }
}
