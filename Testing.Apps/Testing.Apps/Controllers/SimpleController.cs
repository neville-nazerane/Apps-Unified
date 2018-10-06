﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Testing.Apps.Pages;
using Testing.Core;
using Xamarin.Forms.MVC;

namespace Testing.Apps.Controllers
{
    class SimpleController : Controller
    {

        public async Task<IActionResponse> Index()
            => await ViewAsync<HomePage>();

        public async Task<IActionResponse> BlogPage(Blog data)
        {
            if (data == null) return Failed("Invalid data");
            return await ViewAsync<BlogDisplayPage, Blog>(data);
        }
    }
}