﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Newsdog.News.Trending
{
    public class TrendingNewsResult
    {
        public string _type { get; set; }
        public Value[] value { get; set; }
    }

    //public class Value
    //{
    //    public string name { get; set; }
    //    public string description { get; set; }
    //    public Image image { get; set; }
    //    public string webSearchUrl { get; set; }
    //    public bool isBreakingNews { get; set; }
    //    public Query query { get; set; }
    //}
    public class Value
    {
        public string name { get; set; }
        public string url { get; set; }
        public Image image { get; set; } = new Image();
        public string description { get; set; }
        public Provider[] provider { get; set; }
        public DateTime datePublished { get; set; }
    }
    public class Image
    {
        public Thumbnail thumbnail { get; set; } = new Thumbnail();
    }

    public class Thumbnail
    {
        public string contentUrl { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    //public class Image
    //{
    //    public string url { get; set; }
    //    public Provider[] provider { get; set; }
    //}

    public class Provider
    {
        public string _type { get; set; }
        public string name { get; set; }
    }

    public class Query
    {
        public string text { get; set; }
    }

}