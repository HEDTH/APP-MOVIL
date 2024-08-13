using System;
using System.Collections.Generic;
using System.IO; // Asegúrate de tener esto
using System.Threading.Tasks;
using HamburgerDeliveryApp.Models;
using SQLite;

namespace HamburgerDeliveryApp
{
    public class UserService
    {
        private static UserService _instance;

        public static UserService Instance => _instance ??= new UserService();

        private static SQLiteAsyncConnection _database;

        public UserService()
        {
            InitializeDatabase();
        }

        private async void InitializeDatabase()
        {
            // Construcción de la ruta para la base de datos
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "userdatabase.db3");
            _database = new SQLiteAsyncConnection(databasePath);
            await _database.CreateTableAsync<User>();
        }



        public async Task<User> GetUserAsync(string name, DateTime birthdate)
        {
            return await _database.Table<User>().FirstOrDefaultAsync(u => u.Name == name && u.Birthdate == birthdate);
        }


        public Task<int> SaveUserAsync(User user)
        {
            if (user.ID != 0)
            {
                return _database.UpdateAsync(user);
            }
            else
            {
                return _database.InsertAsync(user);
            }
        }

        public Task<User> GetUserAsync(int id)
        {
            return _database.Table<User>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<List<User>> GetUsersAsync()
        {
            return _database.Table<User>().ToListAsync();
        }

        public Task<int> DeleteUserAsync(User user)
        {
            return _database.DeleteAsync(user);
        }
    }
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Birthdate { get; set; } // Asegúrate de que esto exista
        public string Address { get; set; }
    }
}

