using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LABO5
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());// is nodig om te navigeren en uw title te zien
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
