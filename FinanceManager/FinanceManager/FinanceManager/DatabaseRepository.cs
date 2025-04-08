using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;

namespace FinanceManager
{
    public class DatabaseRepository
    {
        readonly SQLiteAsyncConnection _database;

        public DatabaseRepository(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<IncomeMoneyDB>().Wait();
            _database.CreateTableAsync<IncomeCategoryDB>().Wait();
        }

        // Методы для IncomeMoney
        public Task<List<IncomeMoneyDB>> GetIncomeMoneyAsync()
        {
            return _database.Table<IncomeMoneyDB>().ToListAsync();
        }

        public Task<int> SaveIncomeMoneyAsync(IncomeMoneyDB incomeMoney)
        {
            return _database.InsertAsync(incomeMoney);
        }

        // Методы для IncomeCategoryDB
        public Task<List<IncomeCategoryDB>> GetIncomeCategoriesAsync()
        {
            return _database.Table<IncomeCategoryDB>().OrderByDescending(x => x.CreatedDate).ToListAsync();
        }

        public Task<int> AddIncomeCategoryAsync(IncomeCategoryDB category)
        {
            return _database.InsertAsync(category);
        }

        public async Task<int> DeleteIncomeCategoryAsync(IncomeCategoryDB category)
        {
            return await _database.DeleteAsync(category);
        }
        
    }
}