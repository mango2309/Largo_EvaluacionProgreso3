using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Largo_EvaluacionP3.Models
{
    public class DatabaseService_SL
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService_SL(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<CharacterModel_SL>().Wait();
        }

        public Task<List<CharacterModel_SL>> GetCharactersAsync()
        {
            return _database.Table<CharacterModel_SL>().ToListAsync();
        }

        public Task<int> SaveCharacterAsync(CharacterModel_SL character)
        {
            return _database.InsertAsync(character);
        }
    }
}
