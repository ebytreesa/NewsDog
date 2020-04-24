using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newsdog
{
    public class FavoritesCollection : ObservableCollection<FavoriteInformation>
    {
        public async Task<int> AddAsync(FavoriteInformation article)
        {
            int id = 0;
             await Helpers.FavoritesHelper.EnsureCategoriesAsync();
            var category = App.Database.GetCategoryAsync(article.CategoryTitle);
            var favorite = new Favorite()
            {
                ArticleDate = article.ArticleDate,
                Description = article.Description,
                ImageUrl = article.ImageUrl,
                Title = article.Title,
            };
            if (category != null)
            {
                id = await App.Database.SaveItemAsync(favorite);
            }
            article.Id = id;           

           // await FavoritesManager.DefaultManager.SaveFavoriteAsync(favorite);

            this.Add(article);
            return id;
        }
    }

    public class FavoriteInformation : NewsDog.Common.ObservableBase
    {
        private int _id;
        public int Id
        {
            get { return this._id; }
            set { this.SetProperty(ref this._id, value); }
        }

        private string _title;
        public string Title
        {
            get { return this._title; }
            set { this.SetProperty(ref this._title, value); }
        }

        private string _categoryTitle;
        public string CategoryTitle
        {
            get { return this._categoryTitle; }
            set { this.SetProperty(ref this._categoryTitle, value); }
        }

        private string _description;
        public string Description
        {
            get { return this._description; }
            set { this.SetProperty(ref this._description, value); }
        }

        private string _imageUrl;
        public string ImageUrl
        {
            get { return this._imageUrl; }
            set { this.SetProperty(ref this._imageUrl, value); }
        }

        private DateTime _articleDate;
        public DateTime ArticleDate
        {
            get { return this._articleDate; }
            set { this.SetProperty(ref this._articleDate, value); }
        }


    }
}
