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
using Newsdog.Data;

namespace Newsdog.Helpers
{
    public static class NewsFilterHelper
    {
        public async static Task<List<NewsInformation>> GetFilteredNewsAsync()
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

           // var filteredResult = results.Where(w => w.Description.Contains("corona") || w.Title.Contains("Covid-19"))
            var filteredResult = results.Where(w =>( w.Title.IndexOf("Corona", StringComparison.OrdinalIgnoreCase) != -1 ||
                                ( w.Title.IndexOf("covid-19", StringComparison.OrdinalIgnoreCase) != -1)))                              
                .OrderBy(w=>w.CreatedDate)
                .Take(12).ToList();
            return filteredResult;
            //return results.Where(w => !string.IsNullOrEmpty(w.ImageUrl)).Take(10).ToList();
        }

       
    }
}
