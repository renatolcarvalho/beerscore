using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerScoreApp.Models;
using SQLite;

namespace BeerScoreApp.Connection
{
	public class BeerScoreDatabase
	{
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection DatabaseConnection => lazyInitializer.Value;
        static bool initialized = false;

        public BeerScoreDatabase()
        {
			InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!DatabaseConnection.TableMappings.Any(m => m.MappedType.Name == typeof(BeerScore).Name))
                {
                    await DatabaseConnection.CreateTablesAsync(CreateFlags.None, typeof(BeerScore)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }

        public Task<List<BeerScore>> GetItemsAsync()
        {
            return DatabaseConnection.Table<BeerScore>().ToListAsync();
        }

        public Task<List<BeerScore>> GetItemsNotDoneAsync()
        {
            // SQL queries are also possible
            return DatabaseConnection.QueryAsync<BeerScore>("SELECT * FROM [BeerScore] WHERE [Done] = 0");
        }

        public Task<BeerScore> GetItemAsync(int id)
        {
            return DatabaseConnection.Table<BeerScore>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(BeerScore item)
        {
            if (item.ID != 0)
            {
                return DatabaseConnection.UpdateAsync(item);
            }
            else
            {
                return DatabaseConnection.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(BeerScore item)
        {
            return DatabaseConnection.DeleteAsync(item);
        }
    }
}
