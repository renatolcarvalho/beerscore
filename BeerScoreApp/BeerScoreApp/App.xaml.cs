using BeerScoreApp.Connection;
using BeerScoreApp.Views;
using Xamarin.Forms;

namespace BeerScoreApp
{
    public partial class App : Application
    {
        static BeerScoreDatabase database;

        public App()
        {
            InitializeComponent();

            var nav = new NavigationPage(new BeerScoreList());
            MainPage = nav;
        }

        public static BeerScoreDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new BeerScoreDatabase();
                }
                return database;
            }
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
