using LVDD.API;
using LVDD.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace LVDD
{
    public class App : Application
    {
        private readonly string BASEURI = "http://192.168.1.144:11863/api/";

        public App()
        {
            MainPage = new NavigationPage(new MainPage(() => new APIConsumer(this.BASEURI)));
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
