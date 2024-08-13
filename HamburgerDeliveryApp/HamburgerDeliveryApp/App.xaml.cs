using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HamburgerDeliveryApp.Services;
using System.IO;

namespace HamburgerDeliveryApp
{
    public partial class App : Application
    {
        static DatabaseService database;

        public static DatabaseService Database
        {
            get
            {
                if (database == null)
                {
                    database = new DatabaseService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "UserDatabase.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            
            
            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.Transparent, // Esto hace la barra transparente
                BarTextColor = Color.White
            };
        }

        protected override void OnStart() { }

        protected override void OnSleep() { }

        protected override void OnResume() { }
    }
}
