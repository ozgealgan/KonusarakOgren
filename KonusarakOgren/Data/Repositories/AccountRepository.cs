using KonusarakOgren.Data.DataContext;
using KonusarakOgren.Data.Repositories.Interfaces;
using System.Linq;

namespace KonusarakOgren.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private DatabaseContext _database;

        public AccountRepository(DatabaseContext database)
        {
            _database = database;
        }

        public bool Login(string username, string password)
        {
            return _database.Users.Any(x => x.UserName == username && x.Password == password);
        }
    }
}
