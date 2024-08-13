using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using HamburgerDeliveryApp.Models;

namespace HamburgerDeliveryApp.Services
{
    public class DatabaseService
    {
        readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
            _database.CreateTableAsync<Order>().Wait();
        }

        // CRUD para Usuarios
        public Task<int> SaveUserAsync(User user)
        {
            return _database.InsertAsync(user);
        }

        public Task<List<User>> GetUsersAsync()
        {
            return _database.Table<User>().ToListAsync();
        }

        public Task<User> GetUserByEmailAsync(string email)
        {
            return _database.Table<User>().Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        // CRUD para Pedidos
        public Task<int> SaveOrderAsync(Order order)
        {
            return _database.InsertAsync(order);
        }

        public Task<List<Order>> GetOrdersByUserAsync(int userId)
        {
            return _database.Table<Order>().Where(o => o.UserId == userId).ToListAsync();
        }
    }
}
