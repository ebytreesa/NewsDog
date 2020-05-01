using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Newsdog.Data
{
    public class FilterDatabase
    {
        readonly SQLiteAsyncConnection database;

        public FilterDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);

            //database.DropTableAsync<NewsFilterTable>().Wait();

            database.CreateTableAsync<NewsFilterTable>().Wait();
        }

        public Task<int> SaveItemAsync(NewsFilterTable item)
        {
            if (item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<List<NewsFilterTable>> GetItemsAsync()
        {
            return database.Table<NewsFilterTable>().ToListAsync();
        }


    }
}
