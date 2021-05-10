using graduate_work.Databases.MySQL;
using graduate_work.Interfaces.IRepository;
using graduate_work.Models.Database;
using System;

namespace graduate_work.Databases.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly MySQLContext db;

        public ClassRepository(MySQLContext db)
        {
            this.db = db;
        }

        public void Add(Class sClass)
        {
            throw new NotImplementedException();
        }

        public void Update(Class sClass)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Class FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExist(Class sClass)
        {
            throw new NotImplementedException();
        }
    }
}
