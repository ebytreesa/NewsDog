using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Newsdog.Data
{
    public class NewsFilterTable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string FilterTitle { get; set; }
        public string Input1 { get; set; }
        public string Input2 { get; set; }
        public string Input3 { get; set; }

        //[Ignore]
        //public List<string> Inputs { get; set; }
        public bool IsFilterOn { get; set; }


    }
}
