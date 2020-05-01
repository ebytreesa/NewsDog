using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Newsdog
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    //[DesignTimeVisible(false)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            if (App.ViewModel == null)
            {
                App.ViewModel = new ViewModels.MainViewModel();
                App.FilterViewModel = new ViewModels.FilterNewsViewModel();
            }

        }

        protected override void OnAppearing()
        {
            Console.WriteLine("hhhhh");
            //if (App.ViewModel == null)
            //{
            //    App.ViewModel = new ViewModels.MainViewModel();
                var b = App.ViewModel.IsFilterOn;
                App.ViewModel.RefreshNewsAsync();
                 App.FilterViewModel.GetFiltersAsync();
           // }

            App.MainNavigation = Navigation;

            //var label =  Helpers.GeneralHelper.GetLabel();
            var databasePath = Helpers.StorageHelper.GetLocalFilePath();
            

            base.OnAppearing();
        }

        //private async void ToolbarItem_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new Pages.SettingsPage());
        //}

        private async void OnStyleTestsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.testingPage());
        }
    }
}
