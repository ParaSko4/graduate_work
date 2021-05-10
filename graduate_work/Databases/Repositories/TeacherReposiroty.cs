using graduate_work.Databases.MySQL;
using graduate_work.Interfaces.IRepository;
using graduate_work.Models.Database;
using System;

namespace graduate_work.Databases.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly MySQLContext db;

        public TeacherRepository(MySQLContext db)
        {
            this.db = db;
        }

        public void Add(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public void Update(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Teacher FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExist(Teacher teacher)
        {
            throw new NotImplementedException();
        }
    }
}
