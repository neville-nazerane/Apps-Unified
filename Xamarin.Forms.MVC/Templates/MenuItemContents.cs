using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms.MVC.Templates
{
    public class MenuItemContents : List<MenuItemContent>
    {

        public void Add(string title, Func<IActionResponse> linked)
        {
            Add(new MenuItemContent
            {
                Text = title,
                Linked = () => {
                    var res = linked();
                    return Task.FromResult(res);
                }
            });
        }

        public void Add(string title, Func<Task<IActionResponse>> linked = null)
        {
            Add(new MenuItemContent
            {
                Text = title,
                Linked = linked
            });
        }

    }
}
