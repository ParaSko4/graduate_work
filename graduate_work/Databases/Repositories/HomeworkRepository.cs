using graduate_work.Databases.MySQL;
using graduate_work.Interfaces.IRepository;
using graduate_work.Models.Database;
using System;

namespace graduate_work.Databases.Repositories
{
    public class HomeworkRepository : IHomeworkRepository
    {
        private readonly MySQLContext db;

        public HomeworkRepository(MySQLContext db)
        {
            this.db = db;
        }

        public void Add(Homework homework)
        {
            throw new NotImplementedException();
        }

        public void Update(Homework homework)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Homework FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExist(Homework homework)
        {
            throw new NotImplementedException();
        }
    }
}
