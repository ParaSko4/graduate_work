using graduate_work.Databases.MySQL;
using graduate_work.Interfaces.IRepository;
using graduate_work.Models.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace graduate_work.Databases.Repositories
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly MySQLContext db;

        public SchoolRepository(MySQLContext db)
        {
            this.db = db;
        }

        public void Add(School school)
        {
            db.Schools.Add(school);
        }

        public void Add(string Name, string Location, string Email, string Number, int UserAccountId)
        {
            db.Schools.Add(new School(Name, Location, Email, Number, UserAccountId));
        }

        public void Update(School school)
        {
            db.Entry(school).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            db.Schools.Remove(FindById(id));
        }

        public School FindById(int id)
        {
            return db.Schools.Where(s => s.Id == id).FirstOrDefault();
        }

        public School FindByUserId(int id)
        {
            return db.Schools.Where(s => s.UserAccountId == id).FirstOrDefault();
        }

        public bool isExist(int id)
        {
            return db.Schools.Where(s => s.Id == id).Any();
        }

        public bool isExistByName(string name)
        {
            return db.Schools.Where(s => s.Name == name).Any();
        }
    }
}
