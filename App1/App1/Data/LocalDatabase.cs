using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App1.Model;
using SQLite;

namespace App1.Data
{
    public class LocalDatabase
    {
        readonly SQLiteAsyncConnection database;

        public LocalDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Recipe>().Wait();
            database.CreateTableAsync<Category>().Wait();
        }

        public async Task<List<T>> GetItems<T>() where T : class, new()
        {
            var items = await database.Table<T>().ToListAsync();
            return items;
        }

        public async Task<T> GetItemById<T>(int id) where T : class, ISqliteModel, new()
        {
            return await database.Table<T>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync<T>(T item)
        {
            var result = await database.UpdateAsync(item);

            if (result == 0)
                result = await database.InsertAsync(item);

            return result;
        }

        public async Task<int> DeleteItemAsync<T>(T item)
        {
            return await database.DeleteAsync(item);
        }

    }
}
