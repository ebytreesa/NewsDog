using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Newsdog.Common.Commands
{
    public class SpeakCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public void Execute(object parameter)
        {
            Helpers.GeneralHelper.Speak((string)parameter);
        }
    }

    public class NavigateToDetailCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public void Execute(object parameter)
        {
            NavigateToDetailAsync(parameter as News.NewsInformation);
        }

        private async void NavigateToDetailAsync(News.NewsInformation article)
        {
            await App.MainNavigation.PushAsync(new Pages.ItemDetailPage(article), true);
        }
    }

    public class RefreshNewsCommand : ICommand
    {
        private bool _isBusy = false;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return !_isBusy;
        }

        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public void Execute(object parameter)
        {
            RefreshNewsAsync((string)parameter);
        }

        private async void RefreshNewsAsync(string newsType)
        {
            this._isBusy = true;
            this.RaiseCanExecuteChanged();
            App.ViewModel.IsBusy = true;

            switch (newsType)
            {
                //case "World":
                //    await App.ViewModel.RefreshWorldNewsAsync();
                //    break;
                //case "Technology":
                //    await App.ViewModel.RefreshTechnologyNewsAsync();
                //    break;
                case "Trending":
                    await App.ViewModel.RefreshTrendingNewsAsync();
                    break;
            }

            this._isBusy = false;
            this.RaiseCanExecuteChanged();
            App.ViewModel.IsBusy = false;

        }
    }

    public class NavigateToSettingsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public void Execute(object parameter)
        {
            NavigateAsync();
        }

        private async void NavigateAsync()
        {
            await App.MainNavigation.PushAsync(new Pages.SettingsPage(), true);
        }
    }

}

