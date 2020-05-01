using NewsDog.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Newsdog.Model
{
    public class NewsFilter : ObservableBase
    {
        private string filterTitle;
        public string FilterTitle
        {
            get { return this.filterTitle; }
            set { this.SetProperty(ref this.filterTitle, value); }
        }
        private List<string> inputs ;
        public List<string> Inputs
        {
            get { return this.inputs; }
            set { this.SetProperty(ref this.inputs, value); }
        }
        private bool isFilterOn = false;

        public bool IsFilterOn
        {
            get { return this.isFilterOn; }
            set { this.SetProperty(ref this.isFilterOn, value); }
        }
        //public NewsFilter()
        //{
        //    this.inputs = new List<string>();
        //}
    }

    public class FilterCollection : ObservableCollection<NewsFilter>
    {
        public async Task AddAsync(NewsFilter filter)
        {

            //var filter = new NewsFilter()
            //{
            //    ArticleDate = article.ArticleDate,
            //    Description = article.Description,
            //    ImageUrl = article.ImageUrl,
            //    Title = article.Title,
            //};

            //await FavoritesManager.DefaultManager.SaveFavoriteAsync(favorite);

            this.Add(filter);
        }
    }

}
