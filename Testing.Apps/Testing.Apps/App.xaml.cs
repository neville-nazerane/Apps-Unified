﻿using System;
using Testing.Apps.Helpers;
using Testing.Apps.Pages;
using Xamarin.Forms;
using Xamarin.Forms.DependencyInjection;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Testing.Apps
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Services.Configuration = new AppConfig();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}