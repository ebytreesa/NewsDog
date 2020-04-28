using Newtonsoft.Json;
using Newsdog.News;
using Newsdog.News.Trending;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newsdog.Model;
using Microsoft.Toolkit.Parsers.Rss;

namespace Newsdog.Helpers
{
    public static class NewsHelper
    {
        public static string CurrentCultureLabel
        {
            get
            {
                return System.Globalization.CultureInfo.CurrentUICulture.Name;
            }
        }
        public static async Task<List<NewsInformation>> SearchAsync(string searchQuery)
        {
            List<NewsInformation> results = new List<NewsInformation>();

            string searchUrl = $"https://api.cognitive.microsoft.com/bing/v5.0/news/search?q={searchQuery}&count=10&offset=0&mkt={CurrentCultureLabel}&safeSearch=Moderate";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Common.CoreConstants.NewsSearchApiKey);

            var uri = new Uri(searchUrl);
            var result = await client.GetStringAsync(uri);
            var newsResult = JsonConvert.DeserializeObject<NewsResult>(result);

            results = (from item in newsResult.value
                       select new NewsInformation()
                       {
                           Title = item.name,
                           Description = item.description,
                           CreatedDate = item.datePublished,
                           Url = item.url,
                           ImageUrl = item.image?.thumbnail?.contentUrl,
                           Category = item.category + "",

                       }).OrderByDescending(o => o.CreatedDate).ToList();

            return results.Where(w => !string.IsNullOrEmpty(w.ImageUrl)).Take(10).ToList();
        }
        public static async Task<List<NewsInformation>> GetByCategoryAsync(NewsCategoryType category)
        {
            List<NewsInformation> results = new List<NewsInformation>();

            string searchUrl = $"https://api.cognitive.microsoft.com/bing/v7.0/?{category}";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Common.CoreConstants.NewsSearchApiKey);
            
            var uri = new Uri(searchUrl);
            var result = await client.GetStringAsync(uri);
            var newsResult = JsonConvert.DeserializeObject<NewsResult>(result);

            results = (from item in newsResult.value
                       select new NewsInformation()
                       {
                           Title = item.name,
                           Description = item.description,
                           CreatedDate = item.datePublished,
                           ImageUrl = item.image?.thumbnail?.contentUrl,

                       }).ToList();

            return results.Where(w => !string.IsNullOrEmpty(w.ImageUrl)).Take(10).ToList();
        }

        public static async Task<List<NewsInformation>> GetAsync(string searchQuery)
        {
            List<NewsInformation> results = new List<NewsInformation>();

            string searchUrl = $"https://api.cognitive.microsoft.com/bing/v5.0/news/search?q={searchQuery}&count=10&offset=0&mkt=en-us&safeSearch=Moderate";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Common.CoreConstants.NewsSearchApiKey);

            var uri = new Uri(searchUrl);
            var result = await client.GetStringAsync(uri);
            var newsResult = JsonConvert.DeserializeObject<NewsResult>(result);

            results = (from item in newsResult.value
                       select new NewsInformation()
                       {
                           Title = item.name,
                           Description = item.description,
                           CreatedDate = item.datePublished,
                           ImageUrl = item.image?.thumbnail?.contentUrl,

                       }).ToList();

            return results.Where(w => !string.IsNullOrEmpty(w.ImageUrl)).Take(10).ToList();
        }

        //public async static Task<List<NewsInformation>> GetTrendingAsync()
        //{
        //    List<NewsInformation> results = new List<NewsInformation>();

        //    string searchUrl = $"https://api.cognitive.microsoft.com/bing/v7.0/news";

        //    var client = new HttpClient();
        //    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Common.CoreConstants.NewsSearchApiKey);

        //    var uri = new Uri(searchUrl);
        //    var result = await client.GetStringAsync(uri);
        //    var newsResult = JsonConvert.DeserializeObject<TrendingNewsResult>(result);

        //    results = (from item in newsResult.value
        //               select new NewsInformation()
        //               {
        //                   Title = item.name,
        //                   Description = item.description,
        //                   CreatedDate = DateTime.Now,
        //                   ImageUrl = item.image.thumbnail.contentUrl

        //               }).ToList();
        //    return results.Where(w => !string.IsNullOrEmpty(w.ImageUrl)).Take(10).ToList();

        //}

        public async static Task<List<NewsInformation>> GetTrendingAsync()
        {
            List<NewsInformation> results = new List<NewsInformation>();

            var client = new HttpClient();
            var feed = await client.GetStringAsync("https://www.dr.dk/nyheder/service/feeds/allenyheder/");
            var parser = new RssParser();
            var newsResult = parser.Parse(feed);
            
            results = (from item in newsResult

                       select new NewsInformation()
                       {
                           Title = item.Title,
                           Description = item.Summary,
                           CreatedDate = item.PublishDate,
                           //ImageUrl = item.
                           ImageUrl = @"https://is1-ssl.mzstatic.com/image/thumb/Purple124/v4/29/55/2e/29552ea2-5952-af7a-f398-89d177968258/AppIcon-0-0-1x_U007emarketing-0-0-0-7-0-0-85-220.png/600x600wa.png"
                       }).ToList();
            var r = results.Where(w => !string.IsNullOrEmpty(w.ImageUrl)).Take(10).ToList();
            return results.Where(w => !string.IsNullOrEmpty(w.ImageUrl)).Take(10).ToList();
        }

        
    }
}

