using graduate_work.Databases.MySQL;
using graduate_work.Interfaces.IRepository;
using graduate_work.Models.Database;
using System;

namespace graduate_work.Databases.Repositories
{
    public class ProgressRepository : IProgressRepository
    {
        private readonly MySQLContext db;

        public ProgressRepository(MySQLContext db)
        {
            this.db = db;
        }

        public void Add(Progress progress)
        {
            throw new NotImplementedException();
        }

        public void Update(Progress progress)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Progress FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExist(Progress progress)
        {
            throw new NotImplementedException();
        }
    }
}
