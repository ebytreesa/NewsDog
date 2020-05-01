using Newsdog.Data;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Newsdog
{
    public partial class App : Application
    {
        static FavoritesDatabase database;
        static FilterDatabase filterDatabase;

        public static FilterDatabase FilterDatabase
        {
            get
            {

                if (filterDatabase == null)
                {
                    filterDatabase = new FilterDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("Filter.db3"));
                }

                return filterDatabase;
            }

        }
        public static FavoritesDatabase Database
        {
            get
            {

                if (database == null)
                {
                    database = new FavoritesDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("Favorites.db3"));
                }

                return database;
            }

        }
        public static ViewModels.MainViewModel ViewModel { get; set; }
        public static ViewModels.FilterNewsViewModel FilterViewModel { get; set; }
        public static INavigation MainNavigation { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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
