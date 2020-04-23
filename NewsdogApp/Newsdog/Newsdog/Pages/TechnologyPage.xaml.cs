using Newsdog.News;
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
    public partial class TechnologyPage : ContentPage
    {
        public TechnologyPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            LoadNewsAsyncMethod();
            base.OnAppearing();
        }

        private async void LoadNewsAsyncMethod()
        {
            newsListView.IsRefreshing = true;
            var news = await Helpers.NewsHelper.GetByCategoryAsync(NewsCategoryType.suggestions);
            this.BindingContext = news;
            newsListView.IsRefreshing = false;

        }
    }
}