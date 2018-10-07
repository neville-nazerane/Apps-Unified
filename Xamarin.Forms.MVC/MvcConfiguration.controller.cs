using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms.DependencyInjection;
using Xamarin.Forms.MVC.Templates;
using Xamarin.Forms.MVC.Templates.Defaults;

namespace Xamarin.Forms.MVC
{
    public partial class MvcConfiguration 
    {

        public static TController Fetch<TController>()
            where TController : Controller
                => Services.Get<TController>();

    }
}
