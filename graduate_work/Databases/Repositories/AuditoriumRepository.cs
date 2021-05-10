using graduate_work.Databases.MySQL;
using graduate_work.Interfaces.IRepository;
using graduate_work.Models.Database;
using System;

namespace graduate_work.Databases.Repositories
{
    public class AuditoriumRepository : IAuditoriumRepository
    {
        private readonly MySQLContext db;

        public AuditoriumRepository(MySQLContext db)
        {
            this.db = db;
        }

        public void Add(Auditorium auditorium)
        {
            throw new NotImplementedException();
        }

        public void Update(Auditorium auditorium)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Auditorium FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExist(Auditorium auditorium)
        {
            throw new NotImplementedException();
        }
    }
}
