using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Newsdog.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrendingPage : ContentPage
    {
        public TrendingPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            //LoadNewsAsyncMethod();
            this.BindingContext = App.ViewModel;
            base.OnAppearing();
        }

        //private async void LoadNewsAsyncMethod()
        //{
        //    newsListView.IsRefreshing = true;
        //    var news = await Helpers.NewsHelper.GetTrendingAsync();
        //    this.BindingContext = news;
        //    newsListView.IsRefreshing = false;

        //}

        private void newsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            App.Current.Resources["ListTextColor"] = Color.Blue;
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            new Common.Commands.NavigateToDetailCommand().Execute(e.Item as News.NewsInformation);
        }

        //private void newsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        //{

        //}
    }
}