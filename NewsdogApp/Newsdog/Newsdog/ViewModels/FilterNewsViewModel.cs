using Newsdog.Model;
using NewsDog.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Newsdog.ViewModels
{
    public class FilterNewsViewModel : ObservableBase

    {
        public FilterNewsViewModel()
        {
            this.NewsFilter = new ObservableCollection<NewsFilter>() ;
            this.Filterednews = new ObservableCollection<News.NewsInformation>();
        }

        private bool isSelectedFilterOn = false;
        public bool IsSelectedFilterOn
        {
            get => Preferences.Get(nameof(IsSelectedFilterOn), this.isSelectedFilterOn);
            set
            {
                Preferences.Set(nameof(IsSelectedFilterOn), value);
                this.SetProperty(ref this.isSelectedFilterOn, value);
                // OnPropertyChanged(nameof(IsFilterOn));
            }
        }

        private string selectedFilter = "";
        public string SelectedFilter
        {
            get => Preferences.Get(nameof(SelectedFilter), this.selectedFilter);
            set
            {
                Preferences.Set(nameof(SelectedFilter), value);
                this.SetProperty(ref this.selectedFilter, value);
                // OnPropertyChanged(nameof(IsFilterOn));
            }
        }

        private ObservableCollection<NewsFilter> newsFilter;

        public ObservableCollection<NewsFilter> NewsFilter
        {
            get { return this.newsFilter; }
            set { this.SetProperty(ref this.newsFilter, value); }
        }

        private ObservableCollection<News.NewsInformation> _filterednews;

        public ObservableCollection<News.NewsInformation> Filterednews
        {
            get { return this._filterednews; }
            set { this.SetProperty(ref this._filterednews, value); }
        }

        private bool isBusy;
        public bool IsBusy
        {
            get { return this.isBusy; }
            set { this.SetProperty(ref this.isBusy, value); }
        }

        //public async void RefreshNewsAsync()
        //{
        //    this.IsBusy = true;
        //    if (this.NewsFilter.IsFilterOn == true)
        //    {
        //        await RefreshFilteredNewsAsync();
        //    }
        //    else
        //    {
        //        await App.ViewModel.RefreshTrendingNewsAsync();

        //    }
        //    this.IsBusy = false;

        //}

        public async void GetFiltersAsync()
        {
            this.newsFilter.Clear();

            var filters = await App.FilterDatabase.GetItemsAsync();
            foreach (var item in filters)
            {
                this.NewsFilter.Add(item.AsNewsFilter());
            }
        }
    

    }
}
