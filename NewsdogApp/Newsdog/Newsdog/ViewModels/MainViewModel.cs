﻿using Newsdog.Model;
using NewsDog.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Newsdog.ViewModels
{
    public class MainViewModel:ObservableBase
    {

        public MainViewModel()
        {
            this.TrendingNews = new ObservableCollection<News.NewsInformation>();
            this.CurrentUser = new UserInformation
            {
                DisplayName = "Eby",
                BioContent = "",
                ProfileImageUrl = "https://www.thespruce.com/thmb/LCyupmFhZf0tXxj6TpBwWS6ZSfo=/3867x2578/filters:fill(auto,1)/GettyImages-153342142-56a75f045f9b58b7d0e9bee6.jpg"
            };

        }
        private ObservableCollection<News.NewsInformation> trendingnews;
        public ObservableCollection<News.NewsInformation> TrendingNews
        {
            get { return this.trendingnews; }
            set { this.SetProperty(ref this.trendingnews, value); }
        }

        private string _platformLabel;
        public string PlatformLabel
        {
            get { return this._platformLabel; }
            set { this.SetProperty(ref this._platformLabel, value); }
        }

        private string _extendedPlatformLabel;
        public string ExtendedPlatformLabel
        {
            get { return this._extendedPlatformLabel; }
            set { this.SetProperty(ref this._extendedPlatformLabel, value); }
        }

        private DeviceOrientations _currentOrientation;
        public DeviceOrientations CurrentOrientation
        {
            get { return this._currentOrientation; }
            set { this.SetProperty(ref this._currentOrientation, value); }
        }


        private bool isBusy;
        public bool IsBusy
        {
            get { return this.isBusy;  }
            set { this.SetProperty(ref this.isBusy, value);  }
        }

        private UserInformation currentUser;
        public UserInformation CurrentUser
        {
            get { return this.currentUser; }
            set { this.SetProperty(ref this.currentUser, value); }
        }


        public async void RefreshNewsAsync()
        {
            this.IsBusy = true;
            await RefreshTrendingNewsAsync();
            this.IsBusy = false;

        }

        public async Task RefreshTrendingNewsAsync()
        {
            var news = await Helpers.NewsHelper.GetTrendingAsync();
            foreach (var item in news)
            {
                this.TrendingNews.Add(item);
            }
        }
    }
}