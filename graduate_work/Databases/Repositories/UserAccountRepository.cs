using graduate_work.Databases.MySQL;
using graduate_work.Interfaces.IRepository;
using graduate_work.Models.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace graduate_work.Databases.Repositories
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly MySQLContext db;

        public UserAccountRepository(MySQLContext db)
        {
            this.db = db;
        }

        public void Add(UserAccount user)
        {
            db.UserAccounts.Add(user);
        }

        public void Add(string Login, string Password, string Email, string Role)
        {
            db.UserAccounts.Add(new UserAccount(Login, Password, Email, Role));
        }

        public void Delete(int id)
        {
            db.UserAccounts.Remove(FindById(id));
        }

        public void Update(UserAccount user)
        {
            db.Entry(user).State = EntityState.Modified;
        }

        public UserAccount FindById(int id)
        {
            return db.UserAccounts.Where(ua => ua.Id == id).FirstOrDefault();
        }

        public UserAccount FindByCredential(string login, string password)
        {
            return db.UserAccounts.Where(ua => ua.Login == login && ua.Password == password).FirstOrDefault();
        }

        public UserAccount FindByEmail(string email)
        {
            return db.UserAccounts.Where(sa => sa.Email == email).FirstOrDefault();
        }

        public bool isExistById(int id)
        {
            return db.UserAccounts.Where(ua => ua.Id == id).Any();
        }

        public bool isExistByLogin(string login)
        {
            return db.UserAccounts.Where(ua =>  ua.Login == login).Any();
        }

        public bool isExistByEmail(string email)
        {
            return db.UserAccounts.Where(ua => ua.Email == email).Any();
        }
    }
}